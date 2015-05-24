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
using System.Windows.Forms;
using CrashReporterDotNET;

namespace UsefulSnippets
{
    /// <summary>
    /// Provides an abstraction layer to easily prompt a user with a message
    /// </summary>
    public class Notifications
    {
        /// <summary>
        /// Prompts the user with a message that has error characteristics
        /// </summary>
        /// <param name="error"></param>
        public static void ErrorOccured(string error)
        {
            MessageBox.Show(error, "FRC_Scouting_V2 | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Prompts the user with a message with information characteristics
        /// </summary>
        /// <param name="informationText"></param>
        public static void ShowInformationMessage(string informationText)
        {
            MessageBox.Show(informationText, "FRC_Scouting_V2 | Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Prompts the user with a crash report and submits the report to an email address
        /// </summary>
        /// <param name="exception"></param>
        public static void ReportCrash(Exception exception)
        {
            var reportCrash = new ReportCrash
            {
                ToEmail = "aaron@xnovax.net"
            };

            reportCrash.Send(exception);
        }
    }
}
