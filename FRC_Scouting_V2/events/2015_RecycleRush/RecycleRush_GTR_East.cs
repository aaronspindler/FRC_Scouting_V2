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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FRC_Scouting_V2.Models;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class RecycleRush_GTR_East : Form
    {
        //Variables
        UsefulSnippets snippets = new UsefulSnippets();
        private List<RecycleRush_Stack> matchStacks = new List<RecycleRush_Stack>();

        private readonly string[] teamNameArray =
        {
            "The Circuit Stompers", "Red Raider Robotics", "Gearheads", "Kinetic Knights", "Wildcats", "THEORY6",
            "Agincourt Lancers", "Ice Cubed", "Inverse Paradox", "Black Scots", "Cybergnomes", "OP Robotics",
            "RAMAZOIDZ", "Paradigm Shift", "CougarTech", "Xcentrics", "DM High Voltage", "NACI Robotics", "Harfangs",
            "IgKnighters", "Tornades", "Les Aigles d'Or", "Patriotix", "Robotronix", "FSS Cyber Falcons", "Express-O",
            "Scarabot", "Tech for Kids", "Jag", "Bits & Pieces", "Cardinal Robotics", "W.A.F.F.L.E.S.",
            "MANNING ROBOTICS", "Northern Lights Robotics", "RoboPanthers", "SWC Robotics", "RoboRavens",
            "The Coltenoids", "Fullmetal Mustangs", "The Robo Devils", "Fast Eddie Community Robotics", "Stormbots",
            "Blizzard", "Breaking Bots", "Wolverines", "Eagles", "Titans"
        };

        private readonly int[] teamNumberArray =
        {
            378, 578, 746, 781, 886, 1241, 1246, 1305, 1325, 1815, 2013, 2056, 2185, 2198, 2228, 2340, 2852, 2935, 3117,
            3173, 3386, 3387, 3530, 3550, 3710, 3986, 3988, 3990, 4015, 4248, 4252, 4476, 4627, 4704, 4718, 4732, 4783,
            4825, 5031, 5036, 5051, 5076, 5094, 5428, 5596, 5652, 5719
        };

        private string currentTeamName;
        private int currentTeamNumber;
        private int driverRating;
        private string allianceColour = "Unset";
        private Boolean leftClick;
        private int startingX;
        private int startingY;
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        List<RecycleRush_Scout_Match> teamsMatches = new List<RecycleRush_Scout_Match>(); 

        public RecycleRush_GTR_East()
        {
            InitializeComponent();
        }

        private void RecycleRush_GTR_East_Load(object sender, EventArgs e)
        {
            Program.selectedEventName = "RecycleRush_GTR_East";
            scoutingFieldTypeSelectorComboBox.SelectedIndex = 0;
            matchBreakdownFieldTypeComboBox.SelectedIndex = 0;

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
            Program.selectedEventName = "RecycleRush_GTR_East";

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
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Saves");
                string jsonText = JsonConvert.SerializeObject(match, Formatting.Indented);
                string matchLocation = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\RecycleRush_GTR_East_" + Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value) + "_" + currentTeamName + ".json");
                File.WriteAllText(matchLocation, jsonText);
            }
            catch (Exception exception)
            {
                Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.AddItem("Error Occured: " + exception.Message);
                UsefulSnippets.ReportCrash(exception);
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(snippets.MakeMySqlConnectionString());
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string commandText = String.Format("Insert into RecycleRush_GTR_East (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Final_Score_Red,Final_Score_Blue,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');", (snippets.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author, match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number, match.Alliance_Colour, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X, match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone), Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set), Convert.ToInt16(match.Auto_Bin_Set), Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins, match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing), Convert.ToInt16(match.Tele_Tote_Pickup_Upright), Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Tote_Pickup_Sideways), Convert.ToInt16(match.Tele_Bin_Pickup_Upright), Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Bin_Pickup_Sideways), Convert.ToInt16(match.Tele_Human_Station_Load_Totes), Convert.ToInt16(match.Tele_Human_Station_Stack_Totes), Convert.ToInt16(match.Tele_Human_Station_Insert_Litter), Convert.ToInt16(match.Tele_Human_Throwing_Litter), Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls, match.Comments, JsonConvert.SerializeObject(match.Stacks), Convert.ToInt16(match.Coopertition_Set), Convert.ToInt16(match.Coopertition_Stack), match.Final_Score_Red, match.Final_Score_Blue, match.Driver_Rating);
                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.AddItem("Error Occured: " + exception.Message);
                UsefulSnippets.ReportCrash(exception);
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
                ConsoleWindow.AddItem("Error Occured: " + exception.Message);
            }

            if (Home.internetAvailable)
            {
               string url = ("http://www.thebluealliance.com/api/v2/team/frc");
                url = url + Convert.ToString(teamNumberArray[teamSelector.SelectedIndex]);
                string downloadedData;
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id","3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);

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
                    ConsoleWindow.AddItem("Error Message: " + webError.Message);
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
                    var conn = new MySqlConnection(snippets.MakeMySqlConnectionString());
                    MySqlCommand cmd = conn.CreateCommand();
                    MySqlDataReader reader;
                    cmd.CommandText = String.Format("SELECT * FROM RecycleRush_GTR_East WHERE Team_Number = '{0}'", Program.selectedTeamNumber);
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
                            Tele_Human_Station_Insert_Litter = Convert.ToBoolean(reader["Tele_Human_Station_Insert_Litter"]),
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
                    Console.Write("Error Occured: " + exception.Message);
                    ConsoleWindow.AddItem("Error Occured: " + exception.Message);
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

        private void gameManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
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
                ConsoleWindow.AddItem("Error Message: " + exception.Message);
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
                ConsoleWindow.AddItem(exception.ToString());
            }
        }

        private void matchBreakdownMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            matchBreakDownAuthorDisplay.Text = "Author: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Author;
            matchBreakDownTimeCreatedDisplay.Text = "Time: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].TimeCreated;
            matchBreakDownDriveToAutozoneDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Auto_Drive_To_Autozone.ToString();
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
            matchBreakDownFinalScoresRedDisplay.Text = "Red: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Final_Score_Red;
            matchBreakDownFinalScoresBlueDisplay.Text = "Blue: " + teamsMatches[matchBreakdownMatchList.SelectedIndex].Final_Score_Blue;
            matchBreakDownAllianceColourDisplay.Text = teamsMatches[matchBreakdownMatchList.SelectedIndex].Alliance_Colour;
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
            openFileDialog.InitialDirectory = assemblyPath + "\\Saves\\";
            if (Home.internetAvailable)
            {
                if (MessageBox.Show("The importation of these files can take a long time, are you sure you want to continue?", "Are you sure you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var t in openFileDialog.FileNames)
                        {
                            var match = JsonConvert.DeserializeObject<RecycleRush_Scout_Match>(File.ReadAllText(t));
                            try
                            {
                                var conn = new MySqlConnection(snippets.MakeMySqlConnectionString());
                                conn.Open();
                                var cmd = conn.CreateCommand();
                                var commandText = String.Format("Insert into RecycleRush_GTR_East (EntryID,UniqueID,Author,TimeCreated,Team_Number,Team_Name,Match_Number,Alliance_Colour,Robot_Dead,Auto_Starting_X,Auto_Starting_Y,Auto_Drive_To_Autozone,Auto_Robot_Set,Auto_Tote_Set,Auto_Bin_Set,Auto_Stacked_Tote_Set,Auto_Acquired_Step_Bins,Auto_Fouls,Auto_Did_Nothing,Tele_Tote_Pickup_Upright,Tele_Tote_Pickup_Upside_Down,Tele_Tote_Pickup_Sideways,Tele_Bin_Pickup_Upright,Tele_Bin_Pickup_Upside_Down,Tele_Bin_Pickup_Sideways,Tele_Human_Station_Load_Totes,Tele_Human_Station_Stack_Totes,Tele_Human_Station_Insert_Litter,Tele_Human_Throwing_Litter,Tele_Pushed_Litter_To_Landfill,Tele_Fouls,Comments,Stacks,Coopertition_Set,Coopertition_Stack,Final_Score_Red,Final_Score_Blue,Driver_Rating) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}');", (snippets.GetNumberOfRowsInATable() + 1), match.UniqueID, match.Author, match.TimeCreated, match.Team_Number, match.Team_Name, match.Match_Number, match.Alliance_Colour, Convert.ToInt16(match.Robot_Dead), match.Auto_Starting_X, match.Auto_Starting_Y, Convert.ToInt16(match.Auto_Drive_To_Autozone), Convert.ToInt16(match.Auto_Robot_Set), Convert.ToInt16(match.Auto_Tote_Set), Convert.ToInt16(match.Auto_Bin_Set), Convert.ToInt16(match.Auto_Stacked_Tote_Set), match.Auto_Acquired_Step_Bins, match.Auto_Fouls, Convert.ToInt16(match.Auto_Did_Nothing), Convert.ToInt16(match.Tele_Tote_Pickup_Upright), Convert.ToInt16(match.Tele_Tote_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Tote_Pickup_Sideways), Convert.ToInt16(match.Tele_Bin_Pickup_Upright), Convert.ToInt16(match.Tele_Bin_Pickup_Upside_Down), Convert.ToInt16(match.Tele_Bin_Pickup_Sideways), Convert.ToInt16(match.Tele_Human_Station_Load_Totes), Convert.ToInt16(match.Tele_Human_Station_Stack_Totes), Convert.ToInt16(match.Tele_Human_Station_Insert_Litter), Convert.ToInt16(match.Tele_Human_Throwing_Litter), Convert.ToInt16(match.Tele_Pushed_Litter_To_Landfill), match.Tele_Fouls, match.Comments, JsonConvert.SerializeObject(match.Stacks), Convert.ToInt16(match.Coopertition_Set), Convert.ToInt16(match.Coopertition_Stack), match.Final_Score_Red, match.Final_Score_Blue, match.Driver_Rating);
                                cmd.CommandText = commandText;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (MySqlException exception)
                            {
                                Console.Write(exception.ToString());
                                ConsoleWindow.AddItem(exception.ToString());
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
    }
}