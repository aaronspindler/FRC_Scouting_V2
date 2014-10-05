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
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class AerialAssist_RahChaCha : Form
    {
        private const string TABLE_NAME = ("AerialAssist_RahChaCha");

        private readonly string[] teamNameArray =
        {
            "The Rocketeers", "Arctic Warriors", "X-CATS",
            "Greater Rochester Robotics", "Circuit Stompers", "Red Raider Robotics", "The Coyotes",
            "Code Red Robotics", "Warp7", "Simbotics", "SparX", "Theory6", "TheBigBang", "Red Devil Robotics",
            "Finney Robotics", "Warlocks", "Rolling Thunder", "Raider Robotics", "Grapes of Wrath", "DevilTech",
            "Scitobor Robotics", "CougarTech", "XcentricsRobotics", "DM High Voltage", "The Astechz", "Tan[x]",
            "Ranger Robotics", "Eastridge Robotics", "IgKnighters", "Pittsford Panthers", "CyberFalcons", "S.U.I.T.S.",
            "Retro Rams", "MakeShift", "MaxTech", "W.A.F.F.L.E.S.", "VP Robotics", "Electric Mayhem", "Robot Raiders"
        };

        private readonly int[] teamNumberArray =
        {
            20, 174, 191, 340, 378, 578, 610, 639, 865, 1114, 1126, 1241, 1285,
            1334, 1405, 1507, 1511, 1518, 1551, 1559, 1585, 2228, 2340, 2852, 2994, 3003, 3015, 3157, 3173, 3181, 3710,
            3951, 4001, 4039, 4343, 4476, 4914, 4930, 5254
        };

        private readonly UsefulSnippets us = new UsefulSnippets();
        private int rookieYear;

        private int selectedTeam1;
        private int selectedTeam2;
        private string teamLocation = ("");
        private string teamName = ("");
        private int teamNumber;
        private string teamURL;
        private string url = ("http://www.thebluealliance.com/api/v2/team/frc");


        public AerialAssist_RahChaCha()
        {
            InitializeComponent();
        }

        public void importFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string t in openFileDialog.FileNames)
                {
                    var reader = new StreamReader(t);
                    //Bypassing the human readable variables to get to the computer readable portion of the text file
                    for (int i = 0; i < 28; i++)
                    {
                        reader.ReadLine();
                    }
                    int teamNumber = Convert.ToInt32(reader.ReadLine());
                    string teamName = reader.ReadLine();
                    string teamColour = reader.ReadLine();
                    int matchNumber = Convert.ToInt32(reader.ReadLine());
                    int autoHighGoal = Convert.ToInt32(reader.ReadLine());
                    int autoHighMiss = Convert.ToInt32(reader.ReadLine());
                    int autoLowGoal = Convert.ToInt32(reader.ReadLine());
                    int autoLowMiss = Convert.ToInt32(reader.ReadLine());
                    int controlledHighGoal = Convert.ToInt32(reader.ReadLine());
                    int controlledHighMiss = Convert.ToInt32(reader.ReadLine());
                    int controlledLowGoal = Convert.ToInt32(reader.ReadLine());
                    int controlledLowMiss = Convert.ToInt32(reader.ReadLine());
                    int hotGoal = Convert.ToInt32(reader.ReadLine());
                    int missedHotGoal = Convert.ToInt32(reader.ReadLine());
                    int tripleGoal = Convert.ToInt32(reader.ReadLine());
                    int tripleMiss = Convert.ToInt32(reader.ReadLine());
                    int autoBallPickup = Convert.ToInt32(reader.ReadLine());
                    int autoBallPickupMiss = Convert.ToInt32(reader.ReadLine());
                    int controlledPickup = Convert.ToInt32(reader.ReadLine());
                    int controlledPickupMiss = Convert.ToInt32(reader.ReadLine());
                    int pickupFromHuman = Convert.ToInt32(reader.ReadLine());
                    int missedPickupFromHuman = Convert.ToInt32(reader.ReadLine());
                    int passToOtherBot = Convert.ToInt32(reader.ReadLine());
                    int missedPassToOtherBot = Convert.ToInt32(reader.ReadLine());
                    int successfulTruss = Convert.ToInt32(reader.ReadLine());
                    int unsuccessfulTruss = Convert.ToInt32(reader.ReadLine());
                    int startingX = Convert.ToInt32(reader.ReadLine());
                    int startingY = Convert.ToInt32(reader.ReadLine());
                    Boolean didTheRobotDie = Convert.ToBoolean(reader.ReadLine());
                    string comments = Convert.ToString(reader.ReadLine());
                    string testIfFileIsGood = reader.ReadLine();
                    if (testIfFileIsGood.Equals("END OF FILE"))
                    {
                        var conn = new MySqlConnection(us.MakeMySqlConnectionString());
                        var cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = String.Format("Insert into {0} ()", Settings.Default.currentTableName);
                    }
                    else
                    {
                        if (!testIfFileIsGood.Equals("END OF FILE"))
                        {
                            us.ErrorOccured("The file does not seem to be in the correct format.");
                        }
                    }
                }
            }
        }

        public void UpdateTeamComparison()
        {
            string mySqlConnectionString = us.MakeMySqlConnectionString();
            var conn = new MySqlConnection(mySqlConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            for (int i = 0; i < us.GetNumberOfRowsInATable(); i++)
            {
                cmd.CommandText = String.Format("SELECT * from {0} where EntryID={1}", Settings.Default.currentTableName,
                    i);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["TeamName"].ToString() == Convert.ToString(selectedTeam1))
                    {
                    }
                    else
                    {
                        if (reader["TeamName"].ToString() == Convert.ToString(selectedTeam2))
                        {
                        }
                    }
                }
                reader.Close();
            }
        }

        public void whyDoesTheLinkForATeamWebsiteNotWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage("Sometime it works and sometimes it doesn't. This is a known bug.");
        }

        private void AerialAssist_RahChaCha_Load(object sender, EventArgs e)
        {
            Settings.Default.currentTableName = (TABLE_NAME);
            Settings.Default.Save();

            //Starting the clock so that the current time will be displayed and updated every second

            //Setting toolTips
            var ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(teamSelector,
                "Use this to select the team that you want to enter data / look at data for!");

            //Adding teams to team selector and teamListBox
            for (int i = 0; i < teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
                teamCompSelector1.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
                teamCompSelector2.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
            }

            TeamComparisonCHG.Text = "Controlled High Goals";
            TeamComparisonCLG.Text = "Controlled Low Goals";
        }

        private void eventInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aaRahChaChaEventInfo = new AerialAssist_RahChaCha_Information();
            aaRahChaChaEventInfo.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToCSVToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            us.AerialAssistExportTableToCSV();
        }

        private void howComeICannotSeeAnyTeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage(
                "The team information is pulled from TheBluAlliance's API, this means that you need to have an internet connection to get the data.");
        }

        private void teamCompSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var BackgroundThread = new Thread(UpdateTeamComparison);
            selectedTeam1 = teamNumberArray[teamCompSelector1.SelectedIndex];
            BackgroundThread.Start();
            Console.WriteLine(selectedTeam1);
        }

        private void teamCompSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var BackgroundThread = new Thread(UpdateTeamComparison);
            selectedTeam2 = teamNumberArray[teamCompSelector2.SelectedIndex];
            BackgroundThread.Start();
            Console.WriteLine(selectedTeam2);
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            url = ("http://www.thebluealliance.com/api/v2/team/frc");
            url = url + Convert.ToString(teamNumberArray[teamSelector.SelectedIndex]);
            string downloadedData;
            var wc = new MyWebClient();
            wc.Headers.Add("X-TBA-App-Id",
                "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);

            try
            {
                downloadedData = (wc.DownloadString(url));
                var deserializedData = JsonConvert.DeserializeObject<TeamInformationJSONData>(downloadedData);

                teamName = Convert.ToString(deserializedData.nickname);
                teamNumber = Convert.ToInt32(deserializedData.team_number);
                teamLocation = Convert.ToString(deserializedData.location);
                rookieYear = Convert.ToInt32(deserializedData.rookie_year);
                teamURL = Convert.ToString(deserializedData.website);
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);
            teamURLDisplay.Text = teamURL;

            object teamImage = Resources.ResourceManager.GetObject("FRC" + teamNumber);
            teamLogoPictureBox.Image = (Image) teamImage;

            Settings.Default.selectedTeamName = teamNameArray[teamSelector.SelectedIndex];
            Settings.Default.selectedTeamNumber = teamNumber;
            Settings.Default.Save();
        }

        private void teamURLDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 3000;
                return w;
            }
        }

        public class TeamInformationJSONData
        {
            public string country_name { get; set; }
            public string locality { get; set; }
            public string location { get; set; }
            public string name { get; set; }
            public string nickname { get; set; }
            public string region { get; set; }
            public int rookie_year { get; set; }
            public int team_number { get; set; }
            public string website { get; set; }
        }
    }
}