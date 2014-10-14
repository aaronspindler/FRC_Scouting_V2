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

using System;
using System.Drawing;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class MainSettings : Form
    {
        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

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

        private void databaseIPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseIPTextBox.Text != (""))
            {
                Settings.Default.databaseIP = databaseIPTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databaseNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseNameTextBox.Text = ("");
            }
        }

        private void databaseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseNameTextBox.Text != (""))
            {
                Settings.Default.databaseName = databaseNameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databasePasswordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePasswordTextBox.Text = ("");
            }
        }

        private void databasePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePasswordTextBox.Text != (""))
            {
                Settings.Default.databasePassword = databasePasswordTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databasePortTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePortTextBox.Text = ("");
            }
        }

        private void databasePortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePortTextBox.Text != (""))
            {
                Settings.Default.databasePort = databasePortTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databaseUsernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseUsernameTextBox.Text = ("");
            }
        }

        private void databaseUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseUsernameTextBox.Text != (""))
            {
                Settings.Default.databaseUsername = databaseUsernameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void howComeICannotConnectToMyDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage(
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

            teamComparisonEqualValueColourDisplay.BackColor = FRC_Scouting_V2.Properties.Settings.Default.teamComparisonEqualValueColour;

            usernameTextBox.Text = Settings.Default.username;
            databaseIPTextBox.Text = Settings.Default.databaseIP;
            databasePortTextBox.Text = Settings.Default.databasePort;
            databaseUsernameTextBox.Text = Settings.Default.databaseUsername;
            databasePasswordTextBox.Text = Settings.Default.databasePassword;
            databaseNameTextBox.Text = Settings.Default.databaseName;
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
                string databaseIP = Settings.Default.databaseIP;
                string databasePort = Settings.Default.databasePort;
                string databaseName = Settings.Default.databaseName;
                string databaseUsername = Settings.Default.databaseUsername;
                string databasePassword = Settings.Default.databasePassword;
                string mySqlConnectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};password={4};",
                    databaseIP, databasePort, databaseName, databaseUsername, databasePassword);
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                conn.Open();

                if (conn.Ping())
                {
                    Console.WriteLine("You have successfully connected to your database!");
                    connectionDisplay.BackColor = Color.Chartreuse;
                    us.ShowInformationMessage("You have successfully connected to your database!");
                }
                else
                {
                    Console.WriteLine("You have unsuccessfully connected to your database!");
                    connectionDisplay.BackColor = Color.Red;
                    us.ShowInformationMessage("You have unsuccessfully connected to your database!");
                }

                conn.Close();
            }
            catch (MySqlException ex)
            {
                connectionDisplay.BackColor = Color.Red;
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
                us.ErrorOccured(
                    "Something went wrong with the connection to your database! Make sure that your connection info is correct.");
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
                FRC_Scouting_V2.Properties.Settings.Default.teamComparisonEqualValueColour = colorDialog.Color;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }
    }
}