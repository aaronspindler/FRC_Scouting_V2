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
    public partial class AerialAssist_Northbay : Form
    {
        //Variables
        private string selectedTeamLocation;

        private string selectedTeamName;
        private int selectedTeamNumber;

        public AerialAssist_Northbay()
        {
            InitializeComponent();
        }

        private void AerialAssist_Northbay_Load(object sender, EventArgs e)
        {
            FRC_Scouting_V2.Properties.Settings.Default.currentTableName = ("AerialAssist_Northbay");
            FRC_Scouting_V2.Properties.Settings.Default.Save();
            //Loading Team Names
            //36 Teams
            teamSelector.Items.Add("188 | Blizzard");
            teamSelector.Items.Add("610 | The Coyotes");
            teamSelector.Items.Add("772 | Sabre Bytes");
            teamSelector.Items.Add("1305 | Ice Cubed");
            teamSelector.Items.Add("1310 | RUNNYMEDE ROBOTICS");
            teamSelector.Items.Add("1325 | Inverse Paradox");
            teamSelector.Items.Add("1334 | Red Devils");
            teamSelector.Items.Add("1605 | RoboHawks");
            teamSelector.Items.Add("2013 | Cybergnomes");
            teamSelector.Items.Add("2200 | MMRambotics");
            teamSelector.Items.Add("2386 | Trojans");
            teamSelector.Items.Add("2609 | BeaverworX");
            teamSelector.Items.Add("2994 | ASTECHZ");
            teamSelector.Items.Add("3543 | C4 Robotics");
            teamSelector.Items.Add("3571 | Milton Mustangs");
            teamSelector.Items.Add("3710 | FSS Cyber Falcons");
            teamSelector.Items.Add("4001 | Retro-Rams");
            teamSelector.Items.Add("4069 | Lo-Ellen Robotics");
            teamSelector.Items.Add("4152 | Hoya Robotics");
            teamSelector.Items.Add("4343 | MaxTech");
            teamSelector.Items.Add("4476 | W.A.F.F.L.E.S.");
            teamSelector.Items.Add("4704 | Northern Lights Robotics");
            teamSelector.Items.Add("4754 | RoBenedicts");
            teamSelector.Items.Add("4902 | The Wildebots");
            teamSelector.Items.Add("4914 | Panthers");
            teamSelector.Items.Add("4946 | ALPHA DOGS");
            teamSelector.Items.Add("4951 | CDS Cyclones");
            teamSelector.Items.Add("4968 | RoboHawks");
            teamSelector.Items.Add("4976 | Rebels");
            teamSelector.Items.Add("4992 | Spartans");
            teamSelector.Items.Add("5035 | eNimkii");
            teamSelector.Items.Add("5076 | Stormbots");
            teamSelector.Items.Add("5157 | Roboprime Cardinals");
            teamSelector.Items.Add("5164 | Gators");
            teamSelector.Items.Add("5191 | LANCERobotics");
            teamSelector.Items.Add("5324 | Hawks");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (teamSelector.SelectedIndex)
            {
                case 0:
                    selectedTeamName = ("Blizzard");
                    selectedTeamNumber = 188;
                    selectedTeamLocation = ("Toronto, ON, Canada");
                    break;

                case 1:
                    selectedTeamName = ("The Coyotes");
                    selectedTeamNumber = 610;
                    selectedTeamLocation = ("Toronto, ON, Canada");
                    break;

                case 2:
                    selectedTeamName = ("Sabre Bytes");
                    selectedTeamNumber = 772;
                    selectedTeamLocation = ("LaSalle, ON, Canada");
                    break;

                case 3:
                    selectedTeamName = ("Ice Cubed");
                    selectedTeamNumber = 1305;
                    selectedTeamLocation = ("North Bay, ON, Canada");
                    break;

                case 4:
                    selectedTeamName = ("RUNNYMEDE ROBOTICS");
                    selectedTeamNumber = 1310;
                    selectedTeamLocation = ("Toronto, ON, Canada");
                    break;

                case 5:
                    selectedTeamName = ("Inverse Paradox");
                    selectedTeamNumber = 1325;
                    selectedTeamLocation = ("Mississauga, ON, Canada");
                    break;

                case 6:
                    selectedTeamName = ("Red Devils");
                    selectedTeamNumber = 1334;
                    selectedTeamLocation = ("Oakville, ON, Canada");
                    break;

                case 7:
                    selectedTeamName = ("RoboHawks");
                    selectedTeamNumber = 1605;
                    selectedTeamLocation = ("Toronto, ON, Canada");
                    break;

                case 8:
                    selectedTeamName = ("Cybergnomes");
                    selectedTeamNumber = 2013;
                    selectedTeamLocation = ("Stayner, ON, Canada");
                    break;

                case 9:
                    selectedTeamName = ("MMRambotics");
                    selectedTeamNumber = 2200;
                    selectedTeamLocation = ("Burlington, ON, Canada");
                    break;

                case 10:
                    selectedTeamName = ("Trojans");
                    selectedTeamNumber = 2386;
                    selectedTeamLocation = ("Burlington, ON, Canada");
                    break;

                case 11:
                    selectedTeamName = ("BeaverworX");
                    selectedTeamNumber = 2609;
                    selectedTeamLocation = ("Guelph, ON, Canada");
                    break;

                case 12:
                    selectedTeamName = ("ASTECHZ");
                    selectedTeamNumber = 2994;
                    selectedTeamLocation = ("Kanata, ON, Canada");
                    break;

                case 13:
                    selectedTeamName = ("C4 Robotics");
                    selectedTeamNumber = 3543;
                    selectedTeamLocation = ("Arnprior, ON, Canada");
                    break;

                case 14:
                    selectedTeamName = ("Milton Mustangs");
                    selectedTeamNumber = 3571;
                    selectedTeamLocation = ("Milton, ON, Canada");
                    break;

                case 15:
                    selectedTeamName = ("FSS Cyber Falcons");
                    selectedTeamNumber = 3710;
                    selectedTeamLocation = ("Kingston, ON, Canada");
                    break;

                case 16:
                    selectedTeamName = ("Retro-Rams");
                    selectedTeamNumber = 4001;
                    selectedTeamLocation = ("Thornhill, ON, Canada");
                    break;

                case 17:
                    selectedTeamName = ("Lo-Ellen Robotics");
                    selectedTeamNumber = 4069;
                    selectedTeamLocation = ("Sudbury, ON, Canada");
                    break;

                case 18:
                    selectedTeamName = ("Hoya Robotics");
                    selectedTeamNumber = 4152;
                    selectedTeamLocation = ("Huntsville, ON, Canada");
                    break;

                case 19:
                    selectedTeamName = ("MaxTech");
                    selectedTeamNumber = 4343;
                    selectedTeamLocation = ("Aurora, ON, Canada");
                    break;

                case 20:
                    selectedTeamName = ("W.A.F.F.L.E.S.");
                    selectedTeamNumber = 4476;
                    selectedTeamLocation = ("Kingston, ON, Canada");
                    break;

                case 21:
                    selectedTeamName = ("Northern Lights Robotics");
                    selectedTeamNumber = 4704;
                    selectedTeamLocation = ("Timmins, ON, Canada");
                    break;

                case 22:
                    selectedTeamName = ("RoBenedicts");
                    selectedTeamNumber = 4754;
                    selectedTeamLocation = ("Sudbury, ON, Canada");
                    break;

                case 23:
                    selectedTeamName = ("The Wildebots");
                    selectedTeamNumber = 4902;
                    selectedTeamLocation = ("Burlington, ON, Canada");
                    break;

                case 24:
                    selectedTeamName = ("Panthers");
                    selectedTeamNumber = 4914;
                    selectedTeamLocation = ("Toronto, ON, Canada");
                    break;

                case 25:
                    selectedTeamName = ("ALPHA DOGS");
                    selectedTeamNumber = 4946;
                    selectedTeamLocation = ("Bolton, ON, Canada");
                    break;

                case 26:
                    selectedTeamName = ("CDS Cyclones");
                    selectedTeamNumber = 4951;
                    selectedTeamLocation = ("King, ON, Canada");
                    break;

                case 27:
                    selectedTeamName = ("RoboHawks");
                    selectedTeamNumber = 4968;
                    selectedTeamLocation = ("Lively, ON, Canada");
                    break;

                case 28:
                    selectedTeamName = ("Rebels");
                    selectedTeamNumber = 4976;
                    selectedTeamLocation = ("Georgetown, ON, Canada");
                    break;

                case 29:
                    selectedTeamName = ("Spartans");
                    selectedTeamNumber = 4992;
                    selectedTeamLocation = ("Milton, ON, Canada");
                    break;

                case 30:
                    selectedTeamName = ("eNimkii");
                    selectedTeamNumber = 5035;
                    selectedTeamLocation = ("North Bay, ON, Canada");
                    break;

                case 31:
                    selectedTeamName = ("Stormbots");
                    selectedTeamNumber = 5076;
                    selectedTeamLocation = ("Ajax, ON, Canada");
                    break;

                case 32:
                    selectedTeamName = ("Roboprime Cardinals");
                    selectedTeamNumber = 5157;
                    selectedTeamLocation = ("Sudbury, ON, Canada");
                    break;

                case 33:
                    selectedTeamName = ("Gators");
                    selectedTeamNumber = 5164;
                    selectedTeamLocation = ("Sudbury, ON, Canada");
                    break;

                case 34:
                    selectedTeamName = ("LANCERobotics");
                    selectedTeamNumber = 5191;
                    selectedTeamLocation = ("Sudbury, ON, Canada");
                    break;

                case 35:
                    selectedTeamName = ("Hawks");
                    selectedTeamNumber = 5324;
                    selectedTeamLocation = ("Haliburton, ON, Canada");
                    break;
            }

            teamNameDisplay.Text = selectedTeamName;
            teamNumberDisplay.Text = Convert.ToString(selectedTeamNumber);
            teamLocationDisplay.Text = selectedTeamLocation;

            Settings.Default.selectedTeamName = selectedTeamName;
            Settings.Default.selectedTeamNumber = selectedTeamNumber;
            Settings.Default.Save();
        }

        private void eventInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eventInformation = new AerialAssist_Northbay_Information();
            eventInformation.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}