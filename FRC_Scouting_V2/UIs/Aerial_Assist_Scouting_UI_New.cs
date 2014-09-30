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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;

namespace FRC_Scouting_V2.UIs
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI_New : UserControl
    {
        //Variables
        private readonly UsefulSnippets snippets = new UsefulSnippets();
        private int autoBallPickup;
        private int autoBallPickupMiss;
        private int autoHighGoal;
        private int autoHighMiss;
        private int autoLowGoal;
        private int autoLowMiss;
        private int controlledBallPickup;
        private int controlledBallPickupMiss;
        private int controlledHighGoal;
        private int controlledHighMiss;
        private int controlledLowGoal;
        private int controlledLowMiss;
        private int hotGoal;
        private int hotMiss;
        private int matchNumber;
        private int passToOtherRobot;
        private int passToOtherRobotMiss;
        private int pickupFromHuman;
        private int pickupFromHumanMiss;
        private int successfulTruss;
        private int totalGoal;
        private int totalGoodControl;
        private int totalMiss;
        private int totalMissControl;
        private int tripleAssistGoal;
        private int tripleAssistMiss;
        private int unsuccessfulTruss;
        private int xStarting;
        private int yStarting;
        private int didRobotDie;
        private string comments;

        public Aerial_Assist_Scouting_UI_New()
        {
            InitializeComponent();
        }

        public void BlankPanel()
        {
            Graphics clearPanelGraphics = startingLocationPanel.CreateGraphics();
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
            Graphics initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 330, 228);

            //Drawing field lines
            initGraphics.DrawRectangle(fineBluePen, 4, 4, 108, 220);
            initGraphics.DrawRectangle(fineWhitePen, 116, 4, 98, 220);
            initGraphics.DrawRectangle(fineRedPen, 218, 4, 108, 220);
            initGraphics.DrawLine(blackpen, 165, 0, 165, 228);
            initGraphics.Dispose();
        }

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            BlankPanel();
            PlotInitialLines();
            Graphics g = startingLocationPanel.CreateGraphics();
            xStarting = Convert.ToInt32(e.X) - 3;
            yStarting = Convert.ToInt32(e.Y) - 3;
            g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(new Point(xStarting, yStarting), new Size(5, 5)));
            startingLocationXYDisplay.Text = ("X: " + xStarting + " Y: " + yStarting);
        }

        private void startingLocationPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }

        private void Aerial_Assist_Scouting_UI_Load(object sender, EventArgs e)
        {
            Settings.Default.currentTableName = ("AerialAssist_RahChaCha");
            Settings.Default.Save();
        }

        private void autoHighGoalButton_Click(object sender, EventArgs e)
        {
            autoHighGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void autoLowGoalButton_Click(object sender, EventArgs e)
        {
            autoLowGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void controlledHighGoalButton_Click(object sender, EventArgs e)
        {
            controlledHighGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void controlledLowGoalButton_Click(object sender, EventArgs e)
        {
            controlledLowGoal++;
            totalGoal++;
            UpdateLabels();
        }

        private void hotGoalButton_Click(object sender, EventArgs e)
        {
            hotGoal++;
            totalGoal++;
            UpdateLabels();
        }


        private void autoHighMissButton_Click(object sender, EventArgs e)
        {
            autoHighMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void autoLowMissButton_Click(object sender, EventArgs e)
        {
            autoLowMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void controlledHighMissButton_Click(object sender, EventArgs e)
        {
            controlledHighMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void controlledLowMissButton_Click(object sender, EventArgs e)
        {
            controlledLowMiss++;
            totalMiss++;
            UpdateLabels();
        }

        private void hotMissButton_Click(object sender, EventArgs e)
        {
            hotMiss++;
            totalMiss++;
            UpdateLabels();
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

        private void autoBallPickupButton_Click(object sender, EventArgs e)
        {
            autoBallPickup++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void controlledBallPickupButton_Click(object sender, EventArgs e)
        {
            controlledBallPickup++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void pickupFromHumanButton_Click(object sender, EventArgs e)
        {
            pickupFromHuman++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void passToOtherBotButton_Click(object sender, EventArgs e)
        {
            passToOtherRobot++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void successfulTrussButton_Click(object sender, EventArgs e)
        {
            successfulTruss++;
            totalGoodControl++;
            UpdateLabels();
        }

        private void autoBallPickupMissButton_Click(object sender, EventArgs e)
        {
            autoBallPickupMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void controlledBallPickupMissButton_Click(object sender, EventArgs e)
        {
            controlledBallPickupMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void pickupFromHumanMissButton_Click(object sender, EventArgs e)
        {
            pickupFromHumanMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void passToOtherBotMissButton_Click(object sender, EventArgs e)
        {
            passToOtherRobotMiss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void unsuccessfulTrussButton_Click(object sender, EventArgs e)
        {
            unsuccessfulTruss++;
            totalMissControl++;
            UpdateLabels();
        }

        private void submitDataButton_Click(object sender, EventArgs e)
        {
            if (Settings.Default.allowExportToTextFile)
            {
                //Write to TextFile
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(saveFileDialog.FileName);
                    writer.WriteLine("Time Created: " + snippets.GetCurrentTime());
                    writer.WriteLine("Scouted By: " + Settings.Default.username);
                    writer.WriteLine("FRC_Scouting_V2 Match #: " + Convert.ToString(matchNumber));
                    //writer.WriteLine("Did the robot die?: " + didRobotDie);
                    writer.WriteLine("END OF FILE");
                    writer.Close();
                }
            }

            //MySQL Database
            //MySQL Database Connection Info
            string mySqlConnectionString = snippets.MakeMySqlConnectionString();
            try
            {
                //Creating the connection to the database and opening the connection
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};
                conn.Open();

                //Checking if the connection is successful
                if (conn.Ping())
                {
                    Console.WriteLine("The connection to your database has been made successfully.");
                }

                //Creating the MySQLCommand object
                MySqlCommand cmd = conn.CreateCommand();

                //Trying to create the table
                try
                {
                    string createTable =
                        String.Format(
                            "CREATE TABLE `{0}` (`EntryID` int(11) NOT NULL DEFAULT '0',`TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamName` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Default',`TeamColour` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Not Selected',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighGoal` int(11) NOT NULL DEFAULT '0',`AutoHighMiss` int(11) NOT NULL DEFAULT '0',`AutoLowGoal` int(11) NOT NULL DEFAULT '0',`AutoLowMiss` int(11) NOT NULL DEFAULT '0',`ControlledHighGoal` int(11) NOT NULL DEFAULT '0',`ControlledHighMiss` int(11) NOT NULL DEFAULT '0',`ControlledLowGoal` int(11) NOT NULL DEFAULT '0',`ControlledLowMiss` int(11) NOT NULL DEFAULT '0',`HotGoals` int(11) NOT NULL DEFAULT '0',`HotGoalMiss` int(11) NOT NULL DEFAULT '0',`3AssistGoal` int(11) NOT NULL DEFAULT '0',`3AssistMiss` int(11) NOT NULL DEFAULT '0',`AutoBallPickup` int(11) NOT NULL DEFAULT '0',`AutoBallPickupMiss` int(11) NOT NULL DEFAULT '0',`ControlledBallPickup` int(11) NOT NULL DEFAULT '0',`ControlledBallPickupMiss` int(11) NOT NULL DEFAULT '0',`PickupFromHuman` int(11) NOT NULL DEFAULT '0',`MissedPickupFromHuman` int(11) NOT NULL DEFAULT '0',`PassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`MissedPassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`SuccessfulTruss` int(11) NOT NULL DEFAULT '0',`UnsuccessfulTruss` int(11) NOT NULL DEFAULT '0',`StartingX` int(11) NOT NULL DEFAULT '0',`StartingY` int(11) NOT NULL DEFAULT '0',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',`Comments` varchar(300) COLLATE utf8_unicode_ci DEFAULT NULL,PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci",
                            Settings.Default.currentTableName);
                    cmd.CommandText = createTable;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("The table: " + Settings.Default.currentTableName + " has been created.");
                    //end of creating the table
                }
                catch (MySqlException createException)
                {
                    Console.WriteLine("If there is an error it is most likely because the table is already made.");
                    Console.WriteLine("Errorcode: " + createException.ErrorCode);
                    Console.WriteLine(createException.Message);
                }

                //Submit data into the database
                //string insertDataString = String.Format("Insert into {0} (EntryID,TeamName,TeamNumber,TeamColour,MatchNumber,AutoHighTally,AutoLowTally,ControlledHigHTally,ControlledLowTally,HotGoalTally,AutoPickup,ControlledPickup,MissedPickups,StartingLocationX,StartingLocationY,Comments,DidRobotDie) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');",Settings.Default.currentTableName, (snippets.GetNumberOfRowsInATable() + 1),Settings.Default.selectedTeamName,Settings.Default.selectedTeamNumber, teamColour, matchNumber, autoHighTally, autoLowTally,controlledHighTally, controlledLowTally, hotGoalTally, autoPickupTally, controlledPickupTally,missedPickupsTally, xStarting, yStarting, comments, didRobotDieINT);
                //cmd.CommandText = insertDataString;
                //cmd.ExecuteNonQuery();

                Console.WriteLine("Data has been inserted into the database!");

                //Closing the connection
                conn.Close();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
            }
        }

        private void matchNumberUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberUpDown.Value);
        }

        private void didRobotDieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (didRobotDieCheckBox.Checked == true)
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

        private void commentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (commentsTextBox.Text != (""))
            {
                comments = commentsTextBox.Text;
            }
        }
    }
}