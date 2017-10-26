using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.Delivery
{
    public partial class EnterQuantityForm : Form
    {
        public int Quantity
        {
            get
            {
                int quantity = 0;
                int.TryParse(QuantityTextbox.Text.Trim(), out quantity);
                return quantity;
            }
        }
        public EnterQuantityForm(string productDescription)
        {
            InitializeComponent();
            ProductDescriptionLabel.Text = productDescription;
        }

        private void QuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }

            if(e.KeyChar=='\r' && Quantity>0)
            {
                this.Close();
            }
         
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void QuantityTextbox_TextChanged(object sender, EventArgs e)
        {
            AcceptButton.Enabled = Quantity > 0;
        }
    }
}
