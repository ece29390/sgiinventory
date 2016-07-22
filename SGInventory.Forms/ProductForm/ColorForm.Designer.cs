namespace SGInventory.ProductForm
{
    partial class ColorForm
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
            this.dgvColors = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColors
            // 
            this.dgvColors.AllowUserToAddRows = false;
            this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colActualColor});
            this.dgvColors.Location = new System.Drawing.Point(1, 3);
            this.dgvColors.Name = "dgvColors";
            this.dgvColors.RowHeadersVisible = false;
            this.dgvColors.Size = new System.Drawing.Size(732, 400);
            this.dgvColors.TabIndex = 0;
            this.dgvColors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColors_CellClick);
            this.dgvColors.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColors_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 250;
            // 
            // colActualColor
            // 
            this.colActualColor.HeaderText = "";
            this.colActualColor.Name = "colActualColor";
            this.colActualColor.Width = 400;
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 404);
            this.Controls.Add(this.dgvColors);
            this.Name = "ColorForm";
            this.Text = "ColorForm";
            this.Load += new System.EventHandler(this.ColorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualColor;
    }
}