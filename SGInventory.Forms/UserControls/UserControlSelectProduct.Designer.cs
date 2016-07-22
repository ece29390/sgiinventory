namespace SGInventory.UserControls
{
    partial class UserControlSelectProduct
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
            this.components = new System.ComponentModel.Container();
            this.lblStockOrBarcode = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxProductDetails = new System.Windows.Forms.ListBox();
            this.productDetailLookupModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDetailLookupModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockOrBarcode
            // 
            this.lblStockOrBarcode.AutoSize = true;
            this.lblStockOrBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockOrBarcode.Location = new System.Drawing.Point(4, 10);
            this.lblStockOrBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockOrBarcode.Name = "lblStockOrBarcode";
            this.lblStockOrBarcode.Size = new System.Drawing.Size(58, 20);
            this.lblStockOrBarcode.TabIndex = 27;
            this.lblStockOrBarcode.Text = "Code:";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(68, 8);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(362, 22);
            this.textBoxCode.TabIndex = 28;
            this.textBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCode_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxProductDetails);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 189);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Details";
            // 
            // listBoxProductDetails
            // 
            this.listBoxProductDetails.DataSource = this.productDetailLookupModelBindingSource;
            this.listBoxProductDetails.DisplayMember = "Description";
            this.listBoxProductDetails.FormattingEnabled = true;
            this.listBoxProductDetails.ItemHeight = 20;
            this.listBoxProductDetails.Location = new System.Drawing.Point(6, 25);
            this.listBoxProductDetails.Name = "listBoxProductDetails";
            this.listBoxProductDetails.Size = new System.Drawing.Size(415, 164);
            this.listBoxProductDetails.TabIndex = 0;
            this.listBoxProductDetails.ValueMember = "ProductCode";
            this.listBoxProductDetails.SelectedValueChanged += new System.EventHandler(this.listBoxProductDetails_SelectedValueChanged);
            this.listBoxProductDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBoxProductDetails_KeyPress);
            // 
            // productDetailLookupModelBindingSource
            // 
            this.productDetailLookupModelBindingSource.DataSource = typeof(SGInventory.Presenters.Model.ProductDetailLookupModel);
            // 
            // UserControlSelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.lblStockOrBarcode);
            this.Name = "UserControlSelectProduct";
            this.Size = new System.Drawing.Size(433, 228);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productDetailLookupModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockOrBarcode;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxProductDetails;
        private System.Windows.Forms.BindingSource productDetailLookupModelBindingSource;
    }
}
