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

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class AerialAssist_RahChaCha : Form
    {
        public AerialAssist_RahChaCha()
        {
            InitializeComponent();
        }

        //Variables
        private string teamName = ("");
        private int teamNumber = 0;
        private string teamLocation = ("");
        private int rookieYear = 0;

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
        }


        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamSelector.SelectedIndex == 0)
            {
            }
            else
            {
                if (teamSelector.SelectedIndex == 1)
                {
                }
                else
                {
                    if (teamSelector.SelectedIndex == 2)
                    {
                    }
                    else
                    {
                        if (teamSelector.SelectedIndex == 3)
                        {
                        }
                        else
                        {
                            if (teamSelector.SelectedIndex == 4)
                            {
                            }
                            else
                            {
                                if (teamSelector.SelectedIndex == 5)
                                {
                                }
                                else
                                {
                                    if (teamSelector.SelectedIndex == 6)
                                    {
                                    }
                                    else
                                    {
                                        if (teamSelector.SelectedIndex == 7)
                                        {
                                        }
                                        else
                                        {
                                            if (teamSelector.SelectedIndex == 8)
                                            {
                                            }
                                            else
                                            {
                                                if (teamSelector.SelectedIndex == 9)
                                                {
                                                }
                                                else
                                                {
                                                    if (teamSelector.SelectedIndex == 10)
                                                    {
                                                    }
                                                    else
                                                    {
                                                        if (teamSelector.SelectedIndex == 11)
                                                        {
                                                        }
                                                        else
                                                        {
                                                            if (teamSelector.SelectedIndex == 12)
                                                            {
                                                            }
                                                            else
                                                            {
                                                                if (teamSelector.SelectedIndex == 13)
                                                                {
                                                                }
                                                                else
                                                                {
                                                                    if (teamSelector.SelectedIndex == 14)
                                                                    {
                                                                    }
                                                                    else
                                                                    {
                                                                        if (teamSelector.SelectedIndex == 15)
                                                                        {
                                                                        }
                                                                        else
                                                                        {
                                                                            if (teamSelector.SelectedIndex == 16)
                                                                            {
                                                                            }
                                                                            else
                                                                            {
                                                                                if (teamSelector.SelectedIndex == 17)
                                                                                {
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (teamSelector.SelectedIndex == 18)
                                                                                    {
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (
                                                                                            teamSelector.SelectedIndex ==
                                                                                            19)
                                                                                        {
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (
                                                                                                teamSelector
                                                                                                    .SelectedIndex == 20)
                                                                                            {
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (
                                                                                                    teamSelector
                                                                                                        .SelectedIndex ==
                                                                                                    21)
                                                                                                {
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (
                                                                                                        teamSelector
                                                                                                            .SelectedIndex ==
                                                                                                        22)
                                                                                                    {
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (
                                                                                                            teamSelector
                                                                                                                .SelectedIndex ==
                                                                                                            23)
                                                                                                        {
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (
                                                                                                                teamSelector
                                                                                                                    .SelectedIndex ==
                                                                                                                24)
                                                                                                            {
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (
                                                                                                                    teamSelector
                                                                                                                        .SelectedIndex ==
                                                                                                                    25)
                                                                                                                {
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (
                                                                                                                        teamSelector
                                                                                                                            .SelectedIndex ==
                                                                                                                        26)
                                                                                                                    {
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if
                                                                                                                            (
                                                                                                                            teamSelector
                                                                                                                                .SelectedIndex ==
                                                                                                                            27)
                                                                                                                        {
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if
                                                                                                                                (
                                                                                                                                teamSelector
                                                                                                                                    .SelectedIndex ==
                                                                                                                                28)
                                                                                                                            {
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if
                                                                                                                                    (
                                                                                                                                    teamSelector
                                                                                                                                        .SelectedIndex ==
                                                                                                                                    29)
                                                                                                                                {
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}