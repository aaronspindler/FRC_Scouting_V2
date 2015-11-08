#region License

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

#endregion License

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using UsefulSnippets;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI : UserControl
    {
        //Variables
        private int autoHighTally;

        private int autoLowTally;
        private int autoPickupTally;
        private string comments = ("");
        private int controlledHighTally;
        private int controlledLowTally;
        private int controlledPickupTally;
        private bool didRobotDie;
        private int didRobotDieINT;
        private int hotGoalTally;
        private int matchNumber = 1;
        private int missedPickupsTally;
        private string teamColour;
        private int xStarting;
        private int yStarting;

        /// <summary>
        ///     Old Version of Match Scouting UI for Aerial Assist
        /// </summary>
        public Aerial_Assist_Scouting_UI()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Removes Any Drawings On Field, then Repaints The Field Markers
        /// </summary>
        public void BlankPanel()
        {
            var clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.Silver, 0, 0, 258, 191);
            clearPanelGraphics.Dispose();
            PlotInitialLines();
        }

        //Getting the number of rows in the table
        public int CountRowsInDatabase()
        {
            var numberOfRows = 0;
            try
            {
                var mySqlConnectionString = MySQLMethods.MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM " + Program.selectedEventName, conn))
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

        public void PlotInitialLines()
        {
            var blackpen = new Pen(Color.Black, 4);
            var fineBluePen = new Pen(Color.Blue, 2);
            var fineWhitePen = new Pen(Color.White, 2);
            var fineRedPen = new Pen(Color.Red, 2);
            var initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 258, 191);

            //Drawing field lines
            initGraphics.DrawRectangle(fineBluePen, 4, 4, 76, 183);
            initGraphics.DrawRectangle(fineWhitePen, 84, 4, 92, 183);
            initGraphics.DrawRectangle(fineRedPen, 180, 4, 76, 183);
            initGraphics.DrawLine(blackpen, 129, 0, 129, 191);
            initGraphics.Dispose();
        }

        //Updates all of the labels when you click a plus or minus button
        public void UpdateLabels()
        {
            autoHighTallyDisplay.Text = Convert.ToString(autoHighTally);
            autoLowTallyDisplay.Text = Convert.ToString(autoLowTally);
            controlledHighTallyDisplay.Text = Convert.ToString(controlledHighTally);
            controlledLowTallyDisplay.Text = Convert.ToString(controlledLowTally);
            hotGoalTallyDisplay.Text = Convert.ToString(hotGoalTally);
            autoPickupTallyDisplay.Text = Convert.ToString(autoPickupTally);
            controlledPickupTallyDisplay.Text = Convert.ToString(controlledPickupTally);
            missedPickupsTallyDisplay.Text = Convert.ToString(missedPickupsTally);
        }

        private void Aerial_Assist_UI_Layout_Load(object sender, EventArgs e)
        {
            //Setting toolTips
            var ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(commentsRichTextBox,
                "Enter any comments you have about that match that may not fit into any other boxes.");
            ToolTip1.SetToolTip(startingLocationPanel,
                "Just click on this panel to set where the robot's starting location is");
            ToolTip1.SetToolTip(clearAndAdvanceButton,
                "Click this button once you have submitted your data so that it will clear all of the boxes and advance you to the next match.");
            ToolTip1.SetToolTip(submitDataButton, "Click once you have finished scouting a match");

            currentTimeDisplay.Text = ("Current Time: " + Time.GetCurrentTime());
            timer.Start();

            if (Settings.Default.showQuestionButtons)
            {
                teamColourHelpButton.Visible = true;
                matchNumberHelpButton.Visible = true;
                autoHighPointsHelpButton.Visible = true;
                missedAutoHighHelpButton.Visible = true;
                autoLowPointsHelpButton.Visible = true;
                missedAutoLowHelpButton.Visible = true;
                controlledHighPointsHelpButton.Visible = true;
                missedControlledHighHelpButton.Visible = true;
                controlledLowPointsHelpButton.Visible = true;
                missedControlledLowHelpButton.Visible = true;
                hotGoalsHelpButton.Visible = true;
                missedHotGoalHelpButton.Visible = true;
                autoBallPickupHelpButton.Visible = true;
                controlledBallPickupHelpButton.Visible = true;
                missedPickupHelpButton.Visible = true;
                ballReceivedFromHumanHelpButton.Visible = true;
                didRobotDieHelpButton.Visible = true;
                startingLocationHelpButton.Visible = true;
            }
            else
            {
                if (Settings.Default.showQuestionButtons == false)
                {
                    teamColourHelpButton.Visible = false;
                    matchNumberHelpButton.Visible = false;
                    autoHighPointsHelpButton.Visible = false;
                    missedAutoHighHelpButton.Visible = false;
                    autoLowPointsHelpButton.Visible = false;
                    missedAutoLowHelpButton.Visible = false;
                    controlledHighPointsHelpButton.Visible = false;
                    missedControlledHighHelpButton.Visible = false;
                    controlledLowPointsHelpButton.Visible = false;
                    missedControlledLowHelpButton.Visible = false;
                    hotGoalsHelpButton.Visible = false;
                    missedHotGoalHelpButton.Visible = false;
                    autoBallPickupHelpButton.Visible = false;
                    controlledBallPickupHelpButton.Visible = false;
                    missedPickupHelpButton.Visible = false;
                    ballReceivedFromHumanHelpButton.Visible = false;
                    didRobotDieHelpButton.Visible = false;
                    startingLocationHelpButton.Visible = false;
                }
            }
        }

        private void autoBallPickupHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Autonomous ball pickups that the robot can do!");
        }

        private void autoHighMinusButton_Click(object sender, EventArgs e)
        {
            autoHighTally = autoHighTally - 1;
            UpdateLabels();
        }

        private void autoHighPlusButton_Click(object sender, EventArgs e)
        {
            autoHighTally = autoHighTally + 1;
            UpdateLabels();
        }

        private void autoHighPointsHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Autonomous High goals that the robot has scored! ");
        }

        private void autoLowMinusButton_Click(object sender, EventArgs e)
        {
            autoLowTally = autoLowTally - 1;
            UpdateLabels();
        }

        private void autoLowPlusButton_Click(object sender, EventArgs e)
        {
            autoLowTally = autoLowTally + 1;
            UpdateLabels();
        }

        private void autoLowPointsHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Autonomous Low goals that the robot has scored!");
        }

        private void autoPickupMinusButton_Click(object sender, EventArgs e)
        {
            autoPickupTally = autoPickupTally - 1;
            UpdateLabels();
        }

        private void autoPickupPlusButton_Click(object sender, EventArgs e)
        {
            autoPickupTally = autoPickupTally + 1;
            UpdateLabels();
        }

        private void ballReceivedFromHumanHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of balls the robot received from human players.");
        }

        private void clearAndAdvanceButton_Click(object sender, EventArgs e)
        {
            autoHighTally = 0;
            autoLowTally = 0;
            autoPickupTally = 0;
            controlledHighTally = 0;
            controlledLowTally = 0;
            controlledPickupTally = 0;
            hotGoalTally = 0;
            matchNumber = matchNumber + 1;
            matchNumberNumericUpDown.Value = matchNumber;
            missedPickupsTally = 0;
            xStarting = 0;
            yStarting = 0;
            comments = ("");
            commentsRichTextBox.Text = ("");
            UpdateLabels();
            BlankPanel();
            didRobotDie = false;
            didRobotDieCheckBox.Checked = false;
            didRobotDieINT = 0;
            contextDisplayLabel.Text = ("");
        }

        private void commentsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (commentsRichTextBox.Text != (""))
            {
                comments = commentsRichTextBox.Text;
            }
        }

        private void controlledBallPickupHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Controlled ball pickups that the robot can do!");
        }

        private void controlledHighMinusButton_Click(object sender, EventArgs e)
        {
            controlledHighTally = controlledHighTally - 1;
            UpdateLabels();
        }

        private void controlledHighPlusButton_Click(object sender, EventArgs e)
        {
            controlledHighTally = controlledHighTally + 1;
            UpdateLabels();
        }

        private void controlledHighPointsHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Controlled High goals that the robot has scored!");
        }

        private void controlledLowMinusButton_Click(object sender, EventArgs e)
        {
            controlledLowTally = controlledLowTally - 1;
            UpdateLabels();
        }

        private void controlledLowPlusButton_Click(object sender, EventArgs e)
        {
            controlledLowTally = controlledLowTally + 1;
            UpdateLabels();
        }

        private void controlledLowPointsHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Controlled low goals that the robot has scored!");
        }

        private void controllPickupMinusButton_Click(object sender, EventArgs e)
        {
            controlledPickupTally = controlledPickupTally - 1;
            UpdateLabels();
        }

        private void controllPickupPlusButton_Click(object sender, EventArgs e)
        {
            controlledPickupTally = controlledPickupTally + 1;
            UpdateLabels();
        }

        private void didRobotDieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (didRobotDieCheckBox.Checked)
            {
                didRobotDie = true;
                didRobotDieINT = 1;
            }
            else
            {
                if (didRobotDieCheckBox.Checked == false)
                {
                    didRobotDie = false;
                    didRobotDieINT = 0;
                }
            }
        }

        private void didRobotDieHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use this to record if the robot stopped working / died during a match. This is to record full loss of control.");
        }

        private void hotGoalMinusButton_Click(object sender, EventArgs e)
        {
            hotGoalTally = hotGoalTally - 1;
            UpdateLabels();
        }

        private void hotGoalPlusButton_Click(object sender, EventArgs e)
        {
            hotGoalTally = hotGoalTally + 1;
            UpdateLabels();
        }

        private void hotGoalsHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of Hot goals that the robot has scored!");
        }

        private void matchNumberHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the up down box to enter the match number that you are on so that you can piece together data in the future and figure out the teams that played together.");
        }

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
        }

        private void missedAutoHighHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed autonomous high shots!");
        }

        private void missedAutoLowHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed autonomous low shots!");
        }

        private void missedControlledHighHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed controlled high shots!");
        }

        private void missedControlledLowHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed controlled low shots!");
        }

        private void missedHotGoalHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed hot goal shots!");
        }

        private void missedPickupHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use the buttons to the left to increase / decrease the number of missed ball pickups that the has done!");
        }

        private void missedPickupsMinusButton_Click(object sender, EventArgs e)
        {
            missedPickupsTally = missedPickupsTally - 1;
            UpdateLabels();
        }

        private void missedPickupsPlusButton_Click(object sender, EventArgs e)
        {
            missedPickupsTally = missedPickupsTally + 1;
            UpdateLabels();
        }

        private void startingLocationHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Click on the field below where the robot you are scouting was located at the beginning of the match.");
        }

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            startingLocationPanel.Refresh();
            BlankPanel();
            var g = startingLocationPanel.CreateGraphics();
            xStarting = Convert.ToInt32(e.X) - 3;
            yStarting = Convert.ToInt32(e.Y) - 3;
            g.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(new Point(xStarting, yStarting), new Size(5, 5)));
        }

        private void startingLocationPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }

        private void submitDataButton_Click(object sender, EventArgs e)
        {
            UpdateLabels();

            if (Settings.Default.allowExportToTextFile)
            {
                //Write to TextFile
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(saveFileDialog.FileName);
                    writer.WriteLine("Time Created: " + Time.GetCurrentTime());
                    writer.WriteLine("FRC_Scouting_V2 Match #: " + Convert.ToString(matchNumber));
                    writer.WriteLine("Did the robot die?: " + didRobotDie);
                    writer.WriteLine("===============================================");
                    writer.WriteLine("Team Name: " + Convert.ToString(Program.selectedTeamName));
                    writer.WriteLine("Team Number: " + Convert.ToString(Program.selectedTeamNumber));
                    writer.WriteLine("Team Color During Match: " + teamColour);
                    writer.WriteLine("===============================================");
                    writer.WriteLine();
                    writer.WriteLine("Points Scored");
                    writer.WriteLine("Auto High Tally: " + Convert.ToString(autoHighTally));
                    writer.WriteLine("Auto Low Tally: " + Convert.ToString(autoLowTally));
                    writer.WriteLine("Manually Controlled High Tally: " + Convert.ToString(controlledHighTally));
                    writer.WriteLine("Manually Controlled Low Tally: " + Convert.ToString(controlledLowTally));
                    writer.WriteLine("Hot Goals Scored: " + Convert.ToString(hotGoalTally));
                    writer.WriteLine("===============================================");
                    writer.WriteLine("Ball Control");
                    writer.WriteLine("Autonomous Ball Pickups: " + Convert.ToString(autoPickupTally));
                    writer.WriteLine("Controlled Ball Pickups: " + Convert.ToString(controlledPickupTally));
                    writer.WriteLine("Missed Pickups/Loads: " + Convert.ToString(missedPickupsTally));
                    writer.WriteLine("===============================================");
                    writer.WriteLine("Comments");
                    writer.WriteLine(Convert.ToString(comments));
                    writer.WriteLine("===============================================");
                    writer.WriteLine("Starting Location");
                    writer.WriteLine("X Starting Location: " + Convert.ToString(xStarting));
                    writer.WriteLine("Y Starting Location: " + Convert.ToString(yStarting));
                    writer.WriteLine("===============================================");
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

                //Trying to create the table
                try
                {
                    var createTable =
                        string.Format(
                            "CREATE TABLE `{0}` (`EntryID` int(11) NOT NULL,`TeamName` varchar(45) NOT NULL DEFAULT 'Default', `TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamColour` varchar(45) NOT NULL DEFAULT 'Default',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighTally` int(11) NOT NULL DEFAULT '0',`AutoLowTally` int(11) NOT NULL DEFAULT '0',`ControlledHighTally` int(11) NOT NULL DEFAULT '0',`ControlledLowTally` int(11) NOT NULL DEFAULT '0',`HotGoalTally` int(11) NOT NULL DEFAULT '0',`AutoPickup` int(11) NOT NULL DEFAULT '0',`ControlledPickup` int(11) NOT NULL DEFAULT '0',`MissedPickups` int(11) NOT NULL DEFAULT '0',`StartingLocationX` int(11) NOT NULL DEFAULT '0',`StartingLocationY` int(11) NOT NULL DEFAULT '0',`Comments` varchar(45) DEFAULT 'No Comment',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8",
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

                //Submit data into the database
                var insertDataString =
                    string.Format(
                        "Insert into {0} (EntryID,TeamName,TeamNumber,TeamColour,MatchNumber,AutoHighTally,AutoLowTally,ControlledHigHTally,ControlledLowTally,HotGoalTally,AutoPickup,ControlledPickup,MissedPickups,StartingLocationX,StartingLocationY,Comments,DidRobotDie) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');",
                        Program.selectedEventName, (CountRowsInDatabase() + 1),
                        Program.selectedTeamName,
                        Program.selectedTeamNumber, teamColour, matchNumber, autoHighTally, autoLowTally,
                        controlledHighTally, controlledLowTally, hotGoalTally, autoPickupTally, controlledPickupTally,
                        missedPickupsTally, xStarting, yStarting, comments, didRobotDieINT);

                cmd.CommandText = insertDataString;
                cmd.ExecuteNonQuery();

                ConsoleWindow.WriteLine("Data has been inserted into the database!");
                contextDisplayLabel.Text = ("Your data has been inserted into the database!");

                //Closing the connection
                conn.Close();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                contextDisplayLabel.Text = ("An error has occured!");
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
        }

        private void teamColourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (teamColourComboBox.SelectedIndex)
            {
                case 0:
                    teamColour = ("Blue");
                    break;

                case 1:
                    teamColour = ("Red");
                    break;
            }
        }

        private void teamColourHelpButton_Click(object sender, EventArgs e)
        {
            Notifications.ShowInformationMessage(
                "Use this drop down menu to select the colour of the team you are currently scouting.");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTimeDisplay.Text = ("Current Time: " + Time.GetCurrentTime());
        }
    }
}