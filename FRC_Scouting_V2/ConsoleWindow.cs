using System;
using System.Collections.Generic;
using System.Globalization;
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
        static List<string> TimeStampList = new List<string>();
        static List<string> MessageList = new List<string>();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            this.Dispose();
        }

        public static void AddItem(string message)
        {
            string currentTime = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            TimeStampList.Add(currentTime);
            MessageList.Add(message);
        }

        private void ConsoleWindow_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in consoleDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            consoleDataGridView.Rows.Clear();
            for (int i = 0; i < TimeStampList.Count; i++)
            {
                consoleDataGridView.Rows.Add(TimeStampList[i], MessageList[i]);
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            consoleDataGridView.Rows.Clear();
            for (int i = 0; i < TimeStampList.Count; i++)
            {
                consoleDataGridView.Rows.Add(TimeStampList[i], MessageList[i]);
            }
        }
    }
}
