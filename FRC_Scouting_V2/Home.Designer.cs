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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.frcLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fRC3710TeamInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllSavedSettingsToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleConsoleWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventSelector = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.eventSelector, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 729);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // frcLogoPictureBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.frcLogoPictureBox, 8);
            this.frcLogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frcLogoPictureBox.Image = global::FRC_Scouting_V2.Properties.Resources.FRC_LOGO;
            this.frcLogoPictureBox.Location = new System.Drawing.Point(6, 54);
            this.frcLogoPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.frcLogoPictureBox.Name = "frcLogoPictureBox";
            this.tableLayoutPanel1.SetRowSpan(this.frcLogoPictureBox, 8);
            this.frcLogoPictureBox.Size = new System.Drawing.Size(980, 669);
            this.frcLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.frcLogoPictureBox.TabIndex = 1;
            this.frcLogoPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 4);
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(496, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 40);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(244, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changelogToolStripMenuItem,
            this.fRC3710TeamInformationToolStripMenuItem,
            this.programInformationToolStripMenuItem,
            this.licenseInformationToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(152, 40);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(388, 36);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // fRC3710TeamInformationToolStripMenuItem
            // 
            this.fRC3710TeamInformationToolStripMenuItem.Name = "fRC3710TeamInformationToolStripMenuItem";
            this.fRC3710TeamInformationToolStripMenuItem.Size = new System.Drawing.Size(388, 36);
            this.fRC3710TeamInformationToolStripMenuItem.Text = "FRC 3710 Team Information";
            this.fRC3710TeamInformationToolStripMenuItem.Click += new System.EventHandler(this.fRC3710TeamInformationToolStripMenuItem_Click);
            // 
            // programInformationToolStripMenuItem
            // 
            this.programInformationToolStripMenuItem.Name = "programInformationToolStripMenuItem";
            this.programInformationToolStripMenuItem.Size = new System.Drawing.Size(388, 36);
            this.programInformationToolStripMenuItem.Text = "Program Information";
            this.programInformationToolStripMenuItem.Click += new System.EventHandler(this.programInformationToolStripMenuItem_Click);
            // 
            // licenseInformationToolStripMenuItem
            // 
            this.licenseInformationToolStripMenuItem.Name = "licenseInformationToolStripMenuItem";
            this.licenseInformationToolStripMenuItem.Size = new System.Drawing.Size(388, 36);
            this.licenseInformationToolStripMenuItem.Text = "License Information";
            this.licenseInformationToolStripMenuItem.Click += new System.EventHandler(this.licenseInformationToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllSavedSettingsToDefaultToolStripMenuItem,
            this.toggleConsoleWindowToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(99, 40);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // resetAllSavedSettingsToDefaultToolStripMenuItem
            // 
            this.resetAllSavedSettingsToDefaultToolStripMenuItem.Name = "resetAllSavedSettingsToDefaultToolStripMenuItem";
            this.resetAllSavedSettingsToDefaultToolStripMenuItem.Size = new System.Drawing.Size(460, 36);
            this.resetAllSavedSettingsToDefaultToolStripMenuItem.Text = "Reset All Saved Settings to Default";
            this.resetAllSavedSettingsToDefaultToolStripMenuItem.Click += new System.EventHandler(this.resetAllSavedSettingsToDefaultToolStripMenuItem_Click);
            // 
            // toggleConsoleWindowToolStripMenuItem
            // 
            this.toggleConsoleWindowToolStripMenuItem.Name = "toggleConsoleWindowToolStripMenuItem";
            this.toggleConsoleWindowToolStripMenuItem.Size = new System.Drawing.Size(460, 36);
            this.toggleConsoleWindowToolStripMenuItem.Text = "Toggle Console Window";
            this.toggleConsoleWindowToolStripMenuItem.Click += new System.EventHandler(this.toggleConsoleWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(113, 40);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // eventSelector
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.eventSelector, 4);
            this.eventSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventSelector.FormattingEnabled = true;
            this.eventSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.eventSelector.Location = new System.Drawing.Point(502, 6);
            this.eventSelector.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.eventSelector.Name = "eventSelector";
            this.eventSelector.Size = new System.Drawing.Size(484, 33);
            this.eventSelector.TabIndex = 2;
            this.eventSelector.SelectedIndexChanged += new System.EventHandler(this.eventSelector_SelectedIndexChanged);
            this.eventSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eventSelector_KeyDown);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 729);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "FRC_Scouting_V2";
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
        private System.Windows.Forms.ComboBox eventSelector;
        private System.Windows.Forms.ToolStripMenuItem resetAllSavedSettingsToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleConsoleWindowToolStripMenuItem;
    }
}

