namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    partial class matchInfoByNumber
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.matchNumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.matchNumNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(38, 43);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(220, 100);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(38, 149);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(220, 100);
            this.textBox3.TabIndex = 3;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox.Location = new System.Drawing.Point(62, 11);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(83, 20);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "Match Number:";
            // 
            // matchNumNumericUpDown
            // 
            this.matchNumNumericUpDown.Location = new System.Drawing.Point(163, 11);
            this.matchNumNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.matchNumNumericUpDown.Name = "matchNumNumericUpDown";
            this.matchNumNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.matchNumNumericUpDown.TabIndex = 1;
            this.matchNumNumericUpDown.ValueChanged += new System.EventHandler(this.matchNumNumericUpDown_ValueChanged);
            // 
            // matchInfoByNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.matchNumNumericUpDown);
            this.Controls.Add(this.textBox);
            this.Name = "matchInfoByNumber";
            this.Text = "Match Info By Match Number";
            ((System.ComponentModel.ISupportInitialize)(this.matchNumNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown matchNumNumericUpDown;
    }
}