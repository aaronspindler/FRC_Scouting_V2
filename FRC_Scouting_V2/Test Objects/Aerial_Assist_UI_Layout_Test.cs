using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2.Test_Items
{
    //@author xNovax
    public partial class Aerial_Assist_UI_Layout_Test : UserControl
    {
        private int autoHighTally;
        private int autoLowTally;
        private int controlledHighTally;
        private int controlledLowTally;
        private int matchNumber = 1;
        private int teamColour;

        public Aerial_Assist_UI_Layout_Test()
        {
            InitializeComponent();
        }

        private void teamColourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamColourComboBox.SelectedIndex == 0)
            {
                teamColour = 0;
            }
            else
            {
                if (teamColourComboBox.SelectedIndex == 1)
                {
                    teamColour = 1;
                }
            }
        }

        public void UpdateLabels()
        {
            autoHighValueDisplay.Text = Convert.ToString(autoHighTally);
            autoLowValueDisplay.Text = Convert.ToString(autoLowTally);
            controlledHighValueDisplay.Text = Convert.ToString(controlledHighTally);
            controlledLowValueDisplay.Text = Convert.ToString(controlledLowTally);
        }

        private void Aerial_Assist_UI_Layout_Test_Load(object sender, EventArgs e)
        {
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
        }

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
        }

        private void autoHighButton_Click(object sender, EventArgs e)
        {
            autoHighTally = autoHighTally + 1;
            UpdateLabels();
        }

        private void autoLowButton_Click(object sender, EventArgs e)
        {
            autoLowTally = autoLowTally + 1;
            UpdateLabels();
        }

        private void controlledHighButton_Click(object sender, EventArgs e)
        {
            controlledHighTally = controlledHighTally + 1;
            UpdateLabels();
        }

        private void controlledLowButton_Click(object sender, EventArgs e)
        {
            controlledLowTally = controlledLowTally + 1;
            UpdateLabels();
        }
    }
}