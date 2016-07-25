using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Enums;
using System.Linq.Expressions;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Extensions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SGInventory.Presenters.Model;
using SGInventory.Presenters.Utilities;
using SGInventory.Views.UIModel;

namespace SGInventory.Presenters
{
    public class DeliveryPresenter:DeliveryPresenterBase
    {
        private IDeliveryPresenterView _deliveryPresenterView;
        private ISupplierBusinessModel _supplierBusinessModel;
        private IProductBusinessModel _productBusinessModel;      
        private IProductDetailBusinessModel _productDetailBusinessModel;
        private IColorBusinessModel _colorBusinessModel;
        private ISizeBusinessModel _sizeBusinessModel;
        private IWashingBusinessModel _washingBusinessModel;
        private IDeliveryBusinessModel _deliveryBusinessModelHelper;
        
        private ISupplierBusinessModel supplierBusinessModel;
        private IProductBusinessModel productBusinessModel;
        private IProductDetailBusinessModel productDetailBusinessModel;
        private IColorBusinessModel colorBusinessModel;
        private ISizeBusinessModel sizeBusinessModel;
        private IWashingBusinessModel washingBusinessModel;
        private IDeliveryBusinessModel deliveryBusinessModel;
        private bool useScanner;
        private Views.UIModel.SupplierDeliveryViewModel _viewModel;
        
        public List<Supplier> Suppliers { get;  set; }
        
        public Delivery Delivery{get; set;}
        public List<string> SizeCodes { get; set; }
        public List<string> ColorCodes { get; set; }
        public Dictionary<int, DeliveryGridModel> DeliveryGridModelByHashCode{get;set;}
        public Dictionary<string, DeliveryGridModel> DamageDeliveryGridModelByDescription { get; set; }
        public List<string> DamageDescriptions { get; set; }

        public DeliveryPresenter(
            IDeliveryPresenterView deliveryPresenterView
            , ISupplierBusinessModel supplierBusinessModel
            , IProductBusinessModel productBusinessModel
            , IProductDetailBusinessModel productDetailBusinessModel
            , IColorBusinessModel colorBusinessModel
            , ISizeBusinessModel sizeBusinessModel
            , IWashingBusinessModel washingBusinessModel
            , IDeliveryBusinessModel deliveryBusinessModel          
            , SupplierDeliveryViewModel viewModel
            ):base(productBusinessModel,productDetailBusinessModel,colorBusinessModel,sizeBusinessModel,washingBusinessModel, deliveryPresenterView,true)
        {          
            _deliveryPresenterView = deliveryPresenterView;
            _supplierBusinessModel = supplierBusinessModel;
            _productBusinessModel = productBusinessModel;
            _productDetailBusinessModel = productDetailBusinessModel;
            _sizeBusinessModel = sizeBusinessModel;
            _washingBusinessModel = washingBusinessModel;
            _colorBusinessModel = colorBusinessModel;
            _deliveryBusinessModelHelper = deliveryBusinessModel;

            _viewModel = viewModel;

            Suppliers = new List<Supplier>();

            Delivery = new Delivery();
            SizeCodes = new List<string>();
            ColorCodes = new List<string>();
            DeliveryGridModelByHashCode = new Dictionary<int, DeliveryGridModel>();
            DamageDeliveryGridModelByDescription=new Dictionary<string,DeliveryGridModel>();
            DamageDescriptions = new List<string>();            
        }

      
            
        public void LoadSuppliers()
        {
            Suppliers = _supplierBusinessModel.SelectAll();
            _deliveryPresenterView.LoadSuppliers(Suppliers);
        }
              
        public void LoadProductDetail()
        {         
            GetProductDetailCost();
        }
       
        public void LoadProductStatus()
        {           
           var listOfStatus = SgiHelper.ConvertEnumToList<ProductStatus>(
                                            () => Enum.GetValues(typeof(ProductStatus)),
                                            (enumItem) => (ProductStatus)enumItem);
           _deliveryPresenterView.LoadProductStatusIntoForm(listOfStatus);
        }

        public void SelectProductStatus(ProductStatus productStatus)
        {
            _deliveryPresenterView.ShouldEnableDamageDetailGroup(productStatus == ProductStatus.Damaged);
        }

        public override void DisableOrEnableSaveDeliveryButton()
        {
            var supplierName = _deliveryPresenterView.GetSupplierName();
            var orNumber = _deliveryPresenterView.GetOrNumber();

            var enable = !string.IsNullOrEmpty(supplierName) &&
                     !string.IsNullOrEmpty(orNumber);

            if (enable)
            {
                enable = Suppliers.Where(s => string.Equals(s.Name, supplierName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0 ? true : false;
            }
          
            _deliveryPresenterView.EnableSaveDeliveryButton(enable);

        }

        public void Save(Delivery delivery=null)
        {
            var sizeName = _deliveryPresenterView.GetSizeCode();
            var washingName = _deliveryPresenterView.GetWashingCode();
            var colorName = _deliveryPresenterView.GetColorCode();
            var quantity = _deliveryPresenterView.GetQuantity();
            var status = _deliveryPresenterView.GetProductStatus();
            var description = _deliveryPresenterView.GetStatusDescription();
            var stockNumber = _deliveryPresenterView.GetStockNumber();
            var product = _productBusinessModel.SelectByPrimaryId(stockNumber);

            if (delivery == null)
            {
                var supplierName = _deliveryPresenterView.GetSupplierName();
                var orNumber = _deliveryPresenterView.GetOrNumber();
                                                         
                var supplier = Suppliers.Where(s => s.Name.Equals(supplierName, StringComparison.InvariantCultureIgnoreCase)).ToList<Supplier>()[0];

                delivery = new Delivery
                {
                    OrNumber = orNumber,
                    DeliveryDate = _deliveryPresenterView.GetDeliveryDate(),
                    Supplier = supplier,                  
                    DeliveryDetails=new List<DeliveryDetail>()
                };
                
            }
            Delivery = delivery;
            var color = SgiHelper.SelectModelByNameInTheCollection<Color>(Colors, colorName);
            var washing = SgiHelper.SelectModelByNameInTheCollection<Washing>(Washings, washingName);
            var size = SgiHelper.SelectModelByNameInTheCollection<Size>(Sizes, sizeName);

            var productDetail = _productDetailBusinessModel.SelectByPrimaryId(SgiHelper.GetProductDetailCode(
                product.StockNumber,
                color.Code,
                washing.Code,
                size.Code));
                

            delivery.DeliveryDetails.Add(new DeliveryDetail
                                    {
                                        ProductDetail=productDetail,                                      
                                        Quantity = quantity,
                                        Status = (int)status,
                                        StatusDescription = description
                                       // ,Product = new Product { StockNumber = stockNumber }
                                    });

           

           var message =  _deliveryBusinessModelHelper.Save(delivery);

            var lastIndex = delivery.DeliveryDetails.ToList().GetLastIndex();
            _deliveryPresenterView.LoadDelivery(delivery.DeliveryDetails[lastIndex]);
            _deliveryPresenterView.ShowMessage(message);            
        }
                                                                 
        public void SaveDelivery(SGInventory.Model.Delivery delivery)
        {
            var supplierName = _viewModel.Supplier;
            var drNumber = _viewModel.DrNumber;
            var deliveryDate = _viewModel.DeliveryDate;

            var supplier = Suppliers.Where(s => s.Name == supplierName).First<Supplier>();

            if (delivery == null)
            {
                delivery = new Delivery
                {
                    CreatedDate = DateTime.Now,
                    CreatedBy = SgiHelper.GetIdentityUserName(),
                    DeliveryDate = deliveryDate,
                    DeliveryDetails = new List<DeliveryDetail>(),
                    OrNumber = drNumber,
                    Supplier = supplier
                };
            }
            else
            {
                delivery.Supplier = supplier;
                delivery.OrNumber = drNumber;
                delivery.DeliveryDate = deliveryDate;
            }

            var message = _deliveryBusinessModelHelper.SaveInTransaction(delivery);

            this.Delivery = delivery;
           
            _deliveryPresenterView.ShowMessage(message);
                                        
        }

        public void StoreDeliveryDetailToDelivery(ref SGInventory.Model.Delivery delivery)
        {
            var itemCount = delivery != null ? (delivery.DeliveryDetails != null ? delivery.DeliveryDetails.Count : 0) : 0;

            if (!IsTheNumberOfItemsStillAllowed(itemCount))
            {
                _deliveryPresenterView.ShowMessage("The number of items for incoming delivery has already been reached");
                return;
            }

            var deliveryDetail = new DeliveryDetail();

            deliveryDetail.Price = _deliveryPresenterView.GetPrice();
            deliveryDetail.Quantity = _deliveryPresenterView.GetQuantity();
            deliveryDetail.Status = (int)_deliveryPresenterView.GetProductStatus();

            var productStatus = _deliveryPresenterView.GetProductStatus();
            if (productStatus == ProductStatus.Damaged)
            {
                var damage = _deliveryPresenterView.GetDamage();
                deliveryDetail.Damage = (int)damage;
                if (damage == Damage.Others)
                {
                    deliveryDetail.StatusDescription = _deliveryPresenterView.GetStatusDescription();
                }

            }

            var stocknumberOrBarcode = _deliveryPresenterView.GetStockNumber();

            if (deliveryDetail.Id <= 0)
            {
                if (!_deliveryPresenterView.GetSelectByProductCode())
                {                   
                    var color = _deliveryPresenterView.GetSelectedColor();
                    if (color == null)
                    {
                        _deliveryPresenterView.ShowMessage("Color is invalid");
                        return;
                    }
                    var size = _deliveryPresenterView.GetSelectedSize();
                    if (size == null)
                    {
                        _deliveryPresenterView.ShowMessage("Size is invalid");
                        return;
                    }
                    var washing = _deliveryPresenterView.GetSelectedWashing();
                    if (washing == null)
                    {
                        _deliveryPresenterView.ShowMessage("Washing is invalid");
                        return;
                    }                    
                    stocknumberOrBarcode = SgiHelper.GetProductDetailCode(
                    stocknumberOrBarcode, color.Code, washing.Code, size.Code);
                }

                var productDetail = _productDetailBusinessModel.SelectByPrimaryId(stocknumberOrBarcode);

                if (productDetail == null || productDetail.IsActive == 0)
                {
                    _deliveryPresenterView.ShowMessage("Product Detail Doesn't Exists or inactive!");
                    return;
                }

                deliveryDetail.ProductDetail = productDetail;
            }

            if (delivery == null)
            {
                var supplier = Suppliers.Where(s => s.Name == _deliveryPresenterView.GetSupplierName()).First<Supplier>();
                delivery = new Delivery
                {
                    CreatedDate = DateTime.Now,
                    CreatedBy = SgiHelper.GetIdentityUserName(),
                    DeliveryDate = _deliveryPresenterView.GetDeliveryDate(),
                    DeliveryDetails = new List<DeliveryDetail>(),
                    OrNumber = _deliveryPresenterView.GetOrNumber(),
                    Supplier = supplier
                };

                
            }

            bool isDeliveryAlreadyExists = _deliveryPresenterView.DeliveryAlreadyExists(stocknumberOrBarcode, deliveryDetail.Status,deliveryDetail.Damage);

            if (isDeliveryAlreadyExists)
            {
                _deliveryPresenterView.ShowMessage("Delivery already exists in the panel, you may change it by clicking the \"Edit Deliveries\" button");
                return;
            }

            if (delivery.DeliveryDetails != null && delivery.DeliveryDetails.Count > 0)
            {
                var previousStockNumber = delivery.DeliveryDetails.First().ProductDetail.Product.StockNumber;
                var currentStockNumber = deliveryDetail.ProductDetail.Product.StockNumber;
                if (currentStockNumber != previousStockNumber)
                {
                    _deliveryPresenterView.ShowMessage("Only one stock number per dr number is allowed!");
                    return;
                }
            }

            deliveryDetail.Delivery = delivery;
            delivery.DeliveryDetails.Add(deliveryDetail);
            
            _deliveryPresenterView.LoadToDeliveryDetailGrid(delivery);

            SetStocknumber(delivery);
        }
        
        public void SaveDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            deliveryDetail.Price = _deliveryPresenterView.GetPrice();
            deliveryDetail.Quantity = _deliveryPresenterView.GetQuantity();
            deliveryDetail.Status = (int)_deliveryPresenterView.GetProductStatus();

            if (_deliveryPresenterView.GetProductStatus() == ProductStatus.Damaged)
            {
                var damage = _deliveryPresenterView.GetDamage();
                deliveryDetail.Damage = (int)damage;
                if (damage == Damage.Others)
                {
                    deliveryDetail.StatusDescription = _deliveryPresenterView.GetStatusDescription();
                }

            }

            var stockNumber = _deliveryPresenterView.GetStockNumber();

            if (deliveryDetail.Id <= 0)
            {
                if (!_deliveryPresenterView.GetSelectByProductCode())
                {
                    var color = _deliveryPresenterView.GetSelectedColor();
                    var size = _deliveryPresenterView.GetSelectedSize();
                    var washing = _deliveryPresenterView.GetSelectedWashing();
                    stockNumber = SgiHelper.GetProductDetailCode(
                    stockNumber, color.Code, washing.Code, size.Code);
                }

                var productDetail = _productDetailBusinessModel.SelectByPrimaryId(stockNumber);

                if (productDetail == null || productDetail.IsActive == 0)
                {
                    _deliveryPresenterView.ShowMessage("Product Detail Doesn't Exists or inactive!");
                    return;
                }

                deliveryDetail.ProductDetail = productDetail;
            }

            var message = _deliveryBusinessModelHelper.SaveDeliveryDetail(deliveryDetail);
                  
          

        }
        
        public void GetProductDetailCost()
        {
            base.LoadProductDetailOnChangesInSizeOrWashingOrColor((productDetail) => 
            {
                if (productDetail.OverrideCost.HasValue)
                {
                    _deliveryPresenterView.SetDeliveryDetailItemCost(productDetail.OverrideCost.Value);
                }
                else
                {
                    _deliveryPresenterView.SetDeliveryDetailItemCost(productDetail.Product.Cost);
                }
            });            
        }
       
        public void InitialLoad(SGInventory.Model.Delivery _delivery)
        {                     
            LoadSuppliers();
            LoadAllProductDetails();
            LoadProductStatus();
            LoadDamage();
            
            if (_delivery != null)
            {
             
               
            }

            _deliveryPresenterView.EnableEditMenu(_delivery == null ? false : true);
         
        }

        public void LoadDamage()
        {
            var damages = SgiHelper.ConvertEnumToList<Damage>(
                () => Enum.GetValues(typeof(Damage)),
                (item) => (Damage)item);
            _deliveryPresenterView.LoadDamageIntoForm(damages);
        }

        public void SelectDamage(Damage damage)
        {
            _deliveryPresenterView.ShouldEnableStatusDescription(damage == Damage.Others);
        }

        public override void DisableOrEnableSaveDeliveryDetailButton()
        {
            var rowCount = _deliveryPresenterView.GetRowCount();            
            var productStatus = _deliveryPresenterView.GetProductStatus();
            var damage = _deliveryPresenterView.GetDamage();
            var damageDescription = _deliveryPresenterView.GetStatusDescription();

            var rowCountFlag = rowCount > 0 ? "1" : "0";
            var productStatusFlag = productStatus == ProductStatus.Damaged ? "1" : "0";
            var damageFlag = damage == Damage.Others ? "1" : "0";
            var damageDescriptionFlag = !string.IsNullOrEmpty(damageDescription) ? "1" : "0";

            var overAllFlag = string.Concat(rowCountFlag, productStatusFlag, damageFlag, damageDescriptionFlag);

            switch (overAllFlag)
            {   
                case "1100":
                case "1101":
                case "1111":
                case "1110":
                    _deliveryPresenterView.EnableSaveDeliveryDetailButton(true);
                    break;
                default:
                    if (overAllFlag.StartsWith("10"))
                    {
                        _deliveryPresenterView.EnableSaveDeliveryDetailButton(true);
                    }
                    else
                    {
                        _deliveryPresenterView.EnableSaveDeliveryDetailButton(false);
                    }

                    
                    break;
            }


        }
                      
        public void SupplierDetailChange()
        {
            var supplierName = _deliveryPresenterView.GetSupplierName();
            var drNumber = _deliveryPresenterView.GetOrNumber();

            if (!string.IsNullOrEmpty(supplierName) && !string.IsNullOrEmpty(drNumber))
            {
                _deliveryPresenterView.EnableProductDetailsGroup(true);
            }
            else
            {
                _deliveryPresenterView.EnableProductDetailsGroup(false);
            }
        }

        public void BuildDeliveryInPanel(SGInventory.Model.Delivery delivery, DataGridView gvDeliveryDetails)
        {
            var goodDeliveries = CreateMergeGoodSupplierDelivery(delivery);
            var badDeliveries = CreateMergeBadSupplierDelivery(delivery);

            var deliveryGridConstructor = new DeliveryGridConstructor();

            gvDeliveryDetails.Rows.Clear();
            gvDeliveryDetails.Columns.Clear();

            if(goodDeliveries.Count>0)
            {
                deliveryGridConstructor.CreateDeliveries(goodDeliveries, gvDeliveryDetails, "Good");//CreateGoodDeliveries(goodDeliveries, gvDeliveryDetails);
            }

            if (badDeliveries.Count > 0)
            {
                deliveryGridConstructor.CreateDeliveries(badDeliveries, gvDeliveryDetails, "Damage");//CreateBadDeliveries(badDeliveries, gvDeliveryDetails);
            }

            deliveryGridConstructor.SummarizeGridDisplay(gvDeliveryDetails);
            
        }

        private List<DeliveryDetail> CreateMergeGoodDeliveryDetails(Delivery delivery)
        {
            var goodDeliveries = (from deliveryDetail in delivery.DeliveryDetails
                                  where deliveryDetail.Status == (int)ProductStatus.Goods
                                  group deliveryDetail by
                                  new
                                  {
                                      Color = deliveryDetail.ProductDetail.Color.Name,
                                      StockNumber = deliveryDetail.ProductDetail.Product.StockNumber,
                                      Size = deliveryDetail.ProductDetail.Size.Name,
                                      Condition = deliveryDetail.Status,
                                      Damage = deliveryDetail.Damage.HasValue ? deliveryDetail.Damage.Value : 0
                                  }
                                      into deliveryDetailGroup
                                      select new DeliveryDetail
                                      {
                                          Status = deliveryDetailGroup.Key.Condition,
                                          Quantity = deliveryDetailGroup.Sum(dd => dd.Quantity),
                                          ProductDetail = new ProductDetails
                                          {
                                              Product = new Product{StockNumber = deliveryDetailGroup.Key.StockNumber},
                                              Color = new Color { Name = deliveryDetailGroup.Key.Color },
                                              Size = new Size { Name = deliveryDetailGroup.Key.Size }
                                          },

                                      }).ToList();

            return goodDeliveries;
        }

        private List<SupplierDelivery> CreateMergeGoodSupplierDelivery(Delivery delivery)
        {
            var goodDeliveries = (from deliveryDetail in delivery.DeliveryDetails
                                  where deliveryDetail.Status == (int)ProductStatus.Goods
                                  && deliveryDetail.IsActive == 1
                                  group deliveryDetail by
                                  new
                                  {
                                      Color = deliveryDetail.ProductDetail.Color.Name,                                      
                                      Size = deliveryDetail.ProductDetail.Size.Name,  
                                      Id = deliveryDetail.ProductDetail.Code//,
                                      //Quantity = deliveryDetail.Quantity
                                  }
                                      into deliveryDetailGroup
                                      select new SupplierDelivery
                                      {
                                          Quantity = deliveryDetailGroup.Sum(d=>d.Quantity),
                                          ProductDescription = deliveryDetailGroup.Key.Color,
                                          SizeName = deliveryDetailGroup.Key.Size

                                      }).ToList();

            return goodDeliveries;
        }

        private List<SupplierDelivery> CreateMergeBadSupplierDelivery(Delivery delivery)
        {

            var badDeliveries = delivery.DeliveryDetails.Where(dd=>dd.Status ==(int)ProductStatus.Damaged && dd.IsActive ==1).ToList();               
            
            var deliveryDict = new Dictionary<string,int>();

            foreach(var deliveryDetail in badDeliveries)
            {
                var key = string.Format("{0}-{1}",deliveryDetail.Damage.Value,deliveryDetail.ProductDetail.Size.Name);
                if(deliveryDict.ContainsKey(key))
                {
                    deliveryDict[key]=deliveryDetail.Quantity+deliveryDict[key];
                }
                else
                {
                    deliveryDict.Add(key,deliveryDetail.Quantity);
                }
            }

            var retBadDeliveries = new List<SupplierDelivery>();

            foreach (var key in deliveryDict.Keys)
            {
                var keys = key.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                retBadDeliveries.Add(new SupplierDelivery {SizeName = keys[1],ProductDescription = Enum.GetName(typeof(Damage),Convert.ToInt32(keys[0])),Quantity = deliveryDict[key] });
            }

            return retBadDeliveries;
        }

        private List<DeliveryDetail> CreateMergeBadDeliveryDetails(Delivery delivery)
        {
            
            var badDeliveries = (from deliveryDetail in delivery.DeliveryDetails
                                  where deliveryDetail.Status == (int)ProductStatus.Damaged
                                  group deliveryDetail by
                                  new
                                  {
                                      Size = deliveryDetail.ProductDetail.Size.Name,
                                      Damage = deliveryDetail.Damage.Value
                                  }
                                  into deliveryDetailGroup
                                    select new DeliveryDetail
                                    {
                                        Quantity = deliveryDetailGroup.Sum(d=>d.Quantity),
                                        Damage = deliveryDetailGroup.Key.Damage

                                    }).ToList();

            return badDeliveries;
        }

        public void SetStocknumber(Delivery delivery)
        {
            if (delivery.DeliveryDetails != null && delivery.DeliveryDetails.Count > 0)
            {
                var stockNumber = delivery.DeliveryDetails.First().ProductDetail.Product.StockNumber;
                _viewModel.SelectedStockNumber = stockNumber;
                _deliveryPresenterView.ResetViewBindings(true);
             
            }
        }

        public void LoadResultByCode(bool isBarcode, string productCode)
        {
            var result = LoadProductDetails(isBarcode, productCode);
            if (result == null || (result != null && result.Count == 0))
            {              
                _deliveryPresenterView.ShowMessage(string.Format("Code {0} not exists!", productCode));
                return;
            }

            _deliveryPresenterView.LoadResultToView(result);

            if (isBarcode)
            {
                _viewModel.ProductCode = productCode;
                _viewModel.SaveDeliveryEnable = true;
            }
           
        }
    }
}
