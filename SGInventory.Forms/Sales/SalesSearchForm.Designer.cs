namespace SGInventory.Sales
{
    partial class SalesSearchForm
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
            this.groupBoxSearchCriteria = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.ucACOutlet = new SGInventory.UserControls.ucAutoComplete();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateOfSales = new System.Windows.Forms.DateTimePicker();
            this.bindingSourceSales = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSearchList = new System.Windows.Forms.GroupBox();
            this.dataGridViewListOfSales = new System.Windows.Forms.DataGridView();
            this.bindingSourceListOfSales = new System.Windows.Forms.BindingSource(this.components);
            this.colId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.washingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSales)).BeginInit();
            this.groupBoxSearchList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListOfSales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSearchCriteria
            // 
            this.groupBoxSearchCriteria.Controls.Add(this.buttonSearch);
            this.groupBoxSearchCriteria.Controls.Add(this.ucACOutlet);
            this.groupBoxSearchCriteria.Controls.Add(this.label1);
            this.groupBoxSearchCriteria.Controls.Add(this.dtpDateOfSales);
            this.groupBoxSearchCriteria.Controls.Add(this.label2);
            this.groupBoxSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearchCriteria.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSearchCriteria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearchCriteria.Name = "groupBoxSearchCriteria";
            this.groupBoxSearchCriteria.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearchCriteria.Size = new System.Drawing.Size(1168, 137);
            this.groupBoxSearchCriteria.TabIndex = 0;
            this.groupBoxSearchCriteria.TabStop = false;
            this.groupBoxSearchCriteria.Text = "Search Criteria";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(16, 87);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 28);
            this.buttonSearch.TabIndex = 28;
            this.buttonSearch.Text = "Search:";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // ucACOutlet
            // 
            this.ucACOutlet.AutoCompleteValue = "";
            this.ucACOutlet.Location = new System.Drawing.Point(151, 48);
            this.ucACOutlet.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucACOutlet.Name = "ucACOutlet";
            this.ucACOutlet.Size = new System.Drawing.Size(417, 26);
            this.ucACOutlet.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Outlet:";
            // 
            // dtpDateOfSales
            // 
            this.dtpDateOfSales.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceSales, "DateOfSales", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpDateOfSales.Location = new System.Drawing.Point(151, 20);
            this.dtpDateOfSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateOfSales.Name = "dtpDateOfSales";
            this.dtpDateOfSales.Size = new System.Drawing.Size(416, 22);
            this.dtpDateOfSales.TabIndex = 25;
            // 
            // bindingSourceSales
            // 
            this.bindingSourceSales.DataSource = typeof(SGInventory.Model.Sales);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Date of Sales:";
            // 
            // groupBoxSearchList
            // 
            this.groupBoxSearchList.Controls.Add(this.dataGridViewListOfSales);
            this.groupBoxSearchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearchList.Location = new System.Drawing.Point(0, 137);
            this.groupBoxSearchList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearchList.Name = "groupBoxSearchList";
            this.groupBoxSearchList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSearchList.Size = new System.Drawing.Size(1168, 451);
            this.groupBoxSearchList.TabIndex = 1;
            this.groupBoxSearchList.TabStop = false;
            this.groupBoxSearchList.Text = "Search List";
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
            this.quantityDataGridViewTextBoxColumn});
            this.dataGridViewListOfSales.DataSource = this.bindingSourceListOfSales;
            this.dataGridViewListOfSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListOfSales.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewListOfSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewListOfSales.Name = "dataGridViewListOfSales";
            this.dataGridViewListOfSales.RowHeadersVisible = false;
            this.dataGridViewListOfSales.Size = new System.Drawing.Size(1160, 428);
            this.dataGridViewListOfSales.TabIndex = 1;
            this.dataGridViewListOfSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListOfSales_CellContentClick);
            // 
            // bindingSourceListOfSales
            // 
            this.bindingSourceListOfSales.AllowNew = false;
            this.bindingSourceListOfSales.DataSource = typeof(SGInventory.Presenters.Model.SalesDisplayModel);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.idDataGridViewTextBoxColumn.HeaderText = "Code";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // SalesSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 588);
            this.Controls.Add(this.groupBoxSearchList);
            this.Controls.Add(this.groupBoxSearchCriteria);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SalesSearchForm";
            this.Text = "Sales Search";
            this.Load += new System.EventHandler(this.SalesSearchForm_Load);
            this.groupBoxSearchCriteria.ResumeLayout(false);
            this.groupBoxSearchCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSales)).EndInit();
            this.groupBoxSearchList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOfSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceListOfSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearchCriteria;
        private System.Windows.Forms.GroupBox groupBoxSearchList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateOfSales;
        private UserControls.ucAutoComplete ucACOutlet;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.BindingSource bindingSourceListOfSales;
        private System.Windows.Forms.DataGridView dataGridViewListOfSales;
        private System.Windows.Forms.BindingSource bindingSourceSales;
        private System.Windows.Forms.DataGridViewLinkColumn colId;
        private System.Windows.Forms.DataGridViewLinkColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn washingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}