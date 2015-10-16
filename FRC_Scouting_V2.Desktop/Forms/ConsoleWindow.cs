#region License

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

#endregion License

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    public partial class ConsoleWindow : Form
    {
        private static readonly List<string> TimeStampList = new List<string>();
        private static readonly List<string> MessageList = new List<string>();
        private static bool itemAdded;

        public ConsoleWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string[] getLog()
        {
            var logStrings = new string[TimeStampList.Count];

            for (var i = 0; i < TimeStampList.Count; i++)
            {
                logStrings[i] = (TimeStampList[i] + " : " + MessageList[i]);
            }

            return logStrings;
        }

        public static void WriteLine(string message)
        {
            itemAdded = true;
            var currentTime = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
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
                    for (var i = 0; i < TimeStampList.Count; i++)
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
            for (var i = 0; i < TimeStampList.Count; i++)
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
                for (var i = 0; i < TimeStampList.Count; i++)
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