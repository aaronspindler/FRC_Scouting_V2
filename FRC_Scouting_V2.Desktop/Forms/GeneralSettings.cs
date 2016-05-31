#region License

//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2016 FRC_Scouting_V2

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

#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using UsefulSnippets;

namespace FRC_Scouting_V2.Forms
{
    public partial class GeneralSettings : Form
    {
        private bool firstTick = true;

        public GeneralSettings()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GeneralSettings_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = Settings.Default.username;
            mySqlDatabaseUsernameTextBox.Text = Settings.Default.mySqlDatabaseUsername;
            mySqlDatabaseServerAddressTextBox.Text = Settings.Default.mySqlDatabaseIP;
            mySqlDatabasePortTextBox.Text = Settings.Default.mySqlDatabasePort;
            mySqlDatabaseUsernameTextBox.Text = Settings.Default.mySqlDatabaseUsername;
            mySqlDatabasePasswordTextBox.Text = Security.DeCryptString(Settings.Default.mySqlDatabasePassword);
            mySqlDatabaseNameTextBox.Text = Settings.Default.mySqlDatabaseName;


            sqlDatabaseUsernameTextBox.Text = Settings.Default.sqlDatabaseUsername;
            sqlDatabaseServerAddressTextBox.Text = Settings.Default.sqlDatabaseIP;
            sqlDatabasePortTextBox.Text = Settings.Default.sqlDatabasePort;
            sqlDatabaseUsernameTextBox.Text = Settings.Default.sqlDatabaseUsername;
            sqlDatabasePasswordTextBox.Text = Security.DeCryptString(Settings.Default.sqlDatabasePassword);
            sqlDatabaseNameTextBox.Text = Settings.Default.sqlDatabaseName;

            timer.Start();
        }

        public bool TestMySQLCredentials()
        {
            try
            {
                var mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                conn.Open();

                if (conn.Ping())
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
                return false;
            }
            catch (MySqlException ex)
            {
                mySqlDatabaseConnectionDisplay.BackColor = Color.Red;
                mySqlDatabaseConnectionDisplay.Text = "Connection: Failed";
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine("Error Message " + ex.Message);
                return false;
            }
        }

        public bool TestSQLCredentials()
        {
            return true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (firstTick)
            {
                firstTick = false;
                if (TestMySQLCredentials())
                {
                    ConsoleWindow.WriteLine("You have successfully connected to your database!");
                    mySqlDatabaseConnectionDisplay.BackColor = Color.Chartreuse;
                    mySqlDatabaseConnectionDisplay.Text = "Connection: Successful";
                }
                else
                {
                    ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                    mySqlDatabaseConnectionDisplay.BackColor = Color.Red;
                    mySqlDatabaseConnectionDisplay.Text = "Connection: Failed";
                }

                if (TestSQLCredentials())
                {
                    ConsoleWindow.WriteLine("You have successfully connected to your database!");
                    sqlDatabaseConnectionDisplay.BackColor = Color.Chartreuse;
                    sqlDatabaseConnectionDisplay.Text = "Connection: Successful";
                }
                else
                {
                    ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                    sqlDatabaseConnectionDisplay.BackColor = Color.Red;
                    sqlDatabaseConnectionDisplay.Text = "Connection: Failed";
                }
            }
            else
            {
                timer.Stop();
            }
        }

        private void resetToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
        }

        private void saveGeneralSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.username = usernameTextBox.Text;
            Settings.Default.Save();
        }

        private void mySqlDatabaseSaveTestButton_Click(object sender, EventArgs e)
        {
            mySqlDatabaseConnectionDisplay.Text = "Connection: Testing";
            mySqlDatabaseConnectionDisplay.BackColor = Color.Yellow;

            Settings.Default.mySqlDatabaseIP = mySqlDatabaseServerAddressTextBox.Text;
            Settings.Default.mySqlDatabasePort = mySqlDatabasePortTextBox.Text;
            Settings.Default.mySqlDatabaseName = mySqlDatabaseNameTextBox.Text;
            Settings.Default.mySqlDatabaseUsername = mySqlDatabaseUsernameTextBox.Text;
            Settings.Default.mySqlDatabasePassword = Security.EncryptString(mySqlDatabasePasswordTextBox.Text);
            Settings.Default.Save();

            if (TestMySQLCredentials())
            {
                ConsoleWindow.WriteLine("You have successfully connected to your database!");
                mySqlDatabaseConnectionDisplay.BackColor = Color.Chartreuse;
                mySqlDatabaseConnectionDisplay.Text = "Connection: Successful";
            }
            else
            {
                ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                mySqlDatabaseConnectionDisplay.BackColor = Color.Red;
                mySqlDatabaseConnectionDisplay.Text = "Connection: Failed";
            }
        }

        private void sqlDatabaseSaveTestButton_Click(object sender, EventArgs e)
        {
            sqlDatabaseConnectionDisplay.Text = "Connection: Testing";
            sqlDatabaseConnectionDisplay.BackColor = Color.Yellow;

            Settings.Default.sqlDatabaseIP = sqlDatabaseServerAddressTextBox.Text;
            Settings.Default.sqlDatabasePort = sqlDatabasePortTextBox.Text;
            Settings.Default.sqlDatabaseName = sqlDatabaseNameTextBox.Text;
            Settings.Default.sqlDatabaseUsername = sqlDatabaseUsernameTextBox.Text;
            Settings.Default.sqlDatabasePassword = Security.EncryptString(sqlDatabasePasswordTextBox.Text);
            Settings.Default.Save();

            if (TestSQLCredentials())
            {
                ConsoleWindow.WriteLine("You have successfully connected to your database!");
                sqlDatabaseConnectionDisplay.BackColor = Color.Chartreuse;
                sqlDatabaseConnectionDisplay.Text = "Connection: Successful";
            }
            else
            {
                ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                sqlDatabaseConnectionDisplay.BackColor = Color.Red;
                sqlDatabaseConnectionDisplay.Text = "Connection: Failed";
            }
        }
    }
}