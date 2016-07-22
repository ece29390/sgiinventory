﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.CustomEventArgs;
using SGInventory.Model;
using SGInventory.Presenters.Model;

namespace SGInventory.UserControls
{
    public partial class UserControlSelectProduct : UserControl
    {
        public event EventHandler<ScanCodeArgs> OnEnter, OnManuallySelected;
       
        private const int BarcodeLength = 12;
        public ProductDetailLookupModel SelectedProductDetails { get; private set; }
        public UserControlSelectProduct()
        {
            InitializeComponent();
        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (OnEnter != null)
                {
                    var isBarcode = textBoxCode.Text.Trim().Length == BarcodeLength;
                    var code = isBarcode ? textBoxCode.Text.Trim().Substring(2) : textBoxCode.Text.Trim();
                    var args = new ScanCodeArgs(isBarcode, code);
                    OnEnter(sender, args);
                    textBoxCode.Clear();
                    if (isBarcode)
                    {
                        textBoxCode.Focus();
                    }
                    else
                    {
                        listBoxProductDetails.Focus();
                    }
                    
                }
            }
        }

        private void listBoxProductDetails_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxProductDetails.SelectedIndex < 0)
            {
                return;
            }
            SelectedProductDetails =
                (ProductDetailLookupModel) listBoxProductDetails.Items[listBoxProductDetails.SelectedIndex];
            
        }

        internal void LoadResult(List<Model.ProductDetails> result)
        {
            
            var productDetailLookupModels = new List<ProductDetailLookupModel>();
            result.ForEach(prodDetail => productDetailLookupModels.Add(new ProductDetailLookupModel
                {ProductCode = prodDetail.Code
                ,Description = prodDetail.Code//string.Format("{0}(Color:{1} Washing:{2} Size:{3})",prodDetail.Product.StockNumber,prodDetail.Color.Name,prodDetail.Washing.Name,prodDetail.Size.Name)
                ,Cost = ((prodDetail.OverrideCost.HasValue)&&(prodDetail.OverrideCost.Value!=prodDetail.Product.Cost))?prodDetail.OverrideCost.Value:prodDetail.Product.Cost
                }));
            listBoxProductDetails.DataSource = productDetailLookupModels;          
            listBoxProductDetails.Focus();           
        }

        private void listBoxProductDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && OnManuallySelected != null)
            {
                var args = new ScanCodeArgs(false,SelectedProductDetails.ProductCode);
                OnManuallySelected(sender, args);
                textBoxCode.Focus();
            }
        }        
    }
}
