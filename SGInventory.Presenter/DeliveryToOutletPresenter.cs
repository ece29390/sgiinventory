using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Helpers;
using SGInventory.Presenters.Model;
using System.Windows.Forms;
using SGInventory.Presenters.Utilities;
using SGInventory.Enums;
using SGInventory.Views.UIModel;

namespace SGInventory.Presenters
{
    public class DeliveryToOutletPresenter:DeliveryPresenterBase
    {
        private Business.Model.IDeliveryToOutletBusinessModel _iDeliveryToOutletBusinessModel;
        private Views.IDeliveryToOutletView _iDeliveryToOutletView;
        private Business.Model.IOutletBusinessModel _outletBusinessModel;
        private Business.Model.IProductDetailBusinessModel _productDetailBusinessModel;
        private IDeliveryBusinessModelHelper _deliveryBusinessModelHelper;
        private DeliveryToOutletViewModel _viewModel;
        public ProductStatus Status { get; private set; }

        public DeliveryToOutletPresenter(
            Business.Model.IDeliveryToOutletBusinessModel iDeliveryToOutletBusinessModel
            , Views.IDeliveryToOutletView iDeliveryToOutletView
            , IProductBusinessModel productBusinessModel            
            , Business.Model.IOutletBusinessModel outletBusinessModel
            , Business.Model.IProductDetailBusinessModel productDetailBusinessModel
            , IColorBusinessModel colorBusinessModel
            , ISizeBusinessModel sizeBusinessModel
            , IWashingBusinessModel washingBusinessModel
            ,IDeliveryBusinessModelHelper deliveryBusinessModelHelper 
            ,DeliveryToOutletViewModel viewModel
            ):base(productBusinessModel,productDetailBusinessModel,colorBusinessModel,sizeBusinessModel,washingBusinessModel, iDeliveryToOutletView,false)
        {            
            this._iDeliveryToOutletBusinessModel = iDeliveryToOutletBusinessModel;
            this._iDeliveryToOutletView = iDeliveryToOutletView;
            this._outletBusinessModel = outletBusinessModel;
            this._productDetailBusinessModel = productDetailBusinessModel;
            _deliveryBusinessModelHelper = deliveryBusinessModelHelper;
            _viewModel = viewModel;
        }

        public void SaveDeliveryToOutlet(Action doAfterSave)
        {
            var deliveryDate = _iDeliveryToOutletView.GetDeliveryDate();
            var outletId = _iDeliveryToOutletView.GetOutletId();
            var packingListNumber = _iDeliveryToOutletView.GetPackingNumber();

            _iDeliveryToOutletView.ParentDeliveryToOutlet.Outlet = new Outlet { Id = outletId };
            _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryDate = deliveryDate;
            _iDeliveryToOutletView.ParentDeliveryToOutlet.PackingListNumber = packingListNumber;
           
            foreach (var dod in _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails)
            {
                dod.Status = (int)Status;
            }

            if (_iDeliveryToOutletView.ParentDeliveryToOutlet.Id == 0)
            {
                _iDeliveryToOutletView.ParentDeliveryToOutlet.CreatedDate = DateTime.Now;
                _iDeliveryToOutletView.ParentDeliveryToOutlet.CreatedBy = SgiHelper.GetIdentityUserName();
            }
            else
            {
                _iDeliveryToOutletView.ParentDeliveryToOutlet.ModifiedDate = DateTime.Now;
                _iDeliveryToOutletView.ParentDeliveryToOutlet.ModifiedBy = SgiHelper.GetIdentityUserName();
            }
                                   
            var message = _iDeliveryToOutletBusinessModel.SaveDeliveryToOutlet(_iDeliveryToOutletView.ParentDeliveryToOutlet);

            if (message == DeliveryToOutletBusinessModel.SuccessfulMessageOnCreate
                || message == DeliveryToOutletBusinessModel.SuccessfulMessageOnUpdate)
            {
                _iDeliveryToOutletView.ShowMessage(message);
                _iDeliveryToOutletView.ParentDeliveryToOutlet = _iDeliveryToOutletBusinessModel.GetDeliveryToOutletByPackingListNumber(packingListNumber);
               
                doAfterSave();
               
            }                                                            
        }

        public void InitializeControlsToDefaultState()
        {
            LoadStores();
            LoadAllProductDetails();
           
        }

        private void LoadStores()
        {
            var stores = _outletBusinessModel.SelectAll();
            _iDeliveryToOutletView.LoadOutletToControl(stores);
        }
       
        public void LoadDeliveryOutletToView(string packingListNumber)
        {
            var deliveryToOutlet = _iDeliveryToOutletBusinessModel.GetDeliveryToOutletByPackingListNumber(packingListNumber);
            _iDeliveryToOutletView.ParentDeliveryToOutlet = deliveryToOutlet;
            _iDeliveryToOutletView.SelectedDeliveryToOutletDetails = deliveryToOutlet.DeliveryToOutletDetails.ToList();
            _iDeliveryToOutletView.LoadDeliveryToOutlet(deliveryToOutlet);
        }

        public override void DisableOrEnableSaveDeliveryButton()
        {
            throw new NotImplementedException();
        }

        public override void DisableOrEnableSaveDeliveryDetailButton()
        {
            var sizeCode = _iDeliveryToOutletView.GetSizeCode();
            var washingCode = _iDeliveryToOutletView.GetWashingCode();
            var colorCode = _iDeliveryToOutletView.GetColorCode();

            var sizeCodeFlag = !string.IsNullOrEmpty(sizeCode) ? "1" : "0";
            var washingCodeFlag = !string.IsNullOrEmpty(washingCode) ? "1" : "0";
            var colorCodeFlag = !string.IsNullOrEmpty(colorCode) ? "1" : "0";

            var overAllFlag = string.Concat(sizeCodeFlag, washingCodeFlag, colorCodeFlag);

            if (overAllFlag == "111")
            {
                _iDeliveryToOutletView.EnableSaveDeliveryDetailButton(true);
            }
            else
            {
                _iDeliveryToOutletView.EnableSaveDeliveryDetailButton(false);
            }
        }

        public void LoadParentDeliveryToOutlet(string packingNo)
        {
            DeliveryToOutlet deliveryOutlet = null;

            if (!string.IsNullOrEmpty(packingNo))
            {
                deliveryOutlet = _iDeliveryToOutletBusinessModel.GetDeliveryToOutletByPackingListNumber(packingNo);
                deliveryOutlet.ModifiedDate = DateTime.Now;
                deliveryOutlet.ModifiedBy = SgiHelper.GetIdentityUserName();
            }
            else
            {
                deliveryOutlet = new DeliveryToOutlet
                {
                    CreatedBy = SgiHelper.GetIdentityUserName()
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    PackingListNumber = _iDeliveryToOutletView.GetPackingNumber()
                    ,
                    DeliveryDate = _iDeliveryToOutletView.GetDeliveryDate()
                };
            }

            _iDeliveryToOutletView.ParentDeliveryToOutlet = deliveryOutlet;

        }
      
        public void AddDeliveryToOutletDetail(Action doAfterAdd)
        {
            var quantity = _viewModel.Quantity;
            Status = _iDeliveryToOutletView.GetProductStatus();

            if (quantity == 0)
            {
                _iDeliveryToOutletView.ShowMessage("Invalid quantity");
                return;
            }

            var itemCount = GetAllAddedProduct();

            if (!IsTheNumberOfItemsStillAllowed(itemCount))
            {
                _iDeliveryToOutletView.ShowMessage("The outgoing delivery has already reached the maximum limit");
                return;
            }

                       
            var productCode = _iDeliveryToOutletView.GetStockNumber();
            
            var productDetail = _productDetailBusinessModel.SelectByPrimaryId(productCode);

            if (productDetail == null)
            {
                _iDeliveryToOutletView.ShowMessage("Product code not exists!");
                return;
            }

            if (_iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails == null)
            {
                _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails = new List<DeliveryToOutletDetail>();
            }

            var existingQuantity = _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails.Where(c => c.ProductDetail != null && c.ProductDetail.Code.Equals(productCode)).Sum(c => c.Quantity);

            quantity += existingQuantity;

            var isQuantityAvailable =
                _iDeliveryToOutletView.ParentDeliveryToOutlet.Id==0?
                 _deliveryBusinessModelHelper.IsQuantityAvailable(productCode, quantity,Status)
                 :_deliveryBusinessModelHelper.IsQuantityAvailable(productCode,quantity,Status, _iDeliveryToOutletView.ParentDeliveryToOutlet.Id);

            if (!isQuantityAvailable)
            {
                _iDeliveryToOutletView.ShowMessage("Stock is not enough!");
                return;
            }

            DeliveryToOutletDetail detail = null;

            detail = 
                _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails
                .Where(dd => dd.ProductDetail.Code.Equals(productCode
                , StringComparison.InvariantCultureIgnoreCase)
                && dd.Status == (int)Status
                ).FirstOrDefault();

            if(detail==null)
            {
                var deliveryToOutletDetail = new DeliveryToOutletDetail
                {
                    DeliveryToOutlet = _iDeliveryToOutletView.ParentDeliveryToOutlet
                ,
                    ProductDetail = productDetail
                ,
                    Quantity = _iDeliveryToOutletView.GetQuantity()
                ,
                    SuggestedRetailPrice = _iDeliveryToOutletView.Srp
                ,
                    Status = (int)Status
                };

                _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails.Add(deliveryToOutletDetail);
            }
            else
            {
                detail.Quantity = quantity;
            }            
            doAfterAdd();
        }

        private int GetAllAddedProduct()
        {
            var retValue = 0;

            if (_iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails != null)
            {
                retValue = _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails.GroupBy(d => d.ProductDetail.Code).Count();                
            }

            return retValue;
        }

        public void BuildProductDetailIntoPanel(DataGridView gvDeliveryDetails)
        {
            var supplierDeliveriesByStockNumber = GroupSupplyDeliveriesByStockNumber();

            var deliveryGridConstructor = new DeliveryGridConstructor();

            gvDeliveryDetails.Rows.Clear();
            gvDeliveryDetails.Columns.Clear();

            var listOfSupplierDelivery = new List<SupplierDelivery>();

            foreach (var key in supplierDeliveriesByStockNumber.Keys)
            {
                foreach (var colorNameDashSizeNameKey in supplierDeliveriesByStockNumber[key].Keys)
                {
                    listOfSupplierDelivery.Add(supplierDeliveriesByStockNumber[key][colorNameDashSizeNameKey]);
                }

                deliveryGridConstructor.CreateDeliveries(listOfSupplierDelivery, gvDeliveryDetails, key);

                listOfSupplierDelivery.Clear();
            }
            deliveryGridConstructor.SummarizeGridDisplay(gvDeliveryDetails);
        }

        private Dictionary<string, Dictionary<string, SupplierDelivery>> GroupSupplyDeliveriesByStockNumber()
        {            
            var supplierDeliveriesByStockNumber = new Dictionary<string, Dictionary<string, SupplierDelivery>>();

             foreach(var dod in _iDeliveryToOutletView.ParentDeliveryToOutlet.DeliveryToOutletDetails)
            {
                Dictionary<string, SupplierDelivery> supplierDeliveryByColor;

                supplierDeliveriesByStockNumber.TryGetValue(dod.ProductDetail.Product.StockNumber, out supplierDeliveryByColor);

                if (supplierDeliveryByColor != null)
                {
                    SupplierDelivery supplierDelivery;

                    var colorNameDashSizeName = ConcatColorNameDashSizeName(dod.ProductDetail);

                    supplierDeliveryByColor.TryGetValue(colorNameDashSizeName, out supplierDelivery);

                    if (supplierDelivery != null)
                    {
                        supplierDelivery.Quantity += dod.Quantity;
                    }
                    else
                    {
                        supplierDelivery = CreateSupplierDeliveryByDeliveryDetailToOutlet(dod);

                        supplierDeliveryByColor.Add(colorNameDashSizeName, supplierDelivery);
                    }

                }
                else
                {
                    var colorNameDashSizeName = ConcatColorNameDashSizeName(dod.ProductDetail);

                    var supplierDelivery = CreateSupplierDeliveryByDeliveryDetailToOutlet(dod);

                    supplierDeliveriesByStockNumber.Add(dod.ProductDetail.Product.StockNumber,
                        new Dictionary<string, SupplierDelivery> { { colorNameDashSizeName, supplierDelivery } });

                }
            }

            return supplierDeliveriesByStockNumber;
        }

        public void OnPrinting()
        {
            if(_iDeliveryToOutletView.ParentDeliveryToOutlet.Id==0)
            {
                var dialogResult = _iDeliveryToOutletView.ShowYesNoMessage("Saving the changes is required before printing, would you like to save your changes?", "Save first before printing");
                if (dialogResult == DialogResult.Yes)
                {
                    _iDeliveryToOutletView.OnSave();
                    _iDeliveryToOutletView.PopupPrintForm();                  
                }
            }
            else
            {
                _iDeliveryToOutletView.PopupPrintForm();
            }
        }

        private string ConcatColorNameDashSizeName(ProductDetails productDetail)
        {
            var retValue = string.Concat(productDetail.Color.Name, "-", productDetail.Size.Name);
            return retValue;
        }

        private SupplierDelivery CreateSupplierDeliveryByDeliveryDetailToOutlet(DeliveryToOutletDetail dod)
        {
            var supplierDelivery = new SupplierDelivery
            {
                ProductDescription = dod.ProductDetail.Color.Name
                ,
                Quantity = dod.Quantity
                ,
                SizeName = dod.ProductDetail.Size.Name
            };

            return supplierDelivery;

        }

        public void OnProductDetailChanges()
        {
            base.LoadProductDetailOnChangesInSizeOrWashingOrColor((productDetail) => this._iDeliveryToOutletView.Srp= productDetail.Product.MarkdownPrice>0? productDetail.Product.MarkdownPrice: productDetail.Product.RegularPrice);
        }

        public bool VerifyInputs()
        {
            var packingListNumber = _iDeliveryToOutletView.GetPackingNumber();
            var outletId = _iDeliveryToOutletView.GetOutletId();
            var stockNumber = _iDeliveryToOutletView.GetStockNumber();
            
            var quantity = _iDeliveryToOutletView.GetQuantity();

            if (!string.IsNullOrEmpty(packingListNumber)
                && outletId>0
                && !string.IsNullOrEmpty(stockNumber)            
                && quantity>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StoreDetailChange()
        {
            var storeName = _iDeliveryToOutletView.GetStoreName();
            var drNumber = _iDeliveryToOutletView.GetPackingNumber();

            if (!string.IsNullOrEmpty(storeName) && !string.IsNullOrEmpty(drNumber))
            {
                _iDeliveryToOutletView.EnableProductDetailsGroup(true);
            }
            else
            {
                _iDeliveryToOutletView.EnableProductDetailsGroup(false);
            }
        }

        public void LoadProductStatus()
        {
            var listOfStatus = SgiHelper.ConvertEnumToList<ProductStatus>(
                                           () => Enum.GetValues(typeof(ProductStatus)),
                                           (enumItem) => (ProductStatus)enumItem);
            _iDeliveryToOutletView.LoadProductStatusIntoForm(listOfStatus);
        }

        public void LoadResultByCode(bool isBarcode, string productCode)
        {
            var result = LoadProductDetails(isBarcode, productCode);
            if (result == null || (result != null && result.Count == 0))
            {
                _iDeliveryToOutletView.ShowMessage(string.Format("Code {0} not exists!", productCode));
                return;
            }

              _iDeliveryToOutletView.LoadResultToView(result);   
                               
        }           
    }
}
