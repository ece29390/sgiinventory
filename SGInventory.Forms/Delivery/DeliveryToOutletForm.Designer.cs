namespace SGInventory.Delivery
{
    partial class DeliveryToOutletForm
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
            this.grpProductDetail = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.ucSaveDeliveryDetail = new SGInventory.UserControls.ucSaveEditForm();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ncSrpPrice = new SGInventory.UserControls.NumericControl();
            this.label3 = new System.Windows.Forms.Label();
            this.ucScanBarcodeDisplay1 = new SGInventory.UserControls.ucManualEntryDisplay();
            this.grpStore = new System.Windows.Forms.GroupBox();
            this.dtpDateDelivered = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDrNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucAutoCompleteStore = new SGInventory.UserControls.ucAutoComplete();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.msDeliveryToOutletTransaction = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.grpProductDetail.SuspendLayout();
            this.grpStore.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.msDeliveryToOutletTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpProductDetail);
            this.panel1.Controls.Add(this.grpStore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 606);
            this.panel1.TabIndex = 0;
            // 
            // grpProductDetail
            // 
            this.grpProductDetail.Controls.Add(this.buttonAdd);
            this.grpProductDetail.Controls.Add(this.ucSaveDeliveryDetail);
            this.grpProductDetail.Controls.Add(this.txtQuantity);
            this.grpProductDetail.Controls.Add(this.label4);
            this.grpProductDetail.Controls.Add(this.ncSrpPrice);
            this.grpProductDetail.Controls.Add(this.label3);
            this.grpProductDetail.Controls.Add(this.ucScanBarcodeDisplay1);
            this.grpProductDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProductDetail.Enabled = false;
            this.grpProductDetail.Location = new System.Drawing.Point(0, 95);
            this.grpProductDetail.Name = "grpProductDetail";
            this.grpProductDetail.Size = new System.Drawing.Size(329, 511);
            this.grpProductDetail.TabIndex = 1;
            this.grpProductDetail.TabStop = false;
            this.grpProductDetail.Text = "Product Detail";
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(120, 259);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 39);
            this.buttonAdd.TabIndex = 39;
            this.buttonAdd.Text = "Add Product";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // ucSaveDeliveryDetail
            // 
            this.ucSaveDeliveryDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveDeliveryDetail.Location = new System.Drawing.Point(245, 254);
            this.ucSaveDeliveryDetail.Margin = new System.Windows.Forms.Padding(4);
            this.ucSaveDeliveryDetail.Name = "ucSaveDeliveryDetail";
            this.ucSaveDeliveryDetail.Size = new System.Drawing.Size(79, 44);
            this.ucSaveDeliveryDetail.TabIndex = 40;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 232);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(106, 20);
            this.txtQuantity.TabIndex = 26;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Quantity:";
            // 
            // ncSrpPrice
            // 
            this.ncSrpPrice.Enabled = false;
            this.ncSrpPrice.Location = new System.Drawing.Point(120, 207);
            this.ncSrpPrice.Name = "ncSrpPrice";
            this.ncSrpPrice.Numeric = 0D;
            this.ncSrpPrice.Size = new System.Drawing.Size(106, 22);
            this.ncSrpPrice.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "SRP/Price:";
            // 
            // ucScanBarcodeDisplay1
            // 
            this.ucScanBarcodeDisplay1.Location = new System.Drawing.Point(3, 19);
            this.ucScanBarcodeDisplay1.Name = "ucScanBarcodeDisplay1";
            this.ucScanBarcodeDisplay1.Size = new System.Drawing.Size(325, 185);
            this.ucScanBarcodeDisplay1.TabIndex = 0;
            // 
            // grpStore
            // 
            this.grpStore.Controls.Add(this.dtpDateDelivered);
            this.grpStore.Controls.Add(this.label2);
            this.grpStore.Controls.Add(this.txtDrNo);
            this.grpStore.Controls.Add(this.label1);
            this.grpStore.Controls.Add(this.ucAutoCompleteStore);
            this.grpStore.Controls.Add(this.supplierLabel);
            this.grpStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStore.Location = new System.Drawing.Point(0, 0);
            this.grpStore.Name = "grpStore";
            this.grpStore.Size = new System.Drawing.Size(329, 95);
            this.grpStore.TabIndex = 0;
            this.grpStore.TabStop = false;
            this.grpStore.Text = "Store";
            // 
            // dtpDateDelivered
            // 
            this.dtpDateDelivered.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDelivered.Location = new System.Drawing.Point(111, 66);
            this.dtpDateDelivered.Name = "dtpDateDelivered";
            this.dtpDateDelivered.Size = new System.Drawing.Size(212, 20);
            this.dtpDateDelivered.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Delivery Date:";
            // 
            // txtDrNo
            // 
            this.txtDrNo.Location = new System.Drawing.Point(111, 40);
            this.txtDrNo.Name = "txtDrNo";
            this.txtDrNo.Size = new System.Drawing.Size(212, 20);
            this.txtDrNo.TabIndex = 12;
            this.txtDrNo.TextChanged += new System.EventHandler(this.txtDrNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "DR No.:";
            // 
            // ucAutoCompleteStore
            // 
            this.ucAutoCompleteStore.AutoCompleteValue = "";
            this.ucAutoCompleteStore.Location = new System.Drawing.Point(111, 16);
            this.ucAutoCompleteStore.Name = "ucAutoCompleteStore";
            this.ucAutoCompleteStore.Size = new System.Drawing.Size(212, 21);
            this.ucAutoCompleteStore.TabIndex = 10;
            this.ucAutoCompleteStore.Leave += new System.EventHandler(this.ucAutoCompleteStore_Leave);
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierLabel.Location = new System.Drawing.Point(6, 16);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(57, 17);
            this.supplierLabel.TabIndex = 9;
            this.supplierLabel.Text = "Outlet:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvItem);
            this.panel2.Controls.Add(this.msDeliveryToOutletTransaction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(329, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 606);
            this.panel2.TabIndex = 1;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.Location = new System.Drawing.Point(0, 24);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(734, 582);
            this.dgvItem.TabIndex = 0;
            // 
            // msDeliveryToOutletTransaction
            // 
            this.msDeliveryToOutletTransaction.Enabled = false;
            this.msDeliveryToOutletTransaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.printToolStripMenuItem});
            this.msDeliveryToOutletTransaction.Location = new System.Drawing.Point(0, 0);
            this.msDeliveryToOutletTransaction.Name = "msDeliveryToOutletTransaction";
            this.msDeliveryToOutletTransaction.Size = new System.Drawing.Size(734, 24);
            this.msDeliveryToOutletTransaction.TabIndex = 1;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // DeliveryToOutletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 606);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.msDeliveryToOutletTransaction;
            this.Name = "DeliveryToOutletForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery to outlet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryToOutletForm_FormClosing);
            this.Load += new System.EventHandler(this.DeliveryToOutletForm_Load);
            this.panel1.ResumeLayout(false);
            this.grpProductDetail.ResumeLayout(false);
            this.grpProductDetail.PerformLayout();
            this.grpStore.ResumeLayout(false);
            this.grpStore.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.msDeliveryToOutletTransaction.ResumeLayout(false);
            this.msDeliveryToOutletTransaction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpStore;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label supplierLabel;
        private UserControls.ucAutoComplete ucAutoCompleteStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDrNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateDelivered;
        private System.Windows.Forms.GroupBox grpProductDetail;
        private UserControls.ucManualEntryDisplay ucScanBarcodeDisplay1;
        private UserControls.NumericControl ncSrpPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button buttonAdd;
        private UserControls.ucSaveEditForm ucSaveDeliveryDetail;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.MenuStrip msDeliveryToOutletTransaction;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;

    }
}