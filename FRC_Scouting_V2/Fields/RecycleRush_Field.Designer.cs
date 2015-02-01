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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fieldTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fieldTypeLabel = new System.Windows.Forms.Label();
            this.fieldPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.fieldTypeComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fieldTypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fieldPictureBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 546);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // fieldTypeComboBox
            // 
            this.fieldTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldTypeComboBox.FormattingEnabled = true;
            this.fieldTypeComboBox.Items.AddRange(new object[] {
            "Field without Bins / Totes",
            "Field with Bins / Totes"});
            this.fieldTypeComboBox.Location = new System.Drawing.Point(524, 524);
            this.fieldTypeComboBox.Name = "fieldTypeComboBox";
            this.fieldTypeComboBox.Size = new System.Drawing.Size(515, 21);
            this.fieldTypeComboBox.TabIndex = 2;
            this.fieldTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldTypeComboBox_SelectedIndexChanged);
            // 
            // fieldTypeLabel
            // 
            this.fieldTypeLabel.AutoSize = true;
            this.fieldTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldTypeLabel.Location = new System.Drawing.Point(3, 521);
            this.fieldTypeLabel.Name = "fieldTypeLabel";
            this.fieldTypeLabel.Size = new System.Drawing.Size(515, 25);
            this.fieldTypeLabel.TabIndex = 3;
            this.fieldTypeLabel.Text = "Field Type: ";
            this.fieldTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fieldPictureBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fieldPictureBox, 2);
            this.fieldPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldPictureBox.Location = new System.Drawing.Point(3, 3);
            this.fieldPictureBox.Name = "fieldPictureBox";
            this.fieldPictureBox.Size = new System.Drawing.Size(1036, 515);
            this.fieldPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fieldPictureBox.TabIndex = 4;
            this.fieldPictureBox.TabStop = false;
            this.fieldPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.fieldPictureBox_Paint);
            this.fieldPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fieldPictureBox_MouseClick);
            // 
            // RecycleRush_Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RecycleRush_Field";
            this.Size = new System.Drawing.Size(1042, 546);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox fieldTypeComboBox;
        private System.Windows.Forms.Label fieldTypeLabel;
        private System.Windows.Forms.PictureBox fieldPictureBox;
    }
}
