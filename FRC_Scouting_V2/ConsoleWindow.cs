using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    public partial class ConsoleWindow : Form
    {
        public ConsoleWindow()
        {
            InitializeComponent();
        }

        UsefulSnippets us = new UsefulSnippets();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            this.Dispose();
        }

        public void AddItem(string message)
        {
            consoleDataGridView.Rows.Add(us.GetCurrentTime(), message);
        }

        private void ConsoleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
