using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        //Variables
        private UsefulSnippets us = new UsefulSnippets();

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void programInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var programInfo = new ProgramInformation();
            programInfo.Show();
        }

        private void resetAllSavedSettingsToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
        }

        private void fRC3710TeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var team3710Info = new Team3710Information();
            team3710Info.Show();
        }

        private void mainSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainSettings = new MainSettings();
            mainSettings.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}