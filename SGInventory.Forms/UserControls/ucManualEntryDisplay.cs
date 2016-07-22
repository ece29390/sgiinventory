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
    public partial class ucManualEntryDisplay : UserControl,IScanBarcodeDisplay
    {
        public event EventHandler OnCheckProductCodeOrScanner;
        public event EventHandler OnChkBoxUseScanner;
        public event EventHandler<KeyPressEventArgs> OnStockNumberComboBoxKeyPress;
        public event EventHandler OnStockNumberComboBoxSelectedIndex;
        public event EventHandler OnColorAutoCompleteLeave;
        public event EventHandler OnWashingAutoCompleteLeave;
        public event EventHandler OnSizeAutoCompleteLeave;

        public ucAutoComplete WashingAutoCompleteControl
        {
            get { return WashingAutoComplete; }           
        }

        public ucAutoComplete ColorAutoCompleteControl
        {
            get { return ColorAutoComplete; }
        }

        public ucAutoComplete SizeAutoCompleteControl
        {
            get { return SizeAutoComplete; }
        }

        public ComboBox StockNumberComboBoxControl
        {
            get { return StockNumberComboBox; }
        }

        public CheckBox ChkBarcodeOrStockNumberControl
        {
            get { return chkBarcodeOrStockNumber; }
        }

        public ucManualEntryDisplay()
        {
            InitializeComponent();
        }

        public void InitializeControls(bool useScanner)
        {
            chkBarcodeOrStockNumber.Checked = useScanner;
            chkBarcodeOrStockNumber.Enabled = false;

            DisabledProductDetail(useScanner);
        }

        public void LoadProducts(List<Model.Product> list)
        {
            StockNumberComboBox.DataSource = list;
            StockNumberComboBox.DisplayMember = "StockNumber";
            StockNumberComboBox.ValueMember = "StockNumber";
        }

        public string GetStockNumber()
        {
            return StockNumberComboBox.Text.Trim();
        }

        public Model.Product GetSelectedProduct()
        {
            var product = (SGInventory.Model.Product)StockNumberComboBox.SelectedItem;
            return product;
        }

        public void LoadColors(List<Model.Color> list)
        {
           ColorAutoComplete.LoadAutoCompleteNameCodeSource<Model.Color>(list);
        }

        public void LoadWashings(List<Model.Washing> list)
        {
            WashingAutoComplete.LoadAutoCompleteNameCodeSource<Model.Washing>(list);
        }

        public void LoadSizes(List<Model.Size> list)
        {
            SizeAutoComplete.LoadAutoCompleteNameCodeSource<Model.Size>(list);
        }

        public string GetColorCode()
        {
            return ColorAutoComplete.AutoCompleteCode;
        }

        public string GetWashingCode()
        {
            return WashingAutoComplete.AutoCompleteCode;
        }

        public string GetSizeCode()
        {
            return SizeAutoComplete.AutoCompleteCode;
        }

        public bool GetSelectByProductCode()
        {
            return chkBarcodeOrStockNumber.Checked;
        }

        public void DisabledProductDetail(bool disable)
        {
            ColorAutoComplete.Enabled = !disable;
            WashingAutoComplete.Enabled = !disable;
            SizeAutoComplete.Enabled = !disable;
        }

        public void ClearInputText()
        {
            StockNumberComboBox.Text = "";
            StockNumberComboBox.Focus();
        }

        public void RenameStockOrCodeLabel(string label)
        {
            lblStockOrBarcode.Text = label;
        }

        public void LoadProducts(List<Model.ProductDetails> list)
        {
            StockNumberComboBox.DataSource = list;
            StockNumberComboBox.DisplayMember = "Code";
            StockNumberComboBox.ValueMember = "Code";
        }

        public Model.ProductDetails GetSelectedProductDetails()
        {
            var productDetails = (ProductDetails)StockNumberComboBox.SelectedItem;
            return productDetails;
        }

        public void ClearProductDetailControls()
        {
            StockNumberComboBox.DataSource = null;
            SizeAutoComplete.AutoCompleteValue = string.Empty;
            ColorAutoComplete.AutoCompleteValue = string.Empty;
            WashingAutoComplete.AutoCompleteValue = string.Empty;
        }
        
        public void SetSelectByBarcodeTo(bool selectByBarcode)
        {
            chkBarcodeOrStockNumber.Checked = selectByBarcode;
        }

        public void LoadProductDetail(Model.ProductDetails productdetail)
        {
            if (chkBarcodeOrStockNumber.Checked)
            {
                StockNumberComboBox.SelectedValue = productdetail.Code;
            }
            else
            {
                StockNumberComboBox.SelectedValue = productdetail.Product;
                StockNumberComboBox.Text = productdetail.Product.StockNumber;
                ColorAutoComplete.AutoCompleteValue = productdetail.Color.Name;
                SizeAutoComplete.AutoCompleteValue = productdetail.Size.Name;
                WashingAutoComplete.AutoCompleteValue = productdetail.Washing.Name;
                
            }
        }
        
        private void chkBarcodeOrStockNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (OnCheckProductCodeOrScanner != null)
            {
                OnCheckProductCodeOrScanner(sender, e);
            }

            DisabledProductDetail(chkBarcodeOrStockNumber.Checked);           
        }

        private void chkBoxUseScanner_CheckedChanged(object sender, EventArgs e)
        {
            if (OnChkBoxUseScanner != null)
            {
                OnChkBoxUseScanner(sender, e);
            }

            
        }

        private void StockNumberComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OnStockNumberComboBoxKeyPress != null)
            {
                OnStockNumberComboBoxKeyPress(sender, e);
            }
        }

        private void StockNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnStockNumberComboBoxSelectedIndex != null)
            {
                OnStockNumberComboBoxSelectedIndex(sender, e);
            }
        }

        private void ColorAutoComplete_Leave(object sender, EventArgs e)
        {
            if (OnColorAutoCompleteLeave != null)
            {
                OnColorAutoCompleteLeave(sender, e);
            }
        }

        private void WashingAutoComplete_Leave(object sender, EventArgs e)
        {
            if (OnWashingAutoCompleteLeave != null)
            {
                OnWashingAutoCompleteLeave(sender, e);
            }
        }

        private void SizeAutoComplete_Leave(object sender, EventArgs e)
        {
            if (OnSizeAutoCompleteLeave != null)
            {
                OnSizeAutoCompleteLeave(sender, e);
            }
        }

        internal void FocusOnInputText()
        {
            StockNumberComboBox.Focus();
        }
    }
}
