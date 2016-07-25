using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Presenters;
using SGInventory.Views;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Test.Data;
using SGInventory.Enums;
using SGInventory.Helpers;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class DeliveryPresenterTest
    {
        private readonly DeliveryPresenter _presenter;
        private readonly Mock<IDeliveryPresenterView> _mockPresenterView;
        private readonly Mock<ISupplierBusinessModel> _supplierMock;
        private readonly Mock<IProductBusinessModel> _productMock;
        private readonly Mock<IColorBusinessModel> _colorMock;
        private readonly Mock<IWashingBusinessModel> _washingMock;
        private readonly Mock<ISizeBusinessModel> _sizeMock;
        private readonly Mock<IProductDetailBusinessModel> _productDetailMock;
        private readonly Mock<IDeliveryBusinessModel> _deliveryBusinessMock;
        private  List<Supplier> _suppliers;
        private  List<Product> _products;
        private List<Color> _colors;
        private List<Size> _sizes;
        private List<Washing> _washings;
        private List<ProductDetails> _productDetails;
        private Delivery _delivery;
        private DeliveryTestData _deliveryTestData;
        public DeliveryPresenterTest()
        {
            _mockPresenterView=new Mock<IDeliveryPresenterView>(MockBehavior.Strict);            
            _supplierMock=new Mock<ISupplierBusinessModel>(MockBehavior.Strict);
            _productMock=new Mock<IProductBusinessModel>(MockBehavior.Strict);
            _colorMock = new Mock<IColorBusinessModel>(MockBehavior.Strict);
            _washingMock = new Mock<IWashingBusinessModel>(MockBehavior.Strict);
            _sizeMock = new Mock<ISizeBusinessModel>(MockBehavior.Strict);
            _productDetailMock = new Mock<IProductDetailBusinessModel>(MockBehavior.Strict);
            _deliveryBusinessMock = new Mock<IDeliveryBusinessModel>(MockBehavior.Strict);

            _deliveryTestData = new DeliveryTestData();
            _delivery = _deliveryTestData.GetEntity();

            LoadTestData();

            _presenter=new DeliveryPresenter(
                _mockPresenterView.Object,
                _supplierMock.Object
                , _productMock.Object
                ,_productDetailMock.Object
                ,_colorMock.Object
                ,_sizeMock.Object
                ,_washingMock.Object
                ,_deliveryBusinessMock.Object             
                ,null
                );
        }

        private void LoadTestData()
        {
            var supplierTestData = new SupplierTestData();
            _suppliers = supplierTestData.GetEntities();

            var productTestData=new ProductTestData();
            _products=productTestData.GetEntities();

            var colorTestData = new ColorTestData();
            _colors = colorTestData.GetEntities();

            var washingTestData = new WashingTestData();
            _washings = washingTestData.GetEntities();

            var sizeTestData = new SizeTestData();
            _sizes = sizeTestData.GetEntities();

            var productDetailTestData = new ProductDetailTestData();
            _productDetails = productDetailTestData.GetEntities();
        }

        [TestMethod]
        public void LoadSuppliersTest()
        {
            _supplierMock.Setup(s=>s.SelectAll()).Returns(_suppliers);
            _mockPresenterView.Setup(v => v.LoadSuppliers(It.IsAny<List<Supplier>>()));

            _presenter.LoadSuppliers();

            _supplierMock.VerifyAll();
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadProductsByInputSearchByStockNumberNotEmptyTest()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);            
            _productMock.Setup(p => p.SelectByStockNumber(It.IsAny<string>())).Returns(_products);
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns("sample");          
            _mockPresenterView.Setup(v => v.LoadProducts(It.IsAny<List<Product>>()));

            _presenter.LoadProducts();

            _productMock.VerifyAll();
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadProductsByInputSearchByBarcodeNotEmptyTest()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(true);
            _productDetailMock.Setup(p => p.SearchByBarcode(It.IsAny<string>())).Returns(_productDetails);
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns("sample");
            _mockPresenterView.Setup(v => v.LoadProducts(It.IsAny<List<ProductDetails>>()));

            _presenter.LoadProducts();

            _productMock.VerifyAll();
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadAllProductDetailsTest()
        {
            _colorMock.Setup(c=>c.SelectAll()).Returns(_colors);
            _sizeMock.Setup(s => s.SelectAll()).Returns(_sizes);
            _washingMock.Setup(w => w.SelectAll()).Returns(_washings);
            _mockPresenterView.Setup(m => m.LoadWashings(It.IsAny<List<Washing>>()));
            _mockPresenterView.Setup(m => m.LoadSizes(It.IsAny<List<Size>>()));
            _mockPresenterView.Setup(m => m.LoadColors(It.IsAny<List<Color>>()));

            _presenter.LoadAllProductDetails();

            _colorMock.VerifyAll();
            _sizeMock.VerifyAll();
            _washingMock.Verify();
        }

        [TestMethod]
        public void LoadSelectedProductByProductTest()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);
            _mockPresenterView.Setup(v => v.GetSelectedProduct()).Returns(_products[0]);
            _mockPresenterView.Setup(v => v.LoadProductIntoForm(It.IsAny<Product>()));         
            _presenter.LoadSelectedProduct();

            _mockPresenterView.VerifyAll();
          
        }

        [TestMethod]
        public void LoadSelectedProductProductDetailTest()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(true);
            _mockPresenterView.Setup(v => v.GetSelectedProductDetails()).Returns(_productDetails[0]);
            _mockPresenterView.Setup(v => v.LoadProductIntoForm(It.IsAny<ProductDetails>()));
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));
            _presenter.LoadSelectedProduct();

            _mockPresenterView.VerifyAll();

        }

        [TestMethod]
        public void ProcessItemCodeAfterScanning_ProductDetailExists_Test()
        {
            _productDetailMock.Setup(p => p.SelectByPrimaryId(_productDetails[0].Code)).Returns(_productDetails[0]);
            _mockPresenterView.Setup(v=>v.SetBarcodeAs(_productDetails[0]));
            
            Assert.IsTrue(_presenter.ValidateItemCodeAfterScanning(_productDetails[0].Code));

           
            _productDetailMock.VerifyAll();
        }

        [TestMethod]
        public void ProcessItemCodeAfterScanning_ProductDetailNotExists_Test()
        {
            ProductDetails productDetails = null;
            _productDetailMock.Setup(p => p.SelectByPrimaryId(_productDetails[0].Code)).Returns(productDetails);
            

            Assert.IsFalse(_presenter.ValidateItemCodeAfterScanning(_productDetails[0].Code));


            _productDetailMock.VerifyAll();
        }

        [TestMethod]
        public void LoadProductStatusTest()
        {
            _mockPresenterView.Setup(v => v.LoadProductStatusIntoForm(It.IsAny<List<ProductStatus>>()));
            _presenter.LoadProductStatus();
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadDamageStatusTest()
        {
            _mockPresenterView.Setup(v => v.LoadDamageIntoForm(It.IsAny<List<Damage>>()));
            _presenter.LoadDamage();
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void SelectProductStatusIsDamageTest()
        {
            _mockPresenterView.Setup(v => v.ShouldEnableDamageDetailGroup(true));
            _presenter.SelectProductStatus(ProductStatus.Damaged);
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void SelectProductStatusIsGoodTest()
        {
            _mockPresenterView.Setup(v => v.ShouldEnableDamageDetailGroup(false));
            _presenter.SelectProductStatus(ProductStatus.Goods);
            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void SelectDamageIsNotOtherTest()
        {
            _mockPresenterView.Setup(v => v.ShouldEnableStatusDescription(false));
            _presenter.SelectDamage(Damage.Fabric);
            _mockPresenterView.VerifyAll();
            
        }

        [TestMethod]
        public void SelectDamageIsOtherTest()
        {
            _mockPresenterView.Setup(v => v.ShouldEnableStatusDescription(true));
            _presenter.SelectDamage(Damage.Others);
            _mockPresenterView.VerifyAll();

        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_Given_All_Has_Values_And_Status_Is_Good_Enable_Test()
        {
            _mockPresenterView.Setup(v => v.GetSupplierName()).Returns("SupplierA");
            _mockPresenterView.Setup(v => v.GetOrNumber()).Returns("9861A");          
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(true));

            _presenter.Suppliers = _suppliers;
            _presenter.DisableOrEnableSaveDeliveryButton();

            _mockPresenterView.VerifyAll();

        }
        
        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_Given_SupplierName_IsIncorrectlyInput_Test()
        {
            _mockPresenterView.Setup(v => v.GetSupplierName()).Returns("Limelight");
            _mockPresenterView.Setup(v => v.GetOrNumber()).Returns("9861A");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(false));

            _presenter.Suppliers = _suppliers;
            _presenter.DisableOrEnableSaveDeliveryButton();

            _mockPresenterView.VerifyAll();

        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_Given_EmptySupplierName_Test()
        {
            _mockPresenterView.Setup(v => v.GetSupplierName()).Returns("");
            _mockPresenterView.Setup(v => v.GetOrNumber()).Returns("9861A");            
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(false));

            _presenter.Suppliers = _suppliers;
            _presenter.DisableOrEnableSaveDeliveryButton();

            _mockPresenterView.VerifyAll();

        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_Given_EmptyOrNumber_Test()
        {
            _mockPresenterView.Setup(v => v.GetSupplierName()).Returns("SupplierA");
            _mockPresenterView.Setup(v => v.GetOrNumber()).Returns("");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(false));

            _presenter.Suppliers = _suppliers;
            _presenter.DisableOrEnableSaveDeliveryButton();

            _mockPresenterView.VerifyAll();

        }

        //[TestMethod]
        //public void SaveDeliveryTransaction_New_And_Not_Exist_In_Product_Detail_Successfull_Test()
        //{
        //    var expectedMessage = "Delivery Item has been Saved";          
        //    _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("S");
        //    _mockPresenterView.Setup(v => v.GetColorCode()).Returns("Navy Blue");
        //    _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("STONE WASH");                     
        //    _mockPresenterView.Setup(v => v.GetPrice()).Returns(150);
        //    _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damage);
        //    _deliveryBusinessMock.Setup(v => v.Save(It.IsAny<Delivery>())).Returns(expectedMessage);
        //    _mockPresenterView.Setup(v => v.ShowMessage(expectedMessage));
        //    _mockPresenterView.Setup(v => v.LoadDelivery(It.IsAny<DeliveryDetail>()));
        //    _mockPresenterView.Setup(v => v.DisableDeliveryControls());

        //    _supplierMock.Setup(s => s.SelectAll()).Returns(_suppliers);
        //    _mockPresenterView.Setup(v => v.LoadSuppliers(It.IsAny<List<Supplier>>()));
        //    _presenter.LoadSuppliers();

        //    _colorMock.Setup(c => c.SelectAll()).Returns(_colors);
        //    _mockPresenterView.Setup(v => v.LoadColors(It.IsAny<List<Color>>()));

        //    _sizeMock.Setup(s => s.SelectAll()).Returns(_sizes);
        //    _mockPresenterView.Setup(v => v.LoadSizes(It.IsAny<List<Size>>()));

        //    _washingMock.Setup(w => w.SelectAll()).Returns(_washings);
        //    _mockPresenterView.Setup(v => v.LoadWashings(It.IsAny<List<Washing>>()));

        //    _productMock.Setup(p => p.SelectByPrimaryId(It.IsAny<string>())).Returns(_products[0]);

        //    _presenter.LoadAllProductDetails();


        //    _presenter.Save();

        //    _mockPresenterView.VerifyAll();
        //    _deliveryBusinessMock.VerifyAll();
        //    _supplierMock.VerifyAll();
        //    _colorMock.VerifyAll();
        //    _sizeMock.VerifyAll();
        //    _washingMock.VerifyAll();

        //}

        [TestMethod]
        public void MonthGeneratorTest()
        {
            var dt = new DateTime(2013, 8, 5);
           var month = SgiHelper.GetCorrespondingMonthByDate(dt);

           Assert.AreEqual("H", month);

           dt = new DateTime(2013, 12, 25);
           month = SgiHelper.GetCorrespondingMonthByDate(dt);
           Assert.AreEqual("L", month);
            
        }

        [TestMethod]
        public void YearGeneratorTest()
        {
            var dt = new DateTime(2013, 8, 5);
            var year = SgiHelper.GetCorrespondingYearByDate(dt);

            Assert.AreEqual("M", year);

            dt = new DateTime(2026, 8, 5);
            year = SgiHelper.GetCorrespondingYearByDate(dt);
            Assert.AreEqual("Z", year);

            dt = new DateTime(2027, 8, 5);
            year = SgiHelper.GetCorrespondingYearByDate(dt);
            Assert.AreEqual("A", year);

            dt = new DateTime(2052, 8, 5);
            year = SgiHelper.GetCorrespondingYearByDate(dt);
            Assert.AreEqual("Z", year);

            dt = new DateTime(2055, 8, 5);
            year = SgiHelper.GetCorrespondingYearByDate(dt);
            Assert.AreEqual("C", year);

        }

        private DeliveryDetail CreateInitialDeliveryItem()
        {
            return  new DeliveryDetail
            {               
                Id = 3,
                Quantity = 200,             
                Status = (int)ProductStatus.Goods,
                //Product=_delivery.DeliveryDetails[0].Product,
                ProductDetail=_deliveryTestData.CreateProductDetail(
                    new Color { Code = "005", Name = "Cement" },
                    new Washing { Code = "0", Name = "Biowashing" },
                    new Size { Code = "S", Name = "S" })

            };
        }

                              
        [TestMethod]
        public void SaveDelivery_Given_Delivery_Detail_IsNull()
        {
            var expectedMessage = DeliveryBusinessModel.DeliverySuccessfulMessage;
            _mockPresenterView.Setup(v => v.GetSupplierName()).Returns("SupplierA");
            _mockPresenterView.Setup(v => v.GetOrNumber()).Returns("9861A");           
            _mockPresenterView.Setup(v => v.GetDeliveryDate()).Returns(DateTime.Now);            
            _deliveryBusinessMock.Setup(v => v.Save(It.IsAny<Delivery>())).Returns(expectedMessage);
            _mockPresenterView.Setup(v => v.ShowMessage(expectedMessage));
            _mockPresenterView.Setup(v => v.EnableProductDetailsGroup(It.IsAny<bool>()));
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(false));
            _supplierMock.Setup(s => s.SelectAll()).Returns(_suppliers);
            _mockPresenterView.Setup(v => v.LoadSuppliers(It.IsAny<List<Supplier>>()));
            
            _presenter.LoadSuppliers();

            Delivery delivery = null;

            _presenter.SaveDelivery(delivery);

            _supplierMock.VerifyAll();
            _mockPresenterView.VerifyAll();
            _deliveryBusinessMock.VerifyAll();

        }

        [TestMethod]
        public void LoadCost_Given_Size_Is_Given_Test()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(_sizes[0].Code);
            string washing=null;
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing);
            string color = null;
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color);
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns("W011");

            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadCost_Given_Color_Is_Given_Test()
        {
            string size = null;
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(size);
            string washing = null;
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing);
            Color color = _colors[0];
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color.Code);
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns("W011");

            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadCost_Given_Washing_Is_Given_Test()
        {
            string size = null;
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(size);
            Washing washing = _washings[0];
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing.Code);
            string color = null;
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color);
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns("W011");

            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void LoadCost_Given_All_Is_Given_And_ProductDetail_Null_Test()
        {
            Size size = _sizes[0];
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(size.Code);
            Washing washing = _washings[0];
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing.Code);
            Color color = _colors[0];
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color.Code);
            var stockNumber = "W011";
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(stockNumber);
            
            var productDetailCode = SgiHelper.GetProductDetailCode(stockNumber, color.Code, washing.Code, size.Code);
            ProductDetails productDetail = null;
           
            _productDetailMock.Setup(b => b.SelectByPrimaryId(productDetailCode)).Returns(productDetail);
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _mockPresenterView.Setup(v=>v.ShowMessage("Product Detail Doesn't Exists, Go to Product Module"));
            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
        }

        [TestMethod]
        public void LoadCost_Given_All_Is_Given_And_ProductDetailOverrideCost_IsNotNull_Test()
        {
            Size size = _sizes[0];
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(size.Code);
            Washing washing = _washings[0];
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing.Code);
            Color color = _colors[0];
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color.Code);
            var stockNumber = "W011";
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(stockNumber);

            var productDetailCode = SgiHelper.GetProductDetailCode(stockNumber,color.Code,washing.Code,size.Code);
            var productDetail=_productDetails[0];
            productDetail.Code=productDetailCode;
            productDetail.Color=color;
            productDetail.Size=size;
            productDetail.Washing=washing;
            productDetail.Product = _products[0];
            productDetail.OverrideCost = 120;

            _productDetailMock.Setup(b => b.SelectByPrimaryId(productDetailCode)).Returns(productDetail);
            _mockPresenterView.Setup(v => v.SetDeliveryDetailItemCost(productDetail.OverrideCost));
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));
            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
        }

        [TestMethod]
        public void LoadCost_Given_All_Is_Given_And_ProductDetailOverrideCost_IsNull_Test()
        {
            Size size = _sizes[0];
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns(size.Code);
            Washing washing = _washings[0];
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns(washing.Code);
            Color color = _colors[0];
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns(color.Code);
            var stockNumber = "W011";
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(stockNumber);
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));
            var productDetailCode = SgiHelper.GetProductDetailCode(stockNumber, color.Code, washing.Code, size.Code);
            var productDetail = _productDetails[0];
            productDetail.Code = productDetailCode;
            productDetail.Color = color;
            productDetail.Size = size;
            productDetail.Washing = washing;
            productDetail.Product = _products[0];           
            _productDetailMock.Setup(b => b.SelectByPrimaryId(productDetailCode)).Returns(productDetail);
            _mockPresenterView.Setup(v => v.SetDeliveryDetailItemCost(productDetail.Product.Cost));

            _presenter.GetProductDetailCost();

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
        }

        [TestMethod]
        public void SaveDeliveryDetail_Given_ItemIsGood_Test()
        {            
            var deliveryDetails = new DeliveryDetail
            {
                Delivery = _delivery,                
                Quantity=100,
                Status=(int)ProductStatus.Goods,
                Price=_productDetails[0].OverrideCost.HasValue?_productDetails[0].OverrideCost.Value:500.50
                
            };

            _delivery.DeliveryDetails.Add(deliveryDetails);

            _mockPresenterView.Setup(v => v.GetSelectedColor()).Returns(_productDetails[0].Color);
            _mockPresenterView.Setup(v => v.GetSelectedSize()).Returns(_productDetails[0].Size);
            _mockPresenterView.Setup(v => v.GetSelectedWashing()).Returns(_productDetails[0].Washing);
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);
            _mockPresenterView.Setup(v => v.GetQuantity()).Returns(deliveryDetails.Quantity);
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(_productDetails[0].Product.StockNumber);           
            _productDetailMock.Setup(p => p.SelectByPrimaryId(_productDetails[0].Code)).Returns(_productDetails[0]);
            _mockPresenterView.Setup(v=>v.GetPrice()).Returns(deliveryDetails.Price);
            _mockPresenterView.Setup(v=>v.GetProductStatus()).Returns(ProductStatus.Goods);
            _deliveryBusinessMock.Setup(v => v.SaveDeliveryDetail(It.IsAny<DeliveryDetail>())).Returns(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage);
           // _mockPresenterView.SetupGet(v => v.UseScanner).Returns(false);
            _mockPresenterView.Setup(v => v.ShowMessage(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage));
            _mockPresenterView.Setup(v => v.LoadDelivery(It.IsAny<DeliveryDetail>()));
           
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _presenter.SaveDeliveryDetail(deliveryDetails);

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
            _deliveryBusinessMock.VerifyAll();
        }

        [TestMethod]
        public void SaveDeliveryDetail_Given_ItemIsDamageAndNonOthers_Test()
        {
            var deliveryDetails = new DeliveryDetail
            {
                Delivery = _delivery,
                Quantity = 100,
                Status = (int)ProductStatus.Goods,
                Price = _productDetails[0].OverrideCost.HasValue ? _productDetails[0].OverrideCost.Value : 500.50

            };

            _delivery.DeliveryDetails.Add(deliveryDetails);

            _mockPresenterView.Setup(v => v.GetSelectedColor()).Returns(_productDetails[0].Color);
            _mockPresenterView.Setup(v => v.GetSelectedSize()).Returns(_productDetails[0].Size);
            _mockPresenterView.Setup(v => v.GetSelectedWashing()).Returns(_productDetails[0].Washing);
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);
            _mockPresenterView.Setup(v => v.GetQuantity()).Returns(deliveryDetails.Quantity);
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(_productDetails[0].Product.StockNumber);
            _productDetailMock.Setup(p => p.SelectByPrimaryId(_productDetails[0].Code)).Returns(_productDetails[0]);
            _mockPresenterView.Setup(v => v.GetPrice()).Returns(deliveryDetails.Price);
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damaged);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Fabric);
            //_mockPresenterView.SetupGet(v => v.UseScanner).Returns(false);
            _deliveryBusinessMock.Setup(v => v.SaveDeliveryDetail(It.IsAny<DeliveryDetail>())).Returns(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage);
            _mockPresenterView.Setup(v => v.ShowMessage(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage));
            _mockPresenterView.Setup(v => v.LoadDelivery(It.IsAny<DeliveryDetail>()));
        
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _presenter.SaveDeliveryDetail(deliveryDetails);

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
            _deliveryBusinessMock.VerifyAll();
        }

        [TestMethod]
        public void SaveDeliveryDetail_Given_ItemIsDamageAndOthers_Test()
        {
            var deliveryDetails = new DeliveryDetail
            {
                Delivery = _delivery,
                Quantity = 100,
                Status = (int)ProductStatus.Goods,
                Price = _productDetails[0].OverrideCost.HasValue ? _productDetails[0].OverrideCost.Value : 500.50

            };

            _delivery.DeliveryDetails.Add(deliveryDetails);

            _mockPresenterView.Setup(v => v.GetSelectedColor()).Returns(_productDetails[0].Color);
            _mockPresenterView.Setup(v => v.GetSelectedSize()).Returns(_productDetails[0].Size);
            _mockPresenterView.Setup(v => v.GetSelectedWashing()).Returns(_productDetails[0].Washing);
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);
            _mockPresenterView.Setup(v => v.GetQuantity()).Returns(deliveryDetails.Quantity);
            _mockPresenterView.Setup(v => v.GetStockNumber()).Returns(_productDetails[0].Product.StockNumber);
            _productDetailMock.Setup(p => p.SelectByPrimaryId(_productDetails[0].Code)).Returns(_productDetails[0]);
            _mockPresenterView.Setup(v => v.GetPrice()).Returns(deliveryDetails.Price);
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damaged);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("Sample Status");
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Others);
            _deliveryBusinessMock.Setup(v => v.SaveDeliveryDetail(It.IsAny<DeliveryDetail>())).Returns(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage);
            _mockPresenterView.Setup(v => v.ShowMessage(DeliveryBusinessModel.DeliveryDetailSuccessfulMessage));
            _mockPresenterView.Setup(v => v.LoadDelivery(It.IsAny<DeliveryDetail>()));
          
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _presenter.SaveDeliveryDetail(deliveryDetails);

            _mockPresenterView.VerifyAll();
            _productDetailMock.VerifyAll();
            _deliveryBusinessMock.VerifyAll();
        }

        [TestMethod]
        public void InitialLoad_EditMode_Test()
        {
            _supplierMock.Setup(s => s.SelectAll()).Returns(_suppliers);
            _mockPresenterView.Setup(v => v.LoadSuppliers(It.IsAny<List<Supplier>>()));
            _colorMock.Setup(c => c.SelectAll()).Returns(_colors);
            _sizeMock.Setup(s => s.SelectAll()).Returns(_sizes);
            _washingMock.Setup(w => w.SelectAll()).Returns(_washings);
            _mockPresenterView.Setup(m => m.LoadWashings(It.IsAny<List<Washing>>()));
            _mockPresenterView.Setup(m => m.LoadSizes(It.IsAny<List<Size>>()));
            _mockPresenterView.Setup(m => m.LoadColors(It.IsAny<List<Color>>()));
            _mockPresenterView.Setup(v => v.LoadProductStatusIntoForm(It.IsAny<List<ProductStatus>>()));
            _mockPresenterView.Setup(v => v.LoadDamageIntoForm(It.IsAny<List<Damage>>()));
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryButton(true));
            _mockPresenterView.Setup(v => v.EnableProductDetailsGroup(It.IsAny<bool>()));
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(true);
            _mockPresenterView.Setup(v => v.DisabledProductDetail(true));
            _mockPresenterView.Setup(v => v.RenameStockOrCodeLabel("Barcode:"));
            _mockPresenterView.Setup(v => v.ClearProductDetailControls());
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));

            _presenter.InitialLoad(_delivery);

            _supplierMock.VerifyAll();
            _mockPresenterView.VerifyAll();
            _colorMock.VerifyAll();
            _sizeMock.VerifyAll();
            _washingMock.Verify();
        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_GivenAllInputsIsValid_Test()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("XXL");
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("Biowashing");
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns("White");
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damaged);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Others);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("Sample");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));

            _presenter.DisableOrEnableSaveDeliveryDetailButton();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_GivenInputIsGoodTest()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("XXL");
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("Biowashing");
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns("White");
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Goods);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Others);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("Sample");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));

            _presenter.DisableOrEnableSaveDeliveryDetailButton();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_GivenInputDamageIsFabric_Test()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("XXL");
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("Biowashing");
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns("White");
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damaged);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Fabric);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));

            _presenter.DisableOrEnableSaveDeliveryDetailButton();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_GivenInputDamageIsFabricAndEmptyDescription_Test()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("XXL");
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("Biowashing");
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns("White");
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Damaged);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Others);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(true));

            _presenter.DisableOrEnableSaveDeliveryDetailButton();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void DisableOrEnableSaveDeliveryButton_GivenInputDamageSizeIsNull_Test()
        {
            _mockPresenterView.Setup(v => v.GetSizeCode()).Returns("");
            _mockPresenterView.Setup(v => v.GetWashingCode()).Returns("Biowashing");
            _mockPresenterView.Setup(v => v.GetColorCode()).Returns("White");
            _mockPresenterView.Setup(v => v.GetProductStatus()).Returns(ProductStatus.Goods);
            _mockPresenterView.Setup(v => v.GetDamage()).Returns(Damage.Fabric);
            _mockPresenterView.Setup(v => v.GetStatusDescription()).Returns("");
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));

            _presenter.DisableOrEnableSaveDeliveryDetailButton();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void SwitchSearchMode_GivenTrue_Test()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(true);
            _mockPresenterView.Setup(v => v.DisabledProductDetail(true));
            _mockPresenterView.Setup(v => v.RenameStockOrCodeLabel("Barcode:"));
            _mockPresenterView.Setup(v => v.ClearProductDetailControls());
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _presenter.OnSelectBarcodeSwitch();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void SwitchSearchMode_GivenFalse_Test()
        {
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);          
            _mockPresenterView.Setup(v => v.DisabledProductDetail(false));
            _mockPresenterView.Setup(v => v.RenameStockOrCodeLabel("Stock Number:"));
            _mockPresenterView.Setup(v => v.ClearProductDetailControls());
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            _presenter.OnSelectBarcodeSwitch();

            _mockPresenterView.VerifyAll();
        }

        [TestMethod]
        public void UseScannerIsOn_Test()
        {
            _mockPresenterView.Setup(v => v.ShowScannerWindow(true));
            _mockPresenterView.Setup(v => v.SetSelectByBarcodeTo(true));
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(true);
            _mockPresenterView.Setup(v => v.DisabledProductDetail(true));
            _mockPresenterView.Setup(v => v.RenameStockOrCodeLabel("Barcode:"));
            _mockPresenterView.Setup(v => v.ClearProductDetailControls());
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            //_presenter.UsingScanner(true);
            _mockPresenterView.VerifyAll();

        }

        [TestMethod]
        public void UseScannerIsOff_Test()
        {
            _mockPresenterView.Setup(v => v.ShowScannerWindow(false));
            _mockPresenterView.Setup(v => v.SetSelectByBarcodeTo(false));
            _mockPresenterView.Setup(v => v.GetSelectByProductCode()).Returns(false);
            _mockPresenterView.Setup(v => v.DisabledProductDetail(false));
            _mockPresenterView.Setup(v => v.RenameStockOrCodeLabel("Stock Number:"));
            _mockPresenterView.Setup(v => v.ClearProductDetailControls());
            _mockPresenterView.Setup(v => v.EnableSaveDeliveryDetailButton(false));
            //_presenter.UsingScanner(false);
            _mockPresenterView.VerifyAll();

        }

    }
}
