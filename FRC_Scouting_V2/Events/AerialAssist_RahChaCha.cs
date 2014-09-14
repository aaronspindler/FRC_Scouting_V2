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
            teamSelector.Items.Add("20 | The Rocketeers");
            teamSelector.Items.Add("48 | Delphi E.L.I.T.E.");
            teamSelector.Items.Add("174 | Arctic Warriors");
            teamSelector.Items.Add("188 | Woburn Robotics");
            teamSelector.Items.Add("191 | X-Cats");
            teamSelector.Items.Add("229 | Division by Zero");
            teamSelector.Items.Add("340 | G.R.R (Greater Rochester Robotics)");
            teamSelector.Items.Add("378 | The Circuit Stompers");
            teamSelector.Items.Add("578 | Red Raider Robotics");
            teamSelector.Items.Add("610 | The Coyotes");
            teamSelector.Items.Add("639 | Code Red Robotics");
            teamSelector.Items.Add("865 | Warp7");
            teamSelector.Items.Add("1114 | Simbotics");
            teamSelector.Items.Add("1126 | SPARX");
            teamSelector.Items.Add("1241 | THEORY6");
            teamSelector.Items.Add("1285 | The Big Bang");
            teamSelector.Items.Add("1334 | Red Devils");
            teamSelector.Items.Add("1405 | Finney Robotics");
            teamSelector.Items.Add("1507 | Warlocks");
            teamSelector.Items.Add("1511 | Rolling Thunder");
            teamSelector.Items.Add("1518 | Raiders Robotics");
            teamSelector.Items.Add("1551 | The Grapes of Wrath");
            teamSelector.Items.Add("1559 | Devil-Tech");
            teamSelector.Items.Add("1585 | Scitobor Robotics");
            teamSelector.Items.Add("1660 | Harlem Knights");
            teamSelector.Items.Add("2228 | Cougar Tech");
            teamSelector.Items.Add("2852 | DM High Voltage");
            teamSelector.Items.Add("2791 | Shaker Robotics");
            teamSelector.Items.Add("3003 | TAN(X)");
            teamSelector.Items.Add("3015 | Ranger Robotics");
            teamSelector.Items.Add("3683 | Team Dave");
            teamSelector.Items.Add("3710 | CyberFalcons");
            teamSelector.Items.Add("3951 | SUITS");
            teamSelector.Items.Add("4001 | Retro Rams");
            teamSelector.Items.Add("4039 | MakeShift Robotics");
            teamSelector.Items.Add("4343 | MaxTech");
            teamSelector.Items.Add("4476 | W.A.F.F.L.E.S");
            teamSelector.Items.Add("4914 | Panthers");
            teamSelector.Items.Add("4917 | Sir Lancer Bots");
            teamSelector.Items.Add("4930 | Electric Mayhem");
            teamSelector.Items.Add("5254 | Robot Raiders");


            //Adding teams to teamCompSelector1 Control
            teamCompSelector1.Items.Add("20 | The Rocketeers");
            teamCompSelector1.Items.Add("48 | Delphi E.L.I.T.E.");
            teamCompSelector1.Items.Add("174 | Arctic Warriors");
            teamCompSelector1.Items.Add("188 | Woburn Robotics");
            teamCompSelector1.Items.Add("191 | X-Cats");
            teamCompSelector1.Items.Add("229 | Division by Zero");
            teamCompSelector1.Items.Add("340 | G.R.R (Greater Rochester Robotics)");
            teamCompSelector1.Items.Add("378 | The Circuit Stompers");
            teamCompSelector1.Items.Add("578 | Red Raider Robotics");
            teamCompSelector1.Items.Add("610 | The Coyotes");
            teamCompSelector1.Items.Add("639 | Code Red Robotics");
            teamCompSelector1.Items.Add("865 | Warp7");
            teamCompSelector1.Items.Add("1114 | Simbotics");
            teamCompSelector1.Items.Add("1126 | SPARX");
            teamCompSelector1.Items.Add("1241 | THEORY6");
            teamCompSelector1.Items.Add("1285 | The Big Bang");
            teamCompSelector1.Items.Add("1334 | Red Devils");
            teamCompSelector1.Items.Add("1405 | Finney Robotics");
            teamCompSelector1.Items.Add("1507 | Warlocks");
            teamCompSelector1.Items.Add("1511 | Rolling Thunder");
            teamCompSelector1.Items.Add("1518 | Raiders Robotics");
            teamCompSelector1.Items.Add("1551 | The Grapes of Wrath");
            teamCompSelector1.Items.Add("1559 | Devil-Tech");
            teamCompSelector1.Items.Add("1585 | Scitobor Robotics");
            teamCompSelector1.Items.Add("1660 | Harlem Knights");
            teamCompSelector1.Items.Add("2228 | Cougar Tech");
            teamCompSelector1.Items.Add("2852 | DM High Voltage");
            teamCompSelector1.Items.Add("2791 | Shaker Robotics");
            teamCompSelector1.Items.Add("3003 | TAN(X)");
            teamCompSelector1.Items.Add("3015 | Ranger Robotics");
            teamCompSelector1.Items.Add("3683 | Team Dave");
            teamCompSelector1.Items.Add("3710 | CyberFalcons");
            teamCompSelector1.Items.Add("3951 | SUITS");
            teamCompSelector1.Items.Add("4001 | Retro Rams");
            teamCompSelector1.Items.Add("4039 | MakeShift Robotics");
            teamCompSelector1.Items.Add("4343 | MaxTech");
            teamCompSelector1.Items.Add("4476 | W.A.F.F.L.E.S");
            teamCompSelector1.Items.Add("4914 | Panthers");
            teamCompSelector1.Items.Add("4917 | Sir Lancer Bots");
            teamCompSelector1.Items.Add("4930 | Electric Mayhem");
            teamCompSelector1.Items.Add("5254 | Robot Raiders");

            //Adding teams to teamCompSelector2 Control
            teamCompSelector2.Items.Add("20 | The Rocketeers");
            teamCompSelector2.Items.Add("48 | Delphi E.L.I.T.E.");
            teamCompSelector2.Items.Add("174 | Arctic Warriors");
            teamCompSelector2.Items.Add("188 | Woburn Robotics");
            teamCompSelector2.Items.Add("191 | X-Cats");
            teamCompSelector2.Items.Add("229 | Division by Zero");
            teamCompSelector2.Items.Add("340 | G.R.R (Greater Rochester Robotics)");
            teamCompSelector2.Items.Add("378 | The Circuit Stompers");
            teamCompSelector2.Items.Add("578 | Red Raider Robotics");
            teamCompSelector2.Items.Add("610 | The Coyotes");
            teamCompSelector2.Items.Add("639 | Code Red Robotics");
            teamCompSelector2.Items.Add("865 | Warp7");
            teamCompSelector2.Items.Add("1114 | Simbotics");
            teamCompSelector2.Items.Add("1126 | SPARX");
            teamCompSelector2.Items.Add("1241 | THEORY6");
            teamCompSelector2.Items.Add("1285 | The Big Bang");
            teamCompSelector2.Items.Add("1334 | Red Devils");
            teamCompSelector2.Items.Add("1405 | Finney Robotics");
            teamCompSelector2.Items.Add("1507 | Warlocks");
            teamCompSelector2.Items.Add("1511 | Rolling Thunder");
            teamCompSelector2.Items.Add("1518 | Raiders Robotics");
            teamCompSelector2.Items.Add("1551 | The Grapes of Wrath");
            teamCompSelector2.Items.Add("1559 | Devil-Tech");
            teamCompSelector2.Items.Add("1585 | Scitobor Robotics");
            teamCompSelector2.Items.Add("1660 | Harlem Knights");
            teamCompSelector2.Items.Add("2228 | Cougar Tech");
            teamCompSelector2.Items.Add("2852 | DM High Voltage");
            teamCompSelector2.Items.Add("2791 | Shaker Robotics");
            teamCompSelector2.Items.Add("3003 | TAN(X)");
            teamCompSelector2.Items.Add("3015 | Ranger Robotics");
            teamCompSelector2.Items.Add("3683 | Team Dave");
            teamCompSelector2.Items.Add("3710 | CyberFalcons");
            teamCompSelector2.Items.Add("3951 | SUITS");
            teamCompSelector2.Items.Add("4001 | Retro Rams");
            teamCompSelector2.Items.Add("4039 | MakeShift Robotics");
            teamCompSelector2.Items.Add("4343 | MaxTech");
            teamCompSelector2.Items.Add("4476 | W.A.F.F.L.E.S");
            teamCompSelector2.Items.Add("4914 | Panthers");
            teamCompSelector2.Items.Add("4917 | Sir Lancer Bots");
            teamCompSelector2.Items.Add("4930 | Electric Mayhem");
            teamCompSelector2.Items.Add("5254 | Robot Raiders");
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