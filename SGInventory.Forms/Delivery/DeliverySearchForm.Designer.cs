namespace SGInventory.Delivery
{
    partial class DeliverySearchForm
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
            this.ucDateRangeFilter1 = new SGInventory.UserControls.UcDateRangeFilter();
            this.ucSearchBy = new SGInventory.UserControls.ucSaveEditForm();
            this.cboSearchMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucSupplier = new SGInventory.UserControls.ucAutoComplete();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvDeliveries = new System.Windows.Forms.DataGridView();
            this.colDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucDateRangeFilter1);
            this.panel1.Controls.Add(this.ucSearchBy);
            this.panel1.Controls.Add(this.cboSearchMode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ucSupplier);
            this.panel1.Controls.Add(this.supplierLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 147);
            this.panel1.TabIndex = 0;
            // 
            // ucDateRangeFilter1
            // 
            this.ucDateRangeFilter1.Location = new System.Drawing.Point(0, 65);
            this.ucDateRangeFilter1.Name = "ucDateRangeFilter1";
            this.ucDateRangeFilter1.Size = new System.Drawing.Size(664, 21);
            this.ucDateRangeFilter1.TabIndex = 16;
            // 
            // ucSearchBy
            // 
            this.ucSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSearchBy.Location = new System.Drawing.Point(8, 86);
            this.ucSearchBy.Margin = new System.Windows.Forms.Padding(4);
            this.ucSearchBy.Name = "ucSearchBy";
            this.ucSearchBy.Size = new System.Drawing.Size(80, 44);
            this.ucSearchBy.TabIndex = 15;
            // 
            // cboSearchMode
            // 
            this.cboSearchMode.FormattingEnabled = true;
            this.cboSearchMode.Location = new System.Drawing.Point(118, 12);
            this.cboSearchMode.Name = "cboSearchMode";
            this.cboSearchMode.Size = new System.Drawing.Size(316, 21);
            this.cboSearchMode.TabIndex = 10;
            this.cboSearchMode.SelectedIndexChanged += new System.EventHandler(this.cboSearchMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search By ";
            // 
            // ucSupplier
            // 
            this.ucSupplier.AutoCompleteValue = "";
            this.ucSupplier.Location = new System.Drawing.Point(118, 38);
            this.ucSupplier.Name = "ucSupplier";
            this.ucSupplier.Size = new System.Drawing.Size(316, 21);
            this.ucSupplier.TabIndex = 12;
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierLabel.Location = new System.Drawing.Point(3, 38);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(73, 17);
            this.supplierLabel.TabIndex = 9;
            this.supplierLabel.Text = "Supplier:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvDeliveries);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 429);
            this.panel2.TabIndex = 1;
            // 
            // gvDeliveries
            // 
            this.gvDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDeliveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDR,
            this.colDeliveryDate,
            this.colSupplierName,
            this.colCreatedBy,
            this.colCreatedDate});
            this.gvDeliveries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDeliveries.Location = new System.Drawing.Point(0, 0);
            this.gvDeliveries.Name = "gvDeliveries";
            this.gvDeliveries.RowHeadersVisible = false;
            this.gvDeliveries.Size = new System.Drawing.Size(1063, 429);
            this.gvDeliveries.TabIndex = 0;
            this.gvDeliveries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDeliveries_CellClick);
            // 
            // colDR
            // 
            this.colDR.DataPropertyName = "OrNumber";
            this.colDR.HeaderText = "DR";
            this.colDR.Name = "colDR";
            this.colDR.ReadOnly = true;
            this.colDR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDR.Width = 200;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            this.colDeliveryDate.HeaderText = "DeliveryDate";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeliveryDate.Width = 200;
            // 
            // colSupplierName
            // 
            this.colSupplierName.HeaderText = "Supplier Name";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.ReadOnly = true;
            this.colSupplierName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSupplierName.Width = 300;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.DataPropertyName = "CreatedBy";
            this.colCreatedBy.HeaderText = "Created By";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            this.colCreatedBy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.DataPropertyName = "CreatedDate";
            this.colCreatedDate.HeaderText = "Created Date";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeliverySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DeliverySearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliverySearchForm";
            this.Load += new System.EventHandler(this.DeliverySearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucSaveEditForm ucSearchBy;
        private System.Windows.Forms.ComboBox cboSearchMode;
        private System.Windows.Forms.Label label2;
        private UserControls.ucAutoComplete ucSupplier;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.DataGridView gvDeliveries;
        private UserControls.UcDateRangeFilter ucDateRangeFilter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;

    }
}