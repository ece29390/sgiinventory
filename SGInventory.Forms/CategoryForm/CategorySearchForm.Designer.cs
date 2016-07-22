namespace SGInventory.CategoryForm
{
    partial class CategorySearchForm
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
            this.categoryDataView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.colId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.categoryDataView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 316);
            this.panel1.TabIndex = 0;
            // 
            // categoryDataView
            // 
            this.categoryDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colDescription});
            this.categoryDataView.Location = new System.Drawing.Point(3, 41);
            this.categoryDataView.Name = "categoryDataView";
            this.categoryDataView.RowHeadersVisible = false;
            this.categoryDataView.Size = new System.Drawing.Size(767, 269);
            this.categoryDataView.TabIndex = 0;
            this.categoryDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.categoryDataView_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucAddDelete1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 316);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 76);
            this.panel2.TabIndex = 1;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(536, 7);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(242, 58);
            this.ucAddDelete1.TabIndex = 0;
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
            this.colName.Width = 250;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 400;
            // 
            // CategorySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 392);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CategorySearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategorySearchForm";
            this.Load += new System.EventHandler(this.CategorySearchForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView categoryDataView;
        private System.Windows.Forms.Panel panel2;
        private UserControls.ucAddDelete ucAddDelete1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colId;
        private System.Windows.Forms.DataGridViewLinkColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}