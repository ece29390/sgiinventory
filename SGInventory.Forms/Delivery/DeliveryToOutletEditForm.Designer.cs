namespace SGInventory.Delivery
{
    partial class DeliveryToOutletEditForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProductDetails = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ncPrice = new SGInventory.UserControls.NumericControl();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBarcodeNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucItemEditMenu1 = new SGInventory.UserControls.ucItemEditMenu();
            this.colProductDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProductDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 551);
            this.panel1.TabIndex = 0;
            // 
            // dgvProductDetails
            // 
            this.dgvProductDetails.AllowUserToAddRows = false;
            this.dgvProductDetails.AllowUserToDeleteRows = false;
            this.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductDetail,
            this.colQuantity,
            this.colPrice,
            this.colRemarks});
            this.dgvProductDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvProductDetails.Name = "dgvProductDetails";
            this.dgvProductDetails.ReadOnly = true;
            this.dgvProductDetails.RowHeadersVisible = false;
            this.dgvProductDetails.Size = new System.Drawing.Size(641, 551);
            this.dgvProductDetails.TabIndex = 1;
            this.dgvProductDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_CellContentClick);
            this.dgvProductDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProductDetails_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBoxRemarks);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ncPrice);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBoxQuantity);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblBarcodeNumber);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ucItemEditMenu1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(641, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 551);
            this.panel2.TabIndex = 1;
            // 
            // txtBoxRemarks
            // 
            this.txtBoxRemarks.Location = new System.Drawing.Point(9, 136);
            this.txtBoxRemarks.MaxLength = 500;
            this.txtBoxRemarks.Multiline = true;
            this.txtBoxRemarks.Name = "txtBoxRemarks";
            this.txtBoxRemarks.Size = new System.Drawing.Size(428, 150);
            this.txtBoxRemarks.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Remarks:";
            // 
            // ncPrice
            // 
            this.ncPrice.Enabled = false;
            this.ncPrice.Location = new System.Drawing.Point(163, 81);
            this.ncPrice.Margin = new System.Windows.Forms.Padding(5);
            this.ncPrice.Name = "ncPrice";
            this.ncPrice.Numeric = 0D;
            this.ncPrice.Size = new System.Drawing.Size(205, 38);
            this.ncPrice.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Price:";
            // 
            // txtBoxQuantity
            // 
            this.txtBoxQuantity.Location = new System.Drawing.Point(163, 50);
            this.txtBoxQuantity.Name = "txtBoxQuantity";
            this.txtBoxQuantity.Size = new System.Drawing.Size(139, 20);
            this.txtBoxQuantity.TabIndex = 10;
            this.txtBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQuantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Quantity:";
            // 
            // lblBarcodeNumber
            // 
            this.lblBarcodeNumber.AutoSize = true;
            this.lblBarcodeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcodeNumber.Location = new System.Drawing.Point(160, 27);
            this.lblBarcodeNumber.Name = "lblBarcodeNumber";
            this.lblBarcodeNumber.Size = new System.Drawing.Size(68, 17);
            this.lblBarcodeNumber.TabIndex = 8;
            this.lblBarcodeNumber.Text = "Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Barcode #:";
            // 
            // ucItemEditMenu1
            // 
            this.ucItemEditMenu1.Location = new System.Drawing.Point(0, 0);
            this.ucItemEditMenu1.Name = "ucItemEditMenu1";
            this.ucItemEditMenu1.Size = new System.Drawing.Size(470, 24);
            this.ucItemEditMenu1.TabIndex = 0;
            // 
            // colProductDetail
            // 
            this.colProductDetail.HeaderText = "Barcode";
            this.colProductDetail.Name = "colProductDetail";
            this.colProductDetail.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "SuggestedRetailPrice";
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.Width = 250;
            // 
            // DeliveryToOutletEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 551);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DeliveryToOutletEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.DeliveryToOutletEditForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucItemEditMenu ucItemEditMenu1;
        private UserControls.NumericControl ncPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBarcodeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductDetails;
        private System.Windows.Forms.TextBox txtBoxRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewLinkColumn colProductDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
    }
}