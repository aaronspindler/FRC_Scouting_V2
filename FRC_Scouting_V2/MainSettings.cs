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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetAllSettingsButton_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
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

            usernameTextBox.Text = Settings.Default.username;
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

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != (""))
            {
                Settings.Default.username = usernameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void usernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                usernameTextBox.Text = ("");
            }
        }

        private void howDoISaveMySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Your settings save automatically, every time you change a setting it will immediately save the change.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void whatIsTheUsernameFieldUsedForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Username field is used to keep track of who makes changes to any data. This prevents any mischievous changes to data.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}