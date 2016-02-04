#region License
//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2016 FRC_Scouting_V2

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
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FRC_Scouting_V2.Models;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using UsefulSnippets;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class RecycleRush_IRI : Form
    {
        private readonly string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        private readonly List<RecycleRush_Stack> matchStacks = new List<RecycleRush_Stack>();

        private readonly string[] teamNameArray =
        {
            "Bomb Squad", "The Rocketeers", "Team RUSH", "Killer Bees", "Delphi E.L.I.T.E.", "The HOT Team",
            "Truck Town Thunder", "Team R.O.B.O.T.I.C.S.", "WildStang", "Robonauts", "NUTRONS", "Penn Robotics",
            "Robowranglers", "The Children of the Swamp", "Cyber Knights", "ThunderChickens", "TechFire", "Hammerheads",
            "The Pink Team", "Cyber Blue", "Adambots", "LuNaTeCs", "The Beach Bots",
            "G.R.R. (Greater Rochester Robotics)", "Hawaiian Kids", "RoboCats", "Sparky 384", "Las Guerrillas",
            "Frog Force", "Robostangs", "CRyptonite", "Shark Attack", "Digital Goats", "Bedford Express", "Kil-A-Bytes",
            "Simbotics", "Vulcan Robotics", "RUNNYMEDE ROBOTICS", "Inverse Paradox", "Up-A-Creek Robotics",
            "Winnovation", "Sab-BOT-age", "Hamosad", "Raptors", "PhyXTGears", "Team Driven", "Red Alert", "Argos",
            "S.W.A.T.", "Llano Estacado RoboRaiders", "The MidKnight Inventors", "OP Robotics", "Team Tators",
            "EngiNERDs", "Gear It Forward", "Team Appreciate", "Talon Robotics", "Duluth East Daredevils", "Nemesis",
            "MARS", "Wave Robotics", "DM High Voltage", "ElkLogics", "Ranger Robotics", "The Captains",
            "The East Ridge Robotic Ominous RaptorS - the ERRORS", "The Flying Toasters", "HVA RoHAWKtics",
            "MakeShift Robotics", "MARS/ WARS", "CyberCavs", "Classified Robotics", "Robot Raiders", "Stellar Robotics"
        };

        private readonly int[] teamNumberArray =
        {
            16, 20, 27, 33, 48, 67, 68, 107, 111, 118, 125, 135, 148, 179, 195, 217, 225, 226, 233, 234, 245, 316, 330,
            340, 359, 379, 384, 469, 503, 548, 624, 744, 829, 1023, 1024, 1114, 1218, 1310, 1325, 1619, 1625, 1640, 1657,
            1711, 1720, 1730, 1741, 1756, 1806, 1817, 1923, 2056, 2122, 2337, 2338, 2468, 2502, 2512, 2590, 2614, 2826,
            2852, 2867, 3015, 3098, 3130, 3641, 3824, 4039, 4143, 4678, 5188, 5254, 5413
        };

        private readonly List<RecycleRush_Scout_Match> teamsMatches = new List<RecycleRush_Scout_Match>();
        private string allianceColour = "Unset";

        private string currentTeamName;
        private int currentTeamNumber;
        private RecycleRush_Pit_Scouting_Team currentTeamPit;
        private int driverRating;
        private byte[] Front_Picture = {};
        private byte[] Left_Isometric_Picture = {};
        private byte[] Left_Side_Picture = {};
        private bool leftClick;
        private byte[] Other_Picture = {};
        private int startingX;
        private int startingY;

        public RecycleRush_IRI()
        {
            InitializeComponent();
        }

        private void scoutingSubmitButton_Click(object sender, EventArgs e)
        {
            scoutingSubmitButton.Enabled = false;
            Program.selectedEventName = "RecycleRush_IRI";

            var match = new RecycleRush_Scout_Match
            {
                Author = Settings.Default.username,
                TimeCreated = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),
                UniqueID = Guid.NewGuid().ToString(),
                Team_Number = currentTeamNumber,
                Team_Name = currentTeamName,
                Match_Number = Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value),
                Alliance_Colour = allianceColour,
                Robot_Dead = scoutingDidTheRobotDieCheckBox.Checked,
                Auto_Starting_X = startingX,
                Auto_Starting_Y = startingY,
                Auto_Drive_To_Autozone = scoutingDriveToAutoZoneCheckBox.Checked,
                Auto_Robot_Set = scoutingRobotSetCheckBox.Checked,
                Auto_Tote_Set = scoutingToteSetCheckBox.Checked,
                Auto_Bin_Set = scoutingBinSetCheckBox.Checked,
                Auto_Stacked_Tote_Set = scoutingStackedToteSetCheckBox.Checked,
                Auto_Acquired_Step_Bins = Convert.ToInt32(scoutingAcquiredStepBinsNumUpDown.Value),
                Auto_Fouls = Convert.ToInt32(scoutingAutoFoulsNumUpDown.Value),
                Auto_Did_Nothing = scoutingDidNothingCheckBox.Checked,
                Tele_Tote_Pickup_Upright = scoutingTotePickupUprightCheckbox.Checked,
                Tele_Tote_Pickup_Upside_Down = scoutingTotePickupUpsideDownCheckBox.Checked,
                Tele_Tote_Pickup_Sideways = scoutingTotePickupSideWaysCheckBox.Checked,
                Tele_Bin_Pickup_Upright = scoutingBinPickupUprightCheckBox.Checked,
                Tele_Bin_Pickup_Upside_Down = scoutingBinPickupUpsideDownCheckBox.Checked,
                Tele_Bin_Pickup_Sideways = scoutingBinPickupSidewaysCheckBox.Checked,
                Tele_Human_Station_Load_Totes = scoutingHumanStationLoadTotesCheckBox.Checked,
                Tele_Human_Station_Stack_Totes = scoutingHumanStationStackTotesCheckBox.Checked,
                Tele_Human_Station_Insert_Litter = scoutingHumanStationInsertLitterCheckBox.Checked,
                Tele_Human_Throwing_Litter = scoutingHumanThrowingLitterCheckBox.Checked,
                Tele_Pushed_Litter_To_Landfill = scoutingPushedLitterToLandfill.Checked,
                Tele_Fouls = Convert.ToInt32(scoutingTeleFoulPointsNumUpDown.Value),
                Comments = scoutingCommentsRichTextBox.Text,
                Stacks = matchStacks,
                Coopertition_Set = scoutingCoopertitionSetCheckBox.Checked,
                Coopertition_Stack = scoutingCoopertitionStackCheckBox.Checked,
                Final_Score_Red = Convert.ToInt32(scoutingRedAllianceFinalScoreNumUpDown.Value),
                Final_Score_Blue = Convert.ToInt32(scoutingBlueAllianceFinalScoreNumUpDown.Value),
                Driver_Rating = driverRating
            };

            if (match.Comments.Contains(";"))
            {
                match.Comments = Regex.Replace(match.Comments, "[;]", string.Empty);
            }

            try
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Matches");
                var jsonText = JsonConvert.SerializeObject(match, Formatting.Indented);
                var matchLocation = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Matches\\RecycleRush_IRI_" +
                                     Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value) + "_" + currentTeamName +
                                     ".json");
                File.WriteAllText(matchLocation, jsonText);
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception);
            }

            try
            {
                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                conn.Open();
                var cmd = conn.CreateCommand();
                var commandText =
                    string.Format(
                        "Insert into RecycleRush_IRI_Matches (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Final_Score_Red,Final_Score_Blue,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');",
                        (MySQLMethods.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author, match.TimeCreated,
                        match.Team_Number, match.Team_Name, match.Match_Number, match.Alliance_Colour,
                        Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X, match.Auto_Starting_Y,
                        Convert.ToInt16(match.Auto_Drive_To_Autozone), Convert.ToInt16(match.Auto_Robot_Set),
                        Convert.ToInt16(match.Auto_Tote_Set), Convert.ToInt16(match.Auto_Bin_Set),
                        Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins, match.Auto_Fouls,
                        Convert.ToInt16(match.Auto_Did_Nothing), Convert.ToInt16(match.Tele_Tote_Pickup_Upright),
                        Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down),
                        Convert.ToInt16(match.Tele_Tote_Pickup_Sideways), Convert.ToInt16(match.Tele_Bin_Pickup_Upright),
                        Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down),
                        Convert.ToInt16(match.Tele_Bin_Pickup_Sideways),
                        Convert.ToInt16(match.Tele_Human_Station_Load_Totes),
                        Convert.ToInt16(match.Tele_Human_Station_Stack_Totes),
                        Convert.ToInt16(match.Tele_Human_Station_Insert_Litter),
                        Convert.ToInt16(match.Tele_Human_Throwing_Litter),
                        Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls, match.Comments,
                        JsonConvert.SerializeObject(match.Stacks), Convert.ToInt16(match.Coopertition_Set),
                        Convert.ToInt16(match.Coopertition_Stack), match.Final_Score_Red, match.Final_Score_Blue,
                        match.Driver_Rating);
                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception);
            }

            ResetScoutingInterface();
            scoutingSubmitButton.Enabled = true;
        }

        private void scoutingStacksSubmitButton_Click(object sender, EventArgs e)
        {
            scoutingStacksSubmitButton.Enabled = false;

            var stackToAdd = new RecycleRush_Stack
            {
                Stack_Height = Convert.ToInt32(scoutingStacksHeightNumUpDown.Value),
                Bin_On_Top = scoutingStacksBinOnTopCheckBox.Checked,
                Litter_In_Bin = scoutingStacksLitterInBinCheckBox.Checked,
                Did_They_Make_The_Stack = scoutingDidTheyMakeStackCheckBox.Checked
            };

            matchStacks.Add(stackToAdd);

            scoutingStacksHeightNumUpDown.Value = Convert.ToDecimal(0);
            scoutingStacksBinOnTopCheckBox.Checked = false;
            scoutingStacksLitterInBinCheckBox.Checked = false;
            scoutingDidTheyMakeStackCheckBox.Checked = false;

            scoutingStacksSubmitButton.Enabled = true;
        }

        private void scoutingFieldTypeSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlotInitialImage();
        }

        private void PlotInitialImage()
        {
            try
            {
                switch (scoutingFieldTypeSelectorComboBox.SelectedIndex)
                {
                    case 0:
                        scoutingFieldPictureBox.Image = Resources.RecycleRush_2015_No_Items;
                        break;

                    case 1:
                        scoutingFieldPictureBox.Image = Resources.RecycleRush_2015_With_Items;
                        break;
                }
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine(exception.ToString());
            }
        }

        private void scoutingFieldPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startingX = e.X - 2;
                startingY = e.Y - 2;
                leftClick = true;
            }
        }

        private void scoutingFieldPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Commented out cause it uses a ton of CPU time
            // PlotInitialImage();
            var blackpen = new Pen(Color.Black, 2);

            if (leftClick)
            {
                e.Graphics.DrawRectangle(blackpen, startingX, startingY, 8, 8);
            }
        }

        private void scoutingDriverRatingButton1_CheckedChanged(object sender, EventArgs e)
        {
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;

            if (scoutingDriverRatingButton1.Checked)
            {
                driverRating = 1;
                scoutingDriverRatingButton2.Enabled = false;
                scoutingDriverRatingButton3.Enabled = false;
                scoutingDriverRatingButton4.Enabled = false;
            }
        }

        private void scoutingDriverRatingButton2_CheckedChanged(object sender, EventArgs e)
        {
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;

            if (scoutingDriverRatingButton2.Checked)
            {
                driverRating = 2;
                scoutingDriverRatingButton1.Enabled = false;
                scoutingDriverRatingButton3.Enabled = false;
                scoutingDriverRatingButton4.Enabled = false;
            }
        }

        private void scoutingDriverRatingButton3_CheckedChanged(object sender, EventArgs e)
        {
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;

            if (scoutingDriverRatingButton3.Checked)
            {
                driverRating = 3;
                scoutingDriverRatingButton1.Enabled = false;
                scoutingDriverRatingButton2.Enabled = false;
                scoutingDriverRatingButton4.Enabled = false;
            }
        }

        private void scoutingDriverRatingButton4_CheckedChanged(object sender, EventArgs e)
        {
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;

            if (scoutingDriverRatingButton4.Checked)
            {
                driverRating = 4;
                scoutingDriverRatingButton1.Enabled = false;
                scoutingDriverRatingButton2.Enabled = false;
                scoutingDriverRatingButton3.Enabled = false;
            }
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTeamName = teamNameArray[teamSelector.SelectedIndex];
            currentTeamNumber = teamNumberArray[teamSelector.SelectedIndex];
            Program.selectedTeamNumber = currentTeamNumber;

            teamInformationTeamName.Text = ("Team Name: " + teamNameArray[teamSelector.SelectedIndex]);
            teamInformationTeamNumber.Text = ("Team Number: " + teamNumberArray[teamSelector.SelectedIndex]);

            ResetMatchBreakdownInterface();

            Front_Picture = null;
            Left_Side_Picture = null;
            Left_Isometric_Picture = null;
            Other_Picture = null;

            pitScoutingEditorFrontPictureLabel.Text = "Front Picture:";
            pitScoutingEditorSidePictureLabel.Text = "Side Picture:";
            pitScoutingEditorSideIsometricPictureLabel.Text = "Side Isometric Picture:";
            pitScoutingEditorOtherPictureLabel.Text = "Other Picture:";

            try
            {
                var teamImage = Resources.ResourceManager.GetObject("FRC" + teamNumberArray[teamSelector.SelectedIndex]);
                teamInformationLogo.Image = (Image) teamImage;
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
            }

            if (Network.CheckForInternetConnection())
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/frc");
                url = url + Convert.ToString(teamNumberArray[teamSelector.SelectedIndex]);
                string downloadedData;
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);

                try
                {
                    downloadedData = (wc.DownloadString(url));
                    var deserializedData =
                        JsonConvert.DeserializeObject<AerialAssist_RahChaCha.TeamInformationJSONData>(downloadedData);

                    teamInformationTeamLocation.Text = "Team Location: " + Convert.ToString(deserializedData.location);
                    teamInformationRookieYear.Text = "Rookie Year: " + Convert.ToString(deserializedData.rookie_year);
                    teamInformationWebsiteLinkLabel.Text = Convert.ToString(deserializedData.website);
                }
                catch (Exception webError)
                {
                    ConsoleWindow.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamInformationTeamLocation.Text = "Team Location: ";
                teamInformationRookieYear.Text = "Rookie Year: ";
                teamInformationWebsiteLinkLabel.Text = "";
            }

            if (Network.CheckForInternetConnection())
            {
                try
                {
                    var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                    var cmd = conn.CreateCommand();
                    MySqlDataReader reader;
                    cmd.CommandText = string.Format("SELECT * FROM RecycleRush_IRI_Matches WHERE Team_Number = '{0}'",
                        Program.selectedTeamNumber);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var match = new RecycleRush_Scout_Match
                        {
                            Author = reader["Author"].ToString(),
                            TimeCreated = reader["TimeCreated"].ToString(),
                            Match_Number = Convert.ToInt32(reader["Match_Number"]),
                            Alliance_Colour = Convert.ToString(reader["Alliance_Colour"]),
                            Robot_Dead = Convert.ToBoolean(reader["Robot_Dead"]),
                            Auto_Starting_X = Convert.ToInt32(reader["Auto_Starting_X"]),
                            Auto_Starting_Y = Convert.ToInt32(reader["Auto_Starting_Y"]),
                            Auto_Drive_To_Autozone = Convert.ToBoolean(reader["Auto_Drive_To_Autozone"]),
                            Auto_Robot_Set = Convert.ToBoolean(reader["Auto_Robot_Set"]),
                            Auto_Tote_Set = Convert.ToBoolean(reader["Auto_Tote_Set"]),
                            Auto_Bin_Set = Convert.ToBoolean(reader["Auto_Bin_Set"]),
                            Auto_Stacked_Tote_Set = Convert.ToBoolean(reader["Auto_Stacked_Tote_Set"]),
                            Auto_Acquired_Step_Bins = Convert.ToInt32(reader["Auto_Acquired_Step_Bins"]),
                            Auto_Fouls = Convert.ToInt32(reader["Auto_Fouls"]),
                            Auto_Did_Nothing = Convert.ToBoolean(reader["Auto_Did_Nothing"]),
                            Tele_Tote_Pickup_Upright = Convert.ToBoolean(reader["Tele_Tote_Pickup_Upright"]),
                            Tele_Tote_Pickup_Upside_Down = Convert.ToBoolean(reader["Tele_Tote_Pickup_Upside_Down"]),
                            Tele_Tote_Pickup_Sideways = Convert.ToBoolean(reader["Tele_Tote_Pickup_Sideways"]),
                            Tele_Bin_Pickup_Upright = Convert.ToBoolean(reader["Tele_Bin_Pickup_Upright"]),
                            Tele_Bin_Pickup_Upside_Down = Convert.ToBoolean(reader["Tele_Bin_Pickup_Upside_Down"]),
                            Tele_Bin_Pickup_Sideways = Convert.ToBoolean(reader["Tele_Bin_Pickup_Sideways"]),
                            Tele_Human_Station_Load_Totes = Convert.ToBoolean(reader["Tele_Human_Station_Load_Totes"]),
                            Tele_Human_Station_Stack_Totes = Convert.ToBoolean(reader["Tele_Human_Station_Stack_Totes"]),
                            Tele_Human_Station_Insert_Litter =
                                Convert.ToBoolean(reader["Tele_Human_Station_Insert_Litter"]),
                            Tele_Human_Throwing_Litter = Convert.ToBoolean(reader["Tele_Human_Throwing_Litter"]),
                            Tele_Pushed_Litter_To_Landfill = Convert.ToBoolean(reader["Tele_Pushed_Litter_To_Landfill"]),
                            Tele_Fouls = Convert.ToInt32(reader["Tele_Fouls"]),
                            Comments = Convert.ToString(reader["Comments"]),
                            Stacks = JsonConvert.DeserializeObject<List<RecycleRush_Stack>>(reader["Stacks"].ToString()),
                            Coopertition_Set = Convert.ToBoolean(reader["Coopertition_Set"]),
                            Coopertition_Stack = Convert.ToBoolean(reader["Coopertition_Stack"]),
                            Final_Score_Red = Convert.ToInt32(reader["Final_Score_Red"]),
                            Final_Score_Blue = Convert.ToInt32(reader["Final_Score_Blue"]),
                            Driver_Rating = Convert.ToInt32(reader["Driver_Rating"])
                        };

                        teamsMatches.Add(match);

                        matchBreakdownMatchList.Items.Add("Match Number: " + reader["Match_Number"]);
                    }
                    conn.Close();
                }
                catch (MySqlException exception)
                {
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                }

                try
                {
                    ResetPitScoutingViewerInterface();
                    ResetPitScoutingEditorInterface();
                    var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                    var cmd = conn.CreateCommand();
                    MySqlDataReader reader;
                    cmd.CommandText = string.Format("SELECT * FROM RecycleRush_IRI_Pits WHERE Team_Number = '{0}'",
                        Program.selectedTeamNumber);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var pitScout = new RecycleRush_Pit_Scouting_Team
                        {
                            Author = reader["Author"].ToString(),
                            Time_Created = reader["Time_Created"].ToString(),
                            UniqueID = reader["UniqueID"].ToString(),
                            Team_Number = Convert.ToInt32(reader["Team_Number"]),
                            Team_Name = reader["Team_Name"].ToString(),
                            Drive_Train = reader["Drive_Train"].ToString(),
                            Number_Of_Robots = Convert.ToInt32(reader["Number_Of_Robots"]),
                            Does_It_have_A_Ramp = Convert.ToBoolean(reader["Does_It_have_A_Ramp"]),
                            Can_It_Manipulate_Totes = Convert.ToBoolean(reader["Can_It_Manipulate_Totes"]),
                            Can_It_Manipulate_Bins = Convert.ToBoolean(reader["Can_It_Manipulate_Bins"]),
                            Can_It_Manipulate_Litter = Convert.ToBoolean(reader["Can_It_Manipulate_Litter"]),
                            Needs_Special_Starting_Position =
                                Convert.ToBoolean(reader["Needs_Special_Starting_Position"]),
                            Special_Starting_Position = reader["Special_Starting_Position"].ToString(),
                            Max_Stack_Height = Convert.ToInt32(reader["Max_Stack_Height"]),
                            Max_Bin_On_Stack_Height = Convert.ToInt32(reader["Max_Bin_On_Stack_Height"]),
                            Human_Tote_Loading = Convert.ToBoolean(reader["Human_Tote_Loading"]),
                            Human_Litter_Loading = Convert.ToBoolean(reader["Human_Litter_Loading"]),
                            Human_Litter_Throwing = Convert.ToBoolean(reader["Human_Litter_Throwing"]),
                            Comments = reader["Comments"].ToString(),
                            Front_Picture = reader["Front_Picture"] as byte[],
                            Left_Side_Picture = reader["Left_Side_Picture"] as byte[],
                            Left_Isometric_Picture = reader["Left_Isometric_Picture"] as byte[],
                            Other_Picture = reader["Other_Picture"] as byte[]
                        };
                        currentTeamPit = pitScout;
                    }
                    conn.Close();

                    try
                    {
                        pitScoutingViewerEntryInformationAuthorDisplay.Text = currentTeamPit.Author;
                        pitScoutingViewerEntryInformationTimeCreatedDisplay.Text = currentTeamPit.Time_Created;
                        pitScoutingViewerManipulationTotesDisplay.Text =
                            currentTeamPit.Can_It_Manipulate_Totes.ToString();
                        pitScoutingViewerManipulationBinsDisplay.Text = currentTeamPit.Can_It_Manipulate_Bins.ToString();
                        pitScoutingViewerManipulationLitterDisplay.Text =
                            currentTeamPit.Can_It_Manipulate_Litter.ToString();
                        pitScoutingViewerRobotSpecsNumRobotsDisplay.Text = currentTeamPit.Number_Of_Robots.ToString();
                        pitScoutingViewerRobotSpecsDriveTrainTextBox.Text = "Drive Train: " + currentTeamPit.Drive_Train;
                        pitScoutingViewerRobotSpecsDoesItHaveARampDisplay.Text =
                            currentTeamPit.Does_It_have_A_Ramp.ToString();
                        pitScoutingViewerStartingLocationDoesItNeedSpecificStartingLocationDisplay.Text =
                            currentTeamPit.Needs_Special_Starting_Position.ToString();
                        pitScoutingViewerStartingLocationSpecificStartingLocationTextBox.Text = "If so where? " +
                                                                                                currentTeamPit
                                                                                                    .Special_Starting_Position;
                        pitScoutingViewerStackInformationMaxStackHeightDisplay.Text =
                            currentTeamPit.Max_Stack_Height.ToString();
                        pitScoutingViewerStackInformationMaxHeightWithBinDisplay.Text =
                            currentTeamPit.Max_Bin_On_Stack_Height.ToString();
                        pitScoutingViewerPictureBox.Image = null;
                        pitScoutingViewerHumanInteractionToteLoadingDisplay.Text =
                            currentTeamPit.Human_Tote_Loading.ToString();
                        pitScoutingViewerHumanInteractionLitterLoadingDisplay.Text =
                            currentTeamPit.Human_Litter_Loading.ToString();
                        pitScoutingViewerHumanInteractionLitterThrowingDisplay.Text =
                            currentTeamPit.Human_Litter_Throwing.ToString();
                        pitScoutingViewerCommentsBox.Text = "Comments: " + currentTeamPit.Comments;
                    }
                    catch (Exception ex)
                    {
                        ConsoleWindow.WriteLine("Error: " + ex.Message);
                    }
                }
                catch (MySqlException exception)
                {
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                }
            }
        }

        private void ResetScoutingInterface()
        {
            scoutingDriveToAutoZoneCheckBox.Checked = false;
            scoutingRobotSetCheckBox.Checked = false;
            scoutingToteSetCheckBox.Checked = false;
            scoutingBinSetCheckBox.Checked = false;
            scoutingStackedToteSetCheckBox.Checked = false;
            scoutingAcquiredStepBinsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingAutoFoulsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingDidNothingCheckBox.Checked = false;
            scoutingCommentsRichTextBox.Text = "Comments:";
            scoutingMatchNumberNumericUpDown.Value = scoutingMatchNumberNumericUpDown.Value + 1;
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;
            driverRating = 0;
            scoutingDidTheRobotDieCheckBox.Checked = false;
            scoutingRedAllianceFinalScoreNumUpDown.Value = Convert.ToDecimal(0);
            scoutingBlueAllianceFinalScoreNumUpDown.Value = Convert.ToDecimal(0);
            scoutingTotePickupUprightCheckbox.Checked = false;
            scoutingTotePickupUpsideDownCheckBox.Checked = false;
            scoutingTotePickupSideWaysCheckBox.Checked = false;
            scoutingBinPickupUprightCheckBox.Checked = false;
            scoutingBinPickupUpsideDownCheckBox.Checked = false;
            scoutingBinPickupSidewaysCheckBox.Checked = false;
            scoutingHumanStationLoadTotesCheckBox.Checked = false;
            scoutingHumanStationStackTotesCheckBox.Checked = false;
            scoutingHumanStationInsertLitterCheckBox.Checked = false;
            scoutingHumanThrowingLitterCheckBox.Checked = false;
            scoutingPushedLitterToLandfill.Checked = false;
            scoutingTeleFoulPointsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingCoopertitionSetCheckBox.Checked = false;
            scoutingAllianceColourRedCheckBox.Enabled = true;
            scoutingAllianceColourBlueCheckBox.Enabled = true;
            allianceColour = "";
        }

        public void ResetMatchBreakdownInterface()
        {
            matchBreakdownMatchList.Items.Clear();
            teamsMatches.Clear();

            matchBreakDownAuthorDisplay.Text = "Author:";
            matchBreakDownTimeCreatedDisplay.Text = "Time Created:";
            matchBreakDownDriveToAutozoneDisplay.Text = "";
            matchBreakDownRobotSetDisplay.Text = "";
            matchBreakDownToteSetDisplay.Text = "";
            matchBreakDownStackedToteSetDisplay.Text = "";
            matchBreakDownBinSetDisplay.Text = "";
            matchBreakDownBinsOffStepDisplay.Text = "";
            matchBreakDownAutoFoulsDisplay.Text = "";
            matchBreakDownAutoDidNothingDisplay.Text = "";
            matchBreakDownTeleTotePickupUprightDisplay.Text = "Upright:";
            matchBreakDownTeleTotePickupUpsideDownDisplay.Text = "Upside Down:";
            matchBreakDownTeleTotePickupSidewaysDisplay.Text = "Sideways:";
            matchBreakDownTeleBinPickupUprightDisplay.Text = "Upright:";
            matchBreakDownTeleBinPickupUpsideDownDisplay.Text = "Upside Down:";
            matchBreakDownTeleBinPickupSidewaysDisplay.Text = "Sideways:";
            matchBreakDownTeleHumanStationLoadingTotesDisplay.Text = "Loading Totes:";
            matchBreakDownTeleHumanStationStackTotesDisplay.Text = "Inserting Litter:";
            matchBreakDownTeleThrowingLitterDisplay.Text = "";
            matchBreakDownTelePushingLitterDisplay.Text = "";
            matchBreakDownTeleFoulsDisplay.Text = "";
            matchBreakDownDriverRatingDisplay.Text = "0";
            matchBreakDownCoopertitionSetDisplay.Text = "Set:";
            matchBreakDownCoopertitionStackDisplay.Text = "Stack:";
            matchBreakDownFinalScoresRedDisplay.Text = "Red: 0";
            matchBreakDownFinalScoresBlueDisplay.Text = "Blue: 0";
            matchBreakDownAllianceColourDisplay.Text = "";

            matchBreakDownCommentsTextBox.Text = "Comments:";

            matchBreakdownStacksGridView.Rows.Clear();
        }

        public void ResetPitScoutingViewerInterface()
        {
            pitScoutingViewerEntryInformationAuthorDisplay.Text = "";
            pitScoutingViewerEntryInformationTimeCreatedDisplay.Text = "";
            pitScoutingViewerManipulationTotesDisplay.Text = "";
            pitScoutingViewerManipulationBinsDisplay.Text = "";
            pitScoutingViewerManipulationLitterDisplay.Text = "";
            pitScoutingViewerRobotSpecsNumRobotsDisplay.Text = "";
            pitScoutingViewerRobotSpecsDriveTrainTextBox.Text = "Drive Train:";
            pitScoutingViewerRobotSpecsDoesItHaveARampDisplay.Text = "";
            pitScoutingViewerStartingLocationDoesItNeedSpecificStartingLocationDisplay.Text = "";
            pitScoutingViewerStartingLocationSpecificStartingLocationTextBox.Text = "If so where?";
            pitScoutingViewerStackInformationMaxStackHeightDisplay.Text = "";
            pitScoutingViewerStackInformationMaxHeightWithBinDisplay.Text = "";
            pitScoutingViewerPictureBox.Image = null;
            pitScoutingViewerHumanInteractionToteLoadingDisplay.Text = "";
            pitScoutingViewerHumanInteractionLitterLoadingDisplay.Text = "";
            pitScoutingViewerHumanInteractionLitterThrowingDisplay.Text = "";
            pitScoutingViewerCommentsBox.Text = "Comments:";
        }

        public void ResetPitScoutingEditorInterface()
        {
            pitScoutingEditorManipulationTotesCheckBox.Checked = false;
            pitScoutingEditorManipulationBinsCheckBox.Checked = false;
            pitScoutingEditorManipulationLitterCheckBox.Checked = false;
            pitScoutingEditorRobotSpecsNumberOfRobotsNumUpDown.Value = 1;
            pitScoutingEditorRobotSpecsDriveTrainTextBox.Text = "Drive Train";
            pitScoutingEditorRobotSpecsDoTheyHaveARampCheckBox.Checked = false;
            pitScoutingEditorStartingLocationSpecificLocationCheckBox.Checked = false;
            pitScoutingEditorStartingLocationSpecificStartingLocationTextBox.Text = "if so where";
            pitScoutingEditorStackInformationMaxStackHeightNumUpDown.Value = 0;
            pitScoutingEditorStackInformationMaxStackWithBinNumUpDown.Value = 0;
            pitScoutingEditorHumanInteractionToteLoadingCheckBox.Checked = false;
            pitScoutingEditorHumanInteractionLitterLoadingCheckBox.Checked = false;
            pitScoutingEditorHumanInteractionLitterThrowingCheckBox.Checked = false;
            pitScoutingEditorCommentsTextBox.Text = "Comments";
            pitScoutingEditorFrontPictureLabel.Text = "Front Picture:";
            pitScoutingEditorSidePictureLabel.Text = "Side Picture:";
            pitScoutingEditorSideIsometricPictureLabel.Text = "Side Isometric Picture:";
            pitScoutingEditorOtherPictureLabel.Text = "Other Picture:";
        }

        private void gameManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proc = new Process();
            proc.StartInfo = new ProcessStartInfo
            {
                FileName = assemblyPath + "\\Resources\\FRC2015GameManual.pdf"
            };
            proc.Start();
        }

        private void teamInformationWebsiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(teamInformationWebsiteLinkLabel.Text);
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Message: " + exception.Message);
            }
        }

        private void matchBreakdownFieldTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (matchBreakdownFieldTypeComboBox.SelectedIndex)
                {
                    case 0:
                        matchBreakdownFieldImageBox.Image = Resources.RecycleRush_2015_No_Items;
                        break;

                    case 1:
                        matchBreakdownFieldImageBox.Image = Resources.RecycleRush_2015_With_Items;
                        break;
                }
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine(exception.ToString());
            }
        }

        private void matchBreakdownMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            matchBreakDownAuthorDisplay.Text = "Author: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Author;
            matchBreakDownTimeCreatedDisplay.Text = "Time: " +
                                                    teamsMatches[matchBreakdownMatchList.SelectedIndex].TimeCreated;
            matchBreakDownDriveToAutozoneDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Drive_To_Autozone.ToString();
            matchBreakDownRobotSetDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Robot_Set.ToString();
            matchBreakDownToteSetDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Tote_Set.ToString();
            matchBreakDownStackedToteSetDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Stacked_Tote_Set.ToString();
            matchBreakDownBinSetDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Bin_Set.ToString();
            matchBreakDownBinsOffStepDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Acquired_Step_Bins.ToString();
            matchBreakDownAutoFoulsDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Fouls.ToString();
            matchBreakDownAutoDidNothingDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Did_Nothing.ToString();
            matchBreakDownTeleTotePickupUprightDisplay.Text = "Upright: " +
                                                              teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                  .Tele_Tote_Pickup_Upright;
            matchBreakDownTeleTotePickupUpsideDownDisplay.Text = "Upside Down: " +
                                                                 teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                     .Tele_Tote_Pickup_Upside_Down;
            matchBreakDownTeleTotePickupSidewaysDisplay.Text = "Sideways: " +
                                                               teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                   .Tele_Tote_Pickup_Sideways;
            matchBreakDownTeleBinPickupUprightDisplay.Text = "Upright: " +
                                                             teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                 .Tele_Bin_Pickup_Upright;
            matchBreakDownTeleBinPickupUpsideDownDisplay.Text = "Upside Down :" +
                                                                teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                    .Tele_Bin_Pickup_Upside_Down;
            matchBreakDownTeleBinPickupSidewaysDisplay.Text = "Sideways: " +
                                                              teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                  .Tele_Bin_Pickup_Sideways;
            matchBreakDownTeleHumanStationLoadingTotesDisplay.Text = "Loading Totes: " +
                                                                     teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                         .Tele_Human_Station_Load_Totes;
            matchBreakDownTeleHumanStationStackTotesDisplay.Text = "Inserting Litter: " +
                                                                   teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                                       .Tele_Human_Station_Stack_Totes;
            matchBreakDownTeleThrowingLitterDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Human_Throwing_Litter.ToString();
            matchBreakDownTelePushingLitterDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Pushed_Litter_To_Landfill.ToString();
            matchBreakDownTeleFoulsDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Fouls.ToString();
            matchBreakDownDriverRatingDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Driver_Rating.ToString();
            matchBreakDownCoopertitionSetDisplay.Text = "Set: " +
                                                        teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                            .Coopertition_Set;
            matchBreakDownCoopertitionStackDisplay.Text = "Stack: " +
                                                          teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                              .Coopertition_Stack;
            matchBreakDownFinalScoresRedDisplay.Text = "Red: " +
                                                       teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                           .Final_Score_Red;
            matchBreakDownFinalScoresBlueDisplay.Text = "Blue: " +
                                                        teamsMatches[matchBreakdownMatchList.SelectedIndex]
                                                            .Final_Score_Blue;
            matchBreakDownAllianceColourDisplay.Text =
                teamsMatches[matchBreakdownMatchList.SelectedIndex].Alliance_Colour;
            matchBreakDownCommentsTextBox.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Comments;

            matchBreakdownStacksGridView.Rows.Clear();
            for (var i = 0; i < teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks.Count; i++)
            {
                matchBreakdownStacksGridView.Rows.Add((i + 1).ToString(),
                    teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks[i].Stack_Height,
                    teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks[i].Bin_On_Top,
                    teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks[i].Litter_In_Bin,
                    teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks[i].Did_They_Make_The_Stack);
            }
        }

        private void scoutingAllianceColourRedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scoutingAllianceColourRedCheckBox.Enabled = true;
            scoutingAllianceColourBlueCheckBox.Enabled = true;

            if (scoutingAllianceColourRedCheckBox.Checked)
            {
                allianceColour = "Red";
                scoutingAllianceColourBlueCheckBox.Enabled = false;
            }
        }

        private void scoutingAllianceColourBlueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scoutingAllianceColourRedCheckBox.Enabled = true;
            scoutingAllianceColourBlueCheckBox.Enabled = true;

            if (scoutingAllianceColourBlueCheckBox.Checked)
            {
                allianceColour = "Blue";
                scoutingAllianceColourRedCheckBox.Enabled = false;
            }
        }

        private void matchScoutingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importationOpenFileDialog.InitialDirectory = assemblyPath + "\\Saves\\Matches";
            if (Network.CheckForInternetConnection())
            {
                if (
                    MessageBox.Show(
                        "The importation of these files can take a long time, are you sure you want to continue?",
                        "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) ==
                    DialogResult.Yes)
                {
                    if (importationOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var t in importationOpenFileDialog.FileNames)
                        {
                            var match = JsonConvert.DeserializeObject<RecycleRush_Scout_Match>(File.ReadAllText(t));
                            try
                            {
                                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                                conn.Open();
                                var cmd = conn.CreateCommand();
                                var commandText =
                                    string.Format(
                                        "Insert into RecycleRush_IRI_Matches (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Final_Score_Red,Final_Score_Blue,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');",
                                        (MySQLMethods.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author,
                                        match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number,
                                        match.Alliance_Colour, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X,
                                        match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone),
                                        Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set),
                                        Convert.ToInt16(match.Auto_Bin_Set),
                                        Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins,
                                        match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Upright),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Sideways),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Upright),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Sideways),
                                        Convert.ToInt16(match.Tele_Human_Station_Load_Totes),
                                        Convert.ToInt16(match.Tele_Human_Station_Stack_Totes),
                                        Convert.ToInt16(match.Tele_Human_Station_Insert_Litter),
                                        Convert.ToInt16(match.Tele_Human_Throwing_Litter),
                                        Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls,
                                        match.Comments, JsonConvert.SerializeObject(match.Stacks),
                                        Convert.ToInt16(match.Coopertition_Set),
                                        Convert.ToInt16(match.Coopertition_Stack), match.Final_Score_Red,
                                        match.Final_Score_Blue, match.Driver_Rating);
                                cmd.CommandText = commandText;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (MySqlException exception)
                            {
                                ConsoleWindow.WriteLine(exception.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet is Required For Importation!", "Internet is Required!", MessageBoxButtons.OK);
            }
        }

        private void pitScoutingEditorSubmitButton_Click(object sender, EventArgs e)
        {
            pitScoutingEditorSubmitButton.Enabled = false;
            var pitScout = new RecycleRush_Pit_Scouting_Team
            {
                Author = Settings.Default.username,
                Time_Created = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),
                UniqueID = Guid.NewGuid().ToString(),
                Team_Number = currentTeamNumber,
                Team_Name = currentTeamName,
                Drive_Train = pitScoutingEditorRobotSpecsDriveTrainTextBox.Text,
                Number_Of_Robots = Convert.ToInt32(pitScoutingEditorRobotSpecsNumberOfRobotsNumUpDown.Value),
                Does_It_have_A_Ramp = pitScoutingEditorRobotSpecsDoTheyHaveARampCheckBox.Checked,
                Can_It_Manipulate_Totes = pitScoutingEditorManipulationTotesCheckBox.Checked,
                Can_It_Manipulate_Bins = pitScoutingEditorManipulationBinsCheckBox.Checked,
                Can_It_Manipulate_Litter = pitScoutingEditorManipulationLitterCheckBox.Checked,
                Needs_Special_Starting_Position = pitScoutingEditorStartingLocationSpecificLocationCheckBox.Checked,
                Special_Starting_Position = pitScoutingEditorStartingLocationSpecificStartingLocationTextBox.Text,
                Max_Stack_Height = Convert.ToInt32(pitScoutingEditorStackInformationMaxStackHeightNumUpDown.Value),
                Max_Bin_On_Stack_Height =
                    Convert.ToInt32(pitScoutingEditorStackInformationMaxStackWithBinNumUpDown.Value),
                Human_Tote_Loading = pitScoutingEditorHumanInteractionToteLoadingCheckBox.Checked,
                Human_Litter_Loading = pitScoutingEditorHumanInteractionLitterLoadingCheckBox.Checked,
                Human_Litter_Throwing = pitScoutingEditorHumanInteractionLitterThrowingCheckBox.Checked,
                Comments = pitScoutingEditorCommentsTextBox.Text,
                Front_Picture = Front_Picture,
                Left_Side_Picture = Left_Side_Picture,
                Left_Isometric_Picture = Left_Isometric_Picture,
                Other_Picture = Other_Picture
            };

            try
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Pits");
                var jsonText = JsonConvert.SerializeObject(pitScout, Formatting.Indented);
                var pitLocation = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Pits\\RecycleRush_IRI_" +
                                   currentTeamName + ".json");
                File.WriteAllText(pitLocation, jsonText);
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception);
            }

            try
            {
                //Removes entries for a team before adding new info!
                if (GetNumberOfPitEntriesForATeam(currentTeamNumber) == 1)
                {
                    try
                    {
                        var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                        conn.Open();
                        var commandText = string.Format("DELETE FROM RecycleRush_IRI_Pits WHERE `Team_Number`='{0}';",
                            currentTeamNumber);
                        var cmd = new MySqlCommand(commandText, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exception)
                    {
                        ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                        Notifications.ReportCrash(exception);
                    }
                }

                using (var con = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString()))
                {
                    var query =
                        "INSERT INTO `RecycleRush_IRI_Pits`(`UniqueID`,`Author`,`Time_Created`,`Team_Number`,`Team_Name`,`Drive_Train`,`Number_Of_Robots`,`Can_It_Manipulate_Totes`,`Can_It_Manipulate_Bins`,`Can_It_Manipulate_Litter`,`Needs_Special_Starting_Position`,`Special_Starting_Position`,`Max_Stack_Height`,`Max_Bin_On_Stack_Height`,`Human_Tote_Loading`,`Human_Litter_Loading`,`Human_Litter_Throwing`,`Does_It_have_A_Ramp`,`Comments`,`Front_Picture`,`Left_Side_Picture`,`Left_Isometric_Picture`,`Other_Picture`)VALUES(@UniqueID,@Author,@Time_Created,@Team_Number,@Team_Name,@Drive_Train,@Number_Of_Robots,@Can_It_Manipulate_Totes,@Can_It_Manipulate_Bins,@Can_It_Manipulate_Litter,@Needs_Special_Starting_Position,@Special_Starting_Position,@Max_Stack_Height,@Max_Bin_On_Stack_Height,@Human_Tote_Loading,@Human_Litter_Loading,@Human_Litter_Throwing,@Does_It_have_A_Ramp,@Comments,@Front_Picture,@Left_Side_Picture,@Left_Isometric_Picture,@Other_Picture);";
                    using (var cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UniqueID", pitScout.UniqueID);
                        cmd.Parameters.AddWithValue("@Author", pitScout.Author);
                        cmd.Parameters.AddWithValue("@Time_Created", pitScout.Time_Created);
                        cmd.Parameters.AddWithValue("@Team_Number", pitScout.Team_Number);
                        cmd.Parameters.AddWithValue("@Team_Name", pitScout.Team_Name);
                        cmd.Parameters.AddWithValue("@Drive_Train", pitScout.Drive_Train);
                        cmd.Parameters.AddWithValue("@Number_Of_Robots", pitScout.Number_Of_Robots);
                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Totes", pitScout.Can_It_Manipulate_Totes);
                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Bins", pitScout.Can_It_Manipulate_Bins);
                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Litter", pitScout.Can_It_Manipulate_Litter);
                        cmd.Parameters.AddWithValue("@Needs_Special_Starting_Position",
                            pitScout.Needs_Special_Starting_Position);
                        cmd.Parameters.AddWithValue("@Special_Starting_Position", pitScout.Special_Starting_Position);
                        cmd.Parameters.AddWithValue("@Max_Stack_Height", pitScout.Max_Stack_Height);
                        cmd.Parameters.AddWithValue("@Max_Bin_On_Stack_Height", pitScout.Max_Bin_On_Stack_Height);
                        cmd.Parameters.AddWithValue("@Human_Tote_Loading", pitScout.Human_Tote_Loading);
                        cmd.Parameters.AddWithValue("@Human_Litter_Loading", pitScout.Human_Litter_Loading);
                        cmd.Parameters.AddWithValue("@Human_Litter_Throwing", pitScout.Human_Litter_Throwing);
                        cmd.Parameters.AddWithValue("@Does_It_have_A_Ramp", pitScout.Does_It_have_A_Ramp);
                        cmd.Parameters.AddWithValue("@Comments", pitScout.Comments);
                        cmd.Parameters.AddWithValue("@Front_Picture", pitScout.Front_Picture);
                        cmd.Parameters.AddWithValue("@Left_Side_Picture", pitScout.Left_Side_Picture);
                        cmd.Parameters.AddWithValue("@Left_Isometric_Picture", pitScout.Left_Isometric_Picture);
                        cmd.Parameters.AddWithValue("@Other_Picture", pitScout.Other_Picture);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                Notifications.ShowInformationMessage("Successfully submitted pit scouting data!");
            }
            catch (Exception exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception);
            }

            try
            {
                ResetPitScoutingViewerInterface();
                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                var cmd = conn.CreateCommand();
                MySqlDataReader reader;
                cmd.CommandText = string.Format("SELECT * FROM RecycleRush_IRI_Pits WHERE Team_Number = '{0}'",
                    Program.selectedTeamNumber);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var currentPitScout = new RecycleRush_Pit_Scouting_Team
                    {
                        Author = reader["Author"].ToString(),
                        Time_Created = reader["Time_Created"].ToString(),
                        UniqueID = reader["UniqueID"].ToString(),
                        Team_Number = Convert.ToInt32(reader["Team_Number"]),
                        Team_Name = reader["Team_Name"].ToString(),
                        Drive_Train = reader["Drive_Train"].ToString(),
                        Number_Of_Robots = Convert.ToInt32(reader["Number_Of_Robots"]),
                        Does_It_have_A_Ramp = Convert.ToBoolean(reader["Does_It_have_A_Ramp"]),
                        Can_It_Manipulate_Totes = Convert.ToBoolean(reader["Can_It_Manipulate_Totes"]),
                        Can_It_Manipulate_Bins = Convert.ToBoolean(reader["Can_It_Manipulate_Bins"]),
                        Can_It_Manipulate_Litter = Convert.ToBoolean(reader["Can_It_Manipulate_Litter"]),
                        Needs_Special_Starting_Position = Convert.ToBoolean(reader["Needs_Special_Starting_Position"]),
                        Special_Starting_Position = reader["Special_Starting_Position"].ToString(),
                        Max_Stack_Height = Convert.ToInt32(reader["Max_Stack_Height"]),
                        Max_Bin_On_Stack_Height = Convert.ToInt32(reader["Max_Bin_On_Stack_Height"]),
                        Human_Tote_Loading = Convert.ToBoolean(reader["Human_Tote_Loading"]),
                        Human_Litter_Loading = Convert.ToBoolean(reader["Human_Litter_Loading"]),
                        Human_Litter_Throwing = Convert.ToBoolean(reader["Human_Litter_Throwing"]),
                        Comments = reader["Comments"].ToString(),
                        Front_Picture = reader["Front_Picture"] as byte[],
                        Left_Side_Picture = reader["Left_Side_Picture"] as byte[],
                        Left_Isometric_Picture = reader["Left_Isometric_Picture"] as byte[],
                        Other_Picture = reader["Other_Picture"] as byte[]
                    };
                    currentTeamPit = currentPitScout;
                }
                conn.Close();

                try
                {
                    pitScoutingViewerEntryInformationAuthorDisplay.Text = currentTeamPit.Author;
                    pitScoutingViewerEntryInformationTimeCreatedDisplay.Text = currentTeamPit.Time_Created;
                    pitScoutingViewerManipulationTotesDisplay.Text = currentTeamPit.Can_It_Manipulate_Totes.ToString();
                    pitScoutingViewerManipulationBinsDisplay.Text = currentTeamPit.Can_It_Manipulate_Bins.ToString();
                    pitScoutingViewerManipulationLitterDisplay.Text = currentTeamPit.Can_It_Manipulate_Litter.ToString();
                    pitScoutingViewerRobotSpecsNumRobotsDisplay.Text = currentTeamPit.Number_Of_Robots.ToString();
                    pitScoutingViewerRobotSpecsDriveTrainTextBox.Text = "Drive Train: " + currentTeamPit.Drive_Train;
                    pitScoutingViewerRobotSpecsDoesItHaveARampDisplay.Text =
                        currentTeamPit.Does_It_have_A_Ramp.ToString();
                    pitScoutingViewerStartingLocationDoesItNeedSpecificStartingLocationDisplay.Text =
                        currentTeamPit.Needs_Special_Starting_Position.ToString();
                    pitScoutingViewerStartingLocationSpecificStartingLocationTextBox.Text = "If so where? " +
                                                                                            currentTeamPit
                                                                                                .Special_Starting_Position;
                    pitScoutingViewerStackInformationMaxStackHeightDisplay.Text =
                        currentTeamPit.Max_Stack_Height.ToString();
                    pitScoutingViewerStackInformationMaxHeightWithBinDisplay.Text =
                        currentTeamPit.Max_Bin_On_Stack_Height.ToString();
                    pitScoutingViewerPictureBox.Image = null;
                    pitScoutingViewerHumanInteractionToteLoadingDisplay.Text =
                        currentTeamPit.Human_Tote_Loading.ToString();
                    pitScoutingViewerHumanInteractionLitterLoadingDisplay.Text =
                        currentTeamPit.Human_Litter_Loading.ToString();
                    pitScoutingViewerHumanInteractionLitterThrowingDisplay.Text =
                        currentTeamPit.Human_Litter_Throwing.ToString();
                    pitScoutingViewerCommentsBox.Text = "Comments: " + currentTeamPit.Comments;
                }
                catch (Exception ex)
                {
                    ConsoleWindow.WriteLine("Error: " + ex.Message);
                }
            }
            catch (MySqlException exception)
            {
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
            }
            pitScoutingEditorSubmitButton.Enabled = true;
        }

        private void pitScoutingEditorFrontPictureFileSelectorButton_Click(object sender, EventArgs e)
        {
            if (pictureOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileLoc = pictureOpenFileDialog.FileName;
                pitScoutingEditorFrontPictureLabel.Text = fileLoc;

                var fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                Front_Picture = br.ReadBytes((int) fs.Length);
            }
        }

        private void pitScoutingEditorSidePictureFileSelectorButton_Click(object sender, EventArgs e)
        {
            if (pictureOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileLoc = pictureOpenFileDialog.FileName;
                pitScoutingEditorSidePictureLabel.Text = fileLoc;

                var fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                Left_Side_Picture = br.ReadBytes((int) fs.Length);
            }
        }

        private void pitScoutingEditorSideIsometricPictureFileSelectorButton_Click(object sender, EventArgs e)
        {
            if (pictureOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileLoc = pictureOpenFileDialog.FileName;
                pitScoutingEditorSideIsometricPictureLabel.Text = fileLoc;

                var fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                Left_Isometric_Picture = br.ReadBytes((int) fs.Length);
            }
        }

        private void pitScoutingEditorOtherPictureFileSelectorButton_Click(object sender, EventArgs e)
        {
            if (pictureOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileLoc = pictureOpenFileDialog.FileName;
                pitScoutingEditorOtherPictureLabel.Text = fileLoc;

                var fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                Other_Picture = br.ReadBytes((int) fs.Length);
            }
        }

        public int GetNumberOfPitEntriesForATeam(int teamNumber)
        {
            var numberOfRows = 0;
            try
            {
                var mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                var mySQLCommantText = string.Format("SELECT COUNT(*) FROM RecycleRush_IRI_Pits WHERE Team_Number={0}",
                    teamNumber);
                using (var cmd = new MySqlCommand(mySQLCommantText, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
            return numberOfRows;
        }

        private void pitScoutingViewerFrontPictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                pitScoutingViewerPictureBox.Image = Images.byteArrayToImage(currentTeamPit.Front_Picture);
            }
            catch (Exception ex)
            {
                ConsoleWindow.WriteLine(ex.Message);
            }
        }

        private void pitScoutingViewerSidePictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                pitScoutingViewerPictureBox.Image = Images.byteArrayToImage(currentTeamPit.Left_Side_Picture);
            }
            catch (Exception ex)
            {
                ConsoleWindow.WriteLine(ex.Message);
            }
        }

        private void pitScoutingViewerIsometricPictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                pitScoutingViewerPictureBox.Image = Images.byteArrayToImage(currentTeamPit.Left_Isometric_Picture);
            }
            catch (Exception ex)
            {
                ConsoleWindow.WriteLine(ex.Message);
            }
        }

        private void pitScoutingViewerOtherPictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                pitScoutingViewerPictureBox.Image = Images.byteArrayToImage(currentTeamPit.Other_Picture);
            }
            catch (Exception ex)
            {
                ConsoleWindow.WriteLine(ex.Message);
            }
        }

        private void RecycleRush_IRI_Load(object sender, EventArgs e)
        {
            Program.selectedEventName = "RecycleRush_IRI";
            scoutingFieldTypeSelectorComboBox.SelectedIndex = 0;
            matchBreakdownFieldTypeComboBox.SelectedIndex = 0;

            for (var i = 0; i < teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
            }
        }

        private void matchScoutingDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            importationOpenFileDialog.InitialDirectory = assemblyPath + "\\Saves\\Matches";
            if (Network.CheckForInternetConnection())
            {
                if (
                    MessageBox.Show(
                        "The importation of these files can take a long time, are you sure you want to continue?",
                        "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) ==
                    DialogResult.Yes)
                {
                    if (importationOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var t in importationOpenFileDialog.FileNames)
                        {
                            var match = JsonConvert.DeserializeObject<RecycleRush_Scout_Match>(File.ReadAllText(t));
                            try
                            {
                                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                                conn.Open();
                                var cmd = conn.CreateCommand();
                                var commandText =
                                    string.Format(
                                        "Insert into RecycleRush_IRI_Matches (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Final_Score_Red,Final_Score_Blue,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');",
                                        (MySQLMethods.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author,
                                        match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number,
                                        match.Alliance_Colour, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X,
                                        match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone),
                                        Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set),
                                        Convert.ToInt16(match.Auto_Bin_Set),
                                        Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins,
                                        match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Upright),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down),
                                        Convert.ToInt16(match.Tele_Tote_Pickup_Sideways),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Upright),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down),
                                        Convert.ToInt16(match.Tele_Bin_Pickup_Sideways),
                                        Convert.ToInt16(match.Tele_Human_Station_Load_Totes),
                                        Convert.ToInt16(match.Tele_Human_Station_Stack_Totes),
                                        Convert.ToInt16(match.Tele_Human_Station_Insert_Litter),
                                        Convert.ToInt16(match.Tele_Human_Throwing_Litter),
                                        Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls,
                                        match.Comments, JsonConvert.SerializeObject(match.Stacks),
                                        Convert.ToInt16(match.Coopertition_Set),
                                        Convert.ToInt16(match.Coopertition_Stack), match.Final_Score_Red,
                                        match.Final_Score_Blue, match.Driver_Rating);
                                cmd.CommandText = commandText;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (MySqlException exception)
                            {
                                ConsoleWindow.WriteLine(exception.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet is Required For Importation!", "Internet is Required!", MessageBoxButtons.OK);
            }
        }

        private void pitScoutingDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            importationOpenFileDialog.InitialDirectory = assemblyPath + "\\Saves\\Pits";
            if (Network.CheckForInternetConnection())
            {
                if (
                    MessageBox.Show(
                        "The importation of these files can take a long time, are you sure you want to continue?",
                        "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) ==
                    DialogResult.Yes)
                {
                    if (importationOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var t in importationOpenFileDialog.FileNames)
                        {
                            var pitScout =
                                JsonConvert.DeserializeObject<RecycleRush_Pit_Scouting_Team>(File.ReadAllText(t));
                            //Removes entries for a team before adding new info!
                            if (GetNumberOfPitEntriesForATeam(currentTeamNumber) > 0)
                            {
                                try
                                {
                                    var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                                    conn.Open();
                                    var commandText =
                                        string.Format("DELETE FROM RecycleRush_IRI_Pits WHERE `Team_Number`='{0}';",
                                            pitScout.Team_Number);
                                    var cmd = new MySqlCommand(commandText, conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                catch (Exception exception)
                                {
                                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                                    Notifications.ReportCrash(exception);
                                }
                            }
                            try
                            {
                                using (var con = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString()))
                                {
                                    var query =
                                        "INSERT INTO `RecycleRush_IRI_Pits`(`UniqueID`,`Author`,`Time_Created`,`Team_Number`,`Team_Name`,`Drive_Train`,`Number_Of_Robots`,`Can_It_Manipulate_Totes`,`Can_It_Manipulate_Bins`,`Can_It_Manipulate_Litter`,`Needs_Special_Starting_Position`,`Special_Starting_Position`,`Max_Stack_Height`,`Max_Bin_On_Stack_Height`,`Human_Tote_Loading`,`Human_Litter_Loading`,`Human_Litter_Throwing`,`Does_It_have_A_Ramp`,`Comments`,`Front_Picture`,`Left_Side_Picture`,`Left_Isometric_Picture`,`Other_Picture`)VALUES(@UniqueID,@Author,@Time_Created,@Team_Number,@Team_Name,@Drive_Train,@Number_Of_Robots,@Can_It_Manipulate_Totes,@Can_It_Manipulate_Bins,@Can_It_Manipulate_Litter,@Needs_Special_Starting_Position,@Special_Starting_Position,@Max_Stack_Height,@Max_Bin_On_Stack_Height,@Human_Tote_Loading,@Human_Litter_Loading,@Human_Litter_Throwing,@Does_It_have_A_Ramp,@Comments,@Front_Picture,@Left_Side_Picture,@Left_Isometric_Picture,@Other_Picture);";
                                    using (var cmd = new MySqlCommand(query, con))
                                    {
                                        cmd.Parameters.AddWithValue("@UniqueID", pitScout.UniqueID);
                                        cmd.Parameters.AddWithValue("@Author", pitScout.Author);
                                        cmd.Parameters.AddWithValue("@Time_Created", pitScout.Time_Created);
                                        cmd.Parameters.AddWithValue("@Team_Number", pitScout.Team_Number);
                                        cmd.Parameters.AddWithValue("@Team_Name", pitScout.Team_Name);
                                        cmd.Parameters.AddWithValue("@Drive_Train", pitScout.Drive_Train);
                                        cmd.Parameters.AddWithValue("@Number_Of_Robots", pitScout.Number_Of_Robots);
                                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Totes",
                                            pitScout.Can_It_Manipulate_Totes);
                                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Bins",
                                            pitScout.Can_It_Manipulate_Bins);
                                        cmd.Parameters.AddWithValue("@Can_It_Manipulate_Litter",
                                            pitScout.Can_It_Manipulate_Litter);
                                        cmd.Parameters.AddWithValue("@Needs_Special_Starting_Position",
                                            pitScout.Needs_Special_Starting_Position);
                                        cmd.Parameters.AddWithValue("@Special_Starting_Position",
                                            pitScout.Special_Starting_Position);
                                        cmd.Parameters.AddWithValue("@Max_Stack_Height", pitScout.Max_Stack_Height);
                                        cmd.Parameters.AddWithValue("@Max_Bin_On_Stack_Height",
                                            pitScout.Max_Bin_On_Stack_Height);
                                        cmd.Parameters.AddWithValue("@Human_Tote_Loading", pitScout.Human_Tote_Loading);
                                        cmd.Parameters.AddWithValue("@Human_Litter_Loading",
                                            pitScout.Human_Litter_Loading);
                                        cmd.Parameters.AddWithValue("@Human_Litter_Throwing",
                                            pitScout.Human_Litter_Throwing);
                                        cmd.Parameters.AddWithValue("@Does_It_have_A_Ramp", pitScout.Does_It_have_A_Ramp);
                                        cmd.Parameters.AddWithValue("@Comments", pitScout.Comments);
                                        cmd.Parameters.AddWithValue("@Front_Picture", pitScout.Front_Picture);
                                        cmd.Parameters.AddWithValue("@Left_Side_Picture", pitScout.Left_Side_Picture);
                                        cmd.Parameters.AddWithValue("@Left_Isometric_Picture",
                                            pitScout.Left_Isometric_Picture);
                                        cmd.Parameters.AddWithValue("@Other_Picture", pitScout.Other_Picture);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            catch (MySqlException exception)
                            {
                                ConsoleWindow.WriteLine(exception.ToString());
                            }
                        }
                        Notifications.ShowInformationMessage("Successfully imported pit scouting data!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet is Required For Importation!", "Internet is Required!", MessageBoxButtons.OK);
            }
        }
    }
}