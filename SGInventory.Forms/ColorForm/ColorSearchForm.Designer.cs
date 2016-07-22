namespace SGInventory.ColorForm
{
    partial class ColorSearchForm
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
            this.colorSearchGrid = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucAddDelete1 = new SGInventory.UserControls.ucAddDelete();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSearchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.colorSearchGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 316);
            this.panel1.TabIndex = 0;
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
            // colorSearchGrid
            // 
            this.colorSearchGrid.AllowUserToAddRows = false;
            this.colorSearchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorSearchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCode,
            this.colName});
            this.colorSearchGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.colorSearchGrid.Location = new System.Drawing.Point(0, 49);
            this.colorSearchGrid.Name = "colorSearchGrid";
            this.colorSearchGrid.RowHeadersVisible = false;
            this.colorSearchGrid.Size = new System.Drawing.Size(782, 267);
            this.colorSearchGrid.TabIndex = 2;
            this.colorSearchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorSearchGrid_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.Width = 25;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 400;
            // 
            // ucAddDelete1
            // 
            this.ucAddDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAddDelete1.Location = new System.Drawing.Point(536, 14);
            this.ucAddDelete1.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddDelete1.Name = "ucAddDelete1";
            this.ucAddDelete1.Size = new System.Drawing.Size(242, 58);
            this.ucAddDelete1.TabIndex = 0;
            // 
            // ColorSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 392);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ColorSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorSearchForm";
            this.Load += new System.EventHandler(this.ColorSearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorSearchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView colorSearchGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colId;
        private System.Windows.Forms.DataGridViewLinkColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private UserControls.ucAddDelete ucAddDelete1;
    }
}