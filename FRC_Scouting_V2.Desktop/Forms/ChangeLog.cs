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

using Octokit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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