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

using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
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
            TheBlueAlliance.Models.Event.EventInformation ei = TheBlueAlliance.Events.GetEventInformation(Convert.ToString(eventCodeEntryTextBox.Text));
            locationTextBox.Text = ei.location;
            eventNameLabel.Text = ("Event Name: " + ei.name);
            eventSpanLabel.Text = string.Format("Event Date(s): {0} to {1}", ei.start_date,
                ei.end_date);
            isOfficialLabel.Text = "Is Official?: " + ei.official;
            if (ei.official)
            {
                isOfficialLabel.ForeColor = Color.Green;
            }
            else
            {
                isOfficialLabel.ForeColor = Color.Red;
            }
            websiteDisplay.Text = ei.website;
        }

        private void websiteDisplay_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
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
    }
}