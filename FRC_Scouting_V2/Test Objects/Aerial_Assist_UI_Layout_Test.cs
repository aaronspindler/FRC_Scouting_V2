using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2.Test_Items
{
    //@author xNovax
    public partial class Aerial_Assist_UI_Layout_Test : UserControl
    {
        public Aerial_Assist_UI_Layout_Test()
        {
            InitializeComponent();
        }
        //Variables
        private int teamColour;
        private int matchNumber = 1;

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
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
        }

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
        }
    }
}
