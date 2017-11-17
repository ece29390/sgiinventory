using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Model;
using SGInventory.Presenters.Model;
using SGInventory.Enums;
using SGInventory.Extensions;

namespace SGInventory.Presenters
{
    public class SalesEditPresenter
    {
        public event EventHandler<DisplaySalesArg> DisplayListOfSalesOnAdd;
        public const string InsufficientQuantityErrorFormat = "Insufficient Quantity for {0}";
        public bool ShouldUseScanner { get; private set; }

        private readonly ISalesBusinessModel _salesBusinessModel;
        private readonly ISalesEditView _view;
        private readonly IOutletBusinessModel _outletBusinessModel;
        private readonly IProductBusinessModel _productBusinessModel;
        private readonly IProductDetailBusinessModel _productDetailBusinessModel;
        private readonly IColorBusinessModel _colorBusinessModel;
        private readonly ISizeBusinessModel _sizeBusinessModel;
        private readonly IWashingBusinessModel _washingBusinessModel;
        private readonly IDeliveryToOutletBusinessModel _deliveryToOutletBusinessModel;

        public SalesEditPresenter(
            ISalesEditView view
            , ISalesBusinessModel salesbusinessmodel
            , IOutletBusinessModel outletbusinessmodel
            , IProductBusinessModel productbusinessmodel
            , IProductDetailBusinessModel productdetailbusinessmodel
            , IColorBusinessModel colorbusinessmodel
            , ISizeBusinessModel sizebusinessmodel
            , IWashingBusinessModel washingbusinessmodel
            , IDeliveryToOutletBusinessModel deliveryToOutletBusinessModel
            )
        {
            _salesBusinessModel = salesbusinessmodel;
            _outletBusinessModel = outletbusinessmodel;
            _productBusinessModel = productbusinessmodel;
            _productDetailBusinessModel = productdetailbusinessmodel;
            _colorBusinessModel = colorbusinessmodel;
            _sizeBusinessModel = sizebusinessmodel;
            _washingBusinessModel = washingbusinessmodel;
            _deliveryToOutletBusinessModel = deliveryToOutletBusinessModel;

            _view = view;           
        }


        public void InitializeControl(int? salesid)
        {
            var outlets = _outletBusinessModel.SelectAll();
            _view.LoadOutlets(outlets);
            Sales sales = new Sales();
            if (salesid.HasValue)
            {
                 sales = _salesBusinessModel.SelectBy(salesid.Value);                                          
            }
            else
            {
                sales.TransactionNumber = GenerateTransactionNumber();
               
            }
            _view.LoadSales(sales);
        }
        public string GenerateTransactionNumber()
        {
            var date = DateTime.Now;
            var salesNumber = date.ToString("yyyyMMddhhmmss");
            return salesNumber;
        }
        public void OnSelectBarcodeSwitch()
        {
            var getSelectedByBarcode = _view.GetSelectByProductCode();
            _view.DisabledProductDetail(getSelectedByBarcode);
            _view.RenameStockOrCodeLabel(getSelectedByBarcode ? "Barcode:" : "Stock Number:");
            _view.ClearProductDetailControls();
        }

        public void UseScanner(bool shouldusescanner)
        {
            _view.ShowScannerWindow(shouldusescanner);
            _view.SetSelectByBarcodeTo(shouldusescanner);
            OnSelectBarcodeSwitch();
            _view.EnableAddButton(!shouldusescanner);
        }

        public bool ValidateItemCodeAfterScanning(string barcode)
        {
            var productDetail = _productDetailBusinessModel.SelectByPrimaryId(barcode);

            if (productDetail != null)
            {
                _view.SetBarcodeAs(productDetail);
                return true;
            }
            else
            {
                return false;
            }
        }

        private const string CodeNotExistsInStoreFormat = "{0} doesn't exists/has no stocks in {1}";
        public void OnRetrievingProduct(string code, bool isBarCode)
        {
            var outletId = _view.GetOutletId();
            var productDetailList = GetDistinctProductDetailsBySales(code, isBarCode, outletId);
            if(productDetailList!=null && productDetailList.Count>0)
            {
                _view.LoadProducts(productDetailList);
                if(isBarCode)
                {
                    _view.TriggerAddSales();                    
                }
            }
            else
            {
                var outlet = _view.GetSelectedOutlet();
                _view.ShowMessage(string.Format(CodeNotExistsInStoreFormat,code,outlet));
            }            
        }

        public bool VerifyIfQuantityIsEnough(int quantity)
        {
            var outletId = _view.GetOutletId();
            var productDetail = _view.GetSelectedProductCode();
            int totalQuantityInOutlet = _deliveryToOutletBusinessModel.GetOverallQuantityPerOutlet(outletId, productDetail);
            int totalQuantityMadeInSales = _salesBusinessModel.GetTotalQuantityPerOutlet(outletId, productDetail);
            int remainingQuantity = totalQuantityInOutlet - totalQuantityMadeInSales;
            return remainingQuantity >= quantity;
        }
        public bool VerifyIfQuantityIsEnoughOnEdit(int quantity,int salesId)
        {
            var outletId = _view.GetOutletId();
            var productDetail = _view.GetSelectedProductCode();
            int totalQuantityInOutlet = _deliveryToOutletBusinessModel.GetOverallQuantityPerOutlet(outletId, productDetail);
            int totalQuantityMadeInSales = _salesBusinessModel.GetTotalQuantityAsideFromGivenSalesId(outletId, productDetail, salesId);
           
            int remainingQuantity = totalQuantityInOutlet - totalQuantityMadeInSales;
            return remainingQuantity >= quantity;
        }
        public bool ValidateIfCodeExistsInTheOutlet(string code,bool isBarCode)
        {
            int outletId = _view.GetOutletId();
            List<DeliveryToOutletDetail> deliveryToOutletDetail =
                isBarCode ? _deliveryToOutletBusinessModel.GetActiveDeliveryToOutletDetailBy(
                    ProductStatus.Goods
                    , code
                    , outletId
                    ) :
                    _deliveryToOutletBusinessModel.GetActiveDeliveryToOutletDetailByStockNumberAnd(
                        ProductStatus.Goods
                        ,code
                        ,outletId
                        );

            return deliveryToOutletDetail.Count > 0;
        }

        public void LoadOtherSalesWithSameTransaction(Sales sales)
        {
            ToListOfSalesAndLoad(sales);
            _view.ShowEditControls(true);
            _view.EnableAddButton(false);
            _view.LoadProducts(new List<ProductDetails> { sales.ProductDetail });
        }

        private List<ProductDetails> GetDistinctProductDetailsBySales(string code,bool isBarcode,int outletId)
        {
            var productDetailList = _productDetailBusinessModel.GetActiveAvailableProductForSales(code, outletId, ProductStatus.Goods,isBarcode);

            productDetailList.ForEach(pd => 
            {
                pd.Color = _colorBusinessModel.SelectByPrimaryId(pd.Color.Code);
                pd.Size = _sizeBusinessModel.SelectByPrimaryId(pd.Size.Code);
                pd.Washing = _washingBusinessModel.SelectByPrimaryId(pd.Washing.Code);
                pd.Product = _productBusinessModel.SelectByPrimaryId(pd.Product.StockNumber);
            });
        
            return productDetailList;
        }
        public void LoadProductDetail()
        {
            var stockNumber = _view.GetStockNumber();
            var size = _view.GetSizeCode();
            var color = _view.GetColorCode();
            var washing = _view.GetWashingCode();

            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color))
            {
                var productModel = _productBusinessModel.SelectByStockNumber(stockNumber);

                var firstProduct = productModel.First();

                var firstProductDetail = firstProduct.ProductDetails.First();

                washing = firstProductDetail.Washing.Code;

                _view.SetWashingCode(firstProductDetail.Washing.Name);
            }


            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(washing))
            {

                var productDetail = _productDetailBusinessModel.SelectByPrimaryId(SgiHelper.GetProductDetailCode(stockNumber, color, washing, size));

                if (productDetail != null)
                {
                    _view.EnableAddButton(true);
                }
                else
                {
                    _view.EnableAddButton(false);
                    _view.ShowMessage("Product Detail Doesn't Exists, Go to Product Module");
                }

            }
            else
            {
                _view.EnableAddButton(false);
            }
        }

        public void LoadProducts()
        {
            var selectByBarcode = _view.GetSelectByProductCode();
            var code = ShouldUseScanner ? _view.GetStockNumber().Substring(2).Trim() : _view.GetStockNumber();
            if (!selectByBarcode)
            {
                var product = _productBusinessModel.SelectByStockNumber(code);
                _view.LoadProducts(product);
            }
            else
            {
                var productDetails = _productDetailBusinessModel.SearchByBarcode(code);
                _view.LoadProducts(productDetails);
            }            
        }

        public void LoadSelectedProduct()
        {
            if (_view.GetSelectByProductCode())
            {
                var productDetails = _view.GetSelectedProductDetails();
                _view.EnableAddButton(true);
            }
        }

        public void AddSales()
        {
            Sales sales = _view.GetSalesObject();

            if (sales.Id == 0)
            {
                Sales existingSales = _salesBusinessModel.SelectByTransactionNumberOutletAndProductDetail(sales);

                if (existingSales != null)
                {
                    sales.ModifiedDate = DateTime.Now;
                    sales.ModifiedBy = SgiHelper.GetIdentityUserName();
                    sales.Quantity += existingSales.Quantity;
                    sales.Id = existingSales.Id;
                    sales.CreatedDate = existingSales.CreatedDate;
                    sales.CreatedBy = existingSales.CreatedBy;
                }
                else
                {
                    sales.CreatedDate = DateTime.Now;
                    sales.CreatedBy = SgiHelper.GetIdentityUserName();
                }                
            }
            else
            {
                sales.ModifiedDate = DateTime.Now;
                sales.ModifiedBy = SgiHelper.GetIdentityUserName();
            }

            _salesBusinessModel.Save(sales);

            _view.ShowMessage(string.Format("Sales was successfully added to the list!{0}List will now load all sales made on the set date and outlet", Environment.NewLine));

            ToListOfSalesAndLoad(sales);

            _view.ResetControls();
           
        }

        private void ToListOfSalesAndLoad(Sales sales)
        {
            List<Sales> listOfSales = _salesBusinessModel.SelectBy(sales.TransactionNumber);
            LoadListOfSales(listOfSales);
        }

        private void LoadListOfSales(List<Sales> listOfSales)
        {
            var retValue = listOfSales.ToSpecifiedTypeUsingAutoMapper<List<Sales>,List<SalesDisplayModel>>();
                //(from l in listOfSales
                //            select new SalesDisplayModel
                //            {
                //                Color = l.ProductDetail.Color.Name
                //                ,
                //                Id = l.Id
                //                ,
                //                Quantity = l.Quantity
                //                ,
                //                Size = l.ProductDetail.Size.Name
                //                ,
                //                Washing = l.ProductDetail.Washing.Name
                //                ,
                //                Code = l.ProductDetail.Code
                //            }).ToList();
            if (DisplayListOfSalesOnAdd != null)
            {
                DisplayListOfSalesOnAdd(this, new DisplaySalesArg(retValue));
            }
        }

        public void UpdateSales()
        {
            var sales = _view.GetSalesObject();
            var outlet = _view.GetSelectedOutlet();

            if (!ValidateIfCodeExistsInTheOutlet(sales.ProductDetail.Code,true))
            {
                
                _view.ShowMessage(string.Format(CodeNotExistsInStoreFormat, sales.ProductDetail.Code, outlet));
                return;
            }

            if(!VerifyIfQuantityIsEnoughOnEdit(sales.Quantity,sales.Id))
            {
                _view.ShowMessage(string.Format(InsufficientQuantityErrorFormat, outlet));
                return; 
            }

            _salesBusinessModel.Update(sales);
            _view.ShowMessage("Sales has been successfully updated");
            ToListOfSalesAndLoad(sales);
            _view.ResetControls();
            _view.ShowEditControls(false);
            _view.DisabledProductDetail(false);
            _view.EnableAddButton(true);
            _view.SetEditMode(false);
        }

        public void LoadExistingSales(int salesId)
        {
            var sales = _salesBusinessModel.SelectBy(salesId);

            var productDetails = new List<ProductDetails> { sales.ProductDetail };
            _view.LoadProducts(productDetails);

            _view.LoadSales(sales);
            _view.ShowEditControls(true);
            _view.DisabledProductDetail(true);
            _view.EnableAddButton(false);
            _view.SetEditMode(true);
        }

        public void DeleteExistingSales(int salesid)
        {
            var sales = _salesBusinessModel.SelectBy(salesid);
            _salesBusinessModel.Delete(sales);

            ToListOfSalesAndLoad(sales);

            sales = new Sales();
            _view.LoadSales(sales);

            

        }

        public ProductDetails BuildProductDetail()
        {
            var productCode = _view.GetSelectedProductCode();

            ProductDetails productDetail = _productDetailBusinessModel.SelectByPrimaryId(productCode);
            return productDetail;
        }
    }
}
