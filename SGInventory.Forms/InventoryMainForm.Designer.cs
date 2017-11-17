namespace SGInventory.Forms
{
    partial class InventoryMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDeliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDeliveriesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pulloutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.washingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.damageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.userProfileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1043, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // transactionToolStripMenuItem
            // 
            this.transactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveryToolStripMenuItem,
            this.releasingToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.pulloutToolStripMenuItem,
            this.inventoryToolStripMenuItem});
            this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            this.transactionToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.transactionToolStripMenuItem.Text = "Transaction";
            this.transactionToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.transactionToolStripMenuItem_DropDownItemClicked);
            // 
            // deliveryToolStripMenuItem
            // 
            this.deliveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewToolStripMenuItem,
            this.viewDeliveriesToolStripMenuItem});
            this.deliveryToolStripMenuItem.Name = "deliveryToolStripMenuItem";
            this.deliveryToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.deliveryToolStripMenuItem.Text = "Supplier Delivery";
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.createNewToolStripMenuItem.Tag = "NewDelivery";
            this.createNewToolStripMenuItem.Text = "Create New Delivery";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.DeliveryToWarehouse_Click);
            // 
            // viewDeliveriesToolStripMenuItem
            // 
            this.viewDeliveriesToolStripMenuItem.Name = "viewDeliveriesToolStripMenuItem";
            this.viewDeliveriesToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.viewDeliveriesToolStripMenuItem.Tag = "ViewDeliveries";
            this.viewDeliveriesToolStripMenuItem.Text = "View Deliveries";
            this.viewDeliveriesToolStripMenuItem.Click += new System.EventHandler(this.stripMenuItem_Click);
            // 
            // releasingToolStripMenuItem
            // 
            this.releasingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewDeliveryToolStripMenuItem,
            this.viewDeliveriesToolStripMenuItem1});
            this.releasingToolStripMenuItem.Name = "releasingToolStripMenuItem";
            this.releasingToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.releasingToolStripMenuItem.Text = "Outlet Delivery";
            // 
            // createNewDeliveryToolStripMenuItem
            // 
            this.createNewDeliveryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goodToolStripMenuItem,
            this.damageToolStripMenuItem});
            this.createNewDeliveryToolStripMenuItem.Name = "createNewDeliveryToolStripMenuItem";
            this.createNewDeliveryToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.createNewDeliveryToolStripMenuItem.Tag = "NewDelivery";
            this.createNewDeliveryToolStripMenuItem.Text = "Create New Delivery";
            this.createNewDeliveryToolStripMenuItem.Click += new System.EventHandler(this.releasingToolStripMenuItem_Click);
            // 
            // viewDeliveriesToolStripMenuItem1
            // 
            this.viewDeliveriesToolStripMenuItem1.Name = "viewDeliveriesToolStripMenuItem1";
            this.viewDeliveriesToolStripMenuItem1.Size = new System.Drawing.Size(219, 26);
            this.viewDeliveriesToolStripMenuItem1.Tag = "ViewDeliveries";
            this.viewDeliveriesToolStripMenuItem1.Text = "View Deliveries";
            this.viewDeliveriesToolStripMenuItem1.Click += new System.EventHandler(this.viewDeliveriesToolStripMenuItem1_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.editToolStripMenuItem.Tag = "NewSales";
            this.editToolStripMenuItem.Text = "Create New Sales";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.CreateNewSales_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.searchToolStripMenuItem.Tag = "SalesSearch";
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // pulloutToolStripMenuItem
            // 
            this.pulloutToolStripMenuItem.Name = "pulloutToolStripMenuItem";
            this.pulloutToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.pulloutToolStripMenuItem.Text = "Pullout";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryToolStripMenuItem,
            this.outletToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.userToolStripMenuItem,
            this.washingToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.colorToolStripMenuItem1,
            this.productToolStripMenuItem,
            this.storeToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.adminToolStripMenuItem_DropDownItemClicked);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.categoryToolStripMenuItem.Text = "Category";
            // 
            // outletToolStripMenuItem
            // 
            this.outletToolStripMenuItem.Name = "outletToolStripMenuItem";
            this.outletToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.outletToolStripMenuItem.Text = "Outlet";
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.supplierToolStripMenuItem.Text = "Supplier";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.userToolStripMenuItem.Text = "User";
            // 
            // washingToolStripMenuItem
            // 
            this.washingToolStripMenuItem.Name = "washingToolStripMenuItem";
            this.washingToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.washingToolStripMenuItem.Text = "Washing";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // colorToolStripMenuItem1
            // 
            this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
            this.colorToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.colorToolStripMenuItem1.Text = "Color";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.storeToolStripMenuItem.Text = "Store";
            this.storeToolStripMenuItem.Visible = false;
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logToolStripMenuItem});
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.userProfileToolStripMenuItem.Text = "User Profile";
            this.userProfileToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.userProfileToolStripMenuItem_DropDownItemClicked);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.logToolStripMenuItem.Text = "LogOut";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Enabled = false;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Visible = false;
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // goodToolStripMenuItem
            // 
            this.goodToolStripMenuItem.Name = "goodToolStripMenuItem";
            this.goodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.goodToolStripMenuItem.Text = "Good";
            this.goodToolStripMenuItem.Click += new System.EventHandler(this.goodToolStripMenuItem_Click);
            // 
            // damageToolStripMenuItem
            // 
            this.damageToolStripMenuItem.Name = "damageToolStripMenuItem";
            this.damageToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.damageToolStripMenuItem.Text = "Damage";
            this.damageToolStripMenuItem.Click += new System.EventHandler(this.damageToolStripMenuItem_Click);
            // 
            // InventoryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 489);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InventoryMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem transactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem washingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pulloutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDeliveriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewDeliveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDeliveriesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem damageToolStripMenuItem;
    }
}

