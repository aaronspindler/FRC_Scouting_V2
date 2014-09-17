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

//@author xNovax
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

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
            try
            {
                string databaseIP = Settings.Default.databaseIP;
                string databasePort = Settings.Default.databasePort;
                string databaseName = Settings.Default.databaseName;
                string databaseUsername = Settings.Default.databaseUsername;
                string databasePassword = Settings.Default.databasePassword;
                string mySqlConnectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};password={4};",
                    databaseIP, databasePort, databaseName, databaseUsername, databasePassword);
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

                var cmd = new MySqlCommand(("SELECT COUNT(*) FROM " + tableName), conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
            }
        }

        public string GetCurrentTime()
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            return time;
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