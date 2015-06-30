using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class previousMatchInfo : Form
    {
        String eventKey;
        int matchNum;

        public previousMatchInfo(String eventKey, int matchNum)
        {
            InitializeComponent();
            this.eventKey = eventKey;
            this.matchNum = matchNum;
        }

        private void prevMatchInfo_Load(object sender, EventArgs e)
        {
            //blank for now
        }

        private TheBlueAlliance.Models.EventMatches.Match getMatch(int matchNum)
        {
            TheBlueAlliance.Models.EventMatches.Match[] matches = TheBlueAlliance.Events.GetEventMatches(eventKey);
            return matches[matchNum];
        }

        private TheBlueAlliance.Models.EventMatches.Alliances getMatchAlliances(int matchNum)
        {
            TheBlueAlliance.Models.EventMatches.Match match = getMatch(matchNum);
            return match.alliances;
        }

        private String[][] getMatchAllianceTeams(int matchNum)
        {
            TheBlueAlliance.Models.EventMatches.Alliances alliances = getMatchAlliances(matchNum);
            String[][] teams = { alliances.red.teams, alliances.blue.teams };
            return teams;
        }

        private int[] getMatchScores(int matchNum)
        {
            TheBlueAlliance.Models.EventMatches.Alliances alliances = getMatchAlliances(matchNum);
            int[] scores = { alliances.red.score, alliances.blue.score };
            return scores;
        }

        private void getInfoButton_Click(object sender, EventArgs e)
        {
            String t2BoxText = "Teams: ";
            t2BoxText += System.Environment.NewLine;
            t2BoxText += "Red Alliance: ";
            String[][] matchAllianceTeams = getMatchAllianceTeams(matchNum);
            for (int i = 0; i < matchAllianceTeams.Length; i++)
            {
                for (int j = 0; j < matchAllianceTeams[0].Length; j++)
                {
                    if (j < matchAllianceTeams[0].Length - 1)
                    {
                        t2BoxText += matchAllianceTeams[i][j] + ", ";
                    }
                    else
                    {
                        t2BoxText += matchAllianceTeams[i][j] + ".";
                    }
                }
                if (i < matchAllianceTeams.Length - 1)
                {
                    t2BoxText += System.Environment.NewLine;
                    t2BoxText += "Bule Alliance: ";
                }
            } /* won't work until TBA has event info */
            textBox2.Text = t2BoxText;
            String t3BoxText = "Scores: ";
            t3BoxText += System.Environment.NewLine;
            t3BoxText += "Red Alliance: ";
            int[] scores = getMatchScores(matchNum);
            for (int i = 0; i < scores.Length; i++)
            {
                t3BoxText += "" + scores[i];
                if (i == 0)
                {
                    t3BoxText += System.Environment.NewLine;
                    t3BoxText += "Bule Alliance: ";
                }
            } /* won't work until TBA has event info */
            textBox3.Text = t3BoxText;
        }
    }
}
