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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class MainSettings : Form
    {
        public MainSettings()
        {
            InitializeComponent();
        }

        private void allowExportToTextFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allowExportToTextFileCheckBox.Checked)
            {
                Settings.Default.allowExportToTextFile = true;
                Settings.Default.Save();
            }
            else
            {
                if (allowExportToTextFileCheckBox.Checked == false)
                {
                    Settings.Default.allowExportToTextFile = false;
                    Settings.Default.Save();
                }
            }
        }

        private void clearConsoleOnToggleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clearConsoleOnToggleCheckBox.Checked)
            {
                Settings.Default.clearConsoleOnToggle = true;
                Settings.Default.Save();
            }
            else
            {
                if (clearConsoleOnToggleCheckBox.Checked == false)
                {
                    Settings.Default.clearConsoleOnToggle = false;
                    Settings.Default.Save();
                }
            }
        }

        private void clickEmptyTextBoxChecker_CheckedChanged(object sender, EventArgs e)
        {
            if (clickEmptyTextBoxChecker.Checked)
            {
                Settings.Default.clickToEmptyTextBoxes = true;
                Settings.Default.Save();
            }
            else
            {
                if (clickEmptyTextBoxChecker.Checked == false)
                {
                    Settings.Default.clickToEmptyTextBoxes = false;
                    Settings.Default.Save();
                }
            }
        }

        private void databaseIPTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseIPTextBox.Text = ("");
            }
        }

        private void databaseNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseNameTextBox.Text = ("");
            }
        }

        private void databasePasswordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePasswordTextBox.Text = ("");
            }
        }

        private void databasePortTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePortTextBox.Text = ("");
            }
        }

        private void databaseUsernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseUsernameTextBox.Text = ("");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void howComeICannotConnectToMyDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsefulSnippets.Notifications.ShowInformationMessage(
                "The issue is probably because your computer's IP is not whitelisted in your database.");
        }

        private void howDoISaveMySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Your settings save automatically, every time you change a setting it will immediately save the change.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainSettings_Load(object sender, EventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                clickEmptyTextBoxChecker.Checked = true;
            }
            else
            {
                if (Settings.Default.clickToEmptyTextBoxes == false)
                {
                    clickEmptyTextBoxChecker.Checked = false;
                }
            }

            if (Settings.Default.minimizeHomeWentEventLoads)
            {
                minimizeHomeCheckbox.Checked = true;
            }
            else
            {
                if (Settings.Default.minimizeHomeWentEventLoads == false)
                {
                    minimizeHomeCheckbox.Checked = false;
                }
            }

            if (Settings.Default.clearConsoleOnToggle)
            {
                clearConsoleOnToggleCheckBox.Checked = true;
            }
            else
            {
                if (Settings.Default.clearConsoleOnToggle == false)
                {
                    clearConsoleOnToggleCheckBox.Checked = false;
                }
            }

            if (Settings.Default.allowExportToTextFile)
            {
                allowExportToTextFileCheckBox.Checked = true;
            }
            else
            {
                if (Settings.Default.allowExportToTextFile == false)
                {
                    allowExportToTextFileCheckBox.Checked = false;
                }
            }

            if (Settings.Default.showQuestionButtons)
            {
                showQuestionButtonsCheckBox.Checked = true;
            }
            else
            {
                if (Settings.Default.showQuestionButtons == false)
                {
                    showQuestionButtonsCheckBox.Checked = false;
                }
            }

            if (Settings.Default.colourTeamComparisonStatistics)
            {
                colourTeamComparisonStatisticsCheckBox.Checked = true;
            }
            else
            {
                if (Settings.Default.colourTeamComparisonStatistics == false)
                {
                    colourTeamComparisonStatisticsCheckBox.Checked = false;
                }
            }

            teamComparisonEqualValueColourDisplay.BackColor = Settings.Default.teamComparisonEqualValueColour;
            usernameTextBox.Text = Settings.Default.username;
            databaseIPTextBox.Text = Settings.Default.databaseIP;
            databasePortTextBox.Text = Settings.Default.databasePort;
            databaseUsernameTextBox.Text = Settings.Default.databaseUsername;
            databasePasswordTextBox.Text = UsefulSnippets.Security.DeCryptString(Settings.Default.databasePassword);
            databaseNameTextBox.Text = Settings.Default.databaseName;

            try
            {
                string mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

                conn.Open();

                if (conn.Ping())
                {
                    Console.WriteLine("You have successfully connected to your database!");
                    ConsoleWindow.AddItem("You have successfully connected to your database!");
                    connectionDisplay.BackColor = Color.Chartreuse;
                    connectionDisplay.Text = ("Successfully Connected to Database.");
                }
                else
                {
                    Console.WriteLine("You have unsuccessfully connected to your database!");
                    ConsoleWindow.AddItem("You have unsuccessfully connected to your database!");
                    connectionDisplay.BackColor = Color.Red;
                    connectionDisplay.Text = ("Connection to Database Failed.");
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                connectionDisplay.BackColor = Color.Red;
                connectionDisplay.Text = ("Connection to Database Failed.");
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine("Error Message " + ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem("Error Message " + ex.Message);
            }
        }

        private void minimizeHomeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (minimizeHomeCheckbox.Checked)
            {
                Settings.Default.minimizeHomeWentEventLoads = true;
                Settings.Default.Save();
            }
            else
            {
                if (minimizeHomeCheckbox.Checked == false)
                {
                    Settings.Default.minimizeHomeWentEventLoads = false;
                    Settings.Default.Save();
                }
            }
        }

        private void resetAllSettingsButton_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
        }

        private void showQuestionButtonsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showQuestionButtonsCheckBox.Checked)
            {
                Settings.Default.showQuestionButtons = true;
                Settings.Default.Save();
            }
            else
            {
                if (showQuestionButtonsCheckBox.Checked == false)
                {
                    Settings.Default.showQuestionButtons = false;
                    Settings.Default.Save();
                }
            }
        }

        private void testConnectionToDatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                string mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

                conn.Open();

                if (conn.Ping())
                {
                    Console.WriteLine("You have successfully connected to your database!");
                    ConsoleWindow.AddItem("You have successfully connected to your database!");
                    connectionDisplay.BackColor = Color.Chartreuse;
                    connectionDisplay.Text = ("Successfully Connected to Database.");
                    try
                    {
                        MySQLMethods.InitializeDatabases();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error Message: " + exception.Message);
                        ConsoleWindow.AddItem("Error Message: " + exception.Message);
                    }
                }
                else
                {
                    Console.WriteLine("You have unsuccessfully connected to your database!");
                    ConsoleWindow.AddItem("You have unsuccessfully connected to your database!");
                    connectionDisplay.BackColor = Color.Red;
                    connectionDisplay.Text = ("Connection to Database Failed.");
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                connectionDisplay.BackColor = Color.Red;
                connectionDisplay.Text = ("Connection to Database Failed.");
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine("Error Message " + ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem("Error Message " + ex.Message);
            }
        }

        private void usernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                usernameTextBox.Text = ("");
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != (""))
            {
                Settings.Default.username = usernameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void whatIsTheUsernameFieldUsedForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Username field is used to keep track of who makes changes to any data. This prevents any mischievous changes to data.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void colourTeamComparisonStatisticsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (colourTeamComparisonStatisticsCheckBox.Checked)
            {
                Settings.Default.colourTeamComparisonStatistics = true;
                Settings.Default.Save();
            }
            else
            {
                if (colourTeamComparisonStatisticsCheckBox.Checked == false)
                {
                    Settings.Default.colourTeamComparisonStatistics = false;
                    Settings.Default.Save();
                }
            }
        }

        private void teamComparisonEqualColourButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                teamComparisonEqualValueColourDisplay.BackColor = colorDialog.Color;
                Settings.Default.teamComparisonEqualValueColour = colorDialog.Color;
                Settings.Default.Save();
            }
        }

        private void importDatabaseConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var reader = new StreamReader(openFileDialog.FileName);
                    Settings.Default.databaseIP = Convert.ToString(reader.ReadLine());
                    Settings.Default.databasePort = Convert.ToString(reader.ReadLine());
                    Settings.Default.databaseName = Convert.ToString(reader.ReadLine());
                    Settings.Default.databaseUsername = Convert.ToString(reader.ReadLine());
                    Settings.Default.databasePassword = Convert.ToString(reader.ReadLine());
                    Settings.Default.Save();

                    usernameTextBox.Text = Settings.Default.username;
                    databaseIPTextBox.Text = Settings.Default.databaseIP;
                    databasePortTextBox.Text = Settings.Default.databasePort;
                    databaseUsernameTextBox.Text = Settings.Default.databaseUsername;
                    databasePasswordTextBox.Text = Settings.Default.databasePassword;
                    databaseNameTextBox.Text = Settings.Default.databaseName;

                    UsefulSnippets.Notifications.ShowInformationMessage(
                        "You have successfully imported your connection details. Please test the connection");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Occured: " + exception.Message);
                    ConsoleWindow.AddItem("Error Occured: " + exception.Message);
                }
            }
        }

        private void saveDatabaseSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.databaseIP = databaseIPTextBox.Text;
            Settings.Default.databasePort = databasePortTextBox.Text;
            Settings.Default.databaseName = databaseNameTextBox.Text;
            Settings.Default.databaseUsername = databaseUsernameTextBox.Text;
            Settings.Default.databasePassword = UsefulSnippets.Security.EncryptString(databasePasswordTextBox.Text);
            Settings.Default.Save();
            UsefulSnippets.Notifications.ShowInformationMessage("Successfully Saved Database Settings");
        }
    }
}