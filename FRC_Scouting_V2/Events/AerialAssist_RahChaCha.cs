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
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class AerialAssist_RahChaCha : Form
    {
        //Variables
        private int rookieYear;
        private string teamLocation = ("");
        private string teamName = ("");
        private int teamNumber;
        UsefulSnippets us = new UsefulSnippets();

        public AerialAssist_RahChaCha()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eventInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aaRahChaChaEventInfo = new AerialAssist_RahChaCha_Information();
            aaRahChaChaEventInfo.Show();
        }

        private void AerialAssist_RahChaCha_Load(object sender, EventArgs e)
        {
            Settings.Default.currentTableName = ("AerialAssist_RahChaCha");
            Settings.Default.Save();

            //Adding teams to TeamSelector Control
            


            //Adding teams to teamCompSelector1 Control
            


            //Adding teams to teamCompSelector2 Control
            
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamSelector.SelectedIndex == 0)
            {
                teamName = ("The Rocketeers");
                teamNumber = 20;
                teamLocation = ("Clifton Park, NY, USA");
                rookieYear = 1992;
                teamLogoPictureBox.Image = Resources.FRC20_Logo;
            }
            else
            {
                if (teamSelector.SelectedIndex == 1)
                {
                    teamName = ("Delphi E.L.I.T.E");
                    teamNumber = 48;
                    teamLocation = ("Warren, OH, USA");
                    rookieYear = 1998;
                    teamLogoPictureBox.Image = Resources.FRC48_Logo;
                }
            }

            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);

            Settings.Default.selectedTeamName = teamName;
            Settings.Default.selectedTeamNumber = teamNumber;
            Settings.Default.Save();
        }
    }
}