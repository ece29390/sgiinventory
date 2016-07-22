namespace SGInventory.UserControls
{
    partial class ucNameAddress
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
            this.NameAddressDataGridView = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NameAddressDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NameAddressDataGridView
            // 
            this.NameAddressDataGridView.AllowUserToAddRows = false;
            this.NameAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NameAddressDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colAddress});
            this.NameAddressDataGridView.Location = new System.Drawing.Point(3, 3);
            this.NameAddressDataGridView.Name = "NameAddressDataGridView";
            this.NameAddressDataGridView.RowHeadersVisible = false;
            this.NameAddressDataGridView.Size = new System.Drawing.Size(767, 269);
            this.NameAddressDataGridView.TabIndex = 0;
            this.NameAddressDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NameAddressDataGridView_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.Width = 25;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colName.Width = 250;
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 300;
            // 
            // ucNameAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameAddressDataGridView);
            this.Name = "ucNameAddress";
            this.Size = new System.Drawing.Size(774, 275);
            ((System.ComponentModel.ISupportInitialize)(this.NameAddressDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NameAddressDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colId;
        private System.Windows.Forms.DataGridViewLinkColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
    }
}
