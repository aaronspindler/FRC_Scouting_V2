using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class GeneralFormTemplate : Form
    {
        //Variables
        UsefulSnippets us = new UsefulSnippets();
        public GeneralFormTemplate()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTimeDisplay.Text = ("Current Time: " + us.GetCurrentTime());
        }

        private void GeneralFormTemplate_Load(object sender, EventArgs e)
        {
            currentTimeDisplay.Text = ("Current Time: " + us.GetCurrentTime());
            timer.Tick += timer_Tick;
            timer.Start();
        }
    }
}
