using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Enums;

namespace SGInventory.Inventory
{
    public partial class AdjustmentDeliverySupplier : Form
    {
        public event EventHandler OnSave;
        public event EventHandler OnDelete;

        private string _productDetailCode;       
        private BusinessModelContainer _container;
        private DeliveryDetail _deliveryDetail;
     
        public AdjustmentDeliverySupplier(
            string productDetailCode            
            ,BusinessModelContainer container)
        {
            InitializeComponent();
            _productDetailCode = productDetailCode;            
            _container = container;
        }

        public AdjustmentDeliverySupplier AttachId(int id)
        {
            EntityId = id;
            return this;
        }
    
        private void AdjustmentProduct_Load(object sender, EventArgs e)
        {
            baseDeliveryUserControl1.ProductDetailCode = _productDetailCode;
            LoadDamageList();
            LoadStatusList();
            if (EntityId > 0)
            {
                _deliveryDetail = _container.DeliveryBusinessModel.GetPrimaryDeliveryDetail(EntityId);
                baseDeliveryUserControl1.LoadDelivery(_deliveryDetail);
                ucStatus1.LoadDeliveryDetail(_deliveryDetail);             
                btnDelete.Enabled = true;
            }                     
        }

        private void LoadDamageList()
        {
            var damageList = SgiHelper.ConvertEnumToList<Damage>(() => Enum.GetValues(typeof(Damage)),(enumItem) => (Damage)enumItem);
            ucStatus1.LoadDamageList(damageList);
        }

        private void LoadStatusList()
        {
            var statusList = SgiHelper.ConvertEnumToList<ProductStatus>(() => Enum.GetValues(typeof(ProductStatus)), (enumItem) => (ProductStatus)enumItem);
            ucStatus1.LoadProductStatus(statusList);
        }

        public int EntityId { get; private set; }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (baseDeliveryUserControl1.Quantity == 0)
            {
                MessageBox.Show("Quantity must be greater than 1");
                return;
            }

            if (_deliveryDetail == null)
            {
                var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                _deliveryDetail = new DeliveryDetail
                {
                                      
                    Price = productDetail.Product.RegularPrice
                    ,
                    ProductDetail = productDetail                                    
                };
            }

            _deliveryDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;
            _deliveryDetail.Damage = ucStatus1.DamageStatus;
            _deliveryDetail.Quantity = baseDeliveryUserControl1.Quantity;
            _deliveryDetail.Status = (int)ucStatus1.ProductStatus;
            _deliveryDetail.StatusDescription = ucStatus1.DamageDescription;

            var message = _container.DeliveryBusinessModel.SaveDeliveryDetail(_deliveryDetail);
            MessageBox.Show(message);

            if (OnSave != null)
            {
                OnSave(sender, e);
            }
            _deliveryDetail = null;
            EntityId = 0;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _container.DeliveryBusinessModel.DeleteDeliveryDetail(_deliveryDetail);
            if (OnDelete != null)
            {
                OnDelete(sender, e);
            }
            _deliveryDetail = null;
            EntityId = 0;
            Close();
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
                
    }
}
