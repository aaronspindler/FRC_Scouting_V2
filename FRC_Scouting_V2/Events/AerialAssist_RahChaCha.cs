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
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using Newtonsoft.Json;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class AerialAssist_RahChaCha : Form
    {
        private const string TABLE_NAME = ("AerialAssist_RahChaCha");

        private readonly string[] teamNameArray =
        {
            "The Rocketeers", "Arctic Warriors", "X-CATS",
            "Greater Rochester Robotics", "Circuit Stompers", "Red Raider Robotics", "Cresent Robotics",
            "Code Red Robotics", "Warp7", "Simbotics", "SparX", "Theory6", "TheBigBang", "Red Devil Robotics",
            "Finney Robotics", "Warlocks", "Rolling Thunder", "Raider Robotics", "Grapes of Wrath", "DevilTech",
            "Scitobor Robotics", "CougarTech", "XcentricsRobotics", "DM High Voltage", "The Astechz", "Tan[x]",
            "Ranger Robotics", "Eastridge Robotics", "IgKnighters", "Pittsford Panthers", "CyberFalcons", "S.U.I.T.S.",
            "Retro Rams", "MakeShift", "MaxTech", "W.A.F.F.L.E.S.", "VP Robotics", "Electric Mayhem", "Robot Raiders"
        };

        private readonly int[] teamNumberArray =
        {
            20, 174, 191, 340, 378, 578, 610, 639, 865, 1114, 1126, 1241, 1285,
            1334, 1405, 1507, 1511, 1518, 1551, 1559, 1585, 2228, 2340, 2852, 2994, 3003, 3015, 3157, 3173, 3181, 3710,
            3951, 4001, 4039, 4343, 4476, 4914, 4930, 5254
        };

        private readonly UsefulSnippets us = new UsefulSnippets();
        private int rookieYear;
        private string teamLocation = ("");
        private string teamName = ("");
        private int teamNumber;
        private string url = ("http://www.thebluealliance.com/api/v2/team/frc");

        public AerialAssist_RahChaCha()
        {
            InitializeComponent();
        }

        private void AerialAssist_RahChaCha_Load(object sender, EventArgs e)
        {
            Settings.Default.currentTableName = (TABLE_NAME);
            Settings.Default.Save();

            //Starting the clock so that the current time will be displayed and updated every second

            //Setting toolTips
            var ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(teamSelector,
                "Use this to select the team that you want to enter data / look at data for!");

            //Adding teams to team selector and teamListBox
            for (int i = 0; i < teamNumberArray.Length; i++)
            {
                teamSelector.Items.Add(teamNumberArray[i] + " | " + teamNameArray[i]);
            }
        }

        private void eventInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aaRahChaChaEventInfo = new AerialAssist_RahChaCha_Information();
            aaRahChaChaEventInfo.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToCSVToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            us.ExportTableToCSV(TABLE_NAME);
        }

        private void howComeICannotSeeAnyTeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage(
                "The team information is pulled from TheBluAlliance's API, this means that you need to have an internet connection to get the data.");
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            url = ("http://www.thebluealliance.com/api/v2/team/frc");
            url = url + Convert.ToString(teamNumberArray[teamSelector.SelectedIndex]);
            string downloadedData;
            var wc = new MyWebClient();
            wc.Headers.Add("X-TBA-App-Id",
                "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);

            try
            {
                downloadedData = (wc.DownloadString(url));
                var deserializedData = JsonConvert.DeserializeObject<TeamInformationJSONData>(downloadedData);

                teamName = Convert.ToString(deserializedData.nickname);
                teamNumber = Convert.ToInt32(deserializedData.team_number);
                teamLocation = Convert.ToString(deserializedData.location);
                rookieYear = Convert.ToInt32(deserializedData.rookie_year);
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);

            switch (teamSelector.SelectedIndex)
            {
                case 0:
                    teamLogoPictureBox.Image = Resources.FRC20;
                    break;
                case 1:
                    teamLogoPictureBox.Image = Resources.FRC174;
                    break;
                case 2:
                    teamLogoPictureBox.Image = Resources.FRC191;
                    break;
                case 3:
                    teamLogoPictureBox.Image = Resources.FRC340;
                    break;
                case 4:
                    teamLogoPictureBox.Image = Resources.FRC378;
                    break;
                case 5:
                    teamLogoPictureBox.Image = Resources.FRC578;
                    break;
                case 6:
                    teamLogoPictureBox.Image = Resources.FRC610;
                    break;
                case 7:
                    teamLogoPictureBox.Image = Resources.FRC639;
                    break;
                case 8:
                    teamLogoPictureBox.Image = Resources.FRC865;
                    break;
                case 9:
                    teamLogoPictureBox.Image = Resources.FRC1114;
                    break;
                case 10:
                    teamLogoPictureBox.Image = Resources.FRC1126;
                    break;
                case 11:
                    teamLogoPictureBox.Image = Resources.FRC1241;
                    break;
                case 12:
                    teamLogoPictureBox.Image = Resources.FRC1285;
                    break;
                case 13:
                    teamLogoPictureBox.Image = Resources.FRC1334;
                    break;
                case 14:
                    teamLogoPictureBox.Image = Resources.FRC1405;
                    break;
                case 15:
                    teamLogoPictureBox.Image = Resources.FRC1507;
                    break;
                case 16:
                    teamLogoPictureBox.Image = Resources.FRC1511;
                    break;
                case 17:
                    teamLogoPictureBox.Image = Resources.FRC1518;
                    break;
                case 18:
                    teamLogoPictureBox.Image = Resources.FRC1551;
                    break;
                case 19:
                    teamLogoPictureBox.Image = Resources.FRC1559;
                    break;
                case 20:
                    teamLogoPictureBox.Image = null;
                    break;
                case 21:
                    teamLogoPictureBox.Image = Resources.FRC2228;
                    break;
                case 22:
                    teamLogoPictureBox.Image = Resources.FRC2340;
                    break;
                case 23:
                    teamLogoPictureBox.Image = Resources.FRC2852;
                    break;
                case 24:
                    teamLogoPictureBox.Image = Resources.FRC2994;
                    break;
                case 25:
                    teamLogoPictureBox.Image = Resources.FRC3003;
                    break;
                case 26:
                    teamLogoPictureBox.Image = Resources.FRC3015;
                    break;
                case 27:
                    teamLogoPictureBox.Image = Resources.FRC3157;
                    break;
                case 28:
                    teamLogoPictureBox.Image = Resources.FRC3173;
                    break;
                case 29:
                    teamLogoPictureBox.Image = Resources.FRC3181;
                    break;
                case 30:
                    teamLogoPictureBox.Image = Resources.FRC3710;
                    break;
                case 31:
                    teamLogoPictureBox.Image = Resources.FRC3951;
                    break;
                case 32:
                    teamLogoPictureBox.Image = Resources.FRC4001;
                    break;
                case 33:
                    teamLogoPictureBox.Image = Resources.FRC4039;
                    break;
                case 34:
                    teamLogoPictureBox.Image = Resources.FRC4343;
                    break;
                case 35:
                    teamLogoPictureBox.Image = Resources.FRC4476;
                    break;
                case 36:
                    teamLogoPictureBox.Image = Resources.FRC4914;
                    break;
                case 37:
                    teamLogoPictureBox.Image = Resources.FRC4930;
                    break;
                case 38:
                    teamLogoPictureBox.Image = Resources.FRC5254;
                    break;
            }

            Settings.Default.selectedTeamName = teamName;
            Settings.Default.selectedTeamNumber = teamNumber;
            Settings.Default.Save();
        }

        private void whatDoTheQuestionMarkButtonsDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage("They provide information about what the controls to the left of them do.");
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

        public class TeamInformationJSONData
        {
            public string country_name { get; set; }

            public string key { get; set; }

            public string locality { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public string nickname { get; set; }

            public string region { get; set; }

            public int rookie_year { get; set; }

            public int team_number { get; set; }

            public string website { get; set; }
        }
    }
}