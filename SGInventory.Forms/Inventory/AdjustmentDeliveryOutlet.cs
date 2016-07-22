using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;
using SGInventory.Enums;
using SGInventory.Model;

namespace SGInventory.Inventory
{
    public partial class AdjustmentDeliveryOutlet : Form
    {
        public event EventHandler OnSave;
        public event EventHandler OnDelete;

        private string _productDetailCode;
        private BusinessModelContainer _container;
        private DeliveryToOutletDetail _deliveryToOutletDetail;

        public AdjustmentDeliveryOutlet(string productDetailCode
            , BusinessModelContainer container)
        {
            InitializeComponent();
            _productDetailCode = productDetailCode;
            _container = container;
        }

        public AdjustmentDeliveryOutlet AttachId(int id)
        {
            EntityId = id;
            return this;
        }

        private void LoadStatusList()
        {
            var statusList = SgiHelper.ConvertEnumToList<ProductStatus>(() => Enum.GetValues(typeof(ProductStatus)), (enumItem) => (ProductStatus)enumItem);
            cboStatus.DataSource = statusList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (baseDeliveryUserControl1.Quantity == 0)
            {
                MessageBox.Show("Quantity must be greater than 1");
                return;
            }
            var productStatus = (ProductStatus)Enum.ToObject(typeof(ProductStatus),cboStatus.SelectedValue);
            var availableQuantity = 
                _container.DeliveryBusinessModelHelper.IsQuantityAvailable(
                                _productDetailCode
                                ,baseDeliveryUserControl1.Quantity
                                ,productStatus);

            if(!availableQuantity)
            {
                MessageBox.Show("The quantity is more than the quantity on hand");
                return;
            }


            if (_deliveryToOutletDetail == null)
            {
                var productDetail = _container.ProductDetailBusinessModel.SelectByPrimaryId(_productDetailCode);

                _deliveryToOutletDetail = new DeliveryToOutletDetail
                {
                    SuggestedRetailPrice = productDetail.Product.RegularPrice                   
                    ,
                    ProductDetail = productDetail
                };
            }

            _deliveryToOutletDetail.AdjustmentDate = baseDeliveryUserControl1.AdjustmentDate;

            _deliveryToOutletDetail.Quantity = baseDeliveryUserControl1.Quantity;
            _deliveryToOutletDetail.Status = (int)cboStatus.SelectedValue;

            var message = _container.DeliveryToOutletBusinessModel.SaveAdjustment(_deliveryToOutletDetail);
            MessageBox.Show(message);

            if (OnSave != null)
            {
                OnSave(sender, e);
            }
            _deliveryToOutletDetail = null;
            EntityId = 0;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _container.DeliveryToOutletBusinessModel.DeleteDeliveryToOutletDetail(_deliveryToOutletDetail);
            if (OnDelete != null)
            {
                OnDelete(sender, e);
            }
            _deliveryToOutletDetail = null;
            EntityId = 0;
            Close();
        }

        private void AdjustmentDeliveryOutlet_Load(object sender, EventArgs e)
        {
            baseDeliveryUserControl1.ProductDetailCode = _productDetailCode;
           
            LoadStatusList();

            if (EntityId > 0)
            {
                _deliveryToOutletDetail = _container.DeliveryToOutletBusinessModel.GetDeliveryToOutletDetailBy(EntityId);
                baseDeliveryUserControl1.LoadDelivery(_deliveryToOutletDetail);              
                btnDelete.Enabled = true;
            }     
        }

        public int EntityId { get;private set; }
    }
}
