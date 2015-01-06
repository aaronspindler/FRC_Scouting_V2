namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    partial class RecycleRush_GTR_East
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecycleRush_GTR_East));
            this.scoutingTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamSelector = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.matchBreakdownTabPage = new System.Windows.Forms.TabPage();
            this.overallStatisticsTabPage = new System.Windows.Forms.TabPage();
            this.pitScoutingTabPage = new System.Windows.Forms.TabPage();
            this.teamInformationTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scoutingTabPage
            // 
            this.scoutingTabPage.Location = new System.Drawing.Point(4, 34);
            this.scoutingTabPage.Name = "scoutingTabPage";
            this.scoutingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.scoutingTabPage.Size = new System.Drawing.Size(1675, 810);
            this.scoutingTabPage.TabIndex = 0;
            this.scoutingTabPage.Text = "Scouting";
            this.scoutingTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.teamSelector, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1689, 904);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 4);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // teamSelector
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.teamSelector, 4);
            this.teamSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamSelector.FormattingEnabled = true;
            this.teamSelector.Location = new System.Drawing.Point(847, 3);
            this.teamSelector.Name = "teamSelector";
            this.teamSelector.Size = new System.Drawing.Size(839, 33);
            this.teamSelector.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 8);
            this.tabControl1.Controls.Add(this.scoutingTabPage);
            this.tabControl1.Controls.Add(this.matchBreakdownTabPage);
            this.tabControl1.Controls.Add(this.overallStatisticsTabPage);
            this.tabControl1.Controls.Add(this.pitScoutingTabPage);
            this.tabControl1.Controls.Add(this.teamInformationTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1683, 848);
            this.tabControl1.TabIndex = 2;
            // 
            // matchBreakdownTabPage
            // 
            this.matchBreakdownTabPage.Location = new System.Drawing.Point(4, 34);
            this.matchBreakdownTabPage.Name = "matchBreakdownTabPage";
            this.matchBreakdownTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.matchBreakdownTabPage.Size = new System.Drawing.Size(1675, 810);
            this.matchBreakdownTabPage.TabIndex = 1;
            this.matchBreakdownTabPage.Text = "Match Breakdown";
            this.matchBreakdownTabPage.UseVisualStyleBackColor = true;
            // 
            // overallStatisticsTabPage
            // 
            this.overallStatisticsTabPage.Location = new System.Drawing.Point(4, 34);
            this.overallStatisticsTabPage.Name = "overallStatisticsTabPage";
            this.overallStatisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.overallStatisticsTabPage.Size = new System.Drawing.Size(1675, 810);
            this.overallStatisticsTabPage.TabIndex = 2;
            this.overallStatisticsTabPage.Text = "Overall Statistics";
            this.overallStatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // pitScoutingTabPage
            // 
            this.pitScoutingTabPage.Location = new System.Drawing.Point(4, 34);
            this.pitScoutingTabPage.Name = "pitScoutingTabPage";
            this.pitScoutingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pitScoutingTabPage.Size = new System.Drawing.Size(1675, 810);
            this.pitScoutingTabPage.TabIndex = 3;
            this.pitScoutingTabPage.Text = "Pit Scouting";
            this.pitScoutingTabPage.UseVisualStyleBackColor = true;
            // 
            // teamInformationTabPage
            // 
            this.teamInformationTabPage.Location = new System.Drawing.Point(4, 34);
            this.teamInformationTabPage.Name = "teamInformationTabPage";
            this.teamInformationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.teamInformationTabPage.Size = new System.Drawing.Size(1675, 810);
            this.teamInformationTabPage.TabIndex = 4;
            this.teamInformationTabPage.Text = "Team Information";
            this.teamInformationTabPage.UseVisualStyleBackColor = true;
            // 
            // RecycleRush_GTR_East
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1689, 904);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecycleRush_GTR_East";
            this.Text = "RecycleRush | GTR East | 2015";
            this.Load += new System.EventHandler(this.RecycleRush_GTR_East_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage scoutingTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox teamSelector;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage matchBreakdownTabPage;
        private System.Windows.Forms.TabPage overallStatisticsTabPage;
        private System.Windows.Forms.TabPage pitScoutingTabPage;
        private System.Windows.Forms.TabPage teamInformationTabPage;

    }
}