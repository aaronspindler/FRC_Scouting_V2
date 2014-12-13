//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2014 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================

//@author xNovax
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;

namespace FRC_Scouting_V2
{
    internal class UsefulSnippets
    {
        public static string IV = "TEST";
        public static string KEY = "TEST";

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (Stream stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void ClearSettings()
        {
            if (
                MessageBox.Show("Are you sure you want to reset your settings?", "Are you sure?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                Settings.Default.Reset();
                Settings.Default.Save();
                MessageBox.Show("You have successfully reset all settings to default!",
                    "Settings have been reset to default!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string DeCryptString(string encryptedText)
        {
            string plainText;
            const string key = ("abcdefghijklmnopqrstuvwxyz123456");
            const string IV = ("1234567890123456");
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            var aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(IV),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] plainTextBytes = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            plainText = Encoding.ASCII.GetString(plainTextBytes);
            return plainText;
        }

        public string EncryptString(string plainText)
        {
            string encryptedText;
            const string key = ("abcdefghijklmnopqrstuvwxyz123456");
            const string IV = ("1234567890123456");
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            var aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(IV),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            encryptedText = Convert.ToBase64String(encrypted);
            return encryptedText;
        }

        public void ErrorOccured(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string GetCurrentTime()
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            return time;
        }

        public int GetNumberOfRowsInATable()
        {
            int numberOfRows = 0;
            try
            {
                string mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM " + Settings.Default.currentTableName, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    cmd.Dispose();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem(ex.Message);
            }
            return numberOfRows;
        }

        public int GetNumberOfRowsThatContainAValue(int teamNumber)
        {
            int numberOfRows = 0;
            try
            {
                string mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                string mySQLCommantText = String.Format("SELECT COUNT(*) FROM {0} WHERE TeamNumber={1}",
                    Settings.Default.currentTableName, teamNumber);
                using (var cmd = new MySqlCommand(mySQLCommantText, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    cmd.Dispose();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
            }
            return numberOfRows;
        }

        public int GetSecureRandomNum(int startingNum, int endingNum)
        {
            int difference = endingNum - startingNum;
            var bytes = new byte[16];
            var r = new RNGCryptoServiceProvider();

            r.GetBytes(bytes);
            int number = (int) ((decimal) bytes[0]/256*difference) + startingNum;

            return number;
        }

        public string MakeMySqlConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder["Server"] = Settings.Default.databaseIP;
            builder["Database"] = Settings.Default.databaseName;
            builder["Port"] = Settings.Default.databasePort;
            builder["Uid"] = Settings.Default.databaseUsername;
            builder["Password"] = DeCryptString(Settings.Default.databasePassword);
            builder.SslMode = MySqlSslMode.Preferred;
            return builder.ConnectionString;
        }

        //This is here because I may need it at some point. No point in removing it.
        public string MakeRandomPassword(int passwordType, int passwordLength)
        {
            //Password Types
            //0 - No Type Selected
            //1 - Numbers
            //2 - Letters (Uppercase and Lowercase)
            //3 - Numbers and Letters (Uppercase and Lowercase)
            //4 - All Characters (Numbers, Letters, and Special Characters)

            //Variables
            var gen = new Random();
            string passwordToString = ("");
            char[] numbers = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            char[] letters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };
            char[] lettersAndNumbers =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6',
                '7', '8', '9', '0'
            };
            char[] allCharacters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', '0', '!', '@', '#', '$', '%', '^', '&', '*', '<', '>', '?'
            };
            var passwordList = new List<char>();
            int randomNumber = 0;

            if (passwordType == 0)
            {
                ErrorOccured("No password type selected!");
            }
            else
            {
                if (passwordType == 1)
                {
                    for (int i = 0; i < passwordLength; i++)
                    {
                        randomNumber = gen.Next(10);
                        passwordList.Add(numbers[randomNumber]);
                    }
                    passwordToString = string.Join("", passwordList.ToArray());
                }
                else
                {
                    if (passwordType == 2)
                    {
                        for (int i = 0; i < passwordLength; i++)
                        {
                            randomNumber = gen.Next(52);
                            passwordList.Add(letters[randomNumber]);
                        }
                        passwordToString = string.Join("", passwordList.ToArray());
                    }
                    else
                    {
                        if (passwordType == 3)
                        {
                            for (int i = 0; i < passwordLength; i++)
                            {
                                randomNumber = gen.Next(62);
                                passwordList.Add(lettersAndNumbers[randomNumber]);
                            }
                            passwordToString = string.Join("", passwordList.ToArray());
                        }
                        else
                        {
                            if (passwordType == 4)
                            {
                                for (int i = 0; i < passwordLength; i++)
                                {
                                    randomNumber = gen.Next(73);
                                    passwordList.Add(allCharacters[randomNumber]);
                                }
                                passwordToString = string.Join("", passwordList.ToArray());
                            }
                        }
                    }
                }
            }
            return passwordToString;
        }

        public void ShowInformationMessage(string informationText)
        {
            MessageBox.Show(informationText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Boolean SubmitCrashReport()
        {
            Boolean sendSuccessful = false;

            return sendSuccessful;
        }

        public void InitializeDatabases()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MakeMySqlConnectionString());
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                List<string> commands = new List<string>();
                commands.Add("CREATE TABLE `AerialAssist_Northbay` (`EntryID` int(11) NOT NULL,`TeamName` varchar(45) NOT NULL DEFAULT 'Default', `TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamColour` varchar(45) NOT NULL DEFAULT 'Default',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighTally` int(11) NOT NULL DEFAULT '0',`AutoLowTally` int(11) NOT NULL DEFAULT '0',`ControlledHighTally` int(11) NOT NULL DEFAULT '0',`ControlledLowTally` int(11) NOT NULL DEFAULT '0',`HotGoalTally` int(11) NOT NULL DEFAULT '0',`AutoPickup` int(11) NOT NULL DEFAULT '0',`ControlledPickup` int(11) NOT NULL DEFAULT '0',`MissedPickups` int(11) NOT NULL DEFAULT '0',`StartingLocationX` int(11) NOT NULL DEFAULT '0',`StartingLocationY` int(11) NOT NULL DEFAULT '0',`Comments` varchar(45) DEFAULT 'No Comment',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8");
                commands.Add("CREATE TABLE `AerialAssist_RahChaCha` (`EntryID` int(11) NOT NULL DEFAULT '0',`TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamName` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Default',`TeamColour` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Not Selected',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighGoal` int(11) NOT NULL DEFAULT '0',`AutoHighMiss` int(11) NOT NULL DEFAULT '0',`AutoLowGoal` int(11) NOT NULL DEFAULT '0',`AutoLowMiss` int(11) NOT NULL DEFAULT '0',`ControlledHighGoal` int(11) NOT NULL DEFAULT '0',`ControlledHighMiss` int(11) NOT NULL DEFAULT '0',`ControlledLowGoal` int(11) NOT NULL DEFAULT '0',`ControlledLowMiss` int(11) NOT NULL DEFAULT '0',`HotGoals` int(11) NOT NULL DEFAULT '0',`HotGoalMiss` int(11) NOT NULL DEFAULT '0',`3AssistGoal` int(11) NOT NULL DEFAULT '0',`3AssistMiss` int(11) NOT NULL DEFAULT '0',`AutoBallPickup` int(11) NOT NULL DEFAULT '0',`AutoBallPickupMiss` int(11) NOT NULL DEFAULT '0',`ControlledBallPickup` int(11) NOT NULL DEFAULT '0',`ControlledBallPickupMiss` int(11) NOT NULL DEFAULT '0',`PickupFromHuman` int(11) NOT NULL DEFAULT '0',`MissedPickupFromHuman` int(11) NOT NULL DEFAULT '0',`PassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`MissedPassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`SuccessfulTruss` int(11) NOT NULL DEFAULT '0',`UnsuccessfulTruss` int(11) NOT NULL DEFAULT '0',`StartingX` int(11) NOT NULL DEFAULT '0',`StartingY` int(11) NOT NULL DEFAULT '0',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',`DriverRating` int(11) NOT NULL DEFAULT '0',`AutoMovement` tinyint(4) NOT NULL DEFAULT '0',`Comments` varchar(300) COLLATE utf8_unicode_ci DEFAULT NULL,PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci");
                for (int i = 0; i < commands.Count; i++)
                {
                    try
                    {
                        cmd.CommandText = commands[i];
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException error)
                    {
                        Console.WriteLine("Error Code: " + error.ErrorCode);
                        Console.WriteLine(error.Message);
                        ConsoleWindow.AddItem("Error Code: " + error.ErrorCode);
                        ConsoleWindow.AddItem(error.Message);
                    }
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem(ex.Message);
            }
        }

        //From (http://www.developer.com/net/article.php/3794146/Adding-Standard-Deviation-to-LINQ.htm)
        //Update - Mildly updated this method so it is no longer the same as what is on the website above
        private double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            double[] enumerable = values as double[] ?? values.ToArray();
            if (!enumerable.Any()) return ret;
            //Compute the Average
            double avg = enumerable.Average();

            //Perform the Sum of (value-avg)^2
            double sum = enumerable.Sum(d => Math.Pow(d - avg, 2));

            //Put it all together
            ret = Math.Sqrt((sum)/enumerable.Count() - 1);
            return ret;
        }
    }
}