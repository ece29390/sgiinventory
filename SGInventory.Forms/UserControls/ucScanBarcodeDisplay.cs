using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Model;

namespace SGInventory.UserControls
{
    public partial class ucScanBarcodeDisplay : UserControl,IScanDisplayView
    {
        public Func<string, ProductDetails> LoadProductDetail;
        public ucScanBarcodeDisplay()
        {
            InitializeComponent();
        }

        public string GetColorCode()
        {
            return lblColor.Text;
        }

        public string GetWashingCode()
        {
            return lblWashing.Text;
        }

        public string GetSizeCode()
        {
            return lblSize.Text;
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBarcode.Text))
                {
                    if (LoadProductDetail == null)
                    {
                        throw new NotImplementedException("LoadProduct Delegate Function is not yet set");
                    }

                    var productDetail = LoadProductDetail(txtBarcode.Text.Trim());

                    lblColor.Text = productDetail.Color.Name;
                    lblSize.Text = productDetail.Size.Name;
                    lblWashing.Text = productDetail.Washing.Name;
                }
            }
        }        
    }
}
