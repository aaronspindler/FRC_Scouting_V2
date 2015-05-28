using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    public partial class ConsoleWindow : Form
    {
        private static readonly List<string> TimeStampList = new List<string>();
        private static readonly List<string> MessageList = new List<string>();
        private static Boolean itemAdded;

        public ConsoleWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        public string[] getLog()
        {
            var logStrings = new string[TimeStampList.Count];

            for (int i = 0; i < TimeStampList.Count; i++)
            {
                logStrings[i] = (TimeStampList[i] + " : " + MessageList[i]);
            }

            return logStrings;
        }

        public static void WriteLine(string message)
        {
            itemAdded = true;
            string currentTime = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            TimeStampList.Add(currentTime);
            MessageList.Add(message);
        }

        public static void ExportToCSV()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = ("CSV files (*.csv)|*.csv|All files (*.*)|*.*");
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var writer = new StreamWriter(sfd.FileName);
                    writer.WriteLine("Timestamp,Message");
                    for (int i = 0; i < TimeStampList.Count; i++)
                    {
                        writer.WriteLine(TimeStampList[i] + "," + MessageList[i]);
                    }
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error Message: " + exception.Message);
                WriteLine("Error Message: " + exception.Message);
            }
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
            if (itemAdded)
            {
                consoleDataGridView.Rows.Clear();
                for (int i = 0; i < TimeStampList.Count; i++)
                {
                    consoleDataGridView.Rows.Add(TimeStampList[i], MessageList[i]);
                }
                itemAdded = false;
            }
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }
    }
}