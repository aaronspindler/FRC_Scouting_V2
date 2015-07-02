//*********************************Licence***************************************
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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FRC_Scouting_V2.Models;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using UsefulSnippets;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class RecycleRush_TroyAthens : Form
    {
        private readonly string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        private readonly List<RecycleRush_Stack> matchStacks = new List<RecycleRush_Stack>();

        private readonly string[] teamNameArray =
         {
                "Killer Bees", "Hammerheads", "Da Bears", "Las Guerrillas", "Steel Armadillos", "RoboRavens1",
                "EngiNERDs", "RedTails", "Ecorse Robo Raiders", "The Village Bulldogs", "TurboTrojans", "Crushing Crusaders",
                "House of Cards", "RoboJackets", "Byting Bulldogs", "RoboRavens2", "Blackhawks", "The Blue Devils",
                "Dynomite", "Majestic Eagles", "ELECTROPANTHERS", "The Panthers", "Trobots", "Shock and Awe-sum",
                "Kingston Robo-Cards", "Spartronics", "Lakers", "Knights", "Sparks", "Vi-Bots", "Bronco Bots",
                "The Mighty CavBots", "Robocats", "Hillman Gearheads", "Harper Woods Pioneers", "CyberCats",
                "District 5517", "Fitzgerald Spartans", "Cougars", "Flock of Nerds", "Heroes Alliance Flint" 
        };

        private readonly int[] teamNumberArray =
        {
            33, 226, 247, 469, 818, 1188, 2337, 2591, 2676, 3096, 3302, 3398, 3534, 3538, 3539, 3548, 3619,
            4130, 4380, 4811, 4815, 4840, 4854, 4961, 4994,5048, 5053, 5065, 5073, 5167, 5201,
            5214, 5217, 5223, 5239, 5436, 5517, 5555, 5650, 5662, 5774
        };

        private readonly List<RecycleRush_Scout_Match> teamsMatches = new List<RecycleRush_Scout_Match>();
        private string allianceColour = "Unset";

        private string currentTeamName;
        private string Team_Name;
        private string scoutingPosition;
        private String OfficialEventName;
        private int currentTeamNumber;
        private int Team_Number;
        private int driverRating;
        private Boolean leftClick;
        private int startingX;
        private int startingY;

        public RecycleRush_TroyAthens()
        {
            InitializeComponent();
        }

        private void RecycleRush_TroyAthens_Load(object sender, EventArgs e)
        {
            Program.selectedEventName = "RecycleRush_TroyAthens";
            OfficialEventName = "2015mitry";
            scoutingFieldTypeSelectorComboBox.SelectedIndex = 0;
            matchBreakdownFieldTypeComboBox.SelectedIndex = 1;

            for (int i = 0; i < teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
                teamComparisonTeam1Selector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
                teamComparisonTeam2Selector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
            }
        }

        private void scoutingSubmitButton_Click(object sender, EventArgs e)
        {
            scoutingSubmitButton.Enabled = false;
            Program.selectedEventName = "RecycleRush_TroyAthens";
            int teamNo = Convert.ToInt32(teamNumberBeingScoutedNumericUpDown.Value);
            string teamName = currentTeamName;
            try { teamName = teamNameArray[Array.IndexOf(teamNumberArray, teamNo)]; }
            catch (Exception) { teamName = TheBlueAlliance.Teams.GetTeamInformation("frc" + teamNo).nickname; }
            int DS = Convert.ToInt32(scoutingPositionNumericUpDown.Value);
            string sP = allianceColour + DS;
            int autonScoreAprox = calcuateThisRobotsAutonScore();
            int teleopScoreAprox = calcuateThisRobotsTeleopScore();
            int coopScoreAprox = calculateThisRobotsCoopertitionScore();
            int totalScoreAprox = calculateThisRobotsTotalScore();

            var match = new RecycleRush_Scout_Match
            {
                Author = Settings.Default.username,
                TimeCreated = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"),
                UniqueID = Guid.NewGuid().ToString(),
                Team_Number = teamNo,
                Team_Name = teamName,
                scoutingPosition = sP,
                Robot_Dead = scoutingDidTheRobotDieCheckBox.Checked,
                Auto_Starting_X = startingX,
                Auto_Starting_Y = startingY,
                Auto_Drive_To_Autozone = scoutingDriveToAutoZoneCheckBox.Checked,
                Auto_Can_Burgeled = scoutingCanBurgeledCheckbox.Checked,
                Auto_Cans_Grabbed = Convert.ToInt32(numCansGrabbedNumbericUpDown.Value),
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
                Tele_Human_Throwing_Litter = Convert.ToInt32(litterThrownNumUpDown.Value),
                Tele_Pushed_Litter_To_Landfill = Convert.ToInt32(litterPushedToLandFillNumUpDown.Value),
                Tele_Fouls = Convert.ToInt32(scoutingTeleFoulPointsNumUpDown.Value),
                Comments = scoutingCommentsRichTextBox.Text,
                Stacks = matchStacks,
                Coopertition_Set = scoutingCoopertitionSetCheckBox.Checked,
                Coopertition_Stack = scoutingCoopertitionStackCheckBox.Checked,
                Driver_Rating = driverRating,
                Aprox_Robots_Auton_Score = Convert.ToInt32(autonScoreAprox),
                Aprox_Robots_Teleop_Score = Convert.ToInt32(teleopScoreAprox),
                Aprox_Robots_Coopertition_Score = Convert.ToInt32(coopScoreAprox),
                Aprox_Robots_Total_Score = Convert.ToInt32(totalScoreAprox)
            };

            if (match.Comments.Contains(";"))
            {
                match.Comments = Regex.Replace(match.Comments, "[;]", string.Empty);
            }

            try
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves");
                string jsonText = JsonConvert.SerializeObject(match, Formatting.Indented);
                string matchLocation = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\RecycleRush_TroyAthens_" + "Match" + Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value) + "_" + sP + "_" + teamNo + ".json");
                File.WriteAllText(matchLocation, jsonText);
            }
            catch (Exception exception)
            {
                Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception);
            }

            try
            {
                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string commandText = String.Format("Insert into RecycleRush_TroyAthens_Matches (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,scoutingPositon,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');", (MySQLMethods.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author, match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X, match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone), Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set), Convert.ToInt16(match.Auto_Bin_Set), Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins, match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing), Convert.ToInt16(match.Tele_Tote_Pickup_Upright), Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Tote_Pickup_Sideways), Convert.ToInt16(match.Tele_Bin_Pickup_Upright), Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Bin_Pickup_Sideways), Convert.ToInt16(match.Tele_Human_Station_Load_Totes), Convert.ToInt16(match.Tele_Human_Station_Stack_Totes), Convert.ToInt16(match.Tele_Human_Station_Insert_Litter), Convert.ToInt16(match.Tele_Human_Throwing_Litter), Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls, match.Comments, JsonConvert.SerializeObject(match.Stacks), Convert.ToInt16(match.Coopertition_Set), Convert.ToInt16(match.Coopertition_Stack), match.Driver_Rating);
                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                //Do Nothing:
                /* Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                Notifications.ReportCrash(exception); */
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
                Console.WriteLine(exception.ToString());
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

            try
            {
                object teamImage = Resources.ResourceManager.GetObject("FRC" + teamNumberArray[teamSelector.SelectedIndex]);
                teamInformationLogo.Image = (Image)teamImage;
            }
            catch (Exception exception)
            {
                Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
            }

            if (Home.internetAvailable)
            {
                string url = ("http://www.thebluealliance.com/api/v2/team/frc");
                url = url + Convert.ToString(teamNumberArray[teamSelector.SelectedIndex]);
                string downloadedData;
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);

                try
                {
                    downloadedData = (wc.DownloadString(url));
                    var deserializedData = JsonConvert.DeserializeObject<AerialAssist_RahChaCha.TeamInformationJSONData>(downloadedData);

                    teamInformationTeamLocation.Text = "Team Location: " + Convert.ToString(deserializedData.location);
                    teamInformationRookieYear.Text = "Rookie Year: " + Convert.ToString(deserializedData.rookie_year);
                    teamInformationWebsiteLinkLabel.Text = Convert.ToString(deserializedData.website);
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                    ConsoleWindow.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamInformationTeamLocation.Text = "Team Location: ";
                teamInformationRookieYear.Text = "Rookie Year: ";
                teamInformationWebsiteLinkLabel.Text = "";
            }

            if (Home.internetAvailable)
            {
                try
                {
                    var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                    MySqlCommand cmd = conn.CreateCommand();
                    MySqlDataReader reader;
                    cmd.CommandText = String.Format("SELECT * FROM RecycleRush_TroyAthens_Matches WHERE Team_Number = '{0}'", Program.selectedTeamNumber);
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var match = new RecycleRush_Scout_Match
                        {
                            Author = reader["Author"].ToString(),
                            TimeCreated = reader["TimeCreated"].ToString(),
                            Match_Number = Convert.ToInt32(reader["Match_Number"]),
                            scoutingPosition = Convert.ToString(reader["stringPosition"]),
                            Robot_Dead = Convert.ToBoolean(reader["Robot_Dead"]),
                            Auto_Starting_X = Convert.ToInt32(reader["Auto_Starting_X"]),
                            Auto_Starting_Y = Convert.ToInt32(reader["Auto_Starting_Y"]),
                            Auto_Drive_To_Autozone = Convert.ToBoolean(reader["Auto_Drive_To_Autozone"]),
                            Auto_Can_Burgeled = Convert.ToBoolean(reader["Auto_Can_Burgeled"]),
                            Auto_Cans_Grabbed = Convert.ToInt32(reader["Auto_Cans_Grabbed"]),
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
                            Tele_Human_Station_Insert_Litter = Convert.ToBoolean(reader["Tele_Human_Station_Insert_Litter"]),
                            Tele_Human_Throwing_Litter = Convert.ToInt32(reader["Tele_Human_Throwing_Litter"]),
                            Tele_Pushed_Litter_To_Landfill = Convert.ToInt32(reader["Tele_Pushed_Litter_To_Landfill"]),
                            Tele_Fouls = Convert.ToInt32(reader["Tele_Fouls"]),
                            Comments = Convert.ToString(reader["Comments"]),
                            Stacks = JsonConvert.DeserializeObject<List<RecycleRush_Stack>>(reader["Stacks"].ToString()),
                            Coopertition_Set = Convert.ToBoolean(reader["Coopertition_Set"]),
                            Coopertition_Stack = Convert.ToBoolean(reader["Coopertition_Stack"]),
                            Driver_Rating = Convert.ToInt32(reader["Driver_Rating"]),
                            Aprox_Robots_Auton_Score = Convert.ToInt32(calcuateThisRobotsAutonScore()),
                            Aprox_Robots_Teleop_Score = Convert.ToInt32(calcuateThisRobotsTeleopScore()),
                            Aprox_Robots_Coopertition_Score = Convert.ToInt32(calculateThisRobotsCoopertitionScore()),
                            Aprox_Robots_Total_Score = Convert.ToInt32(calculateThisRobotsTotalScore())
                        };

                        teamsMatches.Add(match);

                        matchBreakdownMatchList.Items.Add("Match Number: " + reader["Match_Number"]);
                    }
                    conn.Close();
                }
                catch (MySqlException exception)
                {
                    Console.Write("Error Occured: " + exception.Message);
                    ConsoleWindow.WriteLine("Error Occured: " + exception.Message);
                }
            }
        }

        private void ResetScoutingInterface()
        {
            scoutingDriveToAutoZoneCheckBox.Checked = false;
            scoutingCanBurgeledCheckbox.Checked = false;
            numCansGrabbedLabel.Visible = false;
            numCansGrabbedNumbericUpDown.Visible = false;
            scoutingRobotSetCheckBox.Checked = false;
            scoutingToteSetCheckBox.Checked = false;
            scoutingBinSetCheckBox.Checked = false;
            scoutingStackedToteSetCheckBox.Checked = false;
            scoutingAcquiredStepBinsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingAutoFoulsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingDidNothingCheckBox.Checked = false;
            scoutingCommentsRichTextBox.Text = "Comments: ";
            scoutingMatchNumberNumericUpDown.Value = scoutingMatchNumberNumericUpDown.Value + 1;
            teamNumberBeingScoutedNumericUpDown.Value = 0;
            scoutingPositionNumericUpDown.Value = scoutingPositionNumericUpDown.Value;
            scoutingDriverRatingButton1.Enabled = true;
            scoutingDriverRatingButton2.Enabled = true;
            scoutingDriverRatingButton3.Enabled = true;
            scoutingDriverRatingButton4.Enabled = true;
            driverRating = 0;
            scoutingDidTheRobotDieCheckBox.Checked = false;
            scoutingTotePickupUprightCheckbox.Checked = false;
            scoutingTotePickupUpsideDownCheckBox.Checked = false;
            scoutingTotePickupSideWaysCheckBox.Checked = false;
            scoutingBinPickupUprightCheckBox.Checked = false;
            scoutingBinPickupUpsideDownCheckBox.Checked = false;
            scoutingBinPickupSidewaysCheckBox.Checked = false;
            scoutingHumanStationLoadTotesCheckBox.Checked = false;
            scoutingHumanStationStackTotesCheckBox.Checked = false;
            scoutingHumanStationInsertLitterCheckBox.Checked = false;
            scoutingTeleFoulPointsNumUpDown.Value = Convert.ToDecimal(0);
            scoutingCoopertitionSetCheckBox.Checked = false;
            scoutingAllianceColourRedCheckBox.Enabled = true;
            scoutingAllianceColourBlueCheckBox.Enabled = true;
            scoutingTeleFoulPointsNumUpDown.Value = 0;
            litterThrownNumUpDown.Value = 0;
            litterPushedToLandFillNumUpDown.Value = 0;
            allianceColour = "";
            scoutingPosition = "";
        }

        public void ResetMatchBreakdownInterface()
        {
            matchBreakdownMatchList.Items.Clear();
            teamsMatches.Clear();

            matchBreakDownAuthorDisplay.Text = "Author:";
            matchBreakDownTimeCreatedDisplay.Text = "Time Created:";
            matchBreakDownDriveToAutozoneDisplay.Text = "";
            matchBreakDownCanBurgeledDisplay.Text = "";
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
                Console.WriteLine("Error Message: " + exception.Message);
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
                Console.WriteLine(exception.ToString());
                ConsoleWindow.WriteLine(exception.ToString());
            }
        }

        private void matchBreakdownMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            matchBreakDownAuthorDisplay.Text = "Author: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Author;
            matchBreakDownTimeCreatedDisplay.Text = "Time: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].TimeCreated;
            matchBreakDownDriveToAutozoneDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Drive_To_Autozone.ToString();
            matchBreakDownCanBurgeledDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Can_Burgeled.ToString();
            matchBreakDownRobotSetDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Robot_Set.ToString();
            matchBreakDownToteSetDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Tote_Set.ToString();
            matchBreakDownStackedToteSetDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Stacked_Tote_Set.ToString();
            matchBreakDownBinSetDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Bin_Set.ToString();
            matchBreakDownBinsOffStepDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Acquired_Step_Bins.ToString();
            matchBreakDownAutoFoulsDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Fouls.ToString();
            matchBreakDownAutoDidNothingDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Did_Nothing.ToString();
            matchBreakDownTeleTotePickupUprightDisplay.Text = "Upright: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Tote_Pickup_Upright;
            matchBreakDownTeleTotePickupUpsideDownDisplay.Text = "Upside Down: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Tote_Pickup_Upside_Down;
            matchBreakDownTeleTotePickupSidewaysDisplay.Text = "Sideways: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Tote_Pickup_Sideways;
            matchBreakDownTeleBinPickupUprightDisplay.Text = "Upright: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Bin_Pickup_Upright;
            matchBreakDownTeleBinPickupUpsideDownDisplay.Text = "Upside Down :" + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Bin_Pickup_Upside_Down;
            matchBreakDownTeleBinPickupSidewaysDisplay.Text = "Sideways: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Bin_Pickup_Sideways;
            matchBreakDownTeleHumanStationLoadingTotesDisplay.Text = "Loading Totes: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Human_Station_Load_Totes;
            matchBreakDownTeleHumanStationStackTotesDisplay.Text = "Inserting Litter: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Human_Station_Stack_Totes;
            matchBreakDownTeleThrowingLitterDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Human_Throwing_Litter.ToString();
            matchBreakDownTelePushingLitterDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Pushed_Litter_To_Landfill.ToString();
            matchBreakDownTeleFoulsDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Tele_Fouls.ToString();
            matchBreakDownDriverRatingDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Driver_Rating.ToString();
            matchBreakDownCoopertitionSetDisplay.Text = "Set: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Coopertition_Set;
            matchBreakDownCoopertitionStackDisplay.Text = "Stack: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Coopertition_Stack;
            matchBreakDownCommentsTextBox.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Comments;

            matchBreakdownStacksGridView.Rows.Clear();
            for (int i = 0; i < teamsMatches[matchBreakdownMatchList.SelectedIndex].Stacks.Count; i++)
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
            openFileDialog.InitialDirectory = assemblyPath + "\\Saves\\";
            if (Home.internetAvailable)
            {
                if (MessageBox.Show("The importation of these files can take a long time, are you sure you want to continue?", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string t in openFileDialog.FileNames)
                        {
                            var match = JsonConvert.DeserializeObject<RecycleRush_Scout_Match>(File.ReadAllText(t));
                            try
                            {
                                var conn = new MySqlConnection(MySQLMethods.MakeMySqlConnectionString());
                                conn.Open();
                                MySqlCommand cmd = conn.CreateCommand();
                                string commandText = String.Format("Insert into RecycleRush_TroyAthens_Matches (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');", (MySQLMethods.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author, match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number, match.scoutingPosition, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X, match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone), Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set), Convert.ToInt16(match.Auto_Bin_Set), Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins, match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing), Convert.ToInt16(match.Tele_Tote_Pickup_Upright), Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Tote_Pickup_Sideways), Convert.ToInt16(match.Tele_Bin_Pickup_Upright), Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Bin_Pickup_Sideways), Convert.ToInt16(match.Tele_Human_Station_Load_Totes), Convert.ToInt16(match.Tele_Human_Station_Stack_Totes), Convert.ToInt16(match.Tele_Human_Station_Insert_Litter), Convert.ToInt16(match.Tele_Human_Throwing_Litter), Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls, match.Comments, JsonConvert.SerializeObject(match.Stacks), Convert.ToInt16(match.Coopertition_Set), Convert.ToInt16(match.Coopertition_Stack), match.Driver_Rating);
                                cmd.CommandText = commandText;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (MySqlException exception)
                            {
                                Console.Write(exception.ToString());
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

        private int calcuateThisRobotsAutonScore()
        {
            int score = 0;
            if (scoutingRobotSetCheckBox.Checked) { score += 4; }
            if (scoutingToteSetCheckBox.Checked) { score += 6; }
            if (scoutingStackedToteSetCheckBox.Checked) { score += 20; }
            score -= Convert.ToInt32(scoutingAutoFoulsNumUpDown.Value);
            return score;
        }

        private int calcuateThisRobotsTeleopScore()
        {
            int score = 0;
            for (int i = 0; i < matchStacks.Count; i++)
            {
                RecycleRush_Stack curr = matchStacks[i];
                int localScore = 0;
                if (curr.Did_They_Make_The_Stack)
                {
                    int height = curr.Stack_Height;
                    localScore += height * 2;
                    if (curr.Bin_On_Top && curr.Litter_In_Bin) { localScore += (height * 4) + 6; }
                    else if (curr.Bin_On_Top) { localScore = +(height * 4); }
                }
                score += localScore;
            }
            score += Convert.ToInt32(litterPushedToLandFillNumUpDown.Value);
            score += (Convert.ToInt32(litterThrownNumUpDown.Value)) * 4;
            score -= Convert.ToInt32(scoutingTeleFoulPointsNumUpDown.Value);
            return score;
        }

        private int calculateThisRobotsCoopertitionScore()
        {
            int score = 0;
            if (scoutingCoopertitionSetCheckBox.Checked) { score += 20; }
            if (scoutingCoopertitionStackCheckBox.Checked) { score += 40; }
            return score;
        }

        private int calculateThisRobotsTotalScore()
        {
            return calcuateThisRobotsAutonScore() + calcuateThisRobotsTeleopScore() + calculateThisRobotsCoopertitionScore();
        }

        private void previousMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            previousMatchInfo form = new previousMatchInfo(OfficialEventName, (Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value)) - 1);
            form.Show();
        }

        private void currentMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currMatchInfo form = new currMatchInfo(OfficialEventName, (Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value)));
            form.Show();
        }

        private void nextMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nextMatchInfo form = new nextMatchInfo(OfficialEventName, (Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value)) + 1);
            form.Show();
        }

        private void matchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matchInfoByNumber form = new matchInfoByNumber(OfficialEventName);
            form.Show();
        }

        private void scoutingCanBurgeledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            numCansGrabbedLabel.Visible = true;
            numCansGrabbedNumbericUpDown.Visible = true;
            numCansGrabbedNumbericUpDown.Value = 0;
        }
    }
}