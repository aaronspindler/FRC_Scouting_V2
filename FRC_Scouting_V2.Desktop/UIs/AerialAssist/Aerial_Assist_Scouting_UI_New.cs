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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using UsefulSnippets;

namespace FRC_Scouting_V2.UIs
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI_New : UserControl
    {
        //Variables
        private int autoBallPickup;

        private int autoBallPickupMiss;
        private int autoHighGoal;
        private int autoHighMiss;
        private int autoLowGoal;
        private int autoLowMiss;
        private bool autoMovement;
        private string comments;
        private int controlledBallPickup;
        private int controlledBallPickupMiss;
        private int controlledHighGoal;
        private int controlledHighMiss;
        private int controlledLowGoal;
        private int controlledLowMiss;
        private int didRobotDie;
        private int driverRating;
        private int hotGoal;
        private int hotMiss;
        private int matchNumber = 1;
        private int passToOtherRobot;
        private int passToOtherRobotMiss;
        private int pickupFromHuman;
        private int pickupFromHumanMiss;
        private int successfulTruss;
        private bool tableCreated;
        private string teamColour;
        private int totalGoal;
        private int totalGoodControl;
        private int totalMiss;
        private int totalMissControl;
        private int tripleAssistGoal;
        private int tripleAssistMiss;
        private int unsuccessfulTruss;
        private int xStarting;
        private int yStarting;

        public Aerial_Assist_Scouting_UI_New()
        {
            InitializeComponent();
        }

        public void BlankPanel()
        {
            var clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.Silver, 0, 0, 370, 252);
            clearPanelGraphics.Dispose();
            PlotInitialLines();
        }

        public void PlotInitialLines()
        {
            var blackpen = new Pen(Color.Black, 4);
            var fineBluePen = new Pen(Color.Blue, 2);
            var fineWhitePen = new Pen(Color.White, 2);
            var fineRedPen = new Pen(Color.Red, 2);
            var initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 330, 231);

            //Drawing field lines
            initGraphics.DrawRectangle(fineBluePen, 4, 4, 108, 223);
            initGraphics.DrawRectangle(fineWhitePen, 116, 4, 98, 223);
            initGraphics.DrawRectangle(fineRedPen, 218, 4, 108, 223);
            initGraphics.DrawLine(blackpen, 165, 0, 165, 231);
            initGraphics.Dispose();
        }

        public void UpdateLabels()
        {
            autoHighGoalDisplay.Text = Convert.ToString(autoHighGoal);
            autoLowGoalDisplay.Text = Convert.ToString(autoLowGoal);
            controlledHighGoalDisplay.Text = Convert.ToString(controlledHighGoal);
            controlledLowGoalDisplay.Text = Convert.ToString(controlledLowGoal);
            hotGoalDisplay.Text = Convert.ToString(hotGoal);
            autoHighMissDisplay.Text = Convert.ToString(autoHighMiss);
            autoLowMissDisplay.Text = Convert.ToString(autoLowMiss);
            controlledHighMissDisplay.Text = Convert.ToString(controlledHighMiss);
            controlledLowMissDisplay.Text = Convert.ToString(controlledLowMiss);
            hotMissDisplay.Text = Convert.ToString(hotMiss);
            totalGoalDisplay.Text = Convert.ToString(totalGoal);
            totalMissesDisplay.Text = Convert.ToString(totalMiss);
            tripleAssistGoalDisplay.Text = Convert.ToString(tripleAssistGoal);
            tripleAssistMissDisplay.Text = Convert.ToString(tripleAssistMiss);
            autoBallPickupDisplay.Text = Convert.ToString(autoBallPickup);
            controlledBallPickupDisplay.Text = Convert.ToString(controlledBallPickup);
            pickupFromHumanDisplay.Text = Convert.ToString(pickupFromHuman);
            passToOtherBotDisplay.Text = Convert.ToString(passToOtherRobot);
            successfulTrussDisplay.Text = Convert.ToString(successfulTruss);
            autoBallPickupMissDisplay.Text = Convert.ToString(autoBallPickupMiss);
            controlledBallPickupMissDisplay.Text = Convert.ToString(controlledBallPickupMiss);
            missedPickupFromHumanDisplay.Text = Convert.ToString(pickupFromHumanMiss);
            missedPassToOtherBotDisplay.Text = Convert.ToString(passToOtherRobotMiss);
            unsuccessfulTrussDisplay.Text = Convert.ToString(unsuccessfulTruss);
            totalGoodDisplay.Text = Convert.ToString(totalGoodControl);
            totalBallMissesDisplay.Text = Convert.ToString(totalMissControl);
        }

        private void Aerial_Assist_Scouting_UI_Load(object sender, EventArgs e)
        {
        }

        private void autoBallPickupButton_Click(object sender, EventArgs e)
        {
            autoBallPickup++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void autoBallPickupMissButton_Click(object sender, EventArgs e)
        {
            autoBallPickupMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void autoHighGoalButton_Click(object sender, EventArgs e)
        {
            autoHighGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void autoHighMissButton_Click(object sender, EventArgs e)
        {
            autoHighMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void autoLowGoalButton_Click(object sender, EventArgs e)
        {
            autoLowGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void autoLowMissButton_Click(object sender, EventArgs e)
        {
            autoLowMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void commentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (commentsTextBox.Text != "")
            {
                comments = commentsTextBox.Text;
            }

            if (commentsTextBox.Text.Contains(";"))
            {
                Notifications.ErrorOccured(
                    "You cannot use semi-colons in the comments. If used the export will be unsuccessful.");
            }
        }

        private void controlledBallPickupButton_Click(object sender, EventArgs e)
        {
            controlledBallPickup++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void controlledBallPickupMissButton_Click(object sender, EventArgs e)
        {
            controlledBallPickupMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void controlledHighGoalButton_Click(object sender, EventArgs e)
        {
            controlledHighGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void controlledHighMissButton_Click(object sender, EventArgs e)
        {
            controlledHighMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void controlledLowGoalButton_Click(object sender, EventArgs e)
        {
            controlledLowGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void controlledLowMissButton_Click(object sender, EventArgs e)
        {
            controlledLowMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void didRobotDieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (didRobotDieCheckBox.Checked)
            {
                didRobotDie = 1;
            }
            else
            {
                if (didRobotDieCheckBox.Checked == false)
                {
                    didRobotDie = 0;
                }
            }
        }

        private void hotGoalButton_Click(object sender, EventArgs e)
        {
            hotGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void hotMissButton_Click(object sender, EventArgs e)
        {
            hotMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void matchNumberUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberUpDown.Value);
        }

        private void passToOtherBotButton_Click(object sender, EventArgs e)
        {
            passToOtherRobot++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void passToOtherBotMissButton_Click(object sender, EventArgs e)
        {
            passToOtherRobotMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void pickupFromHumanButton_Click(object sender, EventArgs e)
        {
            pickupFromHuman++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void pickupFromHumanMissButton_Click(object sender, EventArgs e)
        {
            pickupFromHumanMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            BlankPanel();
            PlotInitialLines();
            var g = startingLocationPanel.CreateGraphics();
            xStarting = Convert.ToInt32(e.X) - 3;
            yStarting = Convert.ToInt32(e.Y) - 3;
            g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(new Point(xStarting, yStarting), new Size(5, 5)));
            startingLocationXYDisplay.Text = "X: " + xStarting + " Y: " + yStarting;
        }

        private void startingLocationPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }

        private void submitDataButton_Click(object sender, EventArgs e)
        {
            submitDataButton.Enabled = false;
            if (Settings.Default.allowExportToTextFile)
            {
                //Write to TextFile
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(saveFileDialog.FileName);
                    writer.WriteLine("==========================================================");
                    writer.WriteLine("-===============+ Human Readable Portion +===============-");
                    writer.WriteLine("==========================================================");
                    writer.WriteLine("Time Created: " + Time.GetCurrentTime());
                    writer.WriteLine("Scouted By: " + Settings.Default.username);
                    writer.WriteLine("Match #: " + Convert.ToString(matchNumber));
                    writer.WriteLine("Did the robot die?: " + Convert.ToBoolean(didRobotDie));
                    writer.WriteLine("Team Colour: " + teamColour);
                    writer.WriteLine("Team Name: " + Program.selectedTeamName);
                    writer.WriteLine("Team Number: " + Program.selectedTeamNumber);
                    writer.WriteLine("#########################################################");
                    writer.WriteLine("Auto High: Goal: " + Convert.ToString(autoHighGoal) + " Miss: " +
                                     Convert.ToString(autoHighMiss));
                    writer.WriteLine("Auto Low: Goal: " + Convert.ToString(autoLowGoal) + " Miss: " +
                                     Convert.ToString(autoLowMiss));
                    writer.WriteLine("Controlled High: Goal: " + Convert.ToString(controlledHighGoal) + " Miss: " +
                                     Convert.ToString(controlledHighMiss));
                    writer.WriteLine("Controlled Low: Goal: " + Convert.ToString(controlledLowGoal) + " Miss: " +
                                     Convert.ToString(controlledLowMiss));
                    writer.WriteLine("Hot: Goal: " + Convert.ToString(hotGoal) + " Miss: " + Convert.ToString(hotMiss));
                    writer.WriteLine("3-Assist: Goal: " + Convert.ToString(tripleAssistGoal) + " Miss: " +
                                     Convert.ToString(tripleAssistMiss));
                    writer.WriteLine("Auto Pickup: Successful: " + Convert.ToString(autoBallPickup) + " Unsuccessful: " +
                                     Convert.ToString(autoBallPickupMiss));
                    writer.WriteLine("Controlled Pickup: Successful: " + Convert.ToString(controlledBallPickup) +
                                     " Unsuccessful: " + Convert.ToString(controlledBallPickupMiss));
                    writer.WriteLine("Pickup From Human: Successful: " + Convert.ToString(pickupFromHuman) +
                                     " Unsuccessful: " + Convert.ToString(pickupFromHumanMiss));
                    writer.WriteLine("Pass To Another Robot: Successful: " + Convert.ToString(passToOtherRobot) +
                                     " Unsuccessful: " + Convert.ToString(passToOtherRobotMiss));
                    writer.WriteLine("Truss Shot: Successful: " + Convert.ToString(successfulTruss) + " Unsuccessful: " +
                                     Convert.ToString(unsuccessfulTruss));
                    writer.WriteLine("Starting Location: X: " + Convert.ToString(xStarting) + " Y: " +
                                     Convert.ToString(yStarting));
                    writer.WriteLine("Driver Rating: " + driverRating);
                    writer.WriteLine("Auto Movement: " + Convert.ToBoolean(autoMovement));
                    writer.WriteLine("Comments: " + Convert.ToString(comments));
                    writer.WriteLine("#########################################################");
                    writer.WriteLine("=========================================================");
                    writer.WriteLine("-=============+ Computer Readable Portion +=============-");
                    writer.WriteLine("=========================================================");
                    writer.WriteLine(Convert.ToString(Program.selectedTeamNumber));
                    writer.WriteLine(Convert.ToString(Program.selectedTeamName));
                    writer.WriteLine(Convert.ToString(teamColour));
                    writer.WriteLine(Convert.ToString(matchNumber));
                    writer.WriteLine(Convert.ToString(autoHighGoal));
                    writer.WriteLine(Convert.ToString(autoHighMiss));
                    writer.WriteLine(Convert.ToString(autoLowGoal));
                    writer.WriteLine(Convert.ToString(autoLowMiss));
                    writer.WriteLine(Convert.ToString(controlledHighGoal));
                    writer.WriteLine(Convert.ToString(controlledHighMiss));
                    writer.WriteLine(Convert.ToString(controlledLowGoal));
                    writer.WriteLine(Convert.ToString(controlledLowMiss));
                    writer.WriteLine(Convert.ToString(hotGoal));
                    writer.WriteLine(Convert.ToString(hotMiss));
                    writer.WriteLine(Convert.ToString(tripleAssistGoal));
                    writer.WriteLine(Convert.ToString(tripleAssistMiss));
                    writer.WriteLine(Convert.ToString(autoBallPickup));
                    writer.WriteLine(Convert.ToString(autoBallPickupMiss));
                    writer.WriteLine(Convert.ToString(controlledBallPickup));
                    writer.WriteLine(Convert.ToString(controlledBallPickupMiss));
                    writer.WriteLine(Convert.ToString(pickupFromHuman));
                    writer.WriteLine(Convert.ToString(pickupFromHumanMiss));
                    writer.WriteLine(Convert.ToString(passToOtherRobot));
                    writer.WriteLine(Convert.ToString(passToOtherRobotMiss));
                    writer.WriteLine(Convert.ToString(successfulTruss));
                    writer.WriteLine(Convert.ToString(unsuccessfulTruss));
                    writer.WriteLine(Convert.ToString(xStarting));
                    writer.WriteLine(Convert.ToString(yStarting));
                    writer.WriteLine(Convert.ToBoolean(didRobotDie));
                    writer.WriteLine(Convert.ToInt16(driverRating));
                    writer.WriteLine(Convert.ToBoolean(autoMovement));
                    writer.WriteLine(Convert.ToString(comments));
                    writer.WriteLine("END OF FILE");
                    writer.Close();
                }
            }

            //MySQL Database
            //MySQL Database Connection Info
            var mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
            try
            {
                //Creating the connection to the database and opening the connection
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};
                conn.Open();

                //Checking if the connection is successful
                if (conn.Ping())
                {
                    ConsoleWindow.WriteLine("The connection to your database has been made successfully.");
                }

                //Creating the MySQLCommand object
                var cmd = conn.CreateCommand();

                if (tableCreated == false)
                {
                    //Trying to create the table
                    try
                    {
                        var createTable =
                            string.Format(
                                "CREATE TABLE `{0}` (`EntryID` int(11) NOT NULL DEFAULT '0',`TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamName` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Default',`TeamColour` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Not Selected',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighGoal` int(11) NOT NULL DEFAULT '0',`AutoHighMiss` int(11) NOT NULL DEFAULT '0',`AutoLowGoal` int(11) NOT NULL DEFAULT '0',`AutoLowMiss` int(11) NOT NULL DEFAULT '0',`ControlledHighGoal` int(11) NOT NULL DEFAULT '0',`ControlledHighMiss` int(11) NOT NULL DEFAULT '0',`ControlledLowGoal` int(11) NOT NULL DEFAULT '0',`ControlledLowMiss` int(11) NOT NULL DEFAULT '0',`HotGoals` int(11) NOT NULL DEFAULT '0',`HotGoalMiss` int(11) NOT NULL DEFAULT '0',`3AssistGoal` int(11) NOT NULL DEFAULT '0',`3AssistMiss` int(11) NOT NULL DEFAULT '0',`AutoBallPickup` int(11) NOT NULL DEFAULT '0',`AutoBallPickupMiss` int(11) NOT NULL DEFAULT '0',`ControlledBallPickup` int(11) NOT NULL DEFAULT '0',`ControlledBallPickupMiss` int(11) NOT NULL DEFAULT '0',`PickupFromHuman` int(11) NOT NULL DEFAULT '0',`MissedPickupFromHuman` int(11) NOT NULL DEFAULT '0',`PassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`MissedPassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`SuccessfulTruss` int(11) NOT NULL DEFAULT '0',`UnsuccessfulTruss` int(11) NOT NULL DEFAULT '0',`StartingX` int(11) NOT NULL DEFAULT '0',`StartingY` int(11) NOT NULL DEFAULT '0',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',`DriverRating` int(11) NOT NULL DEFAULT '0',`AutoMovement` tinyint(4) NOT NULL DEFAULT '0',`Comments` varchar(300) COLLATE utf8_unicode_ci DEFAULT NULL,PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci",
                                Program.selectedEventName);
                        cmd.CommandText = createTable;
                        cmd.ExecuteNonQuery();
                        ConsoleWindow.WriteLine("The table: " + Program.selectedEventName + " has been created.");
                        //end of creating the table
                    }
                    catch (MySqlException createException)
                    {
                        ConsoleWindow.WriteLine("If there is an error it is most likely because the table is already made.");
                        ConsoleWindow.WriteLine("Errorcode: " + createException.ErrorCode);
                        ConsoleWindow.WriteLine(createException.Message);
                    }
                    tableCreated = true;
                }

                //Submit data into the database
                var insertDataString =
                    string.Format(
                        "Insert into {0} (EntryID,TeamNumber,TeamName,TeamColour,MatchNumber,AutoHighGoal,AutoHighMiss, AutoLowGoal, AutoLowMiss, ControlledHighGoal, ControlledHighMiss, ControlledLowGoal, ControlledLowMiss, HotGoals, HotGoalMiss, 3AssistGoal, 3AssistMiss, AutoBallPickup, AutoBallPickupMiss, ControlledBallPickup, ControlledBallPickupMiss, PickupFromHuman, MissedPickupFromHuman, PassToAnotherRobot, MissedPassToAnotherRobot, SuccessfulTruss, UnsuccessfulTruss, StartingX, StartingY, DidRobotDie, DriverRating, AutoMovement, Comments) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}');",
                        Program.selectedEventName, MySQLMethods.GetNumberOfRowsInATable() + 1,
                        Program.selectedTeamNumber, Program.selectedTeamName, teamColour, matchNumber,
                        autoHighGoal, autoHighMiss, autoLowGoal, autoLowMiss, controlledHighGoal, controlledHighMiss,
                        controlledLowGoal, controlledLowMiss, hotGoal, hotMiss, tripleAssistGoal, tripleAssistMiss,
                        autoBallPickup, autoBallPickupMiss, controlledBallPickup, controlledBallPickupMiss,
                        pickupFromHuman, pickupFromHumanMiss, passToOtherRobot, passToOtherRobotMiss, successfulTruss,
                        unsuccessfulTruss, xStarting, yStarting, didRobotDie, driverRating,
                        Convert.ToInt16(autoMovement), comments);
                cmd.CommandText = insertDataString;
                cmd.ExecuteNonQuery();

                ConsoleWindow.WriteLine("Data has been inserted into the database!");

                //Closing the connection
                conn.Close();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
            Notifications.ShowInformationMessage("You have successfully inserted your scouting data for Match #: " +
                                                 matchNumber);

            //Clearing the values after you submit the data
            autoHighGoal = 0;
            autoHighMiss = 0;
            autoLowGoal = 0;
            autoLowMiss = 0;
            controlledHighGoal = 0;
            controlledHighMiss = 0;
            controlledLowGoal = 0;
            controlledLowMiss = 0;
            hotGoal = 0;
            hotMiss = 0;
            tripleAssistGoal = 0;
            tripleAssistMiss = 0;
            autoBallPickup = 0;
            autoBallPickupMiss = 0;
            controlledBallPickup = 0;
            controlledBallPickupMiss = 0;
            pickupFromHuman = 0;
            pickupFromHumanMiss = 0;
            passToOtherRobot = 0;
            passToOtherRobotMiss = 0;
            successfulTruss = 0;
            unsuccessfulTruss = 0;
            BlankPanel();
            didRobotDie = 0;
            didRobotDieCheckBox.Checked = false;
            matchNumberUpDown.Value++;
            totalGoal = 0;
            totalMiss = 0;
            totalGoodControl = 0;
            totalMissControl = 0;
            xStarting = 0;
            yStarting = 0;
            startingLocationXYDisplay.Text = "X: 0 Y: 0";
            comments = "";
            commentsTextBox.Text = "Comments: Any other information that may be needed";
            autoMovement = false;
            autonomousMovementCheckBox.Checked = false;
            driverRating = 0;
            driverRatingButton1.Enabled = true;
            driverRatingButton1.Checked = false;
            driverRatingButton2.Enabled = true;
            driverRatingButton2.Checked = false;
            driverRatingButton3.Enabled = true;
            driverRatingButton3.Checked = false;
            driverRatingButton4.Enabled = true;
            driverRatingButton4.Checked = false;
            UpdateLabels();

            submitDataButton.Enabled = true;
        }

        private void successfulTrussButton_Click(object sender, EventArgs e)
        {
            successfulTruss++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void teamColourSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamColourSelector.SelectedIndex == 0)
            {
                teamColour = "Red";
            }
            else
            {
                if (teamColourSelector.SelectedIndex == 1)
                {
                    teamColour = "Blue";
                }
            }
        }

        private void tripleAssistGoals_Click(object sender, EventArgs e)
        {
            tripleAssistGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void tripleAssistMisses_Click(object sender, EventArgs e)
        {
            tripleAssistMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void unsuccessfulTrussButton_Click(object sender, EventArgs e)
        {
            unsuccessfulTruss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void autonomousMovementCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autonomousMovementCheckBox.Checked)
            {
                autoMovement = true;
            }
            else
            {
                if (autonomousMovementCheckBox.Checked == false)
                {
                    autoMovement = false;
                }
            }
        }

        private void driverRatingButton1_CheckedChanged(object sender, EventArgs e)
        {
            driverRatingButton1.Enabled = true;
            driverRatingButton2.Enabled = true;
            driverRatingButton3.Enabled = true;
            driverRatingButton4.Enabled = true;

            if (driverRatingButton1.Checked)
            {
                driverRating = 1;
                driverRatingButton2.Enabled = false;
                driverRatingButton3.Enabled = false;
                driverRatingButton4.Enabled = false;
            }
        }

        private void driverRatingButton2_CheckedChanged(object sender, EventArgs e)
        {
            driverRatingButton1.Enabled = true;
            driverRatingButton2.Enabled = true;
            driverRatingButton3.Enabled = true;
            driverRatingButton4.Enabled = true;

            if (driverRatingButton2.Checked)
            {
                driverRating = 2;
                driverRatingButton1.Enabled = false;
                driverRatingButton3.Enabled = false;
                driverRatingButton4.Enabled = false;
            }
        }

        private void driverRatingButton3_CheckedChanged(object sender, EventArgs e)
        {
            driverRatingButton1.Enabled = true;
            driverRatingButton2.Enabled = true;
            driverRatingButton3.Enabled = true;
            driverRatingButton4.Enabled = true;

            if (driverRatingButton3.Checked)
            {
                driverRating = 3;
                driverRatingButton1.Enabled = false;
                driverRatingButton2.Enabled = false;
                driverRatingButton4.Enabled = false;
            }
        }

        private void driverRatingButton4_CheckedChanged(object sender, EventArgs e)
        {
            driverRatingButton1.Enabled = true;
            driverRatingButton2.Enabled = true;
            driverRatingButton3.Enabled = true;
            driverRatingButton4.Enabled = true;

            if (driverRatingButton4.Checked)
            {
                driverRating = 4;
                driverRatingButton1.Enabled = false;
                driverRatingButton2.Enabled = false;
                driverRatingButton3.Enabled = false;
            }
        }
    }
}