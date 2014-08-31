namespace FRC_Scouting_V2.Test_Objects
{
    partial class TestForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.aerialAssist_TestPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.aerial_Assist_UI_Layout_Test1 = new FRC_Scouting_V2.Test_Items.Aerial_Assist_UI_Layout_Test();
            this.tabControl1.SuspendLayout();
            this.aerialAssist_TestPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.aerialAssist_TestPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 489);
            this.tabControl1.TabIndex = 0;
            // 
            // aerialAssist_TestPage
            // 
            this.aerialAssist_TestPage.Controls.Add(this.aerial_Assist_UI_Layout_Test1);
            this.aerialAssist_TestPage.Location = new System.Drawing.Point(4, 22);
            this.aerialAssist_TestPage.Name = "aerialAssist_TestPage";
            this.aerialAssist_TestPage.Padding = new System.Windows.Forms.Padding(3);
            this.aerialAssist_TestPage.Size = new System.Drawing.Size(593, 463);
            this.aerialAssist_TestPage.TabIndex = 0;
            this.aerialAssist_TestPage.Text = "Aerial Assist Scouting";
            this.aerialAssist_TestPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(393, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // aerial_Assist_UI_Layout_Test1
            // 
            this.aerial_Assist_UI_Layout_Test1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aerial_Assist_UI_Layout_Test1.Location = new System.Drawing.Point(3, 3);
            this.aerial_Assist_UI_Layout_Test1.Name = "aerial_Assist_UI_Layout_Test1";
            this.aerial_Assist_UI_Layout_Test1.Size = new System.Drawing.Size(587, 457);
            this.aerial_Assist_UI_Layout_Test1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 489);
            this.Controls.Add(this.tabControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.tabControl1.ResumeLayout(false);
            this.aerialAssist_TestPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage aerialAssist_TestPage;
        private System.Windows.Forms.TabPage tabPage2;
        private Test_Items.Aerial_Assist_UI_Layout_Test aerial_Assist_UI_Layout_Test1;
    }
}