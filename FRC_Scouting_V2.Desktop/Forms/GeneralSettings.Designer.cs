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
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.generalSettingsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.saveGeneralSettingsButton = new System.Windows.Forms.Button();
            this.oldDatabaseSettingsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.mySqlServerAddressLabel = new System.Windows.Forms.Label();
            this.mySqlServerPortLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseNameLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseUsernameLabel = new System.Windows.Forms.Label();
            this.mySqlDatabasePasswordLabel = new System.Windows.Forms.Label();
            this.mySqlDatabaseServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabasePortTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseUsernameTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.mySqlDatabaseConnectionDisplay = new System.Windows.Forms.Label();
            this.mySqlDatabaseSaveTestButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.newDatabaseSettingsTabPage = new System.Windows.Forms.TabPage();
            this.mysqlGroupBox = new System.Windows.Forms.GroupBox();
            this.sqlGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.sqlServerAddressLabel = new System.Windows.Forms.Label();
            this.sqlServerPortLabel = new System.Windows.Forms.Label();
            this.sqlDatabaseNameLabel = new System.Windows.Forms.Label();
            this.sqlDatabaseUsernameLabel = new System.Windows.Forms.Label();
            this.sqlDatabasePasswordLabel = new System.Windows.Forms.Label();
            this.sqlDatabaseServerAddress = new System.Windows.Forms.TextBox();
            this.sqlDatabasePortTextBox = new System.Windows.Forms.TextBox();
            this.sqlDatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlDatabaseUsernameTextBox = new System.Windows.Forms.TextBox();
            this.sqlDatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.sqlDatabaseConnectionDisplay = new System.Windows.Forms.Label();
            this.sqlDatabaseSaveTestButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.generalSettingsTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.oldDatabaseSettingsTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.newDatabaseSettingsTabPage.SuspendLayout();
            this.mysqlGroupBox.SuspendLayout();
            this.sqlGroupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.generalSettingsTabPage);
            this.settingsTabControl.Controls.Add(this.newDatabaseSettingsTabPage);
            this.settingsTabControl.Controls.Add(this.oldDatabaseSettingsTabPage);
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
            // oldDatabaseSettingsTabPage
            // 
            this.oldDatabaseSettingsTabPage.Controls.Add(this.mysqlGroupBox);
            this.oldDatabaseSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.oldDatabaseSettingsTabPage.Name = "oldDatabaseSettingsTabPage";
            this.oldDatabaseSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.oldDatabaseSettingsTabPage.Size = new System.Drawing.Size(612, 408);
            this.oldDatabaseSettingsTabPage.TabIndex = 1;
            this.oldDatabaseSettingsTabPage.Text = "Database Credentials (2014 - 2015)";
            this.oldDatabaseSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.mySqlServerAddressLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mySqlServerPortLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseNameLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseUsernameLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabasePasswordLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseServerAddressTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabasePortTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseNameTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseUsernameTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabasePasswordTextBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseConnectionDisplay, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.mySqlDatabaseSaveTestButton, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(600, 383);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // mySqlServerAddressLabel
            // 
            this.mySqlServerAddressLabel.AutoSize = true;
            this.mySqlServerAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlServerAddressLabel.Location = new System.Drawing.Point(3, 0);
            this.mySqlServerAddressLabel.Name = "mySqlServerAddressLabel";
            this.mySqlServerAddressLabel.Size = new System.Drawing.Size(174, 25);
            this.mySqlServerAddressLabel.TabIndex = 0;
            this.mySqlServerAddressLabel.Text = "Server Address:";
            this.mySqlServerAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mySqlServerPortLabel
            // 
            this.mySqlServerPortLabel.AutoSize = true;
            this.mySqlServerPortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlServerPortLabel.Location = new System.Drawing.Point(3, 25);
            this.mySqlServerPortLabel.Name = "mySqlServerPortLabel";
            this.mySqlServerPortLabel.Size = new System.Drawing.Size(174, 25);
            this.mySqlServerPortLabel.TabIndex = 1;
            this.mySqlServerPortLabel.Text = "Server Port:";
            this.mySqlServerPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mySqlDatabaseNameLabel
            // 
            this.mySqlDatabaseNameLabel.AutoSize = true;
            this.mySqlDatabaseNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseNameLabel.Location = new System.Drawing.Point(3, 50);
            this.mySqlDatabaseNameLabel.Name = "mySqlDatabaseNameLabel";
            this.mySqlDatabaseNameLabel.Size = new System.Drawing.Size(174, 25);
            this.mySqlDatabaseNameLabel.TabIndex = 2;
            this.mySqlDatabaseNameLabel.Text = "Database Name:";
            this.mySqlDatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mySqlDatabaseUsernameLabel
            // 
            this.mySqlDatabaseUsernameLabel.AutoSize = true;
            this.mySqlDatabaseUsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseUsernameLabel.Location = new System.Drawing.Point(3, 75);
            this.mySqlDatabaseUsernameLabel.Name = "mySqlDatabaseUsernameLabel";
            this.mySqlDatabaseUsernameLabel.Size = new System.Drawing.Size(174, 25);
            this.mySqlDatabaseUsernameLabel.TabIndex = 3;
            this.mySqlDatabaseUsernameLabel.Text = "Username:";
            this.mySqlDatabaseUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mySqlDatabasePasswordLabel
            // 
            this.mySqlDatabasePasswordLabel.AutoSize = true;
            this.mySqlDatabasePasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabasePasswordLabel.Location = new System.Drawing.Point(3, 100);
            this.mySqlDatabasePasswordLabel.Name = "mySqlDatabasePasswordLabel";
            this.mySqlDatabasePasswordLabel.Size = new System.Drawing.Size(174, 25);
            this.mySqlDatabasePasswordLabel.TabIndex = 4;
            this.mySqlDatabasePasswordLabel.Text = "Password:";
            this.mySqlDatabasePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mySqlDatabaseServerAddressTextBox
            // 
            this.mySqlDatabaseServerAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseServerAddressTextBox.Location = new System.Drawing.Point(183, 3);
            this.mySqlDatabaseServerAddressTextBox.Name = "mySqlDatabaseServerAddressTextBox";
            this.mySqlDatabaseServerAddressTextBox.Size = new System.Drawing.Size(414, 20);
            this.mySqlDatabaseServerAddressTextBox.TabIndex = 5;
            // 
            // mySqlDatabasePortTextBox
            // 
            this.mySqlDatabasePortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabasePortTextBox.Location = new System.Drawing.Point(183, 28);
            this.mySqlDatabasePortTextBox.Name = "mySqlDatabasePortTextBox";
            this.mySqlDatabasePortTextBox.Size = new System.Drawing.Size(414, 20);
            this.mySqlDatabasePortTextBox.TabIndex = 6;
            // 
            // mySqlDatabaseNameTextBox
            // 
            this.mySqlDatabaseNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseNameTextBox.Location = new System.Drawing.Point(183, 53);
            this.mySqlDatabaseNameTextBox.Name = "mySqlDatabaseNameTextBox";
            this.mySqlDatabaseNameTextBox.Size = new System.Drawing.Size(414, 20);
            this.mySqlDatabaseNameTextBox.TabIndex = 7;
            // 
            // mySqlDatabaseUsernameTextBox
            // 
            this.mySqlDatabaseUsernameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseUsernameTextBox.Location = new System.Drawing.Point(183, 78);
            this.mySqlDatabaseUsernameTextBox.Name = "mySqlDatabaseUsernameTextBox";
            this.mySqlDatabaseUsernameTextBox.Size = new System.Drawing.Size(414, 20);
            this.mySqlDatabaseUsernameTextBox.TabIndex = 8;
            // 
            // mySqlDatabasePasswordTextBox
            // 
            this.mySqlDatabasePasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabasePasswordTextBox.Location = new System.Drawing.Point(183, 103);
            this.mySqlDatabasePasswordTextBox.Name = "mySqlDatabasePasswordTextBox";
            this.mySqlDatabasePasswordTextBox.PasswordChar = '*';
            this.mySqlDatabasePasswordTextBox.Size = new System.Drawing.Size(414, 20);
            this.mySqlDatabasePasswordTextBox.TabIndex = 9;
            // 
            // mySqlDatabaseConnectionDisplay
            // 
            this.mySqlDatabaseConnectionDisplay.AutoSize = true;
            this.mySqlDatabaseConnectionDisplay.BackColor = System.Drawing.Color.Yellow;
            this.mySqlDatabaseConnectionDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySqlDatabaseConnectionDisplay.Location = new System.Drawing.Point(3, 125);
            this.mySqlDatabaseConnectionDisplay.Name = "mySqlDatabaseConnectionDisplay";
            this.mySqlDatabaseConnectionDisplay.Size = new System.Drawing.Size(174, 30);
            this.mySqlDatabaseConnectionDisplay.TabIndex = 10;
            this.mySqlDatabaseConnectionDisplay.Text = "Connection: Testing";
            this.mySqlDatabaseConnectionDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mySqlDatabaseSaveTestButton
            // 
            this.mySqlDatabaseSaveTestButton.Location = new System.Drawing.Point(183, 128);
            this.mySqlDatabaseSaveTestButton.Name = "mySqlDatabaseSaveTestButton";
            this.mySqlDatabaseSaveTestButton.Size = new System.Drawing.Size(214, 23);
            this.mySqlDatabaseSaveTestButton.TabIndex = 11;
            this.mySqlDatabaseSaveTestButton.Text = "Save and Test";
            this.mySqlDatabaseSaveTestButton.UseVisualStyleBackColor = true;
            this.mySqlDatabaseSaveTestButton.Click += new System.EventHandler(this.databaseSaveTestButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // newDatabaseSettingsTabPage
            // 
            this.newDatabaseSettingsTabPage.Controls.Add(this.sqlGroupBox);
            this.newDatabaseSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.newDatabaseSettingsTabPage.Name = "newDatabaseSettingsTabPage";
            this.newDatabaseSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.newDatabaseSettingsTabPage.Size = new System.Drawing.Size(612, 408);
            this.newDatabaseSettingsTabPage.TabIndex = 2;
            this.newDatabaseSettingsTabPage.Text = "Database Credentials (2016 - Onward)";
            this.newDatabaseSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // mysqlGroupBox
            // 
            this.mysqlGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.mysqlGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mysqlGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mysqlGroupBox.Name = "mysqlGroupBox";
            this.mysqlGroupBox.Size = new System.Drawing.Size(606, 402);
            this.mysqlGroupBox.TabIndex = 1;
            this.mysqlGroupBox.TabStop = false;
            this.mysqlGroupBox.Text = "MySQL";
            // 
            // sqlGroupBox
            // 
            this.sqlGroupBox.Controls.Add(this.tableLayoutPanel4);
            this.sqlGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sqlGroupBox.Name = "sqlGroupBox";
            this.sqlGroupBox.Size = new System.Drawing.Size(606, 402);
            this.sqlGroupBox.TabIndex = 0;
            this.sqlGroupBox.TabStop = false;
            this.sqlGroupBox.Text = "SQL";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.sqlServerAddressLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.sqlServerPortLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseNameLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseUsernameLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabasePasswordLabel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseServerAddress, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabasePortTextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseNameTextBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseUsernameTextBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabasePasswordTextBox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseConnectionDisplay, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.sqlDatabaseSaveTestButton, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(600, 383);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // sqlServerAddressLabel
            // 
            this.sqlServerAddressLabel.AutoSize = true;
            this.sqlServerAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlServerAddressLabel.Location = new System.Drawing.Point(3, 0);
            this.sqlServerAddressLabel.Name = "sqlServerAddressLabel";
            this.sqlServerAddressLabel.Size = new System.Drawing.Size(174, 25);
            this.sqlServerAddressLabel.TabIndex = 0;
            this.sqlServerAddressLabel.Text = "Server Address:";
            this.sqlServerAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlServerPortLabel
            // 
            this.sqlServerPortLabel.AutoSize = true;
            this.sqlServerPortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlServerPortLabel.Location = new System.Drawing.Point(3, 25);
            this.sqlServerPortLabel.Name = "sqlServerPortLabel";
            this.sqlServerPortLabel.Size = new System.Drawing.Size(174, 25);
            this.sqlServerPortLabel.TabIndex = 1;
            this.sqlServerPortLabel.Text = "Server Port:";
            this.sqlServerPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlDatabaseNameLabel
            // 
            this.sqlDatabaseNameLabel.AutoSize = true;
            this.sqlDatabaseNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseNameLabel.Location = new System.Drawing.Point(3, 50);
            this.sqlDatabaseNameLabel.Name = "sqlDatabaseNameLabel";
            this.sqlDatabaseNameLabel.Size = new System.Drawing.Size(174, 25);
            this.sqlDatabaseNameLabel.TabIndex = 2;
            this.sqlDatabaseNameLabel.Text = "Database Name:";
            this.sqlDatabaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlDatabaseUsernameLabel
            // 
            this.sqlDatabaseUsernameLabel.AutoSize = true;
            this.sqlDatabaseUsernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseUsernameLabel.Location = new System.Drawing.Point(3, 75);
            this.sqlDatabaseUsernameLabel.Name = "sqlDatabaseUsernameLabel";
            this.sqlDatabaseUsernameLabel.Size = new System.Drawing.Size(174, 25);
            this.sqlDatabaseUsernameLabel.TabIndex = 3;
            this.sqlDatabaseUsernameLabel.Text = "Username:";
            this.sqlDatabaseUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlDatabasePasswordLabel
            // 
            this.sqlDatabasePasswordLabel.AutoSize = true;
            this.sqlDatabasePasswordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabasePasswordLabel.Location = new System.Drawing.Point(3, 100);
            this.sqlDatabasePasswordLabel.Name = "sqlDatabasePasswordLabel";
            this.sqlDatabasePasswordLabel.Size = new System.Drawing.Size(174, 25);
            this.sqlDatabasePasswordLabel.TabIndex = 4;
            this.sqlDatabasePasswordLabel.Text = "Password:";
            this.sqlDatabasePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlDatabaseServerAddress
            // 
            this.sqlDatabaseServerAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseServerAddress.Location = new System.Drawing.Point(183, 3);
            this.sqlDatabaseServerAddress.Name = "sqlDatabaseServerAddress";
            this.sqlDatabaseServerAddress.Size = new System.Drawing.Size(414, 20);
            this.sqlDatabaseServerAddress.TabIndex = 5;
            // 
            // sqlDatabasePortTextBox
            // 
            this.sqlDatabasePortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabasePortTextBox.Location = new System.Drawing.Point(183, 28);
            this.sqlDatabasePortTextBox.Name = "sqlDatabasePortTextBox";
            this.sqlDatabasePortTextBox.Size = new System.Drawing.Size(414, 20);
            this.sqlDatabasePortTextBox.TabIndex = 6;
            // 
            // sqlDatabaseNameTextBox
            // 
            this.sqlDatabaseNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseNameTextBox.Location = new System.Drawing.Point(183, 53);
            this.sqlDatabaseNameTextBox.Name = "sqlDatabaseNameTextBox";
            this.sqlDatabaseNameTextBox.Size = new System.Drawing.Size(414, 20);
            this.sqlDatabaseNameTextBox.TabIndex = 7;
            // 
            // sqlDatabaseUsernameTextBox
            // 
            this.sqlDatabaseUsernameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseUsernameTextBox.Location = new System.Drawing.Point(183, 78);
            this.sqlDatabaseUsernameTextBox.Name = "sqlDatabaseUsernameTextBox";
            this.sqlDatabaseUsernameTextBox.Size = new System.Drawing.Size(414, 20);
            this.sqlDatabaseUsernameTextBox.TabIndex = 8;
            // 
            // sqlDatabasePasswordTextBox
            // 
            this.sqlDatabasePasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabasePasswordTextBox.Location = new System.Drawing.Point(183, 103);
            this.sqlDatabasePasswordTextBox.Name = "sqlDatabasePasswordTextBox";
            this.sqlDatabasePasswordTextBox.PasswordChar = '*';
            this.sqlDatabasePasswordTextBox.Size = new System.Drawing.Size(414, 20);
            this.sqlDatabasePasswordTextBox.TabIndex = 9;
            // 
            // sqlDatabaseConnectionDisplay
            // 
            this.sqlDatabaseConnectionDisplay.AutoSize = true;
            this.sqlDatabaseConnectionDisplay.BackColor = System.Drawing.Color.Yellow;
            this.sqlDatabaseConnectionDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDatabaseConnectionDisplay.Location = new System.Drawing.Point(3, 125);
            this.sqlDatabaseConnectionDisplay.Name = "sqlDatabaseConnectionDisplay";
            this.sqlDatabaseConnectionDisplay.Size = new System.Drawing.Size(174, 30);
            this.sqlDatabaseConnectionDisplay.TabIndex = 10;
            this.sqlDatabaseConnectionDisplay.Text = "Connection: Testing";
            this.sqlDatabaseConnectionDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sqlDatabaseSaveTestButton
            // 
            this.sqlDatabaseSaveTestButton.Location = new System.Drawing.Point(183, 128);
            this.sqlDatabaseSaveTestButton.Name = "sqlDatabaseSaveTestButton";
            this.sqlDatabaseSaveTestButton.Size = new System.Drawing.Size(214, 23);
            this.sqlDatabaseSaveTestButton.TabIndex = 11;
            this.sqlDatabaseSaveTestButton.Text = "Save and Test";
            this.sqlDatabaseSaveTestButton.UseVisualStyleBackColor = true;
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
            this.oldDatabaseSettingsTabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.newDatabaseSettingsTabPage.ResumeLayout(false);
            this.mysqlGroupBox.ResumeLayout(false);
            this.sqlGroupBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage generalSettingsTabPage;
        private System.Windows.Forms.TabPage oldDatabaseSettingsTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label mySqlServerAddressLabel;
        private System.Windows.Forms.Label mySqlServerPortLabel;
        private System.Windows.Forms.Label mySqlDatabaseNameLabel;
        private System.Windows.Forms.Label mySqlDatabaseUsernameLabel;
        private System.Windows.Forms.Label mySqlDatabasePasswordLabel;
        private System.Windows.Forms.TextBox mySqlDatabaseServerAddressTextBox;
        private System.Windows.Forms.TextBox mySqlDatabasePortTextBox;
        private System.Windows.Forms.TextBox mySqlDatabaseNameTextBox;
        private System.Windows.Forms.TextBox mySqlDatabaseUsernameTextBox;
        private System.Windows.Forms.TextBox mySqlDatabasePasswordTextBox;
        private System.Windows.Forms.Label mySqlDatabaseConnectionDisplay;
        private System.Windows.Forms.Button mySqlDatabaseSaveTestButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultToolStripMenuItem;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button saveGeneralSettingsButton;
        private System.Windows.Forms.TabPage newDatabaseSettingsTabPage;
        private System.Windows.Forms.GroupBox sqlGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label sqlServerAddressLabel;
        private System.Windows.Forms.Label sqlServerPortLabel;
        private System.Windows.Forms.Label sqlDatabaseNameLabel;
        private System.Windows.Forms.Label sqlDatabaseUsernameLabel;
        private System.Windows.Forms.Label sqlDatabasePasswordLabel;
        private System.Windows.Forms.TextBox sqlDatabaseServerAddress;
        private System.Windows.Forms.TextBox sqlDatabasePortTextBox;
        private System.Windows.Forms.TextBox sqlDatabaseNameTextBox;
        private System.Windows.Forms.TextBox sqlDatabaseUsernameTextBox;
        private System.Windows.Forms.TextBox sqlDatabasePasswordTextBox;
        private System.Windows.Forms.Label sqlDatabaseConnectionDisplay;
        private System.Windows.Forms.Button sqlDatabaseSaveTestButton;
        private System.Windows.Forms.GroupBox mysqlGroupBox;
    }
}