#region License

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

#endregion License

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using FRC_Scouting_V2.Events._2015_RecycleRush;
using FRC_Scouting_V2.Forms;
using FRC_Scouting_V2.Information_Forms;
using FRC_Scouting_V2.Properties;
using UsefulSnippets;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void eventSelector_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (eventSelector.SelectedIndex)
            {
                case 0:
                {
                    var aaNorthbay2014 = new AerialAssist_Northbay();
                    aaNorthbay2014.Show();
                }
                    break;

                case 1:
                {
                    var aaRahChaCha2014 = new AerialAssist_RahChaCha();
                    aaRahChaCha2014.Show();
                }
                    break;

                case 2:
                {
                    var rrgtre = new RecycleRush_GTR_East();
                    rrgtre.Show();
                }
                    break;

                case 3:
                {
                    var rrnb = new RecycleRush_Northbay();
                    rrnb.Show();
                }
                    break;

                case 4:
                {
                    var rriri = new RecycleRush_IRI();
                    rriri.Show();
                }
                    break;
                case 5:
                {
                    var rrffj = new RecycleRush_Fall_Fiesta_Junior();
                    rrffj.Show();
                }
                    break;
                case 6:
                {
                    var rrffs = new RecycleRush_Fall_Fiesta_Senior();
                    rrffs.Show();
                }
                    break;
            }

            if (Settings.Default.minimizeHomeWentEventLoads)
            {
                WindowState = FormWindowState.Minimized;
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
            ConsoleWindow.WriteLine("Started FRC_Scouting_V2_" + Assembly.GetExecutingAssembly().GetName().Version);
            timer.Start();
            eventSelector.Items.Add("Aerial Assist | Northbay | 2014");
            eventSelector.Items.Add("Aerial Assist | Rah Cha Cha | 2014");
            eventSelector.Items.Add("RecycleRush | GTR-East | 2015");
            eventSelector.Items.Add("RecycleRush | Northbay | 2015");
            eventSelector.Items.Add("RecycleRush | IRI | 2015");
            eventSelector.Items.Add("RecycleRush | Fall Fiesta - Junior | 2015");
            eventSelector.Items.Add("RecycleRush | Fall Fiesta - Senior | 2015");

            if (Settings.Default.firstTimeLoad)
            {
                if (
                    MessageBox.Show("Do you want to modify your database settings right now?", "Database Settings",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var settingsPage = new MainSettings_dep();
                    settingsPage.Show();
                    WindowState = FormWindowState.Minimized;
                }
                Settings.Default.firstTimeLoad = false;
                Settings.Default.Save();
            }

            myWebsiteRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsToolStripMenuItem.Enabled = false;
            var settings = new GeneralSettings();
            settings.Show();
            settingsToolStripMenuItem.Enabled = true;
        }

        private void teamInformationLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var teamInformationLookup = new TeamInformationLookup();
            teamInformationLookup.Show();
        }

        private void showConsoleWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Console = new ConsoleWindow();
            Console.Show();
        }

        private void eventInformationLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eil = new EventInformationLookup();
            eil.Show();
        }

        private void myWebsiteRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConsoleWindow.ExportToCSV_Timestamp();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Network.CheckForInternetConnection())
            {
                isInternetConnectedLabel.Text = ("Internet Connected");
                isInternetConnectedLabel.ForeColor = Color.DarkGreen;
                ConsoleWindow.WriteLine("Internet Connected");
            }
            else
            {
                if (Network.CheckForInternetConnection() == false)
                {
                    isInternetConnectedLabel.Text = ("Internet Not Connected");
                    isInternetConnectedLabel.ForeColor = Color.Red;
                    ConsoleWindow.WriteLine("Internet Disconnected");
                }
            }
        }

        private void initializeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySQLMethods.InitializeDatabases();
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cl = new ChangeLog();
            cl.Show();
        }

        private void frcLogoPictureBox_Click(object sender, EventArgs e)
        {
        }
    }
}