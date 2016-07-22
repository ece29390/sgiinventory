namespace SGInventory.ProductForm
{
    partial class PriceHistory
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
            this.ucPriceHistory1 = new SGInventory.UserControls.ucPriceHistory();
            this.SuspendLayout();
            // 
            // ucPriceHistory1
            // 
            this.ucPriceHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPriceHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucPriceHistory1.Name = "ucPriceHistory1";
            this.ucPriceHistory1.Size = new System.Drawing.Size(426, 152);
            this.ucPriceHistory1.TabIndex = 0;
            // 
            // PriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 152);
            this.Controls.Add(this.ucPriceHistory1);
            this.Name = "PriceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Price History";
            this.Load += new System.EventHandler(this.PriceHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucPriceHistory ucPriceHistory1;
    }
}