namespace SGInventory.ProductForm
{
    partial class ProductDetailSearchForm
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
            this.ProductDetailSearchGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.colId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWashing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantityOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailSearchGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProductDetailSearchGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 392);
            this.panel1.TabIndex = 0;
            // 
            // ProductDetailSearchGridView
            // 
            this.ProductDetailSearchGridView.AllowUserToAddRows = false;
            this.ProductDetailSearchGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDetailSearchGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colBarcode,
            this.colColor,
            this.colWashing,
            this.colSize,
            this.colQuantityOnHand,
            this.colCost});
            this.ProductDetailSearchGridView.Location = new System.Drawing.Point(0, 44);
            this.ProductDetailSearchGridView.Name = "ProductDetailSearchGridView";
            this.ProductDetailSearchGridView.RowHeadersVisible = false;
            this.ProductDetailSearchGridView.Size = new System.Drawing.Size(778, 263);
            this.ProductDetailSearchGridView.TabIndex = 0;
            this.ProductDetailSearchGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDetailSearchGridView_CellContentClick);
            this.ProductDetailSearchGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ProductDetailSearchGridView_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucAddDelete1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 79);
            this.panel2.TabIndex = 1;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(536, 17);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(242, 58);
            this.ucAddDelete1.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.Width = 50;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Code";
            this.colBarcode.HeaderText = "Code";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBarcode.Width = 125;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // colWashing
            // 
            this.colWashing.HeaderText = "Washing";
            this.colWashing.Name = "colWashing";
            this.colWashing.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colQuantityOnHand
            // 
            this.colQuantityOnHand.DataPropertyName = "QuantityOnHand";
            this.colQuantityOnHand.HeaderText = "Quantity";
            this.colQuantityOnHand.Name = "colQuantityOnHand";
            this.colQuantityOnHand.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "OverrideCost";
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // ProductDetailSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 392);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ProductDetailSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductDetailSearchForm";
            this.Load += new System.EventHandler(this.ProductDetailSearchForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailSearchGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucAddDelete ucAddDelete1;
        private System.Windows.Forms.DataGridView ProductDetailSearchGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colId;
        private System.Windows.Forms.DataGridViewLinkColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWashing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityOnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
    }
}