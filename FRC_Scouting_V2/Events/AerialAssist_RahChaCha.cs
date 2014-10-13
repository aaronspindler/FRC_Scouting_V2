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
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
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

        //TeamComparison Variables

        //Ratios and Statistics
        private double[] TotalPointsMean = new double[2];
        private double[] TotalPointsSD = new double[2];
        private double[] AutoHighMean = new double[2];
        private double[] AutoHighSD = new double[2];
        private readonly double[] AutoHighGoalSuccessRate = new double[2];
        private double[] AutoLowMean = new double[2];
        private double[] AutoLowSD = new double[2];
        private readonly double[] AutolowGoalSuccessRate = new double[2];

        //Point Values for Scoring
        private const int HIGH_GOAL_VALUE = 10;
        private const int LOW_GOAL_VALUE = 1;
        private const int BALL_CATCH_VALUE = 10;
        private const int TRUSS_VALUE = 10;
        private const int TRIPLE_ASSIST_GOAL_VALUE = 30;
        private const int AUTO_MOBILITY_VALUE = 5;
        private const int AUTO_ADDITIONAL_POINTS_VALUE = 5;



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
        private Boolean team1Selected;
        private Boolean team2Selected;
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
            int numberOfFilesImported = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string t in openFileDialog.FileNames)
                {
                    numberOfFilesImported++;
                    var reader = new StreamReader(t);
                    //Bypassing the human readable variables to get to the computer readable portion of the text file
                    for (int i = 0; i < 30; i++)
                    {
                        reader.ReadLine();
                    }
                    int teamNumberImport = Convert.ToInt32(reader.ReadLine());
                    string teamNameImport = reader.ReadLine();
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
                    bool didTheRobotDie = Convert.ToBoolean(reader.ReadLine());
                    int driverRating = Convert.ToInt16(reader.ReadLine());
                    Boolean autoMovement = Convert.ToBoolean(reader.ReadLine());
                    string comments = Convert.ToString(reader.ReadLine());
                    string testIfFileIsGood = reader.ReadLine();
                    if (testIfFileIsGood.Equals("END OF FILE"))
                    {
                        var conn = new MySqlConnection(us.MakeMySqlConnectionString());
                        var cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText =
                            String.Format(
                                "Insert into {0} (EntryID,TeamNumber,TeamName,TeamColour,MatchNumber,AutoHighGoal,AutoHighMiss, AutoLowGoal, AutoLowMiss, ControlledHighGoal, ControlledHighMiss, ControlledLowGoal, ControlledLowMiss, HotGoals, HotGoalMiss, 3AssistGoal, 3AssistMiss, AutoBallPickup, AutoBallPickupMiss, ControlledBallPickup, ControlledBallPickupMiss, PickupFromHuman, MissedPickupFromHuman, PassToAnotherRobot, MissedPassToAnotherRobot, SuccessfulTruss, UnsuccessfulTruss, StartingX, StartingY, DidRobotDie,DriverRating , AutoMovement, Comments) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}');",
                                Settings.Default.currentTableName, (us.GetNumberOfRowsInATable() + 1),
                                teamNumberImport, teamNameImport, teamColour,
                                matchNumber,
                                autoHighGoal, autoHighMiss, autoLowGoal, autoLowMiss, controlledHighGoal,
                                controlledHighMiss,
                                controlledLowGoal, controlledLowMiss, hotGoal, missedHotGoal, tripleGoal, tripleMiss,
                                autoBallPickup, autoBallPickupMiss, controlledPickup, controlledPickupMiss,
                                pickupFromHuman, missedPickupFromHuman, passToOtherBot, missedPassToOtherBot,
                                successfulTruss,
                                unsuccessfulTruss, startingX, startingY, Convert.ToInt32(didTheRobotDie), driverRating,
                                Convert.ToInt32(autoMovement), comments);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
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
            us.ShowInformationMessage("Successfully imported: " + numberOfFilesImported + " File(s) Into the Database.");

        }

        public void GetDataForTeam(int teamNumberLocal, int selection)
        {
            List<int> AutoHighGoal = new List<int>();
            List<int> AutoHighMiss = new List<int>();
            List<int> AutoLowGoal = new List<int>();
            List<int> AutoLowMiss = new List<int>();
            List<int> ControlledHighGoal = new List<int>();
            List<int> ControlledHighMiss = new List<int>();
            List<int> ControlledLowGoal = new List<int>();
            List<int> ControlledLowMiss = new List<int>();
            List<int> HotGoal = new List<int>();
            List<int> HotMiss = new List<int>();
            List<int> TripleAssistGoal = new List<int>();
            List<int> TripleAssistMiss = new List<int>();
            List<int> AutoPickup = new List<int>();
            List<int> AutoPickupMiss = new List<int>();
            List<int> ControlledPickup = new List<int>();
            List<int> ControlledPickupMiss = new List<int>();
            List<int> PickupFromHuman = new List<int>();
            List<int> MissedPickupFromHuman = new List<int>();
            List<int> PassToAnotherRobot = new List<int>();
            List<int> MissedPassToAnotherRobot = new List<int>();
            List<int> SuccessfulTruss = new List<int>();
            List<int> UnSuccessfulTruss = new List<int>();
            List<int> DriverRating = new List<int>();
            List<int> RobotDied = new List<int>();
            List<int> AutoMovement = new List<int>();

            try
            {
                MySqlConnection conn = new MySqlConnection(us.MakeMySqlConnectionString());
                MySqlCommand cmd = conn.CreateCommand();
                MySqlDataReader reader;
                cmd.CommandText = String.Format("SELECT (*) From{0} where TeamNumber={1}",FRC_Scouting_V2.Properties.Settings.Default.currentTableName, teamNumberLocal);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.Message);
            }

            if (selection == 1)
            {
                dataGridViewTeam1.Rows.Clear();
                //Data Name, Mean, Standard Deviation, Successrate
                dataGridViewTeam1.Rows.Add("Total Points", TotalPointsMean[0].ToString("#.##"), "", "N/A");
                dataGridViewTeam1.Rows.Add("Autonomous High", "", "", AutoHighGoalSuccessRate[0].ToString("P"));
                dataGridViewTeam1.Rows.Add("Autonomous Low", "", "", AutolowGoalSuccessRate[0].ToString("P"));
                dataGridViewTeam1.Rows.Add("Autonomous Mobility", "", "", "N/A");
                dataGridViewTeam1.Rows.Add("Driver Rating", "", "", "N/A");
                dataGridViewTeam1.Rows.Add("Controlled High", "", "", "");
                dataGridViewTeam1.Rows.Add("Controlled Low", "", "", "");
                dataGridViewTeam1.Rows.Add("Hot Goal", "", "", "");
                dataGridViewTeam1.Rows.Add("Pickups", "", "", "");
                dataGridViewTeam1.Rows.Add("Truss", "", "", "");
                dataGridViewTeam1.Rows.Add("Survivability", "", "", "");
            }
            else
            {
                if (selection == 2)
                {
                    dataGridViewTeam2.Rows.Clear();
                    //Data Name, Mean, Standard Deviation, Successrate
                    dataGridViewTeam2.Rows.Add("Total Points", "", "", "N/A");
                    dataGridViewTeam2.Rows.Add("Autonomous High", "", "", AutoHighGoalSuccessRate[1].ToString("P"));
                    dataGridViewTeam2.Rows.Add("Autonomous Low", "", "", AutolowGoalSuccessRate[1].ToString("P"));
                    dataGridViewTeam2.Rows.Add("Autonomous Mobility", "", "", "N/A");
                    dataGridViewTeam2.Rows.Add("Driver Rating", "", "", "N/A");
                    dataGridViewTeam2.Rows.Add("Controlled High", "", "", "");
                    dataGridViewTeam2.Rows.Add("Controlled Low", "", "", "");
                    dataGridViewTeam2.Rows.Add("Hot Goal", "", "", "");
                    dataGridViewTeam2.Rows.Add("Pickups", "", "", "");
                    dataGridViewTeam2.Rows.Add("Truss", "", "", "");
                    dataGridViewTeam2.Rows.Add("Survivability", "", "", "");
                }
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
            us.ShowInformationMessage("Your data has been successfully exported to CSV.");
        }

        private void howComeICannotSeeAnyTeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage(
                "The team information is pulled from TheBluAlliance's API, this means that you need to have an internet connection to get the data.");
        }

        private void teamCompSelector1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam1 = teamNumberArray[teamCompSelector1.SelectedIndex];
            ClearColourStats();
            team1Selected = true;
            GetDataForTeam(selectedTeam1, 1);
            ColourStats();
        }

        private void teamCompSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam2 = teamNumberArray[teamCompSelector2.SelectedIndex];
            ClearColourStats();
            team2Selected = true;
            GetDataForTeam(selectedTeam2, 2);
            ColourStats();
        }

        public void ColourStats()
        {
            if (Settings.Default.colourTeamComparisonStatistics)
            {
            }
        }

        public void ClearColourStats()
        {
            for (int i = 0; i < dataGridViewTeam1.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewTeam1.ColumnCount; j++)
                {
                    if (team1Selected)
                    {
                        dataGridViewTeam1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                    if (team2Selected)
                    {
                        dataGridViewTeam2.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
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
                w.Timeout = 4000;
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