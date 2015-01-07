namespace FRC_Scouting_V2
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
            this.recycleRush_Field1 = new FRC_Scouting_V2.RecycleRush_Field();
            this.SuspendLayout();
            // 
            // recycleRush_Field1
            // 
            this.recycleRush_Field1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recycleRush_Field1.Location = new System.Drawing.Point(0, 0);
            this.recycleRush_Field1.Name = "recycleRush_Field1";
            this.recycleRush_Field1.Size = new System.Drawing.Size(1620, 909);
            this.recycleRush_Field1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 909);
            this.Controls.Add(this.recycleRush_Field1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private RecycleRush_Field recycleRush_Field1;
    }
}