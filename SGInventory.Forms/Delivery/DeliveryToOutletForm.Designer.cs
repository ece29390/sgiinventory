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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpProductDetail = new System.Windows.Forms.GroupBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.deliveryToOutletBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.userControlSelectProduct1 = new SGInventory.UserControls.UserControlSelectProduct();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.ucSaveDeliveryDetail = new SGInventory.UserControls.ucSaveEditForm();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ncSrpPrice = new SGInventory.UserControls.NumericControl();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.deliveryToOutletBindingSource)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 746);
            this.panel1.TabIndex = 0;
            // 
            // grpProductDetail
            // 
            this.grpProductDetail.Controls.Add(this.StatusComboBox);
            this.grpProductDetail.Controls.Add(this.label5);
            this.grpProductDetail.Controls.Add(this.userControlSelectProduct1);
            this.grpProductDetail.Controls.Add(this.buttonAdd);
            this.grpProductDetail.Controls.Add(this.ucSaveDeliveryDetail);
            this.grpProductDetail.Controls.Add(this.txtQuantity);
            this.grpProductDetail.Controls.Add(this.label4);
            this.grpProductDetail.Controls.Add(this.ncSrpPrice);
            this.grpProductDetail.Controls.Add(this.label3);
            this.grpProductDetail.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.deliveryToOutletBindingSource, "ProductDetailEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.grpProductDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProductDetail.Enabled = false;
            this.grpProductDetail.Location = new System.Drawing.Point(0, 117);
            this.grpProductDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpProductDetail.Name = "grpProductDetail";
            this.grpProductDetail.Padding = new System.Windows.Forms.Padding(4);
            this.grpProductDetail.Size = new System.Drawing.Size(439, 629);
            this.grpProductDetail.TabIndex = 1;
            this.grpProductDetail.TabStop = false;
            this.grpProductDetail.Text = "Product Detail";
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.deliveryToOutletBindingSource, "Status", true));
            this.StatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.deliveryToOutletBindingSource, "Status", true));
            this.StatusComboBox.Enabled = false;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(159, 30);
            this.StatusComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(271, 24);
            this.StatusComboBox.TabIndex = 16;
            this.StatusComboBox.Visible = false;
            // 
            // deliveryToOutletBindingSource
            // 
            this.deliveryToOutletBindingSource.DataSource = typeof(SGInventory.Views.UIModel.DeliveryToOutletViewModel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Status:";
            this.label5.Visible = false;
            // 
            // userControlSelectProduct1
            // 
            this.userControlSelectProduct1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.deliveryToOutletBindingSource, "ProductDetailEnable", true));
            this.userControlSelectProduct1.Location = new System.Drawing.Point(6, 121);
            this.userControlSelectProduct1.Name = "userControlSelectProduct1";
            this.userControlSelectProduct1.Size = new System.Drawing.Size(433, 228);
            this.userControlSelectProduct1.TabIndex = 22;
            // 
            // buttonAdd
            // 
            this.buttonAdd.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.deliveryToOutletBindingSource, "AddProductEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonAdd.Enabled = false;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(159, 357);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(157, 48);
            this.buttonAdd.TabIndex = 24;
            this.buttonAdd.Text = "Add Product";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // ucSaveDeliveryDetail
            // 
            this.ucSaveDeliveryDetail.DataBindings.Add(new System.Windows.Forms.Binding("SaveButtonEnabled", this.deliveryToOutletBindingSource, "SaveProductEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ucSaveDeliveryDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveDeliveryDetail.Location = new System.Drawing.Point(326, 351);
            this.ucSaveDeliveryDetail.Margin = new System.Windows.Forms.Padding(5);
            this.ucSaveDeliveryDetail.Name = "ucSaveDeliveryDetail";
            this.ucSaveDeliveryDetail.SaveButtonEnabled = false;
            this.ucSaveDeliveryDetail.Size = new System.Drawing.Size(105, 54);
            this.ucSaveDeliveryDetail.TabIndex = 26;
            // 
            // txtQuantity
            // 
            this.txtQuantity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.deliveryToOutletBindingSource, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtQuantity.Location = new System.Drawing.Point(159, 59);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(140, 22);
            this.txtQuantity.TabIndex = 18;
            this.txtQuantity.Visible = false;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Quantity:";
            this.label4.Visible = false;
            // 
            // ncSrpPrice
            // 
            this.ncSrpPrice.DataBindings.Add(new System.Windows.Forms.Binding("Numeric", this.deliveryToOutletBindingSource, "SrpPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ncSrpPrice.Enabled = false;
            this.ncSrpPrice.Location = new System.Drawing.Point(159, 90);
            this.ncSrpPrice.Margin = new System.Windows.Forms.Padding(5);
            this.ncSrpPrice.Name = "ncSrpPrice";
            this.ncSrpPrice.Numeric = 0D;
            this.ncSrpPrice.Size = new System.Drawing.Size(141, 27);
            this.ncSrpPrice.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "SRP/Price:";
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
            this.grpStore.Margin = new System.Windows.Forms.Padding(4);
            this.grpStore.Name = "grpStore";
            this.grpStore.Padding = new System.Windows.Forms.Padding(4);
            this.grpStore.Size = new System.Drawing.Size(439, 117);
            this.grpStore.TabIndex = 0;
            this.grpStore.TabStop = false;
            this.grpStore.Text = "Store";
            // 
            // dtpDateDelivered
            // 
            this.dtpDateDelivered.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.deliveryToOutletBindingSource, "DeliveryDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpDateDelivered.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDelivered.Location = new System.Drawing.Point(148, 81);
            this.dtpDateDelivered.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateDelivered.Name = "dtpDateDelivered";
            this.dtpDateDelivered.Size = new System.Drawing.Size(281, 22);
            this.dtpDateDelivered.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Delivery Date:";
            // 
            // txtDrNo
            // 
            this.txtDrNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.deliveryToOutletBindingSource, "DrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDrNo.Location = new System.Drawing.Point(148, 49);
            this.txtDrNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrNo.Name = "txtDrNo";
            this.txtDrNo.Size = new System.Drawing.Size(281, 22);
            this.txtDrNo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "DR No.:";
            // 
            // ucAutoCompleteStore
            // 
            this.ucAutoCompleteStore.AutoCompleteValue = "";
            this.ucAutoCompleteStore.DataBindings.Add(new System.Windows.Forms.Binding("AutoCompleteValue", this.deliveryToOutletBindingSource, "Outlet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ucAutoCompleteStore.Location = new System.Drawing.Point(148, 20);
            this.ucAutoCompleteStore.Margin = new System.Windows.Forms.Padding(5);
            this.ucAutoCompleteStore.Name = "ucAutoCompleteStore";
            this.ucAutoCompleteStore.Size = new System.Drawing.Size(283, 26);
            this.ucAutoCompleteStore.TabIndex = 10;
            this.ucAutoCompleteStore.Leave += new System.EventHandler(this.ucAutoCompleteStore_Leave);
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierLabel.Location = new System.Drawing.Point(8, 20);
            this.supplierLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(66, 20);
            this.supplierLabel.TabIndex = 9;
            this.supplierLabel.Text = "Outlet:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvItem);
            this.panel2.Controls.Add(this.msDeliveryToOutletTransaction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(439, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 746);
            this.panel2.TabIndex = 1;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.Location = new System.Drawing.Point(0, 28);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(978, 718);
            this.dgvItem.TabIndex = 0;
            // 
            // msDeliveryToOutletTransaction
            // 
            this.msDeliveryToOutletTransaction.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.deliveryToOutletBindingSource, "ProductDetailEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.msDeliveryToOutletTransaction.Enabled = false;
            this.msDeliveryToOutletTransaction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msDeliveryToOutletTransaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.printToolStripMenuItem});
            this.msDeliveryToOutletTransaction.Location = new System.Drawing.Point(0, 0);
            this.msDeliveryToOutletTransaction.Name = "msDeliveryToOutletTransaction";
            this.msDeliveryToOutletTransaction.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msDeliveryToOutletTransaction.Size = new System.Drawing.Size(978, 28);
            this.msDeliveryToOutletTransaction.TabIndex = 1;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // DeliveryToOutletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 746);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.msDeliveryToOutletTransaction;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DeliveryToOutletForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery to outlet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryToOutletForm_FormClosing);
            this.Load += new System.EventHandler(this.DeliveryToOutletForm_Load);
            this.panel1.ResumeLayout(false);
            this.grpProductDetail.ResumeLayout(false);
            this.grpProductDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryToOutletBindingSource)).EndInit();
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
        private UserControls.UserControlSelectProduct userControlSelectProduct1;
        private System.Windows.Forms.BindingSource deliveryToOutletBindingSource;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label5;

    }
}