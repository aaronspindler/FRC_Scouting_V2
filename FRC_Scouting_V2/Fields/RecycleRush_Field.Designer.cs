namespace FRC_Scouting_V2
{
    partial class RecycleRush_Field
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // fieldPanel
            // 
            this.fieldPanel.AutoSize = true;
            this.fieldPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fieldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPanel.Location = new System.Drawing.Point(0, 0);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(1442, 873);
            this.fieldPanel.TabIndex = 0;
            this.fieldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.fieldPanel_Paint);
            // 
            // RecycleRush_Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.fieldPanel);
            this.Name = "RecycleRush_Field";
            this.Size = new System.Drawing.Size(1442, 873);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel fieldPanel;
    }
}
