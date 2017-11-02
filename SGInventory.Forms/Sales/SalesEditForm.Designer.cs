namespace SGInventory.Sales
{
    partial class SalesEditForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxSalesDetail = new System.Windows.Forms.GroupBox();
            this.buttonAddSales = new System.Windows.Forms.Button();
            this.ncQuantity = new SGInventory.UserControls.NumericControl();
            this.bindingSourceSales = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ucACOutlet = new SGInventory.UserControls.ucAutoComplete();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateOfSales = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewListOfSales = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.washingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteDescription = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bindingSourceListOfSales = new System.Windows.Forms.BindingSource(this.components);
            this.userControlSelectProduct1 = new SGInventory.UserControls.UserControlSelectProduct();
            this.groupBoxSalesDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSales)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListOfSales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSalesDetail
            // 
            this.groupBoxSalesDetail.Controls.Add(this.userControlSelectProduct1);
            this.groupBoxSalesDetail.Controls.Add(this.buttonAddSales);
            this.groupBoxSalesDetail.Controls.Add(this.ncQuantity);
            this.groupBoxSalesDetail.Controls.Add(this.label3);
            this.groupBoxSalesDetail.Controls.Add(this.ucACOutlet);
            this.groupBoxSalesDetail.Controls.Add(this.label1);
            this.groupBoxSalesDetail.Controls.Add(this.dtpDateOfSales);
            this.groupBoxSalesDetail.Controls.Add(this.label2);
            this.groupBoxSalesDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxSalesDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSalesDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSalesDetail.Name = "groupBoxSalesDetail";
            this.groupBoxSalesDetail.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSalesDetail.Size = new System.Drawing.Size(639, 462);
            this.groupBoxSalesDetail.TabIndex = 23;
            this.groupBoxSalesDetail.TabStop = false;
            this.groupBoxSalesDetail.Text = "Sales Details";
            // 
            // buttonAddSales
            // 
            this.buttonAddSales.Enabled = false;
            this.buttonAddSales.Location = new System.Drawing.Point(8, 385);
            this.buttonAddSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddSales.Name = "buttonAddSales";
            this.buttonAddSales.Size = new System.Drawing.Size(100, 28);
            this.buttonAddSales.TabIndex = 30;
            this.buttonAddSales.Text = "Add";
            this.buttonAddSales.UseVisualStyleBackColor = true;
            this.buttonAddSales.Click += new System.EventHandler(this.buttonAddSales_Click);
            // 
            // ncQuantity
            // 
            this.ncQuantity.DataBindings.Add(new System.Windows.Forms.Binding("Numeric", this.bindingSourceSales, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "1"));
            this.ncQuantity.Location = new System.Drawing.Point(180, 97);
            this.ncQuantity.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ncQuantity.Name = "ncQuantity";
            this.ncQuantity.Numeric = 1D;
            this.ncQuantity.Size = new System.Drawing.Size(141, 27);
            this.ncQuantity.TabIndex = 28;
            // 
            // bindingSourceSales
            // 
            this.bindingSourceSales.DataSource = typeof(SGInventory.Model.Sales);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Quantity:";
            // 
            // ucACOutlet
            // 
            this.ucACOutlet.AutoCompleteValue = "";
            this.ucACOutlet.Location = new System.Drawing.Point(180, 64);
            this.ucACOutlet.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucACOutlet.Name = "ucACOutlet";
            this.ucACOutlet.Size = new System.Drawing.Size(417, 26);
            this.ucACOutlet.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Outlet:";
            // 
            // dtpDateOfSales
            // 
            this.dtpDateOfSales.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceSales, "DateOfSales", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpDateOfSales.Location = new System.Drawing.Point(180, 32);
            this.dtpDateOfSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateOfSales.Name = "dtpDateOfSales";
            this.dtpDateOfSales.Size = new System.Drawing.Size(416, 22);
            this.dtpDateOfSales.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Date of Sales:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewListOfSales);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(639, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(710, 462);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Sales";
            // 
            // dataGridViewListOfSales
            // 
            this.dataGridViewListOfSales.AutoGenerateColumns = false;
            this.dataGridViewListOfSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListOfSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.idDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.washingDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.DeleteDescription});
            this.dataGridViewListOfSales.DataSource = this.bindingSourceListOfSales;
            this.dataGridViewListOfSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListOfSales.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewListOfSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewListOfSales.Name = "dataGridViewListOfSales";
            this.dataGridViewListOfSales.RowHeadersVisible = false;
            this.dataGridViewListOfSales.Size = new System.Drawing.Size(702, 439);
            this.dataGridViewListOfSales.TabIndex = 0;
            this.dataGridViewListOfSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListOfSales_CellContentClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.idDataGridViewTextBoxColumn.HeaderText = "Code";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            // 
            // washingDataGridViewTextBoxColumn
            // 
            this.washingDataGridViewTextBoxColumn.DataPropertyName = "Washing";
            this.washingDataGridViewTextBoxColumn.HeaderText = "Washing";
            this.washingDataGridViewTextBoxColumn.Name = "washingDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // DeleteDescription
            // 
            this.DeleteDescription.DataPropertyName = "DeleteDescription";
            this.DeleteDescription.HeaderText = "";
            this.DeleteDescription.Name = "DeleteDescription";
            this.DeleteDescription.ReadOnly = true;
            this.DeleteDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteDescription.Text = "Delete";
            // 
            // bindingSourceListOfSales
            // 
            this.bindingSourceListOfSales.DataSource = typeof(SGInventory.Presenters.Model.SalesDisplayModel);
            // 
            // userControlSelectProduct1
            // 
            this.userControlSelectProduct1.Location = new System.Drawing.Point(7, 150);
            this.userControlSelectProduct1.Name = "userControlSelectProduct1";
            this.userControlSelectProduct1.Size = new System.Drawing.Size(433, 228);
            this.userControlSelectProduct1.TabIndex = 31;
            // 
            // SalesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSalesDetail);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SalesEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesEditForm_FormClosing);
            this.Load += new System.EventHandler(this.SalesEditForm_Load);
            this.groupBoxSalesDetail.ResumeLayout(false);
            this.groupBoxSalesDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListOfSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSalesDetail;
        private System.Windows.Forms.Button buttonAddSales;
        private UserControls.NumericControl ncQuantity;
        private System.Windows.Forms.Label label3;
        private UserControls.ucAutoComplete ucACOutlet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateOfSales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewListOfSales;
        private System.Windows.Forms.BindingSource bindingSourceSales;
        private System.Windows.Forms.BindingSource bindingSourceListOfSales;
        private System.Windows.Forms.DataGridViewLinkColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn washingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteDescription;
        private UserControls.UserControlSelectProduct userControlSelectProduct1;
    }
}