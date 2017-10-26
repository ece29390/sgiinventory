namespace SGInventory.Delivery
{
    partial class SupplierDeliveryForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.ProductGroupBox = new System.Windows.Forms.GroupBox();
            this.supplierDeliveryViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.gbDamageDetail = new System.Windows.Forms.GroupBox();
            this.cboDamageStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StatusDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.QuantityTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SupplierGroupBox = new System.Windows.Forms.GroupBox();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.DeliveryDateDtp = new System.Windows.Forms.DateTimePicker();
            this.DeliveryDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OrTextbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gvDeliveryDetails = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblStockNumber = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editDeliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.userControlSelectProduct1 = new SGInventory.UserControls.UserControlSelectProduct();
            this.ucSaveDeliveryDetail = new SGInventory.UserControls.ucSaveEditForm();
            this.CostNumericControl = new SGInventory.UserControls.NumericControl();
            this.SupplierAutoComplete = new SGInventory.UserControls.ucAutoComplete();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ProductGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDeliveryViewModelBindingSource)).BeginInit();
            this.gbDamageDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SupplierGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveryDetails)).BeginInit();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 746);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ProductGroupBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 130);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(445, 616);
            this.panel4.TabIndex = 10;
            // 
            // ProductGroupBox
            // 
            this.ProductGroupBox.Controls.Add(this.userControlSelectProduct1);
            this.ProductGroupBox.Controls.Add(this.buttonAdd);
            this.ProductGroupBox.Controls.Add(this.gbDamageDetail);
            this.ProductGroupBox.Controls.Add(this.QuantityTextbox);
            this.ProductGroupBox.Controls.Add(this.ucSaveDeliveryDetail);
            this.ProductGroupBox.Controls.Add(this.CostNumericControl);
            this.ProductGroupBox.Controls.Add(this.label2);
            this.ProductGroupBox.Controls.Add(this.QuantityLabel);
            this.ProductGroupBox.Controls.Add(this.label5);
            this.ProductGroupBox.Controls.Add(this.StatusComboBox);
            this.ProductGroupBox.Controls.Add(this.label4);
            this.ProductGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.supplierDeliveryViewModelBindingSource, "EnableProductGroup", true));
            this.ProductGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ProductGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProductGroupBox.Name = "ProductGroupBox";
            this.ProductGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ProductGroupBox.Size = new System.Drawing.Size(445, 616);
            this.ProductGroupBox.TabIndex = 9;
            this.ProductGroupBox.TabStop = false;
            this.ProductGroupBox.Text = "Product";
            // 
            // supplierDeliveryViewModelBindingSource
            // 
            this.supplierDeliveryViewModelBindingSource.DataSource = typeof(SGInventory.Views.UIModel.SupplierDeliveryViewModel);
            // 
            // buttonAdd
            // 
            this.buttonAdd.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.supplierDeliveryViewModelBindingSource, "AddButtonEnable", true));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(168, 562);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(157, 48);
            this.buttonAdd.TabIndex = 37;
            this.buttonAdd.Text = "Add Product";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // gbDamageDetail
            // 
            this.gbDamageDetail.Controls.Add(this.cboDamageStatus);
            this.gbDamageDetail.Controls.Add(this.label9);
            this.gbDamageDetail.Controls.Add(this.StatusDescriptionTextbox);
            this.gbDamageDetail.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.supplierDeliveryViewModelBindingSource, "DamageDetailsEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gbDamageDetail.Enabled = false;
            this.gbDamageDetail.Location = new System.Drawing.Point(4, 148);
            this.gbDamageDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gbDamageDetail.Name = "gbDamageDetail";
            this.gbDamageDetail.Padding = new System.Windows.Forms.Padding(4);
            this.gbDamageDetail.Size = new System.Drawing.Size(441, 181);
            this.gbDamageDetail.TabIndex = 32;
            this.gbDamageDetail.TabStop = false;
            this.gbDamageDetail.Text = "Damage Details";
            // 
            // cboDamageStatus
            // 
            this.cboDamageStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.supplierDeliveryViewModelBindingSource, "DamageStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboDamageStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "DamageStatus", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboDamageStatus.FormattingEnabled = true;
            this.cboDamageStatus.Location = new System.Drawing.Point(181, 21);
            this.cboDamageStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboDamageStatus.Name = "cboDamageStatus";
            this.cboDamageStatus.Size = new System.Drawing.Size(249, 24);
            this.cboDamageStatus.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Damage Status:";
            // 
            // StatusDescriptionTextbox
            // 
            this.StatusDescriptionTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "DamageDescription", true));
            this.StatusDescriptionTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.supplierDeliveryViewModelBindingSource, "DamageStatusDescriptionEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StatusDescriptionTextbox.Enabled = false;
            this.StatusDescriptionTextbox.Location = new System.Drawing.Point(9, 54);
            this.StatusDescriptionTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusDescriptionTextbox.MaxLength = 500;
            this.StatusDescriptionTextbox.Multiline = true;
            this.StatusDescriptionTextbox.Name = "StatusDescriptionTextbox";
            this.StatusDescriptionTextbox.Size = new System.Drawing.Size(423, 122);
            this.StatusDescriptionTextbox.TabIndex = 23;
            // 
            // QuantityTextbox
            // 
            this.QuantityTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "Quantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "1", "N0"));
            this.QuantityTextbox.Location = new System.Drawing.Point(163, 54);
            this.QuantityTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.QuantityTextbox.Name = "QuantityTextbox";
            this.QuantityTextbox.Size = new System.Drawing.Size(141, 22);
            this.QuantityTextbox.TabIndex = 17;
            this.QuantityTextbox.Text = "1";
            this.QuantityTextbox.Visible = false;
            this.QuantityTextbox.TextChanged += new System.EventHandler(this.QuantityTextbox_TextChanged);
            this.QuantityTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityTextbox_KeyPress);
            this.QuantityTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuantityTextbox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cost:";
            this.label2.Visible = false;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLabel.Location = new System.Drawing.Point(5, 54);
            this.QuantityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(85, 20);
            this.QuantityLabel.TabIndex = 20;
            this.QuantityLabel.Text = "Quantity:";
            this.QuantityLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Status Description:";
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.supplierDeliveryViewModelBindingSource, "Status", true));
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(163, 86);
            this.StatusComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(271, 24);
            this.StatusComboBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SupplierGroupBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 130);
            this.panel3.TabIndex = 9;
            // 
            // SupplierGroupBox
            // 
            this.SupplierGroupBox.Controls.Add(this.supplierLabel);
            this.SupplierGroupBox.Controls.Add(this.DeliveryDateDtp);
            this.SupplierGroupBox.Controls.Add(this.SupplierAutoComplete);
            this.SupplierGroupBox.Controls.Add(this.DeliveryDateLabel);
            this.SupplierGroupBox.Controls.Add(this.label1);
            this.SupplierGroupBox.Controls.Add(this.OrTextbox);
            this.SupplierGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierGroupBox.Location = new System.Drawing.Point(0, 0);
            this.SupplierGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierGroupBox.Name = "SupplierGroupBox";
            this.SupplierGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.SupplierGroupBox.Size = new System.Drawing.Size(445, 130);
            this.SupplierGroupBox.TabIndex = 14;
            this.SupplierGroupBox.TabStop = false;
            this.SupplierGroupBox.Text = "Supplier";
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierLabel.Location = new System.Drawing.Point(4, 20);
            this.supplierLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(84, 20);
            this.supplierLabel.TabIndex = 8;
            this.supplierLabel.Text = "Supplier:";
            // 
            // DeliveryDateDtp
            // 
            this.DeliveryDateDtp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.supplierDeliveryViewModelBindingSource, "DrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DeliveryDateDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DeliveryDateDtp.Location = new System.Drawing.Point(168, 80);
            this.DeliveryDateDtp.Margin = new System.Windows.Forms.Padding(4);
            this.DeliveryDateDtp.Name = "DeliveryDateDtp";
            this.DeliveryDateDtp.Size = new System.Drawing.Size(149, 22);
            this.DeliveryDateDtp.TabIndex = 13;
            // 
            // DeliveryDateLabel
            // 
            this.DeliveryDateLabel.AutoSize = true;
            this.DeliveryDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryDateLabel.Location = new System.Drawing.Point(8, 80);
            this.DeliveryDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeliveryDateLabel.Name = "DeliveryDateLabel";
            this.DeliveryDateLabel.Size = new System.Drawing.Size(130, 20);
            this.DeliveryDateLabel.TabIndex = 12;
            this.DeliveryDateLabel.Text = "Delivery Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "DR No.:";
            // 
            // OrTextbox
            // 
            this.OrTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "DrNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.OrTextbox.Location = new System.Drawing.Point(164, 48);
            this.OrTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.OrTextbox.Name = "OrTextbox";
            this.OrTextbox.Size = new System.Drawing.Size(267, 22);
            this.OrTextbox.TabIndex = 11;
            this.OrTextbox.TextChanged += new System.EventHandler(this.OrTextbox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(445, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 746);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gvDeliveryDetails);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 55);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(972, 691);
            this.panel6.TabIndex = 4;
            // 
            // gvDeliveryDetails
            // 
            this.gvDeliveryDetails.AllowUserToAddRows = false;
            this.gvDeliveryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDeliveryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDeliveryDetails.Location = new System.Drawing.Point(0, 0);
            this.gvDeliveryDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gvDeliveryDetails.Name = "gvDeliveryDetails";
            this.gvDeliveryDetails.Size = new System.Drawing.Size(972, 691);
            this.gvDeliveryDetails.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblStockNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 28);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(972, 27);
            this.panel5.TabIndex = 3;
            // 
            // lblStockNumber
            // 
            this.lblStockNumber.AutoSize = true;
            this.lblStockNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierDeliveryViewModelBindingSource, "SelectedStockNumber", true));
            this.lblStockNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStockNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockNumber.Location = new System.Drawing.Point(0, 0);
            this.lblStockNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockNumber.Name = "lblStockNumber";
            this.lblStockNumber.Size = new System.Drawing.Size(128, 18);
            this.lblStockNumber.TabIndex = 2;
            this.lblStockNumber.Text = "lblStockNumber";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDeliveriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(972, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editDeliveriesToolStripMenuItem
            // 
            this.editDeliveriesToolStripMenuItem.Name = "editDeliveriesToolStripMenuItem";
            this.editDeliveriesToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.editDeliveriesToolStripMenuItem.Text = "Edit Deliveries";
            this.editDeliveriesToolStripMenuItem.Click += new System.EventHandler(this.editDeliveriesToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 72);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 15;
            // 
            // userControlSelectProduct1
            // 
            this.userControlSelectProduct1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.supplierDeliveryViewModelBindingSource, "ProductDetailEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.userControlSelectProduct1.Location = new System.Drawing.Point(5, 331);
            this.userControlSelectProduct1.Name = "userControlSelectProduct1";
            this.userControlSelectProduct1.Size = new System.Drawing.Size(433, 227);
            this.userControlSelectProduct1.TabIndex = 25;
            // 
            // ucSaveDeliveryDetail
            // 
            this.ucSaveDeliveryDetail.DataBindings.Add(new System.Windows.Forms.Binding("SaveButtonEnabled", this.supplierDeliveryViewModelBindingSource, "SaveDeliveryEnable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ucSaveDeliveryDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaveDeliveryDetail.Location = new System.Drawing.Point(335, 556);
            this.ucSaveDeliveryDetail.Margin = new System.Windows.Forms.Padding(5);
            this.ucSaveDeliveryDetail.Name = "ucSaveDeliveryDetail";
            this.ucSaveDeliveryDetail.SaveButtonEnabled = false;
            this.ucSaveDeliveryDetail.Size = new System.Drawing.Size(105, 54);
            this.ucSaveDeliveryDetail.TabIndex = 38;
            // 
            // CostNumericControl
            // 
            this.CostNumericControl.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.supplierDeliveryViewModelBindingSource, "Cost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0"));
            this.CostNumericControl.Enabled = false;
            this.CostNumericControl.Location = new System.Drawing.Point(164, 22);
            this.CostNumericControl.Margin = new System.Windows.Forms.Padding(5);
            this.CostNumericControl.Name = "CostNumericControl";
            this.CostNumericControl.Numeric = 0D;
            this.CostNumericControl.Size = new System.Drawing.Size(141, 27);
            this.CostNumericControl.TabIndex = 15;
            this.CostNumericControl.Visible = false;
            // 
            // SupplierAutoComplete
            // 
            this.SupplierAutoComplete.AutoCompleteValue = "";
            this.SupplierAutoComplete.DataBindings.Add(new System.Windows.Forms.Binding("AutoCompleteValue", this.supplierDeliveryViewModelBindingSource, "Supplier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SupplierAutoComplete.Location = new System.Drawing.Point(164, 16);
            this.SupplierAutoComplete.Margin = new System.Windows.Forms.Padding(5);
            this.SupplierAutoComplete.Name = "SupplierAutoComplete";
            this.SupplierAutoComplete.Size = new System.Drawing.Size(269, 26);
            this.SupplierAutoComplete.TabIndex = 9;
            this.SupplierAutoComplete.Leave += new System.EventHandler(this.SupplierAutoComplete_Leave);
            // 
            // SupplierDeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 746);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupplierDeliveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Delivery";
            this.Load += new System.EventHandler(this.DeliveryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ProductGroupBox.ResumeLayout(false);
            this.ProductGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDeliveryViewModelBindingSource)).EndInit();
            this.gbDamageDetail.ResumeLayout(false);
            this.gbDamageDetail.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.SupplierGroupBox.ResumeLayout(false);
            this.SupplierGroupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDeliveryDetails)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox ProductGroupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker DeliveryDateDtp;
        private System.Windows.Forms.Label DeliveryDateLabel;
        private System.Windows.Forms.TextBox OrTextbox;
        private System.Windows.Forms.Label label1;
        private UserControls.ucAutoComplete SupplierAutoComplete;
        private System.Windows.Forms.Label supplierLabel;
        private UserControls.NumericControl CostNumericControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.GroupBox SupplierGroupBox;
        private UserControls.ucSaveEditForm ucSaveDeliveryDetail;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox QuantityTextbox;
        private System.Windows.Forms.DataGridView gvDeliveryDetails;
        private System.Windows.Forms.GroupBox gbDamageDetail;
        private System.Windows.Forms.TextBox StatusDescriptionTextbox;
        private System.Windows.Forms.ComboBox cboDamageStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editDeliveriesToolStripMenuItem;
        private System.Windows.Forms.Label lblStockNumber;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private UserControls.UserControlSelectProduct userControlSelectProduct1;
        private System.Windows.Forms.BindingSource supplierDeliveryViewModelBindingSource;
    }
}