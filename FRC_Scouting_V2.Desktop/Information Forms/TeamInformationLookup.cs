﻿//*********************************License***************************************
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
using System.Net;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

//@author xNovax

namespace FRC_Scouting_V2.Information_Forms
{
    public partial class TeamInformationLookup : GeneralFormTemplate.GeneralFormTemplate
    {
        private int rookieYear;
        private string teamLocation;
        private string teamName;
        private int teamNumber;
        private string teamWebsite;
        private string url;

        public TeamInformationLookup()
        {
            InitializeComponent();
        }

        private void findTeamButton_Click(object sender, EventArgs e)
        {
            TheBlueAlliance.Models.TeamInformation ti = TheBlueAlliance.Teams.GetTeamInformation("frc" + teamNumber);
            teamName = Convert.ToString(ti.nickname);
            teamNumber = Convert.ToInt16(ti.team_number);
            teamLocation = Convert.ToString(ti.location);
            rookieYear = Convert.ToInt32(ti.rookie_year);
            teamWebsite = Convert.ToString(ti.website);
            Console.WriteLine("The information for team: " + Convert.ToString(teamNumber) +
                              " has been found successfully.");
            ConsoleWindow.WriteLine("The information for team: " + Convert.ToString(teamNumber) +
                                    " has been found successfully.");
            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            teamWebsiteDisplay.Text = teamWebsite;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);
            if (teamNumber == 3710)
            {
                MessageBox.Show("BEST TEAM EVER! Please invite to your alliance!");
            }
        }

        private void teamNumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                teamNumberTextBox.Text = ("");
            }
        }

        private void teamNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (teamNumberTextBox.Text != (""))
            {
                teamNumber = Convert.ToInt32(teamNumberTextBox.Text);
            }
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 3000;
                return w;
            }
        }
    }
}