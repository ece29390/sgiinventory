namespace SGInventory.Delivery
{
    partial class DeliveryToOutletSearchForm
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
            this.cboSearchMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSearchDetail = new System.Windows.Forms.Panel();
            this.ucDateRangeFilter1 = new SGInventory.UserControls.UcDateRangeFilter();
            this.ucSearchBy = new SGInventory.UserControls.ucSaveEditForm();
            this.ucOutlet = new SGInventory.UserControls.ucAutoComplete();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.gvDeliveries = new System.Windows.Forms.DataGridView();
            this.colDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutletName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearchDetail.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSearchMode
            // 
            this.cboSearchMode.FormattingEnabled = true;
            this.cboSearchMode.Location = new System.Drawing.Point(116, 9);
            this.cboSearchMode.Name = "cboSearchMode";
            this.cboSearchMode.Size = new System.Drawing.Size(316, 21);
            this.cboSearchMode.TabIndex = 14;
            this.cboSearchMode.SelectedIndexChanged += new System.EventHandler(this.cboSearchMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search By ";
            // 
            // pnlSearchDetail
            // 
            this.pnlSearchDetail.Controls.Add(this.ucDateRangeFilter1);
            this.pnlSearchDetail.Controls.Add(this.ucSearchBy);
            this.pnlSearchDetail.Controls.Add(this.ucOutlet);
            this.pnlSearchDetail.Controls.Add(this.lblOutlet);
            this.pnlSearchDetail.Controls.Add(this.label2);
            this.pnlSearchDetail.Controls.Add(this.cboSearchMode);
            this.pnlSearchDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchDetail.Name = "pnlSearchDetail";
            this.pnlSearchDetail.Size = new System.Drawing.Size(1063, 134);
            this.pnlSearchDetail.TabIndex = 16;
            // 
            // ucDateRangeFilter1
            // 
            this.ucDateRangeFilter1.Location = new System.Drawing.Point(0, 62);
            this.ucDateRangeFilter1.Name = "ucDateRangeFilter1";
            this.ucDateRangeFilter1.Size = new System.Drawing.Size(664, 21);
            this.ucDateRangeFilter1.TabIndex = 20;
            // 
            // ucSearchBy
            // 
            this.ucSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSearchBy.Location = new System.Drawing.Point(8, 83);
            this.ucSearchBy.Margin = new System.Windows.Forms.Padding(4);
            this.ucSearchBy.Name = "ucSearchBy";
            this.ucSearchBy.Size = new System.Drawing.Size(80, 44);
            this.ucSearchBy.TabIndex = 19;
            // 
            // ucOutlet
            // 
            this.ucOutlet.AutoCompleteValue = "";
            this.ucOutlet.Location = new System.Drawing.Point(118, 35);
            this.ucOutlet.Name = "ucOutlet";
            this.ucOutlet.Size = new System.Drawing.Size(316, 21);
            this.ucOutlet.TabIndex = 18;
            // 
            // lblOutlet
            // 
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlet.Location = new System.Drawing.Point(3, 35);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(57, 17);
            this.lblOutlet.TabIndex = 17;
            this.lblOutlet.Text = "Outlet:";
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.gvDeliveries);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 134);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1063, 442);
            this.pnlDetail.TabIndex = 17;
            // 
            // gvDeliveries
            // 
            this.gvDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDeliveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDR,
            this.colDeliveryDate,
            this.colOutletName,
            this.colCreatedBy,
            this.colCreatedDate});
            this.gvDeliveries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDeliveries.Location = new System.Drawing.Point(0, 0);
            this.gvDeliveries.Name = "gvDeliveries";
            this.gvDeliveries.RowHeadersVisible = false;
            this.gvDeliveries.Size = new System.Drawing.Size(1063, 442);
            this.gvDeliveries.TabIndex = 1;
            this.gvDeliveries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDeliveries_CellClick);
            // 
            // colDR
            // 
            this.colDR.DataPropertyName = "PackingListNumber";
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
            // colOutletName
            // 
            this.colOutletName.HeaderText = "Outlet Name";
            this.colOutletName.Name = "colOutletName";
            this.colOutletName.ReadOnly = true;
            this.colOutletName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOutletName.Width = 300;
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
            // DeliveryToOutletSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 576);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlSearchDetail);
            this.Name = "DeliveryToOutletSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery to Outlet Search";
            this.Load += new System.EventHandler(this.DeliveryToOutletSearchForm_Load);
            this.pnlSearchDetail.ResumeLayout(false);
            this.pnlSearchDetail.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSearchMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSearchDetail;
        private UserControls.UcDateRangeFilter ucDateRangeFilter1;
        private UserControls.ucSaveEditForm ucSearchBy;
        private UserControls.ucAutoComplete ucOutlet;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.DataGridView gvDeliveries;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutletName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
    }
}