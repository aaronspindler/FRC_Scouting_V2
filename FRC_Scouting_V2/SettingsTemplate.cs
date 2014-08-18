using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class SettingsTemplate : Form
    {
        public SettingsTemplate()
        {
            InitializeComponent();
        }

        private void SettingsTemplate_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
