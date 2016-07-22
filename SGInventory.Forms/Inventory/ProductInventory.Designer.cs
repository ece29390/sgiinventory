namespace SGInventory.Inventory
{
    partial class ProductInventory
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
            this.btnSearchByOrSearchAll = new System.Windows.Forms.Button();
            this.ucAutoComplete1 = new SGInventory.UserControls.ucAutoComplete();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvInventoryStock = new System.Windows.Forms.DataGridView();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductDetailCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWashing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewHistory = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchByOrSearchAll);
            this.panel1.Controls.Add(this.ucAutoComplete1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnSearchByOrSearchAll
            // 
            this.btnSearchByOrSearchAll.Location = new System.Drawing.Point(452, 8);
            this.btnSearchByOrSearchAll.Name = "btnSearchByOrSearchAll";
            this.btnSearchByOrSearchAll.Size = new System.Drawing.Size(183, 25);
            this.btnSearchByOrSearchAll.TabIndex = 2;
            this.btnSearchByOrSearchAll.Text = "Search";
            this.btnSearchByOrSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchByOrSearchAll.Click += new System.EventHandler(this.btnSearchByOrSearchAll_Click);
            // 
            // ucAutoComplete1
            // 
            this.ucAutoComplete1.AutoCompleteValue = "";
            this.ucAutoComplete1.Location = new System.Drawing.Point(88, 10);
            this.ucAutoComplete1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAutoComplete1.Name = "ucAutoComplete1";
            this.ucAutoComplete1.Size = new System.Drawing.Size(366, 22);
            this.ucAutoComplete1.TabIndex = 1;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Number:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvInventoryStock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 501);
            this.panel2.TabIndex = 1;
            // 
            // dgvInventoryStock
            // 
            this.dgvInventoryStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStock,
            this.colProductDetailCode,
            this.colColor,
            this.colWashing,
            this.colSize,
            this.colQuantity,
            this.colViewHistory});
            this.dgvInventoryStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryStock.Location = new System.Drawing.Point(0, 0);
            this.dgvInventoryStock.Name = "dgvInventoryStock";
            this.dgvInventoryStock.RowHeadersVisible = false;
            this.dgvInventoryStock.Size = new System.Drawing.Size(639, 501);
            this.dgvInventoryStock.TabIndex = 0;
            this.dgvInventoryStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryStock_CellContentClick);
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "StockNumber";
            this.colStock.HeaderText = "Stock Number";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colProductDetailCode
            // 
            this.colProductDetailCode.DataPropertyName = "ProductDetailCode";
            this.colProductDetailCode.HeaderText = "Product Code";
            this.colProductDetailCode.Name = "colProductDetailCode";
            this.colProductDetailCode.ReadOnly = true;
            this.colProductDetailCode.Visible = false;
            // 
            // colColor
            // 
            this.colColor.DataPropertyName = "ColorName";
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // colWashing
            // 
            this.colWashing.DataPropertyName = "WashingName";
            this.colWashing.HeaderText = "Washing";
            this.colWashing.Name = "colWashing";
            this.colWashing.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "SizeName";
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colViewHistory
            // 
            this.colViewHistory.DataPropertyName = "ViewHistory";
            this.colViewHistory.HeaderText = "";
            this.colViewHistory.Name = "colViewHistory";
            this.colViewHistory.ReadOnly = true;
            // 
            // ProductInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Inventory";
            this.Load += new System.EventHandler(this.ProductInventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearchByOrSearchAll;
        private UserControls.ucAutoComplete ucAutoComplete1;
        private System.Windows.Forms.DataGridView dgvInventoryStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductDetailCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWashing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewLinkColumn colViewHistory;
    }
}