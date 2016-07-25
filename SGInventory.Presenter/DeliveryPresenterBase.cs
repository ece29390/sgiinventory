using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Model;

namespace SGInventory.Presenters
{
    public abstract class DeliveryPresenterBase
    {
        public List<SGInventory.Model.Color> Colors { get; protected set; }
        public List<SGInventory.Model.Size> Sizes { get; protected set; }
        public List<SGInventory.Model.Washing> Washings { get; protected set; }
        public bool UsingScanner { get; private set; }
        
        private IProductBusinessModel _productBusinessModel;
        private IDeliveryBaseView _viewBase;
        private IProductDetailBusinessModel _productDetailBusinessModel;
        private IColorBusinessModel _colorBusinessModel;
        private ISizeBusinessModel _sizeBusinessModel;
        private IWashingBusinessModel _washingBusinessModel;

        protected DeliveryPresenterBase(
            IProductBusinessModel productBusinessModel
            , IProductDetailBusinessModel productDetailBusinessModel
            , IColorBusinessModel colorBusinessModel
            , ISizeBusinessModel sizeBusinessModel
            , IWashingBusinessModel washingBusinessModel
            ,IDeliveryBaseView viewBase
            ,bool useScanner
            )
        {
            _productBusinessModel = productBusinessModel;
            _productDetailBusinessModel = productDetailBusinessModel;
            _colorBusinessModel = colorBusinessModel;
            _sizeBusinessModel = sizeBusinessModel;
            _washingBusinessModel = washingBusinessModel;
            _viewBase = viewBase;

            Colors = new List<SGInventory.Model.Color>();
            Sizes = new List<SGInventory.Model.Size>();
            Washings = new List<SGInventory.Model.Washing>();

            UsingScanner = useScanner;
        }

        public void LoadProducts()
        {
            var selectByBarcode = _viewBase.GetSelectByProductCode();
            var code = UsingScanner ? _viewBase.GetStockNumber().Substring(2).Trim() : _viewBase.GetStockNumber();
            if (!selectByBarcode)
            {
                var product = _productBusinessModel.SelectByStockNumber(code);
                _viewBase.LoadProducts(product);
            }
            else
            {
                var productDetails = _productDetailBusinessModel.SearchByBarcode(code);
                _viewBase.LoadProducts(productDetails);
            }
        }

        public List<ProductDetails> LoadProductDetails(bool isBarcode,string code)
        {
            var result = isBarcode
                ? _productDetailBusinessModel.SearchByBarcode(code)
                : _productDetailBusinessModel.SelectByStockNumber(code);

            return result;
        }

        public void LoadSelectedProduct()
        {
            if (!_viewBase.GetSelectByProductCode())
            {
                var product = _viewBase.GetSelectedProduct();
                _viewBase.LoadProductIntoForm(product);
            }
            else
            {
                var productDetails = _viewBase.GetSelectedProductDetails();
                _viewBase.LoadProductIntoForm(productDetails);
                _viewBase.EnableSaveDeliveryDetailButton(true);
            }

        }

        public void LoadAllProductDetails()
        {
            Colors = _colorBusinessModel.SelectAll();
            Washings = _washingBusinessModel.SelectAll();
            Sizes = _sizeBusinessModel.SelectAll();          
        }

        public abstract void DisableOrEnableSaveDeliveryButton();

        public abstract void DisableOrEnableSaveDeliveryDetailButton();

        public void OnSelectBarcodeSwitch()
        {
            var getSelectedByBarcode = _viewBase.GetSelectByProductCode();
            _viewBase.DisabledProductDetail(getSelectedByBarcode);
            _viewBase.RenameStockOrCodeLabel(getSelectedByBarcode ? "Barcode:" : "Stock Number:");
            _viewBase.ClearProductDetailControls();
            _viewBase.EnableSaveDeliveryDetailButton(false);
        }

        public void UseScanner(bool shouldUseScanner)
        {
            _viewBase.ShowScannerWindow(shouldUseScanner);
            _viewBase.SetSelectByBarcodeTo(shouldUseScanner);
            OnSelectBarcodeSwitch();
            _viewBase.EnableSaveAddProductButton(!shouldUseScanner);
        }

        public bool ValidateItemCodeAfterScanning(string barcode)
        {
            var productDetail = _productDetailBusinessModel.SelectByPrimaryId(barcode);

            if (productDetail != null)
            {
                _viewBase.SetBarcodeAs(productDetail);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LoadProductDetailOnChangesInSizeOrWashingOrColor(Action<ProductDetails> processLoadProductDetails)
        {
            var stockNumber = _viewBase.GetStockNumber();
            var size = _viewBase.GetSizeCode();
            var color = _viewBase.GetColorCode();
            var washing = _viewBase.GetWashingCode();

            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color))
            {
                var productModel = _productBusinessModel.SelectByStockNumber(stockNumber);

                var firstProduct = productModel.First();

                var firstProductDetail = firstProduct.ProductDetails.First();

                washing = firstProductDetail.Washing.Code;

                _viewBase.SetWashingCode(firstProductDetail.Washing.Name);
            }
            

            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(washing))
            {

                var productDetail = _productDetailBusinessModel.SelectByPrimaryId(SgiHelper.GetProductDetailCode(stockNumber, color, washing, size));

                if (productDetail != null)
                {                    
                    processLoadProductDetails(productDetail);

                    _viewBase.EnableSaveDeliveryDetailButton(true);
                }
                else
                {
                    _viewBase.EnableSaveDeliveryDetailButton(false);
                    _viewBase.ShowMessage("Product Detail Doesn't Exists, Go to Product Module");
                }

            }
            else
            {
                _viewBase.EnableSaveDeliveryDetailButton(false);
            }
        }

        protected bool IsTheNumberOfItemsStillAllowed(int actualItem)
        {
            return actualItem <= _viewBase.GetMaximumLimit();
        }
    }
}
