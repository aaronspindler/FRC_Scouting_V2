namespace FRC_Scouting_V2.Events._2016_Stronghold.RegularSeason.GTR_East
{
    partial class Stronghold_GTR_East
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stronghold_GTR_East));
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTeamSelector = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.matchScoutingTabPage = new System.Windows.Forms.TabPage();
            this.pitScoutingTabPage = new System.Windows.Forms.TabPage();
            this.mainTableLayout.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayout.Controls.Add(this.mainMenuStrip, 0, 0);
            this.mainTableLayout.Controls.Add(this.mainTeamSelector, 1, 0);
            this.mainTableLayout.Controls.Add(this.tabControl1, 0, 1);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Size = new System.Drawing.Size(1018, 539);
            this.mainTableLayout.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(509, 23);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // mainTeamSelector
            // 
            this.mainTeamSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTeamSelector.FormattingEnabled = true;
            this.mainTeamSelector.Location = new System.Drawing.Point(512, 3);
            this.mainTeamSelector.Name = "mainTeamSelector";
            this.mainTeamSelector.Size = new System.Drawing.Size(503, 21);
            this.mainTeamSelector.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.mainTableLayout.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.matchScoutingTabPage);
            this.tabControl1.Controls.Add(this.pitScoutingTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 510);
            this.tabControl1.TabIndex = 2;
            // 
            // matchScoutingTabPage
            // 
            this.matchScoutingTabPage.Location = new System.Drawing.Point(4, 22);
            this.matchScoutingTabPage.Name = "matchScoutingTabPage";
            this.matchScoutingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.matchScoutingTabPage.Size = new System.Drawing.Size(1004, 484);
            this.matchScoutingTabPage.TabIndex = 0;
            this.matchScoutingTabPage.Text = "Match Scouting";
            this.matchScoutingTabPage.UseVisualStyleBackColor = true;
            // 
            // pitScoutingTabPage
            // 
            this.pitScoutingTabPage.Location = new System.Drawing.Point(4, 22);
            this.pitScoutingTabPage.Name = "pitScoutingTabPage";
            this.pitScoutingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pitScoutingTabPage.Size = new System.Drawing.Size(1004, 484);
            this.pitScoutingTabPage.TabIndex = 1;
            this.pitScoutingTabPage.Text = "Pit Scouting";
            this.pitScoutingTabPage.UseVisualStyleBackColor = true;
            // 
            // Stronghold_GTR_East
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 539);
            this.Controls.Add(this.mainTableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Stronghold_GTR_East";
            this.Text = "Stronghold | GTR East | 2016";
            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox mainTeamSelector;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage matchScoutingTabPage;
        private System.Windows.Forms.TabPage pitScoutingTabPage;
    }
}