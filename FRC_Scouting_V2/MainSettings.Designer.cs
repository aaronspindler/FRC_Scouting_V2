namespace FRC_Scouting_V2
{
    partial class MainSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalSettingsPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.clickEmptyTextBoxChecker = new System.Windows.Forms.CheckBox();
            this.clickEmptyTextBoxLabel = new System.Windows.Forms.Label();
            this.resetAllSettingsButton = new System.Windows.Forms.Button();
            this.resetSettingsLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howDoISaveMySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalSettingsPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 289);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 8);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(326, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 8);
            this.tabControl1.Controls.Add(this.generalSettingsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 8);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 258);
            this.tabControl1.TabIndex = 1;
            // 
            // generalSettingsPage
            // 
            this.generalSettingsPage.Controls.Add(this.tableLayoutPanel2);
            this.generalSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.generalSettingsPage.Name = "generalSettingsPage";
            this.generalSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalSettingsPage.Size = new System.Drawing.Size(312, 232);
            this.generalSettingsPage.TabIndex = 0;
            this.generalSettingsPage.Text = "General Settings";
            this.generalSettingsPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.clickEmptyTextBoxChecker, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.clickEmptyTextBoxLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.resetAllSettingsButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.resetSettingsLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.usernameLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.usernameTextBox, 4, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 226);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // clickEmptyTextBoxChecker
            // 
            this.clickEmptyTextBoxChecker.AutoSize = true;
            this.clickEmptyTextBoxChecker.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tableLayoutPanel2.SetColumnSpan(this.clickEmptyTextBoxChecker, 4);
            this.clickEmptyTextBoxChecker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickEmptyTextBoxChecker.Location = new System.Drawing.Point(155, 31);
            this.clickEmptyTextBoxChecker.Name = "clickEmptyTextBoxChecker";
            this.clickEmptyTextBoxChecker.Size = new System.Drawing.Size(148, 22);
            this.clickEmptyTextBoxChecker.TabIndex = 1;
            this.clickEmptyTextBoxChecker.UseVisualStyleBackColor = true;
            this.clickEmptyTextBoxChecker.CheckedChanged += new System.EventHandler(this.clickEmptyTextBoxChecker_CheckedChanged);
            // 
            // clickEmptyTextBoxLabel
            // 
            this.clickEmptyTextBoxLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.clickEmptyTextBoxLabel, 4);
            this.clickEmptyTextBoxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clickEmptyTextBoxLabel.Location = new System.Drawing.Point(3, 28);
            this.clickEmptyTextBoxLabel.Name = "clickEmptyTextBoxLabel";
            this.clickEmptyTextBoxLabel.Size = new System.Drawing.Size(146, 28);
            this.clickEmptyTextBoxLabel.TabIndex = 1;
            this.clickEmptyTextBoxLabel.Text = "Click to Empty Text Boxes";
            this.clickEmptyTextBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetAllSettingsButton
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.resetAllSettingsButton, 4);
            this.resetAllSettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetAllSettingsButton.Location = new System.Drawing.Point(155, 3);
            this.resetAllSettingsButton.Name = "resetAllSettingsButton";
            this.resetAllSettingsButton.Size = new System.Drawing.Size(148, 22);
            this.resetAllSettingsButton.TabIndex = 1;
            this.resetAllSettingsButton.Text = "Reset Settings";
            this.resetAllSettingsButton.UseVisualStyleBackColor = true;
            this.resetAllSettingsButton.Click += new System.EventHandler(this.resetAllSettingsButton_Click);
            // 
            // resetSettingsLabel
            // 
            this.resetSettingsLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.resetSettingsLabel, 4);
            this.resetSettingsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetSettingsLabel.Location = new System.Drawing.Point(3, 0);
            this.resetSettingsLabel.Name = "resetSettingsLabel";
            this.resetSettingsLabel.Size = new System.Drawing.Size(146, 28);
            this.resetSettingsLabel.TabIndex = 1;
            this.resetSettingsLabel.Text = "Reset all Settings to Default";
            this.resetSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.usernameLabel, 4);
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameLabel.Location = new System.Drawing.Point(3, 56);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(146, 28);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username: ";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameTextBox
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.usernameTextBox, 4);
            this.usernameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameTextBox.Location = new System.Drawing.Point(155, 59);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(148, 20);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.Text = "Example : Anonymous";
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.usernameTextBox_MouseClick);
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howDoISaveMySettingsToolStripMenuItem,
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howDoISaveMySettingsToolStripMenuItem
            // 
            this.howDoISaveMySettingsToolStripMenuItem.Name = "howDoISaveMySettingsToolStripMenuItem";
            this.howDoISaveMySettingsToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.howDoISaveMySettingsToolStripMenuItem.Text = "How do I save my settings?";
            this.howDoISaveMySettingsToolStripMenuItem.Click += new System.EventHandler(this.howDoISaveMySettingsToolStripMenuItem_Click);
            // 
            // whatIsTheUsernameFieldUsedForToolStripMenuItem
            // 
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem.Name = "whatIsTheUsernameFieldUsedForToolStripMenuItem";
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem.Text = "What is the Username field used for?";
            this.whatIsTheUsernameFieldUsedForToolStripMenuItem.Click += new System.EventHandler(this.whatIsTheUsernameFieldUsedForToolStripMenuItem_Click);
            // 
            // MainSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 289);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainSettings";
            this.Text = "MainSettings";
            this.Load += new System.EventHandler(this.MainSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.generalSettingsPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalSettingsPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button resetAllSettingsButton;
        private System.Windows.Forms.Label resetSettingsLabel;
        private System.Windows.Forms.CheckBox clickEmptyTextBoxChecker;
        private System.Windows.Forms.Label clickEmptyTextBoxLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howDoISaveMySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatIsTheUsernameFieldUsedForToolStripMenuItem;
    }
}