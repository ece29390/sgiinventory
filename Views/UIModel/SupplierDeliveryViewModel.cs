using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Views.UIModel
{
    public class SupplierDeliveryViewModel
    {
        private string _supplier;
        private string _drNumber;
        private Damage? _damageStatus;
        private bool _enableProductGroup;
        private ProductStatus? _status;
        private string _productCode;


        public SupplierDeliveryViewModel()
        {
            DeliveryDate = DateTime.Now;
            Quantity = 1;
            Cost = 0;
        }

        public string Supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
               EnableProductGroupBox();
            }
        }

        public string DrNumber
        {
            get { return _drNumber; }
            set
            {
                _drNumber = value;
                EnableProductGroupBox();
            }            
        }
       
        public DateTime DeliveryDate { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
        public string SelectedStockNumber { get; set; }
        public ProductStatus? Status
        {
            get { return _status; }
            set
            {
                _status = value;
                EnableDisableDamageDetail();
            }
        }

        public Damage? DamageStatus
        {
            get { return _damageStatus; }
            set
            {
                _damageStatus = value;
                EnableDamageDetailDescription();                
            }
        }
        public string DamageDescription { get; set; }

        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                _productCode = value;
                AddButtonEnable = !string.IsNullOrEmpty(_productCode);
            }
        }
        public bool DamageDetailsEnable { get; set; }
        public bool DamageStatusDescriptionEnable { get; set; }
        public bool ProductDetailEnable { get; set; }
        public bool AddButtonEnable { get; set; }
        public bool SaveDeliveryEnable { get; set; }

        public bool EnableProductGroup
        {
            get { return _enableProductGroup; }
            set
            {
                _enableProductGroup = value;
                ProductDetailEnable = value;
            }
        }
        public bool RowHasBeenAdded { get; set; }

        private bool SupplierAndDrNumberAreNotEmpty()
        {
            var shouldEnable = !string.IsNullOrEmpty(Supplier) && !string.IsNullOrEmpty(DrNumber);
            return shouldEnable;
        }
        private void EnableProductGroupBox()
        {
            var shouldEnable = SupplierAndDrNumberAreNotEmpty();
            EnableProductGroup = shouldEnable;
        }

        private void EnableDisableDamageDetail()
        {
            var shouldEnable = (Status.HasValue && Status == ProductStatus.Damaged);
            DamageDetailsEnable = shouldEnable;
        }

        private void EnableDamageDetailDescription()
        {
            bool shouldEnable = DamageStatus.HasValue && DamageStatus.Value == Damage.Others;
            DamageStatusDescriptionEnable = shouldEnable;
        }

        private void EnableProductDetail()
        {
            var supplierAndDrNumberIsOk = SupplierAndDrNumberAreNotEmpty();
            var secondaryDetailIsOk = Quantity > 0;
          
            if (Status.HasValue && Status.Value == ProductStatus.Damaged)
            {
                if (DamageStatus.HasValue && DamageStatus.Value == Damage.Others)
                {
                    secondaryDetailIsOk = !string.IsNullOrEmpty(DamageDescription) && secondaryDetailIsOk;
                }                
            }

            ProductDetailEnable = supplierAndDrNumberIsOk && secondaryDetailIsOk;
        }

        private void EnableOrDisableFlags()
        {
            EnableProductGroupBox();
            EnableProductDetail();
        }       
    }
}
