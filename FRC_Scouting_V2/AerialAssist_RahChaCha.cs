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
    }
}
