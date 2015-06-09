using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Octokit;

namespace FRC_Scouting_V2.Information_Forms
{
    public partial class ChangeLog : Form
    {
        private readonly GitHubClient github = new GitHubClient(new ProductHeaderValue("FRC_Scouting_V2"));

        public ChangeLog()
        {
            InitializeComponent();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            LoadAndDisplayCommits();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAndDisplayCommits();
        }

        public async void LoadAndDisplayCommits()
        {
            statusLabel.Text = "Loading!";
            commitListBox.Items.Clear();
            try
            {
                IReadOnlyList<GitHubCommit> projectCommits = await github.Repository.Commits.GetAll("xNovax", "FRC_Scouting_V2");
                for (int i = 0; i < projectCommits.Count - 1; i++)
                {
                    commitListBox.Items.Add(projectCommits[i].Commit.Author.Date + " | " + projectCommits[i].Commit.Message + " by: " + projectCommits[i].Commit.Author.Name);
                }
                statusLabel.Text = "Load complete!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                statusLabel.Text = "Error: " + ex.Message;
            }
        }
    }
}