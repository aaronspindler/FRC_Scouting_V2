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
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add(""); 
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
            teamSelector.Items.Add("");
        }
    }
}