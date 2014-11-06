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
using System.Windows.Forms;
using FRC_Scouting_V2.Information_Forms;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

        public Home()
        {
            InitializeComponent();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeLog = new Changelog();
            changeLog.Show();
        }

        private void eventSelector_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (eventSelector.SelectedIndex == 0)
            {
                var aaNorthbay2014 = new AerialAssist_Northbay();
                aaNorthbay2014.Show();

                if (Settings.Default.minimizeHomeWentEventLoads)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (eventSelector.SelectedIndex == 1)
                {
                    var aaRahChaCha2014 = new AerialAssist_RahChaCha();
                    aaRahChaCha2014.Show();

                    if (Settings.Default.minimizeHomeWentEventLoads)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fRC3710TeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var team3710Info = new Team3710Information();
            team3710Info.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            eventSelector.Items.Add("Aerial Assist | Northbay | 2014");
            eventSelector.Items.Add("Aerial Assist | Rah Cha Cha | 2014");
            eventSelector.Items.Add("Unknown | GTR-East | 2015");
            eventSelector.Items.Add("Unknown | Northbay | 2015");

            if (Settings.Default.firstTimeLoad)
            {
                if (MessageBox.Show("Since this is the first time you have used this program please take a look at the settings page. This will prevent any headaches when trying to use the program. Do you want to be taken to the settings page now?","Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var settingsPage = new MainSettings();
                    settingsPage.Show();
                    WindowState = FormWindowState.Minimized;
                }

                Settings.Default.firstTimeLoad = false;
                Settings.Default.Save();
            }
        }

        private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var li = new License();
            li.Show();
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainSettings = new MainSettings();
            mainSettings.Show();
        }

        private void teamInformationLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var teamInformationLookup = new TeamInformationLookup();
            teamInformationLookup.Show();
        }

        private void showConsoleWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eventInformationLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eil = new EventInformationLookup();
            eil.Show();
        }
    }
}