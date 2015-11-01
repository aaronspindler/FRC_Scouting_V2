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
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    public partial class ConsoleWindow : Form
    {
        static BindingList<ConsoleEntry> logCollection = new BindingList<ConsoleEntry>();

        public ConsoleWindow()
        {
            InitializeComponent();
            consoleDataGridView.DataSource = logCollection;
            consoleDataGridView.Columns[0].Width = 219;
            consoleDataGridView.Columns[0].FillWeight = (float) 57.33928;
            consoleDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            consoleDataGridView.Columns[1].Width = 539;
            consoleDataGridView.Columns[1].FillWeight = (float) 140.8333;
            consoleDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static void WriteLine(string message)
        {
            var currentTime = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            logCollection.Add(new ConsoleEntry(currentTime, message));
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
                    for (var i = 0; i < logCollection.Count; i++)
                    {
                        writer.WriteLine(logCollection[i].TimeStamp + "," + logCollection[i].Message);
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

            foreach (ConsoleEntry ce in logCollection)
            {
                //consoleDataGridView.Rows.Add(ce.TimeStamp, ce.Message);
            }
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        public class ConsoleEntry
        {
            public ConsoleEntry() { }

            public ConsoleEntry(string timeIn, string messageIn)
            {
                TimeStamp = timeIn;
                Message = messageIn;
            }

            // Properties.
            public string TimeStamp { get; set; }
            public string Message { get; set; }

        }
    }
}