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

        private void Aerial_Assist_UI_Layout_Test_Load(object sender, EventArgs e)
        {
            //Set team colour items
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
        }

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
        }

        private void autoHighNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            autoHighTally = Convert.ToInt32(autoHighNumUpDown.Value);
        }

        private void autoLowNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            autoLowTally = Convert.ToInt32(autoLowNumUpDown.Value);
        }

        private void controlHighNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controlledHighTally = Convert.ToInt32(controlHighNumUpDown.Value);
        }

        private void controlLowNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            controlledLowTally = Convert.ToInt32(controlLowNumUpDown.Value);
        }
    }
}