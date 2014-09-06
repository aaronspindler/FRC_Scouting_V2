using System;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

            usernameTextBox.Text = Settings.Default.username;
            databaseIPTextBox.Text = FRC_Scouting_V2.Properties.Settings.Default.databaseIP;
            databasePortTextBox.Text = FRC_Scouting_V2.Properties.Settings.Default.databasePort;
            databaseUsernameTextBox.Text = FRC_Scouting_V2.Properties.Settings.Default.databaseUsername;
            databasePasswordTextBox.Text = FRC_Scouting_V2.Properties.Settings.Default.databasePassword;
            databaseNameTextBox.Text = FRC_Scouting_V2.Properties.Settings.Default.databaseName;
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

        private void databaseIPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseIPTextBox.Text != (""))
            {
                FRC_Scouting_V2.Properties.Settings.Default.databaseIP = databaseIPTextBox.Text;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }

        private void databasePortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePortTextBox.Text != (""))
            {
                FRC_Scouting_V2.Properties.Settings.Default.databasePort = databasePortTextBox.Text;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }

        private void databaseUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseUsernameTextBox.Text != (""))
            {
                FRC_Scouting_V2.Properties.Settings.Default.databaseUsername = databaseUsernameTextBox.Text;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }

        private void databasePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePasswordTextBox.Text != (""))
            {
                FRC_Scouting_V2.Properties.Settings.Default.databasePassword = databasePasswordTextBox.Text;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }

        private void databaseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseNameTextBox.Text != (""))
            {
                FRC_Scouting_V2.Properties.Settings.Default.databaseName = databaseNameTextBox.Text;
                FRC_Scouting_V2.Properties.Settings.Default.Save();
            }
        }
    }
}