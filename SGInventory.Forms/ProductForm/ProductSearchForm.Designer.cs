namespace SGInventory.ProductForm
{
    partial class ProductSearchForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.rbNonActive = new System.Windows.Forms.RadioButton();
            this.rbIsActive = new System.Windows.Forms.RadioButton();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colStockNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWashingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarkdownPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegularPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userControlSearch1 = new SGInventory.UserControls.UserControlSearch();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucAddDelete1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 474);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 88);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbStatus);
            this.panel2.Controls.Add(this.userControlSearch1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 134);
            this.panel2.TabIndex = 1;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rbNonActive);
            this.gbStatus.Controls.Add(this.rbIsActive);
            this.gbStatus.Location = new System.Drawing.Point(4, 49);
            this.gbStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbStatus.Size = new System.Drawing.Size(267, 80);
            this.gbStatus.TabIndex = 2;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // rbNonActive
            // 
            this.rbNonActive.AutoSize = true;
            this.rbNonActive.Location = new System.Drawing.Point(8, 52);
            this.rbNonActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNonActive.Name = "rbNonActive";
            this.rbNonActive.Size = new System.Drawing.Size(97, 21);
            this.rbNonActive.TabIndex = 1;
            this.rbNonActive.Text = "Non Active";
            this.rbNonActive.UseVisualStyleBackColor = true;
            // 
            // rbIsActive
            // 
            this.rbIsActive.AutoSize = true;
            this.rbIsActive.Checked = true;
            this.rbIsActive.Location = new System.Drawing.Point(8, 23);
            this.rbIsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbIsActive.Name = "rbIsActive";
            this.rbIsActive.Size = new System.Drawing.Size(67, 21);
            this.rbIsActive.TabIndex = 0;
            this.rbIsActive.TabStop = true;
            this.rbIsActive.Text = "Active";
            this.rbIsActive.UseVisualStyleBackColor = true;
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.colStockNumber,
            this.colDescription,
            this.colCategory,
            this.colColor,
            this.colWashingCode,
            this.colCost,
            this.colMarkdownPrice,
            this.colRegularPrice});
            this.productDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productDataGridView.Location = new System.Drawing.Point(0, 134);
            this.productDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.RowHeadersVisible = false;
            this.productDataGridView.Size = new System.Drawing.Size(1043, 340);
            this.productDataGridView.TabIndex = 2;
            this.productDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellContentClick);
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Width = 40;
            // 
            // colStockNumber
            // 
            this.colStockNumber.DataPropertyName = "StockNumber";
            this.colStockNumber.HeaderText = "Stock Number";
            this.colStockNumber.Name = "colStockNumber";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 200;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 150;
            // 
            // colColor
            // 
            this.colColor.DataPropertyName = "ColorName";
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // colWashingCode
            // 
            this.colWashingCode.DataPropertyName = "WashingName";
            this.colWashingCode.HeaderText = "Washing";
            this.colWashingCode.Name = "colWashingCode";
            this.colWashingCode.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "Cost";
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colMarkdownPrice
            // 
            this.colMarkdownPrice.DataPropertyName = "MarkdownPrice";
            this.colMarkdownPrice.HeaderText = "Markdown Price";
            this.colMarkdownPrice.Name = "colMarkdownPrice";
            this.colMarkdownPrice.ReadOnly = true;
            // 
            // colRegularPrice
            // 
            this.colRegularPrice.DataPropertyName = "RegularPrice";
            this.colRegularPrice.HeaderText = "Regular Price";
            this.colRegularPrice.Name = "colRegularPrice";
            this.colRegularPrice.ReadOnly = true;
            // 
            // userControlSearch1
            // 
            this.userControlSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userControlSearch1.Location = new System.Drawing.Point(0, 0);
            this.userControlSearch1.Margin = new System.Windows.Forms.Padding(5);
            this.userControlSearch1.Name = "userControlSearch1";
            this.userControlSearch1.Size = new System.Drawing.Size(1043, 137);
            this.userControlSearch1.TabIndex = 1;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(720, 0);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(5);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(323, 88);
            this.ucAddDelete1.TabIndex = 0;
            // 
            // ProductSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 562);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Search";
            this.Load += new System.EventHandler(this.ProductSearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UserControls.ucAddDelete ucAddDelete1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.UserControlSearch userControlSearch1;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rbNonActive;
        private System.Windows.Forms.RadioButton rbIsActive;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewLinkColumn colStockNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWashingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarkdownPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegularPrice;
    }
}