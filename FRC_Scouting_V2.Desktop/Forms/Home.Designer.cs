namespace FRC_Scouting_V2
{
    partial class Home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.frcLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fRC3710TeamInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.teamInformationLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventInformationLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConsoleWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.initializeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventSelector = new System.Windows.Forms.ToolStripComboBox();
            this.myWebsiteRichTextBox = new System.Windows.Forms.RichTextBox();
            this.isInternetConnectedLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frcLogoPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.frcLogoPictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.myWebsiteRichTextBox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.isInternetConnectedLabel, 4, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // frcLogoPictureBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.frcLogoPictureBox, 8);
            this.frcLogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frcLogoPictureBox.Image = global::FRC_Scouting_V2.Properties.Resources.FRC_LOGO;
            this.frcLogoPictureBox.Location = new System.Drawing.Point(3, 28);
            this.frcLogoPictureBox.Name = "frcLogoPictureBox";
            this.tableLayoutPanel1.SetRowSpan(this.frcLogoPictureBox, 7);
            this.frcLogoPictureBox.Size = new System.Drawing.Size(490, 323);
            this.frcLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.frcLogoPictureBox.TabIndex = 1;
            this.frcLogoPictureBox.TabStop = false;
            this.frcLogoPictureBox.Click += new System.EventHandler(this.frcLogoPictureBox_Click);
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 8);
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.eventSelector});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fRC3710TeamInformationToolStripMenuItem,
            this.programInformationToolStripMenuItem,
            this.licenseInformationToolStripMenuItem,
            this.toolStripSeparator2,
            this.teamInformationLookupToolStripMenuItem,
            this.eventInformationLookupToolStripMenuItem,
            this.toolStripSeparator1,
            this.changeLogToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 21);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // fRC3710TeamInformationToolStripMenuItem
            // 
            this.fRC3710TeamInformationToolStripMenuItem.Name = "fRC3710TeamInformationToolStripMenuItem";
            this.fRC3710TeamInformationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.fRC3710TeamInformationToolStripMenuItem.Text = "FRC 3710 Team Information";
            this.fRC3710TeamInformationToolStripMenuItem.Click += new System.EventHandler(this.fRC3710TeamInformationToolStripMenuItem_Click);
            // 
            // programInformationToolStripMenuItem
            // 
            this.programInformationToolStripMenuItem.Name = "programInformationToolStripMenuItem";
            this.programInformationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.programInformationToolStripMenuItem.Text = "Program Information";
            this.programInformationToolStripMenuItem.Click += new System.EventHandler(this.programInformationToolStripMenuItem_Click);
            // 
            // licenseInformationToolStripMenuItem
            // 
            this.licenseInformationToolStripMenuItem.Name = "licenseInformationToolStripMenuItem";
            this.licenseInformationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.licenseInformationToolStripMenuItem.Text = "License Information";
            this.licenseInformationToolStripMenuItem.Click += new System.EventHandler(this.licenseInformationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // teamInformationLookupToolStripMenuItem
            // 
            this.teamInformationLookupToolStripMenuItem.Name = "teamInformationLookupToolStripMenuItem";
            this.teamInformationLookupToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.teamInformationLookupToolStripMenuItem.Text = "Team Information Lookup";
            this.teamInformationLookupToolStripMenuItem.Click += new System.EventHandler(this.teamInformationLookupToolStripMenuItem_Click);
            // 
            // eventInformationLookupToolStripMenuItem
            // 
            this.eventInformationLookupToolStripMenuItem.Name = "eventInformationLookupToolStripMenuItem";
            this.eventInformationLookupToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.eventInformationLookupToolStripMenuItem.Text = "Event Information Lookup";
            this.eventInformationLookupToolStripMenuItem.Click += new System.EventHandler(this.eventInformationLookupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.changeLogToolStripMenuItem.Text = "Changelog";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConsoleWindowToolStripMenuItem,
            this.toolStripSeparator3,
            this.initializeDatabaseToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // showConsoleWindowToolStripMenuItem
            // 
            this.showConsoleWindowToolStripMenuItem.Name = "showConsoleWindowToolStripMenuItem";
            this.showConsoleWindowToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showConsoleWindowToolStripMenuItem.Text = "Console Window";
            this.showConsoleWindowToolStripMenuItem.Click += new System.EventHandler(this.showConsoleWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // initializeDatabaseToolStripMenuItem
            // 
            this.initializeDatabaseToolStripMenuItem.Name = "initializeDatabaseToolStripMenuItem";
            this.initializeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.initializeDatabaseToolStripMenuItem.Text = "Initialize Database";
            this.initializeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.initializeDatabaseToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // eventSelector
            // 
            this.eventSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventSelector.DropDownWidth = 245;
            this.eventSelector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eventSelector.Name = "eventSelector";
            this.eventSelector.Size = new System.Drawing.Size(248, 21);
            this.eventSelector.SelectedIndexChanged += new System.EventHandler(this.eventSelector_SelectedIndexChanged_1);
            // 
            // myWebsiteRichTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.myWebsiteRichTextBox, 4);
            this.myWebsiteRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myWebsiteRichTextBox.Location = new System.Drawing.Point(3, 357);
            this.myWebsiteRichTextBox.Name = "myWebsiteRichTextBox";
            this.myWebsiteRichTextBox.ReadOnly = true;
            this.myWebsiteRichTextBox.Size = new System.Drawing.Size(242, 19);
            this.myWebsiteRichTextBox.TabIndex = 2;
            this.myWebsiteRichTextBox.Text = "See my other projects at www.xNovax.net";
            this.myWebsiteRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.myWebsiteRichTextBox_LinkClicked);
            // 
            // isInternetConnectedLabel
            // 
            this.isInternetConnectedLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.isInternetConnectedLabel, 4);
            this.isInternetConnectedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isInternetConnectedLabel.Location = new System.Drawing.Point(251, 354);
            this.isInternetConnectedLabel.Name = "isInternetConnectedLabel";
            this.isInternetConnectedLabel.Size = new System.Drawing.Size(242, 25);
            this.isInternetConnectedLabel.TabIndex = 3;
            this.isInternetConnectedLabel.Text = "Testing your internet connection...";
            this.isInternetConnectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 15000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRC_Scouting_V2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.Load += new System.EventHandler(this.Home_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frcLogoPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fRC3710TeamInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.PictureBox frcLogoPictureBox;
        private System.Windows.Forms.ToolStripMenuItem licenseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamInformationLookupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox eventSelector;
        private System.Windows.Forms.ToolStripMenuItem showConsoleWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventInformationLookupToolStripMenuItem;
        private System.Windows.Forms.RichTextBox myWebsiteRichTextBox;
        private System.Windows.Forms.Label isInternetConnectedLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem initializeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
    }
}

