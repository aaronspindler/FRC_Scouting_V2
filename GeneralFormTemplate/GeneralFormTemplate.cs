using System;
using System.Windows.Forms;

namespace GeneralFormTemplate
{
    //@author xNovax
    public partial class GeneralFormTemplate : Form
    {
        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

        public GeneralFormTemplate()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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