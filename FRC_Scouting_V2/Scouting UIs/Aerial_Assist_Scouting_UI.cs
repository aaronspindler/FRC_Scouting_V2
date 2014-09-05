using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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

        public void BlankPanel()
        {
            Graphics clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.Silver, 0, 0, 258, 191);
            clearPanelGraphics.Dispose();
            PlotInitialLines();
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

        private void submitDataButton_Click(object sender, EventArgs e)
        {
            UpdateLabels();

            //Write to TextFile
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(saveFileDialog.FileName);
                writer.WriteLine("FRC_Scouting_V2 Match #: " + Convert.ToString(matchNumber));
                writer.WriteLine("Team Name: " + Convert.ToString(FRC_Scouting_V2.Properties.Settings.Default.selectedTeamName));
                writer.WriteLine("Team Number: " + Convert.ToString(FRC_Scouting_V2.Properties.Settings.Default.selectedTeamNumber));
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
            MySql.Data.MySqlClient.MySqlConnection conn;
            string mySqlConnectionString;

            mySqlConnectionString = ("server=127.0.0.1;uid=" + " " + "pwd=12345;database=test;");

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = mySqlConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void Aerial_Assist_UI_Layout_Load(object sender, EventArgs e)
        {
            //Set team colour items
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
        }
    }
}