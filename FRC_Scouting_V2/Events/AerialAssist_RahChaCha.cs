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
using System.Linq;
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

        private const int HIGH_GOAL_VALUE = 10;
        private const int LOW_GOAL_VALUE = 1;
        private const int BALL_CATCH_VALUE = 10;
        private const int TRUSS_VALUE = 10;
        private const int TRIPLE_ASSIST_GOAL_VALUE = 30;
        private const int AUTO_MOBILITY_VALUE = 5;
        private const int AUTO_ADDITIONAL_POINTS_VALUE = 5;
        private const int HOT_GOT_POINTS_VALUE = 5;

        private readonly double[] _autoHighGoalSuccessRate = new double[2];
        private readonly double[] _autoHighMean = new double[2];
        private readonly double[] _autoHighStandardDeviation = new double[2];
        private readonly double[] _autoLowMean = new double[2];
        private readonly double[] _autoLowStandardDeviation = new double[2];
        private readonly double[] _autoMobilitySuccessRate = new double[2];
        private readonly double[] _autolowGoalSuccessRate = new double[2];
        private readonly double[] _controlledHighMean = new double[2];
        private readonly double[] _controlledHighStandardDeviation = new double[2];
        private readonly double[] _controlledHighSuccessRate = new double[2];
        private readonly double[] _controlledLowMean = new double[2];
        private readonly double[] _controlledLowStandardDeviation = new double[2];
        private readonly double[] _controlledLowSuccessRate = new double[2];
        private readonly double[] _driverRatingMean = new double[2];
        private readonly double[] _driverRatingStandardDeviation = new double[2];
        private readonly double[] _hotGoalMean = new double[2];
        private readonly double[] _hotGoalStandardDeviation = new double[2];
        private readonly double[] _hotGoalSuccessRate = new double[2];
        private readonly double[] _pickupStandardDeviation = new double[2];
        private readonly double[] _pickupSuccessRate = new double[2];
        private readonly double[] _pickupsMean = new double[2];
        private readonly double[] _successfulTrussMean = new double[2];
        private readonly double[] _survivability = new double[2];

        private readonly string[] _teamNameArray =
        {
            "The Rocketeers", "Arctic Warriors", "X-CATS",
            "Greater Rochester Robotics", "Circuit Stompers", "Red Raider Robotics", "The Coyotes",
            "Code Red Robotics", "Warp7", "Simbotics", "SparX", "Theory6", "TheBigBang", "Red Devil Robotics",
            "Finney Robotics", "Warlocks", "Rolling Thunder", "Raider Robotics", "Grapes of Wrath", "DevilTech",
            "Scitobor Robotics", "CougarTech", "XcentricsRobotics", "DM High Voltage", "The Astechz", "Tan[x]",
            "Ranger Robotics", "Eastridge Robotics", "IgKnighters", "Pittsford Panthers", "CyberFalcons", "S.U.I.T.S.",
            "Retro Rams", "MakeShift", "MaxTech", "W.A.F.F.L.E.S.", "VP Robotics", "Electric Mayhem", "Robot Raiders"
        };

        private readonly int[] _teamNumberArray =
        {
            20, 174, 191, 340, 378, 578, 610, 639, 865, 1114, 1126, 1241, 1285,
            1334, 1405, 1507, 1511, 1518, 1551, 1559, 1585, 2228, 2340, 2852, 2994, 3003, 3015, 3157, 3173, 3181, 3710,
            3951, 4001, 4039, 4343, 4476, 4914, 4930, 5254
        };

        private readonly double[] _trussStandardDeviation = new double[2];
        private readonly double[] _trussSuccessRate = new double[2];
        private readonly List<int> matchSummaryAutoBallPickup = new List<int>();
        private readonly List<int> matchSummaryAutoBallPickupMiss = new List<int>();

        private readonly List<int> matchSummaryAutoHighGoal = new List<int>();
        private readonly List<int> matchSummaryAutoHighMiss = new List<int>();
        private readonly List<int> matchSummaryAutoLowGoal = new List<int>();
        private readonly List<int> matchSummaryAutoLowMiss = new List<int>();
        private readonly List<int> matchSummaryAutoMovement = new List<int>();
        private readonly List<string> matchSummaryComments = new List<string>();
        private readonly List<int> matchSummaryControlledBallPickup = new List<int>();
        private readonly List<int> matchSummaryControlledBallPickupMiss = new List<int>();
        private readonly List<int> matchSummaryControlledHighGoal = new List<int>();
        private readonly List<int> matchSummaryControlledHighMiss = new List<int>();
        private readonly List<int> matchSummaryControlledLowGoal = new List<int>();
        private readonly List<int> matchSummaryControlledLowMiss = new List<int>();
        private readonly List<int> matchSummaryDidRobotDie = new List<int>();
        private readonly List<int> matchSummaryDriverRating = new List<int>();
        private readonly List<int> matchSummaryEntryID = new List<int>();
        private readonly List<int> matchSummaryHotGoals = new List<int>();
        private readonly List<int> matchSummaryHotMisses = new List<int>();
        private readonly List<int> matchSummaryMatchNumber = new List<int>();
        private readonly List<int> matchSummaryPassToAnotherRobot = new List<int>();
        private readonly List<int> matchSummaryPassToAnotherRobotMiss = new List<int>();
        private readonly List<int> matchSummaryPickupFromHuman = new List<int>();
        private readonly List<int> matchSummaryPickupFromHumanMiss = new List<int>();
        private readonly List<int> matchSummaryStartingX = new List<int>();
        private readonly List<int> matchSummaryStartingY = new List<int>();
        private readonly List<int> matchSummarySuccessfulTruss = new List<int>();
        private readonly List<string> matchSummaryTeamColour = new List<string>();
        private readonly List<string> matchSummaryTeamName = new List<string>();
        private readonly List<int> matchSummaryTeamNumber = new List<int>();
        private readonly List<int> matchSummaryTripleAssistGoal = new List<int>();
        private readonly List<int> matchSummaryTripleAssistMiss = new List<int>();
        private readonly List<int> matchSummaryUnSuccessfulTruss = new List<int>();
        private readonly List<int> matchSummaryX = new List<int>();
        private readonly List<int> matchSummaryY = new List<int>();
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

        //From (http://www.developer.com/net/article.php/3794146/Adding-Standard-Deviation-to-LINQ.htm)
        //Update - Mildly updated this method so it is no longer the same as what is on the website above
        private double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            double[] enumerable = values as double[] ?? values.ToArray();
            if (!enumerable.Any()) return ret;
            //Compute the Average
            double avg = enumerable.Average();

            //Perform the Sum of (value-avg)^2
            double sum = enumerable.Sum(d => Math.Pow(d - avg, 2));

            //Put it all together
            ret = Math.Sqrt((sum)/enumerable.Count() - 1);
            return ret;
        }

        public void GetDataForTeam(int teamNumberLocal, int selection)
        {
            int numberOfMatches = 0;
            var AutoHighGoal = new List<double>();
            var AutoHighMiss = new List<double>();
            var AutoLowGoal = new List<double>();
            var AutoLowMiss = new List<double>();
            var ControlledHighGoal = new List<double>();
            var ControlledHighMiss = new List<double>();
            var ControlledLowGoal = new List<double>();
            var ControlledLowMiss = new List<double>();
            var HotGoal = new List<double>();
            var HotMiss = new List<double>();
            var TripleAssistGoal = new List<double>();
            var TripleAssistMiss = new List<double>();
            var AutoPickup = new List<double>();
            var AutoPickupMiss = new List<double>();
            var ControlledPickup = new List<double>();
            var ControlledPickupMiss = new List<double>();
            var PickupFromHuman = new List<double>();
            var MissedPickupFromHuman = new List<double>();
            var PassToAnotherRobot = new List<double>();
            var MissedPassToAnotherRobot = new List<double>();
            var SuccessfulTruss = new List<double>();
            var UnSuccessfulTruss = new List<double>();
            var DriverRating = new List<double>();
            var RobotDied = new List<double>();
            var AutoMovementGood = new List<double>();
            var StartingX = new List<double>();
            var StartingY = new List<double>();

            try
            {
                var conn = new MySqlConnection(us.MakeMySqlConnectionString());
                MySqlCommand cmd = conn.CreateCommand();
                MySqlDataReader reader;
                cmd.CommandText = String.Format("SELECT * From {0} where TeamNumber={1}",
                    Settings.Default.currentTableName, teamNumberLocal);
                conn.Open();
                if (conn.Ping())
                {
                    Console.WriteLine("Connected to the databse. Collecting and generating statistics now!");
                }
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    numberOfMatches++;
                    AutoHighGoal.Add(Convert.ToDouble(reader["AutoHighGoal"]));
                    AutoHighMiss.Add(Convert.ToDouble(reader["AutoHighMiss"]));
                    AutoLowGoal.Add(Convert.ToDouble(reader["AutoLowGoal"]));
                    AutoLowMiss.Add(Convert.ToDouble(reader["AutoLowMiss"]));
                    ControlledHighGoal.Add(Convert.ToDouble(reader["ControlledHighGoal"]));
                    ControlledHighMiss.Add(Convert.ToDouble(reader["ControlledHighMiss"]));
                    ControlledLowGoal.Add(Convert.ToDouble(reader["ControlledLowGoal"]));
                    ControlledLowMiss.Add(Convert.ToDouble(reader["ControlledLowMiss"]));
                    HotGoal.Add(Convert.ToDouble(reader["HotGoals"]));
                    HotMiss.Add(Convert.ToDouble(reader["HotGoalMiss"]));
                    TripleAssistGoal.Add(Convert.ToDouble(reader["3AssistGoal"]));
                    TripleAssistMiss.Add(Convert.ToDouble(reader["3AssistMiss"]));
                    AutoPickup.Add(Convert.ToDouble(reader["AutoBallPickup"]));
                    AutoPickupMiss.Add(Convert.ToDouble(reader["AutoBallPickupMiss"]));
                    ControlledPickup.Add(Convert.ToDouble(reader["ControlledBallPickup"]));
                    ControlledPickupMiss.Add(Convert.ToDouble(reader["ControlledBallPickupMiss"]));
                    PickupFromHuman.Add(Convert.ToDouble(reader["PickupFromHuman"]));
                    MissedPickupFromHuman.Add(Convert.ToDouble(reader["MissedPickupFromHuman"]));
                    PassToAnotherRobot.Add(Convert.ToDouble(reader["PassToAnotherRobot"]));
                    MissedPassToAnotherRobot.Add(Convert.ToDouble(reader["MissedPassToAnotherRobot"]));
                    SuccessfulTruss.Add(Convert.ToDouble(reader["SuccessfulTruss"]));
                    UnSuccessfulTruss.Add(Convert.ToDouble(reader["UnsuccessfulTruss"]));
                    DriverRating.Add(Convert.ToDouble(reader["DriverRating"]));
                    if (Convert.ToInt32(reader["DidRobotDie"]) == 1)
                    {
                        RobotDied.Add(1);
                    }

                    if (Convert.ToInt32(reader["AutoMovement"].ToString()) == 1)
                    {
                        AutoMovementGood.Add(Convert.ToDouble(reader["AutoMovement"]));
                    }
                    StartingX.Add(Convert.ToDouble(reader["StartingX"]));
                    StartingY.Add(Convert.ToDouble(reader["StartingY"]));
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.Message);
                us.ErrorOccured("Looks like something went wrong. Check console for the error message");
            }

            if (selection == 1)
            {
                try
                {
                    _autoHighMean[0] = AutoHighGoal.Average();
                    _autoHighStandardDeviation[0] = CalculateStdDev(AutoHighGoal);
                    _autoHighGoalSuccessRate[0] = AutoHighGoal.Sum()/(AutoHighGoal.Sum() + AutoHighMiss.Sum());
                    _autoLowMean[0] = AutoLowGoal.Average();
                    _autoLowStandardDeviation[0] = CalculateStdDev(AutoLowGoal);
                    _autolowGoalSuccessRate[0] = AutoLowGoal.Sum()/(AutoLowGoal.Sum() + AutoLowMiss.Sum());
                    _autoMobilitySuccessRate[0] = AutoMovementGood.Sum()/(numberOfMatches);
                    _driverRatingMean[0] = DriverRating.Average();
                    _driverRatingStandardDeviation[0] = CalculateStdDev(DriverRating);
                    _controlledHighMean[0] = ControlledHighGoal.Average();
                    _controlledHighStandardDeviation[0] = CalculateStdDev(ControlledHighGoal);
                    _controlledHighSuccessRate[0] = ControlledHighGoal.Sum()/
                                                    (ControlledHighGoal.Sum() + ControlledHighMiss.Sum());
                    _controlledLowMean[0] = ControlledLowGoal.Average();
                    _controlledLowStandardDeviation[0] = CalculateStdDev(ControlledLowGoal);
                    _controlledLowSuccessRate[0] = ControlledLowGoal.Sum()/
                                                   (ControlledLowGoal.Sum() + ControlledLowMiss.Sum());
                    _hotGoalMean[0] = HotGoal.Average();
                    _hotGoalStandardDeviation[0] = CalculateStdDev(HotGoal);
                    _hotGoalSuccessRate[0] = HotGoal.Sum()/(HotGoal.Sum() + HotMiss.Sum());
                    _pickupsMean[0] = (AutoPickup.Average()) + (ControlledPickup.Average()) +
                                      (PickupFromHuman.Average());
                    _pickupStandardDeviation[0] = CalculateStdDev(ControlledPickup);
                    _pickupSuccessRate[0] = (AutoPickup.Sum() + ControlledPickup.Sum() + PickupFromHuman.Sum())/
                                            (AutoPickup.Sum() + ControlledPickup.Sum() + PickupFromHuman.Sum() +
                                             AutoPickupMiss.Sum() + ControlledPickupMiss.Sum() +
                                             MissedPickupFromHuman.Sum());
                    _successfulTrussMean[0] = SuccessfulTruss.Average();
                    _trussStandardDeviation[0] = CalculateStdDev(SuccessfulTruss);
                    _trussSuccessRate[0] = SuccessfulTruss.Sum()/(SuccessfulTruss.Sum() + UnSuccessfulTruss.Sum());
                    _survivability[0] = numberOfMatches/(numberOfMatches + RobotDied.Sum());

                    dataGridViewTeam1.Rows.Clear();

                    //Data Name, Mean, Standard Deviation, Successrate
                    dataGridViewTeam1.Rows.Add("Autonomous High", _autoHighMean[0].ToString("#.##"),
                        _autoHighStandardDeviation[0].ToString("#.##"), _autoHighGoalSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Autonomous Low", _autoLowMean[0].ToString("#.##"),
                        _autoLowStandardDeviation[0].ToString("#.##"), _autolowGoalSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Autonomous Mobility", "N/A", "N/A",
                        _autoMobilitySuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Driver Rating", _driverRatingMean[0].ToString("#.##"),
                        _driverRatingStandardDeviation[0].ToString("#.##"), "N/A");
                    dataGridViewTeam1.Rows.Add("Controlled High", _controlledHighMean[0].ToString("#.##"),
                        _controlledHighStandardDeviation[0].ToString("#.##"),
                        _controlledHighSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Controlled Low", _controlledLowMean[0].ToString("#.##"),
                        _controlledLowStandardDeviation[0].ToString("#.##"), _controlledLowSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Hot Goal", _hotGoalMean[0].ToString("#.##"),
                        _hotGoalStandardDeviation[0].ToString("#.##"), _hotGoalSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Pickups", _pickupsMean[0].ToString("#.##"),
                        _pickupStandardDeviation[0].ToString("#.##"), _pickupSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Truss", _successfulTrussMean[0].ToString("#.##"),
                        _trussStandardDeviation[0].ToString("#.##"), _trussSuccessRate[0].ToString("P"));
                    dataGridViewTeam1.Rows.Add("Survivability", "N/A", "N/A", _survivability[0].ToString("P"));
                }
                catch (Exception e)
                {
                    dataGridViewTeam1.Rows.Clear();
                    team1Selected = false;
                    us.ErrorOccured("Looks like something went wrong. Check console for the error message");
                    Console.WriteLine("Error Message: " + e.Message);
                }
            }
            else
            {
                if (selection == 2)
                {
                    try
                    {
                        _autoHighMean[1] = AutoHighGoal.Average();
                        _autoHighStandardDeviation[1] = CalculateStdDev(AutoHighGoal);
                        _autoHighGoalSuccessRate[1] = AutoHighGoal.Sum()/(AutoHighGoal.Sum() + AutoHighMiss.Sum());
                        _autoLowMean[1] = AutoLowGoal.Average();
                        _autoLowStandardDeviation[1] = CalculateStdDev(AutoLowGoal);
                        _autolowGoalSuccessRate[1] = AutoLowGoal.Sum()/(AutoLowGoal.Sum() + AutoLowMiss.Sum());
                        _autoMobilitySuccessRate[1] = AutoMovementGood.Sum()/(numberOfMatches);
                        _driverRatingMean[1] = DriverRating.Average();
                        _driverRatingStandardDeviation[1] = CalculateStdDev(DriverRating);
                        _controlledHighMean[1] = ControlledHighGoal.Average();
                        _controlledHighStandardDeviation[1] = CalculateStdDev(ControlledHighGoal);
                        _controlledHighSuccessRate[1] = ControlledHighGoal.Sum()/
                                                        (ControlledHighGoal.Sum() + ControlledHighMiss.Sum());
                        _controlledLowMean[1] = ControlledLowGoal.Average();
                        _controlledLowStandardDeviation[1] = CalculateStdDev(ControlledLowGoal);
                        _controlledLowSuccessRate[1] = ControlledLowGoal.Sum()/
                                                       (ControlledLowGoal.Sum() + ControlledLowMiss.Sum());
                        _hotGoalMean[1] = HotGoal.Average();
                        _hotGoalStandardDeviation[1] = CalculateStdDev(HotGoal);
                        _hotGoalSuccessRate[1] = HotGoal.Sum()/(HotGoal.Sum() + HotMiss.Sum());
                        _pickupsMean[1] = (AutoPickup.Average()) + (ControlledPickup.Average()) +
                                          (PickupFromHuman.Average());
                        _pickupStandardDeviation[1] = CalculateStdDev(ControlledPickup);
                        _pickupSuccessRate[1] = (AutoPickup.Sum() + ControlledPickup.Sum() + PickupFromHuman.Sum())/
                                                (AutoPickup.Sum() + ControlledPickup.Sum() + PickupFromHuman.Sum() +
                                                 AutoPickupMiss.Sum() + ControlledPickupMiss.Sum() +
                                                 MissedPickupFromHuman.Sum());
                        _successfulTrussMean[1] = SuccessfulTruss.Average();
                        _trussStandardDeviation[1] = CalculateStdDev(SuccessfulTruss);
                        _trussSuccessRate[1] = SuccessfulTruss.Sum()/(SuccessfulTruss.Sum() + UnSuccessfulTruss.Sum());
                        _survivability[1] = numberOfMatches/(numberOfMatches + RobotDied.Sum());

                        dataGridViewTeam2.Rows.Clear();

                        //Data Name, Mean, Standard Deviation, Successrate
                        dataGridViewTeam2.Rows.Add("Autonomous High", _autoHighMean[1].ToString("#.##"),
                            _autoHighStandardDeviation[1].ToString("#.##"), _autoHighGoalSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Autonomous Low", _autoLowMean[1].ToString("#.##"),
                            _autoLowStandardDeviation[1].ToString("#.##"), _autolowGoalSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Autonomous Mobility", "N/A", "N/A",
                            _autoMobilitySuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Driver Rating", _driverRatingMean[1].ToString("#.##"),
                            _driverRatingStandardDeviation[1].ToString("#.##"), "N/A");
                        dataGridViewTeam2.Rows.Add("Controlled High", _controlledHighMean[1].ToString("#.##"),
                            _controlledHighStandardDeviation[1].ToString("#.##"),
                            _controlledHighSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Controlled Low", _controlledLowMean[1].ToString("#.##"),
                            _controlledLowStandardDeviation[1].ToString("#.##"),
                            _controlledLowSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Hot Goal", _hotGoalMean[1].ToString("#.##"),
                            _hotGoalStandardDeviation[1].ToString("#.##"), _hotGoalSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Pickups", _pickupsMean[1].ToString("#.##"),
                            _pickupStandardDeviation[1].ToString("#.##"), _pickupSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Truss", _successfulTrussMean[1].ToString("#.##"),
                            _trussStandardDeviation[1].ToString("#.##"), _trussSuccessRate[1].ToString("P"));
                        dataGridViewTeam2.Rows.Add("Survivability", "N/A", "N/A", _survivability[1].ToString("P"));
                    }
                    catch (Exception e)
                    {
                        dataGridViewTeam2.Rows.Clear();
                        team2Selected = false;
                        us.ErrorOccured("Looks like something went wrong. Check console for the error message");
                        Console.WriteLine("Error Message: " + e.Message);
                    }
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
            for (int i = 0; i < _teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(_teamNumberArray[i] + " | " + _teamNameArray[i]);
                teamCompSelector1.Items.Add(_teamNumberArray[i] + " | " + _teamNameArray[i]);
                teamCompSelector2.Items.Add(_teamNumberArray[i] + " | " + _teamNameArray[i]);
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
            selectedTeam1 = _teamNumberArray[teamCompSelector1.SelectedIndex];
            ClearColourStats();
            team1Selected = true;
            GetDataForTeam(selectedTeam1, 1);
            ColourStats();
        }

        private void teamCompSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeam2 = _teamNumberArray[teamCompSelector2.SelectedIndex];
            ClearColourStats();
            team2Selected = true;
            GetDataForTeam(selectedTeam2, 2);
            ColourStats();
        }

        public void ColourStats()
        {
            if (Settings.Default.colourTeamComparisonStatistics)
            {
                if (team1Selected && team2Selected)
                {
                    if (_autoHighMean[0] > _autoHighMean[1])
                    {
                        dataGridViewTeam1.Rows[0].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[0].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_autoHighMean[1] > _autoHighMean[0])
                        {
                            dataGridViewTeam1.Rows[0].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[0].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_autoHighMean[1] == _autoHighMean[0])
                            {
                                dataGridViewTeam1.Rows[0].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[0].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autoHighStandardDeviation[0] > _autoHighStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[0].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[0].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_autoHighStandardDeviation[1] > _autoHighStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[0].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[0].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_autoHighStandardDeviation[0] == _autoHighStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[0].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[0].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autoHighGoalSuccessRate[0] > _autoHighGoalSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[0].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[0].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_autoHighGoalSuccessRate[1] > _autoHighGoalSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[0].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[0].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_autoHighGoalSuccessRate[0] == _autoHighGoalSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[0].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[0].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autoLowMean[0] > _autoLowMean[1])
                    {
                        dataGridViewTeam1.Rows[1].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[1].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_autoLowMean[1] > _autoLowMean[0])
                        {
                            dataGridViewTeam1.Rows[1].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[1].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_autoLowMean[0] == _autoLowMean[1])
                            {
                                dataGridViewTeam1.Rows[1].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[1].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autoLowStandardDeviation[0] > _autoLowStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[1].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[1].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_autoLowStandardDeviation[1] > _autoLowStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[1].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[1].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_autoLowStandardDeviation[0] == _autoLowStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[1].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[1].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autolowGoalSuccessRate[0] > _autolowGoalSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[1].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[1].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_autolowGoalSuccessRate[1] > _autolowGoalSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[1].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[1].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_autolowGoalSuccessRate[0] == _autolowGoalSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[1].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[1].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_autoMobilitySuccessRate[0] > _autoMobilitySuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[2].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[2].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_autoMobilitySuccessRate[1] > _autoMobilitySuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[2].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[2].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_autoMobilitySuccessRate[0] == _autoMobilitySuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[2].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[2].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_driverRatingMean[0] > _driverRatingMean[1])
                    {
                        dataGridViewTeam1.Rows[3].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[3].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_driverRatingMean[1] > _driverRatingMean[0])
                        {
                            dataGridViewTeam1.Rows[3].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[3].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_driverRatingMean[0] == _driverRatingMean[1])
                            {
                                dataGridViewTeam1.Rows[3].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[3].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_driverRatingStandardDeviation[0] > _driverRatingStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[3].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[3].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_driverRatingStandardDeviation[1] > _driverRatingStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[3].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[3].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_driverRatingStandardDeviation[0] == _driverRatingStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[3].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[3].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledHighMean[0] > _controlledHighMean[1])
                    {
                        dataGridViewTeam1.Rows[4].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[4].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_controlledHighMean[1] > _controlledHighMean[0])
                        {
                            dataGridViewTeam1.Rows[4].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[4].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_controlledHighMean[1] == _controlledHighMean[0])
                            {
                                dataGridViewTeam1.Rows[4].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[4].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledHighStandardDeviation[0] > _controlledHighStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[4].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[4].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_controlledHighStandardDeviation[1] > _controlledHighStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[4].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[4].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_controlledHighStandardDeviation[0] == _controlledHighStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[4].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[4].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledHighSuccessRate[0] > _controlledHighSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[4].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[4].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_controlledHighSuccessRate[1] > _controlledHighSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[4].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[4].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_controlledHighSuccessRate[0] == _controlledHighSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[4].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[4].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledLowMean[0] > _controlledLowMean[1])
                    {
                        dataGridViewTeam1.Rows[5].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[5].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_controlledLowMean[1] > _controlledLowMean[0])
                        {
                            dataGridViewTeam1.Rows[5].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[5].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_controlledLowMean[1] == _controlledLowMean[0])
                            {
                                dataGridViewTeam1.Rows[5].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[5].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledLowStandardDeviation[0] > _controlledLowStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[5].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[5].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_controlledLowStandardDeviation[1] > _controlledLowStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[5].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[5].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_controlledLowStandardDeviation[0] == _controlledLowStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[5].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[5].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_controlledLowSuccessRate[0] > _controlledLowSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[5].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[5].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_controlledLowSuccessRate[1] > _controlledLowSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[5].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[5].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_controlledLowSuccessRate[0] == _controlledLowSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[5].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[5].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_hotGoalMean[0] > _hotGoalMean[1])
                    {
                        dataGridViewTeam1.Rows[6].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[6].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_hotGoalMean[1] > _hotGoalMean[0])
                        {
                            dataGridViewTeam1.Rows[6].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[6].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_hotGoalMean[1] == _hotGoalMean[0])
                            {
                                dataGridViewTeam1.Rows[6].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[6].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_hotGoalStandardDeviation[0] > _hotGoalStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[6].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[6].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_hotGoalStandardDeviation[1] > _hotGoalStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[6].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[6].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_hotGoalStandardDeviation[0] == _hotGoalStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[6].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[6].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_hotGoalSuccessRate[0] > _hotGoalSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[6].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[6].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_hotGoalSuccessRate[1] > _hotGoalSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[6].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[6].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_hotGoalSuccessRate[0] == _hotGoalSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[6].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[6].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_pickupsMean[0] > _pickupsMean[1])
                    {
                        dataGridViewTeam1.Rows[7].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[7].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_pickupsMean[1] > _pickupsMean[0])
                        {
                            dataGridViewTeam1.Rows[7].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[7].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_pickupsMean[1] == _pickupsMean[0])
                            {
                                dataGridViewTeam1.Rows[7].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[7].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_pickupStandardDeviation[0] > _pickupStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[8].Cells[7].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[8].Cells[7].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_pickupStandardDeviation[1] > _pickupStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[7].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[7].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_pickupStandardDeviation[0] == _pickupStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[7].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[7].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_pickupSuccessRate[0] > _pickupSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[7].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[7].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_pickupSuccessRate[1] > _pickupSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[7].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[7].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_pickupSuccessRate[0] == _pickupSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[7].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[7].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_successfulTrussMean[0] > _successfulTrussMean[1])
                    {
                        dataGridViewTeam1.Rows[8].Cells[1].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[8].Cells[1].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_successfulTrussMean[1] > _successfulTrussMean[0])
                        {
                            dataGridViewTeam1.Rows[8].Cells[1].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[8].Cells[1].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_successfulTrussMean[1] == _successfulTrussMean[0])
                            {
                                dataGridViewTeam1.Rows[8].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[8].Cells[1].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_trussStandardDeviation[0] > _trussStandardDeviation[1])
                    {
                        dataGridViewTeam1.Rows[8].Cells[2].Style.ForeColor = Color.Red;
                        dataGridViewTeam2.Rows[8].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (_trussStandardDeviation[1] > _trussStandardDeviation[0])
                        {
                            dataGridViewTeam1.Rows[8].Cells[2].Style.ForeColor = Color.Green;
                            dataGridViewTeam2.Rows[8].Cells[2].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            if (_trussStandardDeviation[0] == _trussStandardDeviation[1])
                            {
                                dataGridViewTeam1.Rows[8].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[8].Cells[2].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_trussSuccessRate[0] > _trussSuccessRate[1])
                    {
                        dataGridViewTeam1.Rows[8].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[8].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_trussSuccessRate[1] > _trussSuccessRate[0])
                        {
                            dataGridViewTeam1.Rows[8].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[8].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_trussSuccessRate[0] == _trussSuccessRate[1])
                            {
                                dataGridViewTeam1.Rows[8].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[8].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }

                    if (_survivability[0] > _survivability[1])
                    {
                        dataGridViewTeam1.Rows[9].Cells[3].Style.ForeColor = Color.Green;
                        dataGridViewTeam2.Rows[9].Cells[3].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (_survivability[1] > _survivability[0])
                        {
                            dataGridViewTeam1.Rows[9].Cells[3].Style.ForeColor = Color.Red;
                            dataGridViewTeam2.Rows[9].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            if (_survivability[0] == _survivability[1])
                            {
                                dataGridViewTeam1.Rows[9].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                                dataGridViewTeam2.Rows[9].Cells[3].Style.ForeColor =
                                    Settings.Default.teamComparisonEqualValueColour;
                            }
                        }
                    }
                }
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
            url = url + Convert.ToString(_teamNumberArray[teamSelector.SelectedIndex]);
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

            Settings.Default.selectedTeamName = _teamNameArray[teamSelector.SelectedIndex];
            Settings.Default.selectedTeamNumber = teamNumber;
            Settings.Default.Save();

            matchSummaryEntryID.Clear();
            matchSummaryTeamNumber.Clear();
            matchSummaryTeamName.Clear();
            matchSummaryTeamColour.Clear();
            matchSummaryMatchNumber.Clear();
            matchSummaryAutoHighGoal.Clear();
            matchSummaryAutoHighMiss.Clear();
            matchSummaryAutoLowGoal.Clear();
            matchSummaryAutoLowMiss.Clear();
            matchSummaryControlledHighGoal.Clear();
            matchSummaryControlledHighMiss.Clear();
            matchSummaryControlledLowGoal.Clear();
            matchSummaryControlledLowMiss.Clear();
            matchSummaryHotGoals.Clear();
            matchSummaryHotMisses.Clear();
            matchSummaryTripleAssistGoal.Clear();
            matchSummaryTripleAssistMiss.Clear();
            matchSummaryAutoBallPickup.Clear();
            matchSummaryAutoBallPickupMiss.Clear();
            matchSummaryControlledBallPickup.Clear();
            matchSummaryControlledBallPickupMiss.Clear();
            matchSummaryPickupFromHuman.Clear();
            matchSummaryPickupFromHumanMiss.Clear();
            matchSummaryPassToAnotherRobot.Clear();
            matchSummaryPassToAnotherRobotMiss.Clear();
            matchSummarySuccessfulTruss.Clear();
            matchSummaryUnSuccessfulTruss.Clear();
            matchSummaryStartingX.Clear();
            matchSummaryStartingY.Clear();
            matchSummaryDidRobotDie.Clear();
            matchSummaryAutoMovement.Clear();
            matchSummaryDriverRating.Clear();
            matchSummaryComments.Clear();
            matchSummaryX.Clear();
            matchSummaryY.Clear();

            try
            {
                var conn = new MySqlConnection(us.MakeMySqlConnectionString());
                MySqlCommand cmd = conn.CreateCommand();
                MySqlDataReader reader;
                cmd.CommandText = String.Format("SELECT * From {0} where TeamNumber={1}",
                    Settings.Default.currentTableName, Settings.Default.selectedTeamNumber);
                conn.Open();
                reader = cmd.ExecuteReader();
                teamMatchBox.Items.Clear();
                while (reader.Read())
                {
                    teamMatchBox.Items.Add("Match Number: " + reader["MatchNumber"]);

                    matchSummaryEntryID.Add(Convert.ToInt32(reader["EntryID"]));
                    matchSummaryTeamNumber.Add(Convert.ToInt32(reader["TeamNumber"]));
                    matchSummaryTeamName.Add(reader["TeamName"].ToString());
                    matchSummaryTeamColour.Add(reader["TeamColour"].ToString());
                    matchSummaryMatchNumber.Add(Convert.ToInt32(reader["MatchNumber"]));
                    matchSummaryAutoHighGoal.Add(Convert.ToInt32(reader["AutoHighGoal"]));
                    matchSummaryAutoHighMiss.Add(Convert.ToInt32(reader["AutoHighMiss"]));
                    matchSummaryAutoLowGoal.Add(Convert.ToInt32(reader["AutoLowGoal"]));
                    matchSummaryAutoLowMiss.Add(Convert.ToInt32(reader["AutoLowMiss"]));
                    matchSummaryControlledHighGoal.Add(Convert.ToInt32(reader["ControlledHighGoal"]));
                    matchSummaryControlledHighMiss.Add(Convert.ToInt32(reader["ControlledHighMiss"]));
                    matchSummaryControlledLowGoal.Add(Convert.ToInt32(reader["ControlledLowGoal"]));
                    matchSummaryControlledLowMiss.Add(Convert.ToInt32(reader["ControlledLowMiss"]));
                    matchSummaryHotGoals.Add(Convert.ToInt32(reader["HotGoals"]));
                    matchSummaryHotMisses.Add(Convert.ToInt32(reader["HotGoalMiss"]));
                    matchSummaryTripleAssistGoal.Add(Convert.ToInt32(reader["3AssistGoal"]));
                    matchSummaryTripleAssistMiss.Add(Convert.ToInt32(reader["3AssistMiss"]));
                    matchSummaryAutoBallPickup.Add(Convert.ToInt32(reader["AutoBallPickup"]));
                    matchSummaryAutoBallPickupMiss.Add(Convert.ToInt32(reader["AutoBallPickupMiss"]));
                    matchSummaryControlledBallPickup.Add(Convert.ToInt32(reader["ControlledBallPickup"]));
                    matchSummaryControlledBallPickupMiss.Add(Convert.ToInt32(reader["ControlledBallPickupMiss"]));
                    matchSummaryPickupFromHuman.Add(Convert.ToInt32(reader["PickupFromHuman"]));
                    matchSummaryPickupFromHumanMiss.Add(Convert.ToInt32(reader["MissedPickupFromHuman"]));
                    matchSummaryPassToAnotherRobot.Add(Convert.ToInt32(reader["PassToAnotherRobot"]));
                    matchSummaryPassToAnotherRobotMiss.Add(Convert.ToInt32(reader["MissedPassToAnotherRobot"]));
                    matchSummarySuccessfulTruss.Add(Convert.ToInt32(reader["SuccessfulTruss"]));
                    matchSummaryUnSuccessfulTruss.Add(Convert.ToInt32(reader["UnsuccessfulTruss"]));
                    matchSummaryStartingX.Add(Convert.ToInt32(reader["StartingX"]));
                    matchSummaryStartingY.Add(Convert.ToInt32(reader["StartingY"]));
                    matchSummaryDidRobotDie.Add(Convert.ToInt32(reader["DidRobotDie"]));
                    matchSummaryDriverRating.Add(Convert.ToInt32(reader["DriverRating"]));
                    matchSummaryAutoMovement.Add(Convert.ToInt32(reader["AutoMovement"]));
                    matchSummaryX.Add(Convert.ToInt32(reader["StartingX"]));
                    matchSummaryY.Add(Convert.ToInt32(reader["StartingY"]));
                    matchSummaryComments.Add(reader["Comments"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException exception)
            {
                Console.WriteLine("Error Code: " + exception.ErrorCode);
                Console.WriteLine("Error Message: " + exception.Message);
            }
        }

        private void teamURLDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public void PlotInitialLines()
        {
            var blackpen = new Pen(Color.Black, 4);
            var fineBluePen = new Pen(Color.Blue, 2);
            var fineWhitePen = new Pen(Color.White, 2);
            var fineRedPen = new Pen(Color.Red, 2);
            Graphics initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 330, 231);

            //Drawing field lines
            initGraphics.DrawRectangle(fineBluePen, 4, 4, 108, 223);
            initGraphics.DrawRectangle(fineWhitePen, 116, 4, 98, 223);
            initGraphics.DrawRectangle(fineRedPen, 218, 4, 108, 223);
            initGraphics.DrawLine(blackpen, 165, 0, 165, 231);
            initGraphics.Dispose();
        }

        public void BlankPanel()
        {
            Graphics clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.White, 0, 0, 370, 252);
            clearPanelGraphics.Dispose();
            PlotInitialLines();
        }

        private void startingLocationPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }

        private void teamMatchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamMatchSummaryTeamNameDisplay.Text = "Team Name: " + matchSummaryTeamName[teamMatchBox.SelectedIndex];
            teamMatchSummaryTeamNumberDisplay.Text = "Team Number: " +
                                                     matchSummaryTeamNumber[teamMatchBox.SelectedIndex];
            teamMatchSummaryTeamColourDisplay.Text = "Team Colour: " +
                                                     matchSummaryTeamColour[teamMatchBox.SelectedIndex];
            teamMatchSummaryMatchNumberDisplay.Text = "Match Number: " +
                                                      matchSummaryMatchNumber[teamMatchBox.SelectedIndex];
            teamMatchSummaryAutoHighDisplay.Text = "Auto High Goals: " +
                                                   matchSummaryAutoHighGoal[teamMatchBox.SelectedIndex] + " Misses: " +
                                                   matchSummaryAutoHighMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryAutoLowDisplay.Text = "Auto Low Goals: " +
                                                  matchSummaryAutoLowGoal[teamMatchBox.SelectedIndex] + " Misses: " +
                                                  matchSummaryAutoLowMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryControlledHighDisplay.Text = "Controlled High Goals: " +
                                                         matchSummaryControlledHighGoal[teamMatchBox.SelectedIndex] +
                                                         " Misses: " +
                                                         matchSummaryControlledHighMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryControlledLowDisplay.Text = "Controlled Low Goals: " +
                                                        matchSummaryControlledLowGoal[teamMatchBox.SelectedIndex] +
                                                        " Misses: " +
                                                        matchSummaryControlledLowMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryHotDisplay.Text = "Hot Goal: " + matchSummaryHotGoals[teamMatchBox.SelectedIndex] +
                                              " Misses: " + matchSummaryHotMisses[teamMatchBox.SelectedIndex];
            teamMatchSummaryTripleAssistDisplay.Text = "Triple Assist Goals: " +
                                                       matchSummaryTripleAssistGoal[teamMatchBox.SelectedIndex] +
                                                       " Misses: " +
                                                       matchSummaryTripleAssistMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryAutoBallPickupDisplay.Text = "Autonomous Ball Pickup: " +
                                                         matchSummaryAutoBallPickup[teamMatchBox.SelectedIndex] +
                                                         " Missed Pickup: " +
                                                         matchSummaryAutoBallPickupMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryControlledBallPickupDisplay.Text = "Controlled Ball Pickup: " +
                                                               matchSummaryControlledBallPickup[
                                                                   teamMatchBox.SelectedIndex] + " Missed Pickup: " +
                                                               matchSummaryControlledBallPickupMiss[
                                                                   teamMatchBox.SelectedIndex];
            teamMatchSummaryPickupFromHumanDisplay.Text = "Pickup From Human: " +
                                                          matchSummaryPickupFromHuman[teamMatchBox.SelectedIndex] +
                                                          " Missed Pickup: " +
                                                          matchSummaryPickupFromHumanMiss[teamMatchBox.SelectedIndex];
            teamMatchSummaryPassToAnotherRobotDisplay.Text = "Pass to Another Robot: " +
                                                             matchSummaryPassToAnotherRobot[teamMatchBox.SelectedIndex] +
                                                             " Missed Pass: " +
                                                             matchSummaryPassToAnotherRobotMiss[
                                                                 teamMatchBox.SelectedIndex];
            teamMatchSummaryTrussDisplay.Text = "Successful Truss: " +
                                                matchSummarySuccessfulTruss[teamMatchBox.SelectedIndex] +
                                                " Unsuccessful Truss: " +
                                                matchSummaryUnSuccessfulTruss[teamMatchBox.SelectedIndex];
            teamMatchSummaryDidRobotDieDisplay.Text = "Did robot die?: " +
                                                      Convert.ToBoolean(
                                                          matchSummaryDidRobotDie[teamMatchBox.SelectedIndex]);
            teamMatchSummaryDriverRatingDisplay.Text = "Driver Rating: " +
                                                       matchSummaryDriverRating[teamMatchBox.SelectedIndex];
            teamMatchSummaryAutoMovementDisplay.Text = "Autonomous Movement: " +
                                                       Convert.ToBoolean(
                                                           matchSummaryAutoMovement[teamMatchBox.SelectedIndex]);
            teamMatchSummaryCommentsDisplay.Text = "Comments: " + matchSummaryComments[teamMatchBox.SelectedIndex];

            //Draw the starting location on the starting location panel
            BlankPanel();
            PlotInitialLines();
            Graphics g = startingLocationPanel.CreateGraphics();
            int xStarting = Convert.ToInt32(matchSummaryX[teamMatchBox.SelectedIndex]) - 3;
            int yStarting = Convert.ToInt32(matchSummaryY[teamMatchBox.SelectedIndex]) - 3;
            g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(new Point(xStarting, yStarting), new Size(5, 5)));
            teamMatchSummaryXYDisplay.Text = ("X: " + xStarting + " Y: " + yStarting);
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