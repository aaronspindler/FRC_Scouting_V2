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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FRC_Scouting_V2.Events._2015_RecycleRush;
using FRC_Scouting_V2.Information_Forms;
using FRC_Scouting_V2.Properties;
using UsefulSnippets;
using Microsoft.VisualBasic;
using System.Text;
//using System.Web.Caching;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        //Variables
        public static Boolean internetAvailable;

        private readonly Thread internetTestTH = new Thread(checkInternet);

        public Home()
        {
            InitializeComponent();
        }

        private static void checkInternet()
        {
            while (true)
            {
                try
                {
                    using (var client = new WebClient())
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        internetAvailable = true;
                    }
                }
                catch
                {
                    internetAvailable = false;
                }
                Thread.Sleep(5000);
            }
        }

        private void eventSelector_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (eventSelector.SelectedIndex == 0)
            {
                var iri = new RecycleRush_IRI();
                iri.Show();

                if (Settings.Default.minimizeHomeWentEventLoads)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (eventSelector.SelectedIndex == 1)
                {
                    var tahs = new RecycleRush_TroyAthens();
                    tahs.Show();

                    if (Settings.Default.minimizeHomeWentEventLoads)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
                else
                {
                    //nothing there
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
            ConsoleWindow.WriteLine("Started FRC_Scouting_V2_" + Assembly.GetExecutingAssembly().GetName().Version);
            internetTestTH.Start();
            timer.Start();
            eventSelector.Items.Add("RecycleRush | IRI | 2015");
            eventSelector.Items.Add("RecycleRush | Troy Athens | 2015 (Old/Debug)");

            if (Settings.Default.firstTimeLoad)
            {
                if (MessageBox.Show("Since this is the first time you have used this program please take a look at the settings page. This will prevent any headaches when trying to use the program. Do you want to be taken to the settings page now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var settingsPage = new MainSettings();
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
            internetTestTH.Abort();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (internetAvailable)
            {
                isInternetConnectedLabel.Text = ("Internet Connected");
                isInternetConnectedLabel.ForeColor = Color.DarkGreen;
                ConsoleWindow.WriteLine("Internet Connected");
            }
            else
            {
                if (internetAvailable == false)
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

        private void contributeToFRCScoutingV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contribute = new Contribute();
            contribute.Show();
        }

        private void frcLogoPictureBox_Click(object sender, EventArgs e)
        {
        }

        private void eventSelector_Click(object sender, EventArgs e)
        {

        }

        private void cacheTBAEventData(object sender, EventArgs e)
        {
            if (MessageBox.Show("This downloads the file(s) for ONE FRC event from TBA. The downloading of these file(s) may take a long time, and these files may take up a lot of storage space. Are you sure you want to continue?", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                try
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\");
                    getEvent:  string eventCode = Interaction.InputBox("What is the event code for the event that you want to cache?", "Get Event Info to Cache", "", -1, -1);
                    if (!(eventCode.Length > 4)) { goto getEvent;  }
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventCode + ".html");
                    string appendedUriString = "http://www.thebluealliance.com/event/" + eventCode;
                    TheBlueAlliance.Models.Event.EventInformation eventInfo = TheBlueAlliance.Events.GetEventInformation(eventCode);
                    string tmp = eventInfo.short_name;
                    if (System.String.IsNullOrWhiteSpace(tmp)) { tmp = eventCode.ToUpper().Substring(4);  }
                    if (MessageBox.Show(("Is the event: " + tmp + " (" + eventCode + "), correct?"), "Correct event?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                        Uri siteUri = new Uri(appendedUriString);
                        WebClient client = new WebClient();
                        byte[] siteData = client.DownloadData(siteUri);
                        string siteDataEncoded = Encoding.ASCII.GetString(siteData);
                        File.WriteAllText(path, siteDataEncoded);
                        MessageBox.Show(("Completed saving the data of: " + appendedUriString + " to " + path + "."), "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        goto getEvent;
                    }
                }
                catch (Exception exception)
                {
                    Console.Write("Error Occured: " + exception.Message);
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                    Notifications.ReportCrash(exception);
                } 
            }
        }

        private void cacheATeamsTBADataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This downloads the file(s) for ONE FRC team from TBA. The downloading of these file(s) may take a long time, and these files may take up a lot of storage space. Are you sure you want to continue?", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                try
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\");
                getTeamNum: string teamNum = Interaction.InputBox("What is the team number for the team's info that you want to cache?", "Get Team Num's Info to Cache", "", -1, -1);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "Info.html");
                    string appendedUriString = "http://www.thebluealliance.com/team/" + (Convert.ToInt32(teamNum));
                    TheBlueAlliance.Models.TeamInformation teamInfo = TheBlueAlliance.Teams.GetTeamInformation("frc" + (Convert.ToInt32(teamNum)));
                    string tmp = teamInfo.nickname;
                    if (MessageBox.Show(("Is the team: " + tmp + " (Team " + (Convert.ToInt32(teamNum)) + "), correct?"), "Correct event?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                        Uri siteUri = new Uri(appendedUriString);
                        WebClient client = new WebClient();
                        byte[] siteData = client.DownloadData(siteUri);
                        string siteDataEncoded = Encoding.ASCII.GetString(siteData);
                        File.WriteAllText(path, siteDataEncoded);
                        MessageBox.Show(("Completed saving the data of: " + appendedUriString + " to " + path + "."), "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        goto getTeamNum;
                    }
                }
                catch (Exception exception)
                {
                    Console.Write("Error Occured: " + exception.Message);
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                    Notifications.ReportCrash(exception);
                }
            }
        }

        private void reCacheDefaultTBADataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This downloads the default files needed for Offline scouting. The downloading of these files may take a long time, and these files may take up a lot of storage space. Are you sure you want to continue?", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves");
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\DefaultData\\");
                string teamListPath = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\DefaultData\\" + "TeamList.html");
                WebClient client = new WebClient();
                int[] thousands = { 1, 2, 3, 4, 5 };
                try
                {
                    for (int i = 0; i < thousands.Length; i++)
                    {
                        cacheAllTeamsListOffline(client, teamListPath, thousands[i]);
                    }
                }
                catch (Exception exception)
                {
                    Console.Write("Error Occured: " + exception.Message);
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                    Notifications.ReportCrash(exception);
                }
            }
        }

        private void cacheAllTeamsListOffline(WebClient client, string path, int whichSetOfThousands)
        {
            string UriString = "http://www.thebluealliance.com/teams/" + whichSetOfThousands;
            Uri siteUri = new Uri(UriString);
            byte[] siteData = client.DownloadData(siteUri);
            string siteDataEncoded = Encoding.ASCII.GetString(siteData);
            File.WriteAllText(path, siteDataEncoded);
            MessageBox.Show(("Completed saving the data of: " + UriString + " to " + path + "."), "Completed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}