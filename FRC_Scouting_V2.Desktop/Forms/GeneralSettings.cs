using System;
using System.Drawing;
using System.Threading.Tasks;
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
            databaseUsernameTextBox.Text = Settings.Default.username;
            databaseServerAddressTextBox.Text = Settings.Default.databaseIP;
            databasePortTextBox.Text = Settings.Default.databasePort;
            databaseUsernameTextBox.Text = Settings.Default.databaseUsername;
            databasePasswordTextBox.Text = Security.DeCryptString(Settings.Default.databasePassword);
            databaseNameTextBox.Text = Settings.Default.databaseName;

            timer.Start();


        }

        private void databaseSaveTestButton_Click(object sender, EventArgs e)
        {
            Settings.Default.databaseIP = databaseServerAddressTextBox.Text;
            Settings.Default.databasePort = databasePortTextBox.Text;
            Settings.Default.databaseName = databaseNameTextBox.Text;
            Settings.Default.databaseUsername = databaseUsernameTextBox.Text;
            Settings.Default.databasePassword = Security.EncryptString(databasePasswordTextBox.Text);
            Settings.Default.Save();

            if (TestMySQLCredentials())
            {
                ConsoleWindow.WriteLine("You have successfully connected to your database!");
                databaseConnectionDisplay.BackColor = Color.Chartreuse;
                databaseConnectionDisplay.Text = ("Connection: Successful");
            }
            else
            {
                ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                databaseConnectionDisplay.BackColor = Color.Red;
                databaseConnectionDisplay.Text = ("Connection: Failed");
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
                databaseConnectionDisplay.BackColor = Color.Red;
                databaseConnectionDisplay.Text = ("Connection: Failed");
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
                    databaseConnectionDisplay.BackColor = Color.Chartreuse;
                    databaseConnectionDisplay.Text = ("Connection: Successful");
                }
                else
                {
                    ConsoleWindow.WriteLine("You have unsuccessfully connected to your database!");
                    databaseConnectionDisplay.BackColor = Color.Red;
                    databaseConnectionDisplay.Text = ("Connection: Failed");
                }
            }
            else
            {
                timer.Stop();
            }
        }
    }
}