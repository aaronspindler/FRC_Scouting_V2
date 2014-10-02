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

using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

//@author xNovax

namespace FRC_Scouting_V2
{
    internal class UsefulSnippets
    {
        public void ClearSettings()
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            MessageBox.Show("You have successfully reset all settings to default!",
                "Settings have been reset to default!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ErrorOccured(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ExportTableToCSV(string tableName)
        {
            int autoBallPickup;
            int autoBallPickupMiss;
            int autoHighGoal;
            int autoHighMiss;
            int autoLowGoal;
            int autoLowMiss;
            int controlledBallPickup;
            int controlledBallPickupMiss;
            int controlledHighGoal;
            int controlledHighMiss;
            int controlledLowGoal;
            int controlledLowMiss;
            int hotGoal;
            int hotMiss;
            int matchNumber;
            int passToOtherRobot;
            int passToOtherRobotMiss;
            int pickupFromHuman;
            int pickupFromHumanMiss;
            int successfulTruss;
            int totalGoal;
            int totalGoodControl;
            int totalMiss;
            int totalMissControl;
            int tripleAssistGoal;
            int tripleAssistMiss;
            int unsuccessfulTruss;
            int xStarting;
            int yStarting;
            int didRobotDie;
            string comments;
            string teamColour;

            var sfd = new SaveFileDialog();
            sfd.Filter = ("CSV files (*.csv)|*.csv|All files (*.*)|*.*");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Making the connection string and then creating the connection
                    var mySqlConnectionString = MakeMySqlConnectionString();
                    var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};
                    conn.Open();
                    var cmd = new MySqlCommand();
                    var writer = new StreamWriter(sfd.FileName);
                    //Writing the column names
                    writer.WriteLine("EntryID, TeamNumber, TeamName, TeamColour, MatchNumber, AutoHighGoal, AutoHighMiss, AutoLowGoal, AutoLowMiss, ControlledHighGoal, ControlledHighMiss, ControlledLowGoal, ControlledLowMiss, HotGoals, HotGoalMiss, 3AssistGoal, 3AssistMiss, AutoBallPickup, AutoBallPickupMiss, ControlledBallPickup, ControlledBallPickupMiss, PickupFromHuman, MissedPickupFromHuman, PassToAnotherRobot, MissedPassToAnotherRobot, SuccessfulTruss, UnsuccessfulTruss, StartingX, StartingY, DidRobotDie, Comments");
                    for (int i = 0; i < GetNumberOfRowsInATable(); i++)
                    {
                        string commandText = String.Format("SELECT * from {0}", tableName);
                        cmd.CommandText = commandText;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Row: " + i + " has been exported.");
                    }
                    Console.WriteLine("Your data has been successfully exported!");
                    writer.Close();
                    conn.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error Code: " + ex.ErrorCode);
                    Console.WriteLine(ex.Message);
                }
            }
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
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

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
            }
            return numberOfRows;
        }

        public int GetSecureRandomNum(int startingNum, int endingNum)
        {
            int difference = endingNum - startingNum;
            var bytes = new byte[16];
            var r = new RNGCryptoServiceProvider();

            r.GetBytes(bytes);
            int number = (int)((decimal)bytes[0] / 256 * difference) + startingNum;

            return number;
        }

        public string MakeMySqlConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder["Server"] = Settings.Default.databaseIP;
            builder["Database"] = Settings.Default.databaseName;
            builder["Port"] = Settings.Default.databasePort;
            builder["Uid"] = Settings.Default.databaseUsername;
            builder["Password"] = Settings.Default.databasePassword;
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
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
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
    }
}