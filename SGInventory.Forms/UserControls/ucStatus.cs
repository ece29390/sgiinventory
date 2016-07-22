using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Enums;
using SGInventory.Model;

namespace SGInventory.UserControls
{
    public partial class ucStatus : UserControl
    {
        public ucStatus()
        {
            InitializeComponent();
        }
      
        internal void LoadProductStatus(List<ProductStatus> listOfProductStatus)
        {
            StatusComboBox.DataSource = listOfProductStatus;
        }

        internal void LoadDamageList(List<Damage> listOfDamages)
        {
            cboDamageStatus.DataSource = listOfDamages;
        }

        internal void LoadDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            StatusComboBox.SelectedItem = Enum.ToObject(typeof(ProductStatus), deliveryDetail.Status);

            gbDamageDetail.Enabled = deliveryDetail.Damage.HasValue;
            if (deliveryDetail.Damage.HasValue)
            {
                
                cboDamageStatus.SelectedItem = Enum.ToObject(typeof(Damage), deliveryDetail.Damage.Value);
                StatusDescriptionTextbox.Text = deliveryDetail.StatusDescription;
            }
        }

        private void cboDamageStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDamage = (Damage)cboDamageStatus.SelectedItem;
            StatusDescriptionTextbox.Enabled = selectedDamage==Damage.Others?true:false;
            
        }

        internal void SetToDeliveryDetail(DeliveryDetail selectedDeliveryDetail)
        {
            var status = (ProductStatus)StatusComboBox.SelectedItem;
            selectedDeliveryDetail.Status = (int)status;

            if (status == ProductStatus.Damaged)
            {
                selectedDeliveryDetail.Damage = (int)cboDamageStatus.SelectedItem;
                selectedDeliveryDetail.StatusDescription = StatusDescriptionTextbox.Text.Trim();
            }
            
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productStatus = (ProductStatus)StatusComboBox.SelectedItem;
            gbDamageDetail.Enabled = productStatus == ProductStatus.Damaged ? true : false;
        }

        internal SGInventory.Enums.ProductStatus ProductStatus
        {
            get
            {
                return (SGInventory.Enums.ProductStatus)StatusComboBox.SelectedItem;
            }
        }

        internal int? DamageStatus
        {
            get
            {
                if (ProductStatus == SGInventory.Enums.ProductStatus.Damaged)
                {
                    var damageStatus = (SGInventory.Enums.Damage)cboDamageStatus.SelectedItem;
                    return (int)damageStatus;
                }
                return null;
            }

        }

        internal string DamageDescription
        {
            get
            {
                return StatusDescriptionTextbox.Text;
            }
        }

       
    }
}
