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

using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace FRC_Scouting_V2.Information_Forms
{
    //@author xNovax
    public partial class EventInformationLookup : Form
    {
        public EventInformationLookup()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findEventButton_Click(object sender, EventArgs e)
        {
            var wc = new MyWebClient();
            wc.Headers.Add("X-TBA-App-Id",
                "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                string url = ("http://www.thebluealliance.com/api/v2/event/" +
                              Convert.ToString(eventCodeEntryTextBox.Text));
                string downloadedData = (wc.DownloadString(url));
                var deserializedData = JsonConvert.DeserializeObject<Event>(downloadedData);

                locationTextBox.Text = deserializedData.venue_address;
                eventNameLabel.Text = ("Event Name: " + deserializedData.name);
                eventSpanLabel.Text = string.Format("Event Date(s): {0} to {1}", deserializedData.start_date,
                    deserializedData.end_date);
                isOfficialLabel.Text = "Is Official?: " + deserializedData.official;
                if (deserializedData.official)
                {
                    isOfficialLabel.ForeColor = Color.Green;
                }
                else
                {
                    isOfficialLabel.ForeColor = Color.Red;
                }
                websiteDisplay.Text = deserializedData.website;
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
                ConsoleWindow.AddItem("Error Message: " + webError.Message);
            }
        }

        private void websiteDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public class Alliances
        {
            public object[] declines { get; set; }

            public string[] picks { get; set; }
        }

        public class Event
        {
            public string key { get; set; }

            public string website { get; set; }

            public bool official { get; set; }

            public string end_date { get; set; }

            public string name { get; set; }

            public string short_name { get; set; }

            public object facebook_eid { get; set; }

            public object event_district_string { get; set; }

            public string venue_address { get; set; }

            public int event_district { get; set; }

            public string location { get; set; }

            public string event_code { get; set; }

            public int year { get; set; }

            public Webcast[] webcast { get; set; }

            public Alliances[] alliances { get; set; }

            public string event_type_string { get; set; }

            public string start_date { get; set; }

            public int event_type { get; set; }
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 3000;
                return w;
            }
        }

        public class Webcast
        {
            public string type { get; set; }

            public string channel { get; set; }
        }
    }
}