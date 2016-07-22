using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Views;
using SGInventory.Business.Model;
using SGInventory.Model;
using System.Windows.Forms;
using SGInventory.Enums;
using SGInventory.Helpers;
using SGInventory.Extensions;

namespace SGInventory.Presenters
{
    public class SupplierDeliveryEditPresenter
    {
        private ISupplierDeliveryEditView _view;
        private IDeliveryBusinessModel _deliveryBusinessModel;
        private IList<DeliveryDetail> _deliveryDetails;
        private List<ProductStatus> _listOfProductStatus;
        private List<Damage> _listOfDamages;
        public DeliveryDetail SelectedDeliveryDetail { get; private set; }
        public DeliveryDetail PreviousSelectedDeliveryDetail { get; private set; }
        
        public SupplierDeliveryEditPresenter(ISupplierDeliveryEditView view, IDeliveryBusinessModel deliveryBusinessModel)
        {            
            _view = view;
            _deliveryDetails = new List<DeliveryDetail>();
            this._deliveryBusinessModel = deliveryBusinessModel;
        }
        
        public SupplierDeliveryEditPresenter LoadDeliveryDistinctDetails(IList<DeliveryDetail> deliveryDetails)
        {
            var goodDeliveries = (from deliveryDetail in deliveryDetails
                                  where deliveryDetail.Status == (int)ProductStatus.Goods
                                  && deliveryDetail.IsActive == 1
                                  group deliveryDetail by new
                                  {
                                      Barcode = deliveryDetail.ProductDetail.Code,
                                      //Quantity = deliveryDetail.Quantity,
                                      Id = deliveryDetail.Id,
                                      Remarks = deliveryDetail.Remarks,
                                      Price = deliveryDetail.Price,
                                      Delivery = deliveryDetail.Delivery,
                                      StockNumber = deliveryDetail.ProductDetail.Product.StockNumber

                                  } into ddGroup
                                  select new DeliveryDetail
                                  {
                                      ProductDetail = new ProductDetails { Code = ddGroup.Key.Barcode, Product = new Product {  StockNumber= ddGroup.Key.StockNumber} },
                                      Id = ddGroup.Key.Id,
                                      Price = ddGroup.Key.Price,
                                      Quantity = ddGroup.Sum(d=>d.Quantity),
                                      Remarks = ddGroup.Key.Remarks,
                                      Status = (int)ProductStatus.Goods,
                                      Delivery = ddGroup.Key.Delivery
                                  }).ToList();

            var badDeliveries = (from deliveryDetail in deliveryDetails
                                  where deliveryDetail.Status == (int)ProductStatus.Damaged
                                   && deliveryDetail.IsActive == 1
                                  group deliveryDetail by new
                                  {
                                      Barcode = deliveryDetail.ProductDetail.Code,
                                      //Quantity = deliveryDetail.Quantity,
                                      Id = deliveryDetail.Id,
                                      Remarks = deliveryDetail.Remarks,
                                      Price = deliveryDetail.Price,
                                      Damage = deliveryDetail.Damage.Value,
                                      Delivery = deliveryDetail.Delivery,
                                      StockNumber = deliveryDetail.ProductDetail.Product.StockNumber

                                  } into ddGroup
                                  select new DeliveryDetail
                                  {
                                      ProductDetail = new ProductDetails { Code = ddGroup.Key.Barcode, Product = new Product { StockNumber = ddGroup.Key.StockNumber } },
                                      Id = ddGroup.Key.Id,
                                      Price = ddGroup.Key.Price,
                                      Quantity = ddGroup.Sum(d=>d.Quantity),
                                      Remarks = ddGroup.Key.Remarks,
                                      Status = (int)ProductStatus.Damaged,
                                      Damage = ddGroup.Key.Damage,
                                      Delivery = ddGroup.Key.Delivery
                                  }).ToList();

            var tempDeliveryDetails = new List<DeliveryDetail>();
            tempDeliveryDetails.AddRange(goodDeliveries);
            tempDeliveryDetails.AddRange(badDeliveries);

            _deliveryDetails = tempDeliveryDetails;
            
            return this;
        }

        

        public SupplierDeliveryEditPresenter LoadStatus()
        {
            _listOfProductStatus = SgiHelper.ConvertEnumToList<ProductStatus>(
                                            () => Enum.GetValues(typeof(ProductStatus)),
                                            (enumItem) => (ProductStatus)enumItem);
            _view.DisplayProductStausList(_listOfProductStatus);
            return this;
        }

        public SupplierDeliveryEditPresenter LoadDamageList()
        {
            _listOfDamages = SgiHelper.ConvertEnumToList<Damage>(
                                            () => Enum.GetValues(typeof(Damage)),
                                            (enumItem) => (Damage)enumItem);
            _view.DisplayDamageList(_listOfDamages);
            return this;
        }

        public void ToDataGridView(DataGridView dgvProductDetails)
        {
            dgvProductDetails.DataSource = null;
            dgvProductDetails.DataSource = _deliveryDetails;
        }

        public void ToDataGridView(DataGridView dgvProductDetails,IList<DeliveryDetail> deliveryDetails)
        {
            dgvProductDetails.DataSource = null;
            dgvProductDetails.DataSource = deliveryDetails;
        }
        
        public void LoadDeliveryDetailBy(DeliveryDetail deliveryDetail)
        {            
            SelectedDeliveryDetail = deliveryDetail;
            PreviousSelectedDeliveryDetail = new DeliveryDetail
            {
                Damage = SelectedDeliveryDetail.Damage,
                Delivery= SelectedDeliveryDetail.Delivery,
                Id = SelectedDeliveryDetail.Id,
                IsActive = SelectedDeliveryDetail.IsActive,
                Price = SelectedDeliveryDetail.Price,
                ProductDetail = SelectedDeliveryDetail.ProductDetail,
                Quantity = SelectedDeliveryDetail.Quantity,
                Remarks = SelectedDeliveryDetail.Remarks,
                Status = SelectedDeliveryDetail.Status,
                StatusDescription = SelectedDeliveryDetail.StatusDescription
            };
            _view.DisplayDeliveryDetail(deliveryDetail);
            //_view.EnableDelete(deliveryDetail.Id>0?true:false);
        }

        

        public void CancelEdit()
        {
            _view.RefreshControls();
        }

        public string SaveUpdate()
        {
            var retValue = "";
            
            var quantity = _view.GetQuantity();
          
            var remarks =  _view.GetRemarks();

            
            SelectedDeliveryDetail.Quantity = quantity;
            SelectedDeliveryDetail.Remarks = remarks;

            _view.SetStatusToDeliveryDetail(SelectedDeliveryDetail);

            if (SelectedDeliveryDetail.Delivery.Id > 0)
            {
                retValue = _deliveryBusinessModel.SaveDeliveryDetail(SelectedDeliveryDetail);
            }
                       
            _view.RefreshControls();

            return retValue;
        }

        public SupplierDeliveryEditPresenter DeActivateDeliveryDetail()
        {
            
            var delivery = _deliveryBusinessModel.DeactivateDelivertyDetailReturnAllActive(SelectedDeliveryDetail);

            LoadDeliveryDistinctDetails(delivery.DeliveryDetails);

            _view.RefreshControls();

            return this;
        }

        public bool CheckIfStatusAndProductDetailCodeAlreadyExists(DataGridView dgvProductDetails)
        {
            var isValid = true;
            
            for(var i=0;i<dgvProductDetails.Rows.Count;i++)
            {
                var deliveryDetail = (DeliveryDetail)dgvProductDetails.Rows[i].DataBoundItem;

                if (deliveryDetail.Damage.HasValue &&
                    _view.GetProductStatus() == ProductStatus.Damaged)
                {
                    if (deliveryDetail.ProductDetail.Code == SelectedDeliveryDetail.ProductDetail.Code
                    && deliveryDetail.Damage.Value == _view.GetDamageStatus().Value
                        && deliveryDetail.GetHashCode() != SelectedDeliveryDetail.GetHashCode()
                        )
                    {
                        isValid = false;
                        break;
                    }

                }
                else
                {
                    if (deliveryDetail.ProductDetail.Code == SelectedDeliveryDetail.ProductDetail.Code
                        && deliveryDetail.Status == (int)_view.GetProductStatus()
                            && deliveryDetail.GetHashCode() != SelectedDeliveryDetail.GetHashCode()
                            )
                    {
                        isValid = false;
                        break;
                    }
                        
                }
            }
                                    
            return isValid;
        }
    }
}
