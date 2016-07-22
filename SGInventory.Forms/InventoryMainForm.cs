using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.CategoryForm;
using SGInventory.OutletForm;
using SGInventory.SupplierForm;
using SGInventory.User;
using System.Threading;
using SGInventory.Enums;
using System.Reflection;
using SGInventory.Presenters;
using SGInventory.WashingForm;
using SGInventory.ProductForm;
using SGInventory.SizeForm;
using SGInventory.ColorForm;
using SGInventory.Model;
using SGInventory.Dal;
using SGInventory.Business.Model;
using SGInventory.Delivery;
using SGInventory.Inventory;
using SGInventory.Sales;


namespace SGInventory.Forms
{
    public partial class InventoryMainForm : Form
    {
        private readonly BusinessModelContainer _container;
        private readonly LogIn _logIn;
        private readonly string _initialCaption;
        public InventoryMainForm(BusinessModelContainer container)
        {
            InitializeComponent();
            
            _container = container;
            _logIn = new LogIn(_container);
            _logIn.SuccessfullLogin += new EventHandler<LogInEventArgs>(_logIn_SuccessfullLogin);
            _initialCaption = this.Text;
            

        }

        void _logIn_SuccessfullLogin(object sender, LogInEventArgs e)
        {
          
            this.Text = string.Concat(this.Text, " - ", "Welcome, ", e.User.Name);
            if (e.User.Roletype != (int)RoleType.Administrator)
            {
                adminToolStripMenuItem.Enabled = false;
                inventoryToolStripMenuItem.Enabled = false;
                viewDeliveriesToolStripMenuItem.Enabled = false;
                viewDeliveriesToolStripMenuItem1.Enabled = false;
                
            }
            else
            {
                adminToolStripMenuItem.Enabled = true;
                inventoryToolStripMenuItem.Enabled = true;
                viewDeliveriesToolStripMenuItem.Enabled = true;
                viewDeliveriesToolStripMenuItem1.Enabled = true;
            }
          
            
        }

        private void adminToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form form = null;
            switch (e.ClickedItem.Text)
            {
                case "Category":
                    form = new CategorySearchForm(_container);
                    form.Show();
                    break;
                case "Outlet":
                     form = new OutletSearchForm(_container);
                    form.Show();
                    break;
                case "Supplier":
                      form = new SupplierSearchForm(_container);
                    form.Show();
                    break;
                case "User":
                    form = new UserSearchForm(_container);
                    form.Show();
                    break;
                case "Washing":
                    form = new WashingSearchForm(_container);
                    form.Show();
                    break;
                case "Size":
                    form =new SizeSearchForm(_container);
                    form.Show();
                    break;
                case "Color":
                    form = new ColorSearchForm(_container);
                    form.Show();
                    break;
                case "Product":
                    form = new ProductSearchForm(_container);
                    form.Show();
                    break;
                //case "Store":
                //    form = new StoreSearchForm(_container);
                //    form.Show();
                //    break;
            }
        }

        private void ValidatePrincipal()
        {
            var principal = Thread.CurrentPrincipal;
            var identity = principal.Identity;
            if (!identity.IsAuthenticated)
            {
                this.Close();
            }
           
        }
        private void InventoryMainForm_Load(object sender, EventArgs e)
        {
            _logIn.ShowDialog();
            ValidatePrincipal();
            aboutToolStripMenuItem.DropDownItems.Add(string.Format("Version:{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version));
            aboutToolStripMenuItem.DropDownItems.Add(string.Format("Product Name:{0}", Application.ProductName));
            
        }

      

        private void userProfileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Change Password":
                    var changePassword = new ChangePassword(_container);
                    changePassword.Show();
                    break;
                case "LogOut":
                    Thread.CurrentPrincipal = null;
                    this.Text = _initialCaption;
                    _logIn.ShowDialog();
                    ValidatePrincipal();
                    break;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void transactionToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void stripMenuItem_Click(object sender, EventArgs e)
        {           
            var searchDelivery = new DeliverySearchForm(_container);
            searchDelivery.Show();
        }

        private void releasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as System.Windows.Forms.ToolStripMenuItem;
            Form form;
            switch (menuItem.Tag.ToString())
            {               
                case "ViewDeliveries":
                    form = new DeliveryToOutletSearchForm(_container);
                    form.ShowDialog();
                    break;
            }
        }

        private void DeliveryToWarehouse_Click(object sender, EventArgs e)
        {
            MenuItemOnClick(sender, e, (tag) => {
                var useScanner = tag=="Scan"?true:false;
                Form form = new SupplierDeliveryForm(_container, 0, useScanner);
                return form;                
            });
        }



        private void DeliveryToOutlet_Click(object sender, EventArgs e)
        {
            MenuItemOnClick(sender, e, (tag) =>
            {
                var useScanner = false;
                var condition = ProductStatus.Goods;
                switch (tag)
                {
                    case "ScanGood":
                        useScanner = true;
                        break;
                    case "ScanDamage":
                        condition = ProductStatus.Damaged;
                        useScanner = true;
                        break;
                    case "ManualDamage":
                        condition = ProductStatus.Damaged;                                                     
                        break;
                }

                
                Form form = new DeliveryToOutletForm(_container, null, useScanner,condition);
                return form;
            });
        }

        private void MenuItemOnClick(object sender, EventArgs e, Func<string,Form> loadForm)
        {
            var menuItem = sender as System.Windows.Forms.ToolStripMenuItem;
            var form = loadForm(menuItem.Tag.ToString());
            form.Show();
        }

        private void viewDeliveriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new DeliveryToOutletSearchForm(_container);
            form.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductInventory(_container);
            form.ShowDialog();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SalesSearchForm(_container);
            form.ShowDialog();
        }

        private void CreateNewSales_Click(object sender, EventArgs e)
        {
            MenuItemOnClick(sender, e, ((tag) =>
            {
                var useScanner = false;

                switch (tag)
                {
                    case "Scan":
                        useScanner = true;
                        break;
                    case "Manual":
                        useScanner = false;
                        break;
                }

                var form = new SalesEditForm(_container, useScanner);
                return form;
            }));
        }             
    }
}
