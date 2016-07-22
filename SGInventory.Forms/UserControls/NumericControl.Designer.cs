namespace SGInventory.UserControls
{
    partial class NumericControl
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
            this.NumericTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumericTextbox
            // 
            this.NumericTextbox.Location = new System.Drawing.Point(0, 0);
            this.NumericTextbox.MaxLength = 15;
            this.NumericTextbox.Name = "NumericTextbox";
            this.NumericTextbox.Size = new System.Drawing.Size(105, 20);
            this.NumericTextbox.TabIndex = 3;
            this.NumericTextbox.Text = "0";
            this.NumericTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextbox_KeyPress);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(-136, 66);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(54, 17);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name:";
            // 
            // NumericControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumericTextbox);
            this.Controls.Add(this.NameLabel);
            this.Name = "NumericControl";
            this.Size = new System.Drawing.Size(106, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumericTextbox;
        private System.Windows.Forms.Label NameLabel;
    }
}
