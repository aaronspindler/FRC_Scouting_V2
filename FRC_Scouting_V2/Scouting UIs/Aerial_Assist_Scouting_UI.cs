
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

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI : UserControl
    {
        //Variables
        private int autoHighTally;
        private int autoLowTally;
        private int autoPickupTally;
        private int controlledHighTally;
        private int controlledLowTally;
        private int controlledPickupTally;
        private int hotGoalTally;
        private int matchNumber = 1;
        private int missedPickupsTally;
        private string teamColour;
        private int xStarting;
        private int yStarting;

        public Aerial_Assist_Scouting_UI()
        {
            InitializeComponent();
        }

        public void BlankPanel()
        {
            Graphics clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.Silver, 0, 0, 258, 191);
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
            //Set team colour items
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
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

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
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

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            startingLocationPanel.Refresh();
            BlankPanel();
            Graphics g = startingLocationPanel.CreateGraphics();
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

            //Write to TextFile
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(saveFileDialog.FileName);
                writer.WriteLine("FRC_Scouting_V2 Match #: " + Convert.ToString(matchNumber));
                writer.WriteLine("Team Name: " + Convert.ToString(Settings.Default.selectedTeamName));
                writer.WriteLine("Team Number: " + Convert.ToString(Settings.Default.selectedTeamNumber));
                writer.WriteLine("Team Color During Match: " + teamColour);
                writer.WriteLine("=====================================");
                writer.WriteLine("Points Scored");
                writer.WriteLine("=====================================");
                writer.WriteLine("Auto High Tally: " + Convert.ToString(autoHighTally));
                writer.WriteLine("Auto Low Tally: " + Convert.ToString(autoLowTally));
                writer.WriteLine("Manually Controlled High Tally: " + Convert.ToString(controlledHighTally));
                writer.WriteLine("Manually Controlled Low Tally: " + Convert.ToString(controlledLowTally));
                writer.WriteLine("Hot Goals Scored: " + Convert.ToString(hotGoalTally));
                writer.WriteLine("=====================================");
                writer.WriteLine("Ball Control");
                writer.WriteLine("=====================================");
                writer.WriteLine("Autonomous Ball Pickups: " + Convert.ToString(autoPickupTally));
                writer.WriteLine("Controlled Ball Pickups: " + Convert.ToString(controlledPickupTally));
                writer.WriteLine("Missed Pickups/Loads: " + Convert.ToString(missedPickupsTally));
                writer.Close();
            }
            else
            {
                MessageBox.Show("File not Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //MySQL Database
            MySqlConnection conn;
            var databaseIP = Settings.Default.databaseIP;
            var databasePort = Settings.Default.databasePort;
            var databaseName = Settings.Default.databaseName;
            var databaseUsername = Settings.Default.databaseUsername;
            var databasePassword = Settings.Default.databasePassword;
            var mySqlConnectionString = String.Format("Server={0};Port={1};Database={2};Uid={3};password={4};",
                databaseIP, databasePort, databaseName, databaseUsername, databasePassword);
            try
            {
                conn = new MySqlConnection {ConnectionString = mySqlConnectionString};
                conn.Open();

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
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
            UpdateLabels();
            BlankPanel();
        }
    }
}