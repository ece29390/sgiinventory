namespace SGInventory.Inventory
{
    partial class ViewHistory
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
            this.dgViewHistory = new System.Windows.Forms.DataGridView();
            this.colTransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuAdjustment = new System.Windows.Forms.MenuStrip();
            this.adjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSearchDate = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.rbDateRange = new System.Windows.Forms.RadioButton();
            this.rbSearch3Months = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewHistory)).BeginInit();
            this.mnuAdjustment.SuspendLayout();
            this.gbSearchDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgViewHistory
            // 
            this.dgViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransactionDate,
            this.colEntity,
            this.colQuantity,
            this.colRemarks});
            this.dgViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewHistory.Location = new System.Drawing.Point(0, 0);
            this.dgViewHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgViewHistory.Name = "dgViewHistory";
            this.dgViewHistory.RowHeadersVisible = false;
            this.dgViewHistory.Size = new System.Drawing.Size(1005, 818);
            this.dgViewHistory.TabIndex = 0;
            this.dgViewHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewHistory_CellContentClick);
            this.dgViewHistory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgViewHistory_DataBindingComplete);
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DataPropertyName = "TransactionDate";
            this.colTransactionDate.HeaderText = "Transaction Date";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.ReadOnly = true;
            this.colTransactionDate.Width = 150;
            // 
            // colEntity
            // 
            this.colEntity.DataPropertyName = "Entity";
            this.colEntity.HeaderText = "Supplier/Outlet";
            this.colEntity.Name = "colEntity";
            this.colEntity.ReadOnly = true;
            this.colEntity.Width = 200;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "DeliveryDescription";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            this.colRemarks.Width = 300;
            // 
            // mnuAdjustment
            // 
            this.mnuAdjustment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustmentToolStripMenuItem});
            this.mnuAdjustment.Location = new System.Drawing.Point(0, 0);
            this.mnuAdjustment.Name = "mnuAdjustment";
            this.mnuAdjustment.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuAdjustment.Size = new System.Drawing.Size(1005, 28);
            this.mnuAdjustment.TabIndex = 1;
            this.mnuAdjustment.Text = "menuStrip1";
            // 
            // adjustmentToolStripMenuItem
            // 
            this.adjustmentToolStripMenuItem.Name = "adjustmentToolStripMenuItem";
            this.adjustmentToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.adjustmentToolStripMenuItem.Text = "Adjust";
            this.adjustmentToolStripMenuItem.Click += new System.EventHandler(this.adjustmentToolStripMenuItem_Click);
            // 
            // gbSearchDate
            // 
            this.gbSearchDate.Controls.Add(this.btnLoad);
            this.gbSearchDate.Controls.Add(this.dtpTo);
            this.gbSearchDate.Controls.Add(this.label2);
            this.gbSearchDate.Controls.Add(this.label1);
            this.gbSearchDate.Controls.Add(this.dtpFrom);
            this.gbSearchDate.Controls.Add(this.rbDateRange);
            this.gbSearchDate.Controls.Add(this.rbSearch3Months);
            this.gbSearchDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearchDate.Location = new System.Drawing.Point(0, 28);
            this.gbSearchDate.Margin = new System.Windows.Forms.Padding(4);
            this.gbSearchDate.Name = "gbSearchDate";
            this.gbSearchDate.Padding = new System.Windows.Forms.Padding(4);
            this.gbSearchDate.Size = new System.Drawing.Size(1005, 112);
            this.gbSearchDate.TabIndex = 2;
            this.gbSearchDate.TabStop = false;
            this.gbSearchDate.Text = "Search Date";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 80);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Location = new System.Drawing.Point(517, 49);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(265, 22);
            this.dtpTo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Location = new System.Drawing.Point(204, 49);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(265, 22);
            this.dtpFrom.TabIndex = 2;
            // 
            // rbDateRange
            // 
            this.rbDateRange.AutoSize = true;
            this.rbDateRange.Location = new System.Drawing.Point(8, 52);
            this.rbDateRange.Margin = new System.Windows.Forms.Padding(4);
            this.rbDateRange.Name = "rbDateRange";
            this.rbDateRange.Size = new System.Drawing.Size(105, 21);
            this.rbDateRange.TabIndex = 1;
            this.rbDateRange.TabStop = true;
            this.rbDateRange.Text = "Date Range";
            this.rbDateRange.UseVisualStyleBackColor = true;
            this.rbDateRange.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbSearch3Months
            // 
            this.rbSearch3Months.AutoSize = true;
            this.rbSearch3Months.Checked = true;
            this.rbSearch3Months.Location = new System.Drawing.Point(8, 23);
            this.rbSearch3Months.Margin = new System.Windows.Forms.Padding(4);
            this.rbSearch3Months.Name = "rbSearch3Months";
            this.rbSearch3Months.Size = new System.Drawing.Size(130, 21);
            this.rbSearch3Months.TabIndex = 0;
            this.rbSearch3Months.TabStop = true;
            this.rbSearch3Months.Text = "Latest 3 Months";
            this.rbSearch3Months.UseVisualStyleBackColor = true;
            this.rbSearch3Months.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgViewHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 818);
            this.panel1.TabIndex = 3;
            // 
            // ViewHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 958);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbSearchDate);
            this.Controls.Add(this.mnuAdjustment);
            this.MainMenuStrip = this.mnuAdjustment;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View History/Adjustment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewHistory_FormClosing);
            this.Load += new System.EventHandler(this.ViewHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewHistory)).EndInit();
            this.mnuAdjustment.ResumeLayout(false);
            this.mnuAdjustment.PerformLayout();
            this.gbSearchDate.ResumeLayout(false);
            this.gbSearchDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewHistory;
        private System.Windows.Forms.MenuStrip mnuAdjustment;
        private System.Windows.Forms.GroupBox gbSearchDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.RadioButton rbDateRange;
        private System.Windows.Forms.RadioButton rbSearch3Months;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.ToolStripMenuItem adjustmentToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}