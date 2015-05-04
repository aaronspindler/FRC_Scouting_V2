using System;
using System.Net.Configuration;
using FRC_Scouting_V2.Models;
using Newtonsoft.Json;
using Octokit;
using System.Net;
using System.Windows.Forms;

namespace FRC_Scouting_V2.Information_Forms
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                ConsoleWindow.AddItem("STARTED!");

                var github = new GitHubClient(new ProductHeaderValue("FRC_Scouting_V2"));
                var project = await github.Repository.Commits.GetAll("xNovax", "FRC_Scouting_V2");
                Console.WriteLine(project[0].Author.Login);


                ConsoleWindow.AddItem("FINISHED~!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}