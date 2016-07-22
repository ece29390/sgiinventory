using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.UserControls
{
    public partial class ucBarcodePriceQuantity : UserControl
    {
        public ucBarcodePriceQuantity()
        {
            InitializeComponent();
        }

        public void SetInputs(string barcode, int quantity, double price)
        {
            lblBarcodeNumber.Text = barcode;
            txtBoxQuantity.Text = quantity.ToString();
            ncPrice.Numeric = price;
        }
    }
}
