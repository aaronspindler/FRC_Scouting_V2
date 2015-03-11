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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FRC_Scouting_V2.Models;
using FRC_Scouting_V2.Properties;
using Newtonsoft.Json;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class RecycleRush_GTR_East : Form
    {
        //Variables
        private string currentTeamName;
        private int currentTeamNumber;
        private int startingX;
        private int startingY;
        private int driverRating;
        private List<RecycleRush_Stack> matchStacks = new List<RecycleRush_Stack>();
        private Boolean leftClick = false;

        private readonly string[] teamNameArray = new[]
        {
            "The Circuit Stompers","Red Raider Robotics","Gearheads","Kinetic Knights","Wildcats","THEORY6","Agincourt Lancers","Ice Cubed","Inverse Paradox","Black Scots","Cybergnomes","OP Robotics","RAMAZOIDZ","Paradigm Shift","CougarTech","Xcentrics","DM High Voltage","NACI Robotics","Harfangs","IgKnighters","Tornades","Les Aigles d'Or","Patriotix","Robotronix","FSS Cyber Falcons","Express-O","Scarabot","Tech for Kids","Jag","Bits & Pieces","Cardinal Robotics","W.A.F.F.L.E.S.","MANNING ROBOTICS","Northern Lights Robotics","RoboPanthers","SWC Robotics","RoboRavens","The Coltenoids","Fullmetal Mustangs","The Robo Devils","Fast Eddie Community Robotics","Stormbots","Blizzard","Breaking Bots","Wolverines","Eagles","Titans"
        };

        private readonly int[] teamNumberArray = new[]
        {
            378,578,746,781,886,1241,1246,1305,1325,1815,2013,2056,2185,2198,2228,2340,2852,2935,3117,3173,3386,3387,3530,3550,3710,3986,3988,3990,4015,4248,4252,4476,4627,4704,4718,4732,4783,4825,5031,5036,5051,5076,5094,5428,5596,5652,5719
        };

        public RecycleRush_GTR_East()
        {
            InitializeComponent();
        }

        private void RecycleRush_GTR_East_Load(object sender, EventArgs e)
        {
            scoutingFieldTypeSelectorComboBox.SelectedIndex = 0;
            for (int i = 0; i < teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
            }
        }

        private void scoutingSubmitButton_Click(object sender, EventArgs e)
        {
            scoutingSubmitButton.Enabled = false;

            var match = new RecycleRush_Scout_Match
            {
                Author = Settings.Default.username,
                TimeCreated = DateTime.Now,
                UniqueID = Guid.NewGuid().ToString(),
                Team_Number = currentTeamNumber,
                Team_Name = currentTeamName,
                Match_Number = Convert.ToInt32(scoutingMatchNumberNumericUpDown.Value),
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

            try
            {
                var jsonText = JsonConvert.SerializeObject(match, Formatting.Indented);
                File.WriteAllText(@"C:\Users\xNovax\Desktop\match.json", jsonText);
            }
            catch (Exception exception)
            {
                Console.Write("Error Occured: " + exception.Message);
                ConsoleWindow.AddItem("Error Occured: " + exception.Message);
            }
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
            PlotInitialImage();
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
            scoutingCoopertitionStackCheckBox.Checked = false;


        }
    }
}