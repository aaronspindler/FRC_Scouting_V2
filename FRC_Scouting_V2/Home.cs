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
        UsefulSnippets us = new UsefulSnippets();

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainSettings = new MainSettings();
            mainSettings.Show();
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
    }
}
