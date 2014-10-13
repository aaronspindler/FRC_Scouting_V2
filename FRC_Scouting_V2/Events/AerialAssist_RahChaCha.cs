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
        private readonly double[] AutoHighGoalTotal = new double[2];
        private readonly double[] AutoHighMissTotal = new double[2];
        private readonly double[] AutoLowGoalTotal = new double[2];
        private readonly double[] AutoLowMissTotal = new double[2];
        private readonly double[] AutoPickup = new double[2];
        private readonly double[] AutoPickupMiss = new double[2];
        private readonly double[] ControlledHighGoalTotal = new double[2];
        private readonly double[] ControlledHighMissTotal = new double[2];
        private readonly double[] ControlledLowGoalTotal = new double[2];
        private readonly double[] ControlledLowMissTotal = new double[2];
        private readonly double[] ControlledPickup = new double[2];
        private readonly double[] ControlledPickupMiss = new double[2];
        private readonly double[] HotGoalTotal = new double[2];
        private readonly double[] HotMissTotal = new double[2];
        private readonly double[] MissedPassToAnotherRobot = new double[2];
        private readonly double[] MissedPickupFromHuman = new double[2];
        private readonly double[] PassToAnotherRobot = new double[2];
        private readonly double[] PickupFromHuman = new double[2];
        private readonly double[] RobotDied = new double[2];
        private readonly double[] RobotSurvived = new double[2];
        private readonly double[] SuccessfulTruss = new double[2];
        private readonly double[] TripleGoal = new double[2];
        private readonly double[] TripleMiss = new double[2];
        private readonly double[] UnSuccessfulTruss = new double[2];
        private readonly int[] NumberOfMatches = new int[2];
        double[] TotalPoints = new double[2];

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

        public void UpdateTeamComparison1()
        {
            NumberOfMatches[0] = 0;
            AutoHighGoalTotal[0] = 0;
            AutoHighMissTotal[0] = 0;
            AutoLowGoalTotal[0] = 0;
            AutoLowMissTotal[0] = 0;
            ControlledHighGoalTotal[0] = 0;
            ControlledHighMissTotal[0] = 0;
            ControlledLowGoalTotal[0] = 0;
            ControlledLowMissTotal[0] = 0;
            HotGoalTotal[0] = 0;
            HotMissTotal[0] = 0;
            TripleGoal[0] = 0;
            TripleMiss[0] = 0;
            AutoPickup[0] = 0;
            AutoPickupMiss[0] = 0;
            ControlledPickup[0] = 0;
            ControlledPickupMiss[0] = 0;
            PickupFromHuman[0] = 0;
            MissedPickupFromHuman[0] = 0;
            PassToAnotherRobot[0] = 0;
            MissedPassToAnotherRobot[0] = 0;
            SuccessfulTruss[0] = 0;
            UnSuccessfulTruss[0] = 0;
            RobotSurvived[0] = 0;
            RobotDied[0] = 0;
            try
            {
                string mySqlConnectionString = us.MakeMySqlConnectionString();
                var conn = new MySqlConnection(mySqlConnectionString);
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = String.Format("SELECT * from {0} where TeamNumber={1}",
                    Settings.Default.currentTableName, selectedTeam1);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NumberOfMatches[0] ++;
                    AutoHighGoalTotal[0] = AutoHighGoalTotal[0] + Convert.ToDouble(reader["AutoHighGoal"]);
                    AutoHighMissTotal[0] = AutoHighMissTotal[0] + Convert.ToDouble(reader["AutoHighMiss"]);
                    AutoLowGoalTotal[0] = AutoLowGoalTotal[0] + Convert.ToDouble(reader["AutoLowGoal"]);
                    AutoLowMissTotal[0] = AutoLowMissTotal[0] + Convert.ToDouble(reader["AutoLowMiss"]);
                    ControlledHighGoalTotal[0] = ControlledHighGoalTotal[0] +
                                                 Convert.ToDouble(reader["ControlledHighGoal"]);
                    ControlledHighMissTotal[0] = ControlledHighMissTotal[0] +
                                                 Convert.ToDouble(reader["ControlledHighMiss"]);
                    ControlledLowGoalTotal[0] = ControlledLowGoalTotal[0] +
                                                Convert.ToDouble(reader["ControlledLowGoal"]);
                    ControlledLowMissTotal[0] = ControlledLowMissTotal[0] +
                                                Convert.ToDouble(reader["ControlledLowMiss"]);
                    HotGoalTotal[0] = HotGoalTotal[0] + Convert.ToDouble(reader["HotGoals"]);
                    HotMissTotal[0] = HotMissTotal[0] + Convert.ToDouble(reader["HotGoalMiss"]);
                    TripleGoal[0] = TripleGoal[0] + Convert.ToDouble(reader["3AssistGoal"]);
                    TripleMiss[0] = TripleMiss[0] + Convert.ToDouble(reader["3AssistMiss"]);
                    AutoPickup[0] = AutoPickup[0] + Convert.ToDouble(reader["AutoBallPickup"]);
                    AutoPickupMiss[0] = AutoPickupMiss[0] + Convert.ToDouble(reader["AutoBallPickupMiss"]);
                    ControlledPickup[0] = ControlledPickup[0] + Convert.ToDouble(reader["ControlledBallPickup"]);
                    ControlledPickupMiss[0] = ControlledPickupMiss[0] +
                                              Convert.ToDouble(reader["ControlledBallPickupMiss"]);
                    PickupFromHuman[0] = PickupFromHuman[0] + Convert.ToDouble(reader["PickupFromHuman"]);
                    MissedPickupFromHuman[0] = MissedPickupFromHuman[0] +
                                               Convert.ToDouble(reader["MissedPickupFromHuman"]);
                    PassToAnotherRobot[0] = PassToAnotherRobot[0] + Convert.ToDouble(reader["PassToAnotherRobot"]);
                    MissedPassToAnotherRobot[0] = MissedPassToAnotherRobot[0] +
                                                  Convert.ToDouble(reader["MissedPassToAnotherRobot"]);
                    SuccessfulTruss[0] = SuccessfulTruss[0] + Convert.ToDouble(reader["SuccessfulTruss"]);
                    UnSuccessfulTruss[0] = UnSuccessfulTruss[0] + Convert.ToDouble(reader["UnsuccessfulTruss"]);
                    switch (Convert.ToInt32(reader["DidRobotDie"]))
                    {
                        case 0:
                            RobotSurvived[0] = RobotSurvived[0] + 1;
                            break;

                        case 1:
                            RobotDied[0] = RobotDied[0] + 1;
                            break;
                    }
                }
                reader.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Message);
            }
            TotalPoints[0] = (((AutoHighGoalTotal[0] + AutoLowGoalTotal[0])*AUTO_ADDITIONAL_POINTS_VALUE) + (AutoLowGoalTotal[0] * LOW_GOAL_VALUE) + (AutoHighGoalTotal[0] * HIGH_GOAL_VALUE) + (SuccessfulTruss[0] * TRUSS_VALUE) + (TripleGoal[0] * TRIPLE_ASSIST_GOAL_VALUE));
            TotalPointsMean[0] = TotalPoints[0] / NumberOfMatches[0];
            AutoHighGoalSuccessRate[0] = AutoHighGoalTotal[0]/(AutoHighGoalTotal[0] + AutoHighMissTotal[0]);
            AutolowGoalSuccessRate[0] = AutoLowGoalTotal[0] / (AutoLowGoalTotal[0] + AutoLowMissTotal[0]);
            DisplayDataTeam1();
        }

        public void GetDataForTeam(int teamNumber, int selection)
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
        }

        public void UpdateTeamComparison2()
        {
            NumberOfMatches[1] = 0;
            AutoHighGoalTotal[1] = 0;
            AutoHighMissTotal[1] = 0;
            AutoLowGoalTotal[1] = 0;
            AutoLowMissTotal[1] = 0;
            ControlledHighGoalTotal[1] = 0;
            ControlledHighMissTotal[1] = 0;
            ControlledLowGoalTotal[1] = 0;
            ControlledLowMissTotal[1] = 0;
            HotGoalTotal[1] = 0;
            HotMissTotal[1] = 0;
            TripleGoal[1] = 0;
            TripleMiss[1] = 0;
            AutoPickup[1] = 0;
            AutoPickupMiss[1] = 0;
            ControlledPickup[1] = 0;
            ControlledPickupMiss[1] = 0;
            PickupFromHuman[1] = 0;
            MissedPickupFromHuman[1] = 0;
            PassToAnotherRobot[1] = 0;
            MissedPassToAnotherRobot[1] = 0;
            SuccessfulTruss[1] = 0;
            UnSuccessfulTruss[1] = 0;
            RobotSurvived[1] = 0;
            RobotDied[1] = 0;
            try
            {
                string mySqlConnectionString = us.MakeMySqlConnectionString();
                var conn = new MySqlConnection(mySqlConnectionString);
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = String.Format("SELECT * from {0} where TeamNumber={1}",
                    Settings.Default.currentTableName, selectedTeam2);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NumberOfMatches[1]++;
                    AutoHighGoalTotal[1] = AutoHighGoalTotal[1] + Convert.ToDouble(reader["AutoHighGoal"]);
                    AutoHighMissTotal[1] = AutoHighMissTotal[1] + Convert.ToDouble(reader["AutoHighMiss"]);
                    AutoLowGoalTotal[1] = AutoLowGoalTotal[1] + Convert.ToDouble(reader["AutoLowGoal"]);
                    AutoLowMissTotal[1] = AutoLowMissTotal[1] + Convert.ToDouble(reader["AutoLowMiss"]);
                    ControlledHighGoalTotal[1] = ControlledHighGoalTotal[1] +
                                                 Convert.ToDouble(reader["ControlledHighGoal"]);
                    ControlledHighMissTotal[1] = ControlledHighMissTotal[1] +
                                                 Convert.ToDouble(reader["ControlledHighMiss"]);
                    ControlledLowGoalTotal[1] = ControlledLowGoalTotal[1] +
                                                Convert.ToDouble(reader["ControlledLowGoal"]);
                    ControlledLowMissTotal[1] = ControlledLowMissTotal[1] +
                                                Convert.ToDouble(reader["ControlledLowMiss"]);
                    HotGoalTotal[1] = HotGoalTotal[1] + Convert.ToDouble(reader["HotGoals"]);
                    HotMissTotal[1] = HotMissTotal[1] + Convert.ToDouble(reader["HotGoalMiss"]);
                    TripleGoal[1] = TripleGoal[1] + Convert.ToDouble(reader["3AssistGoal"]);
                    TripleMiss[1] = TripleMiss[1] + Convert.ToDouble(reader["3AssistMiss"]);
                    AutoPickup[1] = AutoPickup[1] + Convert.ToDouble(reader["AutoBallPickup"]);
                    AutoPickupMiss[1] = AutoPickupMiss[1] + Convert.ToDouble(reader["AutoBallPickupMiss"]);
                    ControlledPickup[1] = ControlledPickup[1] + Convert.ToDouble(reader["ControlledBallPickup"]);
                    ControlledPickupMiss[1] = ControlledPickupMiss[1] +
                                              Convert.ToDouble(reader["ControlledBallPickupMiss"]);
                    PickupFromHuman[1] = PickupFromHuman[1] + Convert.ToDouble(reader["PickupFromHuman"]);
                    MissedPickupFromHuman[1] = MissedPickupFromHuman[1] +
                                               Convert.ToDouble(reader["MissedPickupFromHuman"]);
                    PassToAnotherRobot[1] = PassToAnotherRobot[1] + Convert.ToDouble(reader["PassToAnotherRobot"]);
                    MissedPassToAnotherRobot[1] = MissedPassToAnotherRobot[1] +
                                                  Convert.ToDouble(reader["MissedPassToAnotherRobot"]);
                    SuccessfulTruss[1] = SuccessfulTruss[1] + Convert.ToDouble(reader["SuccessfulTruss"]);
                    UnSuccessfulTruss[1] = UnSuccessfulTruss[1] + Convert.ToDouble(reader["UnsuccessfulTruss"]);
                    switch (Convert.ToInt32(reader["DidRobotDie"]))
                    {
                        case 0:
                            RobotSurvived[1] = RobotSurvived[1] + 1;
                            break;

                        case 1:
                            RobotDied[1] = RobotDied[1] + 1;
                            break;
                    }
                }
                reader.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Message);
            }
            TotalPointsMean[1] = TotalPoints[1]/NumberOfMatches[1];
            AutoHighGoalSuccessRate[1] = AutoHighGoalTotal[1] / (AutoHighGoalTotal[1] + AutoHighMissTotal[1]);
            AutolowGoalSuccessRate[1] = AutoLowGoalTotal[1] / (AutoLowGoalTotal[1] + AutoLowMissTotal[1]);
            DisplayDataTeam2();
        }

        public void DisplayDataTeam1()
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

        public void DisplayDataTeam2()
        {
            dataGridViewTeam2.Rows.Clear();
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
            UpdateTeamComparison1();
            ColourStats();
        }

        private void teamCompSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam2 = teamNumberArray[teamCompSelector2.SelectedIndex];
            ClearColourStats();
            team2Selected = true;
            UpdateTeamComparison2();
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