using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Model;
using SGInventory.Presenters.Model;

namespace SGInventory.Presenters
{
    public class SalesEditPresenter
    {
        public event EventHandler<DisplaySalesArg> DisplayListOfSalesOnAdd;

        public bool ShouldUseScanner { get; private set; }

        private ISalesBusinessModel _salesBusinessModel;
        private ISalesEditView _view;
        private IOutletBusinessModel _outletBusinessModel;
        private IProductBusinessModel _productBusinessModel;
        private IProductDetailBusinessModel _productDetailBusinessModel;
        private IColorBusinessModel _colorBusinessModel;
        private ISizeBusinessModel _sizeBusinessModel;
        private IWashingBusinessModel _washingBusinessModel;

        public SalesEditPresenter(
            ISalesEditView view
            , ISalesBusinessModel salesbusinessmodel
            , IOutletBusinessModel outletbusinessmodel
            , IProductBusinessModel productbusinessmodel
            , IProductDetailBusinessModel productdetailbusinessmodel
            , IColorBusinessModel colorbusinessmodel
            , ISizeBusinessModel sizebusinessmodel
            , IWashingBusinessModel washingbusinessmodel
            , bool usescanner
            )
        {
            _salesBusinessModel = salesbusinessmodel;
            _outletBusinessModel = outletbusinessmodel;
            _productBusinessModel = productbusinessmodel;
            _productDetailBusinessModel = productdetailbusinessmodel;
            _colorBusinessModel = colorbusinessmodel;
            _sizeBusinessModel = sizebusinessmodel;
            _washingBusinessModel = washingbusinessmodel;

            _view = view;

            ShouldUseScanner = usescanner;
        }


        public void InitializeControl(int? salesid)
        {
            var outlets = _outletBusinessModel.SelectAll();
            _view.LoadOutlets(outlets);
            Sales sales = new Sales();
            if (salesid.HasValue)
            {
                 sales = _salesBusinessModel.SelectBy(salesid.Value);
                 //ToListOfSalesAndLoad(sales);
                 if (ShouldUseScanner)
                 {
                     _view.LoadProducts(new List<ProductDetails> { sales.ProductDetail });
                 }
                 else
                 {
                     _view.LoadProducts(new List<Product> { sales.ProductDetail.Product });
                 }

            }

            _view.LoadSales(sales);
            var colors = _colorBusinessModel.SelectAll();
            var sizes = _sizeBusinessModel.SelectAll();

            _view.LoadColors(colors);
            _view.LoadSizes(sizes);

            if (salesid.HasValue)
            {
                if (!ShouldUseScanner)
                {
                    _view.LoadColor(sales.ProductDetail.Color);
                    _view.LoadSizes(sales.ProductDetail.Size);
                    _view.LoadWashings(sales.ProductDetail.Washing);
                }               
            }
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
                Sales existingSales = _salesBusinessModel.SelectByOutletDateOfSalesProductDetail(sales);

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
            List<Sales> listOfSales = _salesBusinessModel.SelectByOutletAndDateOfSales(sales);
            var retValue = (from l in listOfSales
                            select new SalesDisplayModel
                            {
                                Color = l.ProductDetail.Color.Name
                                ,
                                Id = l.Id
                                ,
                                Quantity = l.Quantity
                                ,
                                Size = l.ProductDetail.Size.Name
                                ,
                                Washing = l.ProductDetail.Washing.Name
                                ,
                                Code = l.ProductDetail.Code
                            }).ToList();
            if (DisplayListOfSalesOnAdd != null)
            {
                DisplayListOfSalesOnAdd(this, new DisplaySalesArg(retValue));
            }
        }

        public void LoadExistingSales(int salesId)
        {
            var sales = _salesBusinessModel.SelectBy(salesId);
           
            if (ShouldUseScanner)
            {
                 var productDetails = new List<ProductDetails>{sales.ProductDetail};
                _view.LoadProducts(productDetails);
            }
            else
            {
                var products = new List<Product>{sales.ProductDetail.Product};
                _view.LoadProducts(products);
            }
                       
            _view.LoadSales(sales);
            
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
            var stockNumber = _view.GetStockNumber();
            var color = _view.GetColorCode();
            var size = _view.GetSizeCode();

            ProductDetails productDetail = _productDetailBusinessModel.SelectByStockNumberAndColorAndSize(stockNumber, color, size);
            return productDetail;
        }
    }
}
