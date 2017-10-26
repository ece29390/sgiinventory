using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Views.UIModel
{
    public class DeliveryToOutletViewModel
    {
        private string _outlet;
        private string _drNumber;
        private int _quantity;
        private string _productCode;
        
        public DeliveryToOutletViewModel()
        {
            DeliveryDate = DateTime.Now;
            SrpPrice = 0;
        }

        public string Outlet
        {
            get { return _outlet; }
            set
            {
                _outlet = value;
                SetProductDetailEnable();
            }
        }

        private void SetProductDetailEnable()
        {
            bool validOutlet = IsOutletNotEmpty();
            bool validDrNumber = IsDrNumberNotEmpty();
            ProductDetailEnable = validOutlet && validDrNumber;
        }

        private bool IsDrNumberNotEmpty()
        {
            return !string.IsNullOrEmpty(_drNumber);
        }

        private bool IsOutletNotEmpty()
        {
            return !string.IsNullOrEmpty(_outlet);
        }

        public string DrNumber
        {
            get { return _drNumber; }
            set
            {
                _drNumber = value;
                SetProductDetailEnable();
            }
        }

        public DateTime DeliveryDate { get; set; }
        public int SelectedStatusIndex { get; set; }
        public ProductStatus Status { get; set; }      
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                SetSelectProductEnable();
            }
        }

        private void SetSelectProductEnable()
        {
            SelectProductEnable = _quantity > 0;
        }

        public double SrpPrice { get; set; }

        public string SelectedStockNumber { get; set; }

        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                _productCode = value;
                SetAddProductEnable();
            }
        }

        private void SetAddProductEnable()
        {
            AddProductEnable = !string.IsNullOrEmpty(_productCode);
        }

        public bool ProductDetailEnable { get; set; }

        public bool SelectProductEnable { get; set; }

        public bool AddProductEnable { get; set; }

        public bool SaveProductEnable { get; set; }
    }
}
