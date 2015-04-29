using System;
using System.Windows.Forms;
using CrashReporterDotNET;

namespace UsefulSnippets
{
    public class Notifications
    {
        public static void ErrorOccured(string error)
        {
            MessageBox.Show(error, "FRC_Scouting_V2 | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformationMessage(string informationText)
        {
            MessageBox.Show(informationText, "FRC_Scouting_V2 | Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
