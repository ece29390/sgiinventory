using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;

namespace SGInventory.UserControls
{
    public partial class BaseDeliveryUserControl : UserControl
    {
        public BaseDeliveryUserControl()
        {
            InitializeComponent();
        }

        public void LoadDelivery(IDelivery delivery)
        {
            var quantity = Math.Abs(delivery.Quantity);
            txtQuantity.Text = quantity.ToString();
            dtpDeliveryDate.Value = delivery.AdjustmentDate.Value;
        }
        
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public int Quantity
        {
            get
            {
                var retValue = 0;
                int.TryParse(txtQuantity.Text.Trim(), out retValue);
                return retValue;
            }
            set
            {
                txtQuantity.Text = value.ToString();
            }
        }
        public DateTime AdjustmentDate
        {
            get
            {
                return dtpDeliveryDate.Value;
            }
        }

        public string ProductDetailCode
        {
            get
            {
                return lblProductCode.Text;
            }
            set
            {
                lblProductCode.Text = value;
            }
        }
    }
}
