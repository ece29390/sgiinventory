namespace SGInventory.UserControls
{
    partial class ucPriceHistory
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
            this.lblPriceHistory = new System.Windows.Forms.Label();
            this.txtBoxPriceHistory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPriceHistory
            // 
            this.lblPriceHistory.AutoSize = true;
            this.lblPriceHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceHistory.Location = new System.Drawing.Point(3, 0);
            this.lblPriceHistory.Name = "lblPriceHistory";
            this.lblPriceHistory.Size = new System.Drawing.Size(106, 17);
            this.lblPriceHistory.TabIndex = 28;
            this.lblPriceHistory.Text = "Price History:";
            // 
            // txtBoxPriceHistory
            // 
            this.txtBoxPriceHistory.Location = new System.Drawing.Point(6, 20);
            this.txtBoxPriceHistory.Multiline = true;
            this.txtBoxPriceHistory.Name = "txtBoxPriceHistory";
            this.txtBoxPriceHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxPriceHistory.Size = new System.Drawing.Size(416, 127);
            this.txtBoxPriceHistory.TabIndex = 29;
            // 
            // ucPriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBoxPriceHistory);
            this.Controls.Add(this.lblPriceHistory);
            this.Name = "ucPriceHistory";
            this.Size = new System.Drawing.Size(427, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPriceHistory;
        private System.Windows.Forms.TextBox txtBoxPriceHistory;
    }
}
