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
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using TheBlueAlliance;

//@author xNovax

namespace FRC_Scouting_V2.Information_Forms
{
    public partial class TeamInformationLookup : GeneralFormTemplate.GeneralFormTemplate
    {
        public TeamInformationLookup()
        {
            InitializeComponent();
        }

        private void findTeamButton_Click(object sender, EventArgs e)
        {
            var teamInformation = Teams.GetTeamInformation("frc" + teamNumberTextBox.Text);

            teamNameDisplay.Text = teamInformation.nickname;
            teamNumberDisplay.Text = Convert.ToString(teamInformation.team_number);
            teamLocationDisplay.Text = teamInformation.location;
            teamWebsiteDisplay.Text = teamInformation.website;
            rookieYearDisplay.Text = Convert.ToString(teamInformation.rookie_year);
        }

        private void teamNumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                teamNumberTextBox.Text = "";
            }
        }
    }
}