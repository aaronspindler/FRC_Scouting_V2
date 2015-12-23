namespace FRC_Scouting_V2.Forms
{
    partial class GeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.generalSettingsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.databaseSettingsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.serverAddressLabel = new System.Windows.Forms.Label();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.databaseUsernameLabel = new System.Windows.Forms.Label();
            this.databasePasswordLabel = new System.Windows.Forms.Label();
            this.databaseServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.databasePortTextBox = new System.Windows.Forms.TextBox();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.databaseUsernameTextBox = new System.Windows.Forms.TextBox();
            this.databasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.databaseConnectionDisplay = new System.Windows.Forms.Label();
            this.databaseSaveTestButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.saveGeneralSettingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.generalSettingsTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.databaseSettingsTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.settingsTabControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(626, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.generalSettingsTabPage);
            this.settingsTabControl.Controls.Add(this.databaseSettingsTabPage);
            this.settingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTabControl.Location = new System.Drawing.Point(3, 28);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(620, 434);
            this.settingsTabControl.TabIndex = 1;
            // 
            // generalSettingsTabPage
            // 
            this.generalSettingsTabPage.Controls.Add(this.tableLayoutPanel3);
            this.generalSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalSettingsTabPage.Name = "generalSettingsTabPage";
            this.generalSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalSettingsTabPage.Size = new System.Drawing.Size(612, 408);
            this.generalSettingsTabPage.TabIndex = 0;
            this.generalSettingsTabPage.Text = "General Settings";
            this.generalSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.usernameLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.usernameTextBox, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.saveGeneralSettingsButton, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(606, 402);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // databaseSettingsTabPage
            // 
            this.databaseSettingsTabPage.Controls.Add(this.tableLayoutPanel2);
            this.databaseSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.databaseSettingsTabPage.Name = "databaseSettingsTabPage";
            this.databaseSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.databaseSettingsTabPage.Size = new System.Drawing.Size(612, 408);
            this.databaseSettingsTabPage.TabIndex = 1;
            this.databaseSettingsTabPage.Text = "Database Credentials";
            this.databaseSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.serverAddressLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.serverPortLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.databaseNameLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.databaseUsernameLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.databasePasswordLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.databaseServerAddressTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.databasePortTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.databaseNameTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.databaseUsernameTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.databasePasswordTextBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.databaseConnectionDisplay, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.databaseSaveTestButton, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(606, 402);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // serverAddressLabel
            // 
            this.serverAddressLabel.AutoSize = true;
            this.serverAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverAddressLabel.Location = new System.Drawing.Point(3, 0);
            this.serverAddressLabel.Name = "serverAddressLabel";
            this.serverAddressLabel.Size = new System.Drawing.Size(175, 25);
            this.serverAddressLabel.TabIndex = 0;
            this.serverAddressLabel.Text = "Server Address:";
            this.serverAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverPortLabel.Location = new System.Drawing.Point(3, 25);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(175, 25);
            this.serverPortLabel.TabIndex = 1;
            this.serverPortLabel.Text = "Server Port:";
            this.serverPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseNameLabel.Location = new System.Drawing.Point(3, 50);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(175, 25);
            this.databaseNameLabel.TabIndex = 2;
            this.databaseNameLabel.Text = "Database Name:";
            this.databaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // databaseUsernameLabel
            // 
            this.databaseUsernameLabel.AutoSize = true;
            this.databaseUsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseUsernameLabel.Location = new System.Drawing.Point(3, 75);
            this.databaseUsernameLabel.Name = "databaseUsernameLabel";
            this.databaseUsernameLabel.Size = new System.Drawing.Size(175, 25);
            this.databaseUsernameLabel.TabIndex = 3;
            this.databaseUsernameLabel.Text = "Username:";
            this.databaseUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // databasePasswordLabel
            // 
            this.databasePasswordLabel.AutoSize = true;
            this.databasePasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePasswordLabel.Location = new System.Drawing.Point(3, 100);
            this.databasePasswordLabel.Name = "databasePasswordLabel";
            this.databasePasswordLabel.Size = new System.Drawing.Size(175, 25);
            this.databasePasswordLabel.TabIndex = 4;
            this.databasePasswordLabel.Text = "Password:";
            this.databasePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // databaseServerAddressTextBox
            // 
            this.databaseServerAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseServerAddressTextBox.Location = new System.Drawing.Point(184, 3);
            this.databaseServerAddressTextBox.Name = "databaseServerAddressTextBox";
            this.databaseServerAddressTextBox.Size = new System.Drawing.Size(419, 20);
            this.databaseServerAddressTextBox.TabIndex = 5;
            // 
            // databasePortTextBox
            // 
            this.databasePortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePortTextBox.Location = new System.Drawing.Point(184, 28);
            this.databasePortTextBox.Name = "databasePortTextBox";
            this.databasePortTextBox.Size = new System.Drawing.Size(419, 20);
            this.databasePortTextBox.TabIndex = 6;
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseNameTextBox.Location = new System.Drawing.Point(184, 53);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.databaseNameTextBox.TabIndex = 7;
            // 
            // databaseUsernameTextBox
            // 
            this.databaseUsernameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseUsernameTextBox.Location = new System.Drawing.Point(184, 78);
            this.databaseUsernameTextBox.Name = "databaseUsernameTextBox";
            this.databaseUsernameTextBox.Size = new System.Drawing.Size(419, 20);
            this.databaseUsernameTextBox.TabIndex = 8;
            // 
            // databasePasswordTextBox
            // 
            this.databasePasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasePasswordTextBox.Location = new System.Drawing.Point(184, 103);
            this.databasePasswordTextBox.Name = "databasePasswordTextBox";
            this.databasePasswordTextBox.PasswordChar = '*';
            this.databasePasswordTextBox.Size = new System.Drawing.Size(419, 20);
            this.databasePasswordTextBox.TabIndex = 9;
            // 
            // databaseConnectionDisplay
            // 
            this.databaseConnectionDisplay.AutoSize = true;
            this.databaseConnectionDisplay.BackColor = System.Drawing.Color.Yellow;
            this.databaseConnectionDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseConnectionDisplay.Location = new System.Drawing.Point(3, 125);
            this.databaseConnectionDisplay.Name = "databaseConnectionDisplay";
            this.databaseConnectionDisplay.Size = new System.Drawing.Size(175, 30);
            this.databaseConnectionDisplay.TabIndex = 10;
            this.databaseConnectionDisplay.Text = "Connection: Testing";
            this.databaseConnectionDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // databaseSaveTestButton
            // 
            this.databaseSaveTestButton.Location = new System.Drawing.Point(184, 128);
            this.databaseSaveTestButton.Name = "databaseSaveTestButton";
            this.databaseSaveTestButton.Size = new System.Drawing.Size(214, 23);
            this.databaseSaveTestButton.TabIndex = 11;
            this.databaseSaveTestButton.Text = "Save and Test";
            this.databaseSaveTestButton.UseVisualStyleBackColor = true;
            this.databaseSaveTestButton.Click += new System.EventHandler(this.databaseSaveTestButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToDefaultToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // resetToDefaultToolStripMenuItem
            // 
            this.resetToDefaultToolStripMenuItem.Name = "resetToDefaultToolStripMenuItem";
            this.resetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetToDefaultToolStripMenuItem.Text = "Reset To Default";
            this.resetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.resetToDefaultToolStripMenuItem_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.usernameLabel, 2);
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameLabel.Location = new System.Drawing.Point(3, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(296, 25);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usernameTextBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.usernameTextBox, 2);
            this.usernameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameTextBox.Location = new System.Drawing.Point(305, 3);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(298, 20);
            this.usernameTextBox.TabIndex = 8;
            // 
            // saveGeneralSettingsButton
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.saveGeneralSettingsButton, 2);
            this.saveGeneralSettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveGeneralSettingsButton.Location = new System.Drawing.Point(154, 28);
            this.saveGeneralSettingsButton.Name = "saveGeneralSettingsButton";
            this.saveGeneralSettingsButton.Size = new System.Drawing.Size(296, 24);
            this.saveGeneralSettingsButton.TabIndex = 9;
            this.saveGeneralSettingsButton.Text = "Save";
            this.saveGeneralSettingsButton.UseVisualStyleBackColor = true;
            this.saveGeneralSettingsButton.Click += new System.EventHandler(this.saveGeneralSettingsButton_Click);
            // 
            // GeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GeneralSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRC_Scouting_V2 | Settings";
            this.Load += new System.EventHandler(this.GeneralSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.settingsTabControl.ResumeLayout(false);
            this.generalSettingsTabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.databaseSettingsTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage generalSettingsTabPage;
        private System.Windows.Forms.TabPage databaseSettingsTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label serverAddressLabel;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.Label databaseUsernameLabel;
        private System.Windows.Forms.Label databasePasswordLabel;
        private System.Windows.Forms.TextBox databaseServerAddressTextBox;
        private System.Windows.Forms.TextBox databasePortTextBox;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.TextBox databaseUsernameTextBox;
        private System.Windows.Forms.TextBox databasePasswordTextBox;
        private System.Windows.Forms.Label databaseConnectionDisplay;
        private System.Windows.Forms.Button databaseSaveTestButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button saveGeneralSettingsButton;
    }
}