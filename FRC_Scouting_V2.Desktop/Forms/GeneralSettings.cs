﻿using System;
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

            timer.Start();
        }

        private void databaseSaveTestButton_Click(object sender, EventArgs e)
        {
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
                mySqlDatabaseConnectionDisplay.Text = ("Connection: Successful");
            }
            else
            {
                ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                mySqlDatabaseConnectionDisplay.BackColor = Color.Red;
                mySqlDatabaseConnectionDisplay.Text = ("Connection: Failed");
            }
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
                mySqlDatabaseConnectionDisplay.Text = ("Connection: Failed");
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine("Error Message " + ex.Message);
                return false;
            }
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
                    mySqlDatabaseConnectionDisplay.Text = ("Connection: Successful");
                }
                else
                {
                    ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                    mySqlDatabaseConnectionDisplay.BackColor = Color.Red;
                    mySqlDatabaseConnectionDisplay.Text = ("Connection: Failed");
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
    }
}