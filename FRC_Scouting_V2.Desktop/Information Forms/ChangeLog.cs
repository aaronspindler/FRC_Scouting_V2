using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FRC_Scouting_V2.Models;
using Newtonsoft.Json;
using Octokit;

namespace FRC_Scouting_V2.Information_Forms
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ConsoleWindow.AddItem("STARTED!");
            try
            {
                var wc = new WebClient();
                string downloadedData = (wc.DownloadString("https://api.github.com/repos/xNovax/FRC_Scouting_V2/commits"));
                var deserializedData = JsonConvert.DeserializeObject<Github_Repo_Commits.Rootobject>(downloadedData);
                ConsoleWindow.AddItem(deserializedData.Property1[0].commit.message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            ConsoleWindow.AddItem("FINISHED~!");
        }
    }
}
