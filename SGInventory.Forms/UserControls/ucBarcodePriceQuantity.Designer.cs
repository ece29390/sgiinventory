namespace SGInventory.UserControls
{
    partial class ucBarcodePriceQuantity
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
            this.ncPrice = new SGInventory.UserControls.NumericControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBarcodeNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ncPrice
            // 
            this.ncPrice.Enabled = false;
            this.ncPrice.Location = new System.Drawing.Point(163, 56);
            this.ncPrice.Margin = new System.Windows.Forms.Padding(4);
            this.ncPrice.Name = "ncPrice";
            this.ncPrice.Numeric = 0D;
            this.ncPrice.Size = new System.Drawing.Size(139, 31);
            this.ncPrice.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Price:";
            // 
            // txtBoxQuantity
            // 
            this.txtBoxQuantity.Location = new System.Drawing.Point(163, 23);
            this.txtBoxQuantity.Name = "txtBoxQuantity";
            this.txtBoxQuantity.Size = new System.Drawing.Size(139, 20);
            this.txtBoxQuantity.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Quantity:";
            // 
            // lblBarcodeNumber
            // 
            this.lblBarcodeNumber.AutoSize = true;
            this.lblBarcodeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcodeNumber.Location = new System.Drawing.Point(160, 0);
            this.lblBarcodeNumber.Name = "lblBarcodeNumber";
            this.lblBarcodeNumber.Size = new System.Drawing.Size(68, 17);
            this.lblBarcodeNumber.TabIndex = 8;
            this.lblBarcodeNumber.Text = "Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Barcode #:";
            // 
            // ucBarcodePriceQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ncPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBarcodeNumber);
            this.Controls.Add(this.label1);
            this.Name = "ucBarcodePriceQuantity";
            this.Size = new System.Drawing.Size(452, 82);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericControl ncPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBarcodeNumber;
        private System.Windows.Forms.Label label1;
    }
}
