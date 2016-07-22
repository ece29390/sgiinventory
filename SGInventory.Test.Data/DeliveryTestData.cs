using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Helpers;

namespace SGInventory.Test.Data
{
    public class DeliveryTestData:TestDataBase<Delivery>
    {
        Product _parentProduct;
        public DeliveryTestData()
        {            
            var productDetailTestData = new ProductDetailTestData();
            var productDetail = productDetailTestData.GetEntity();
            _parentProduct = productDetail.Product;
            base._entity=new Delivery
            {
                DeliveryDate=new DateTime(2013,03,15),
                OrNumber="RCPT101",               
                Supplier = (new SupplierTestData()).GetEntity(),
               DeliveryDetails=new List<DeliveryDetail>{
                    new DeliveryDetail{                       
                        Quantity=1200,                       
                        Status=(int)ProductStatus.Goods,                       
                        //Product = productDetail.Product,
                        ProductDetail=productDetail
                    }               
               }
            };

            AddMoreData();
            base._entities.Add(base._entity);
        }

        public ProductDetails CreateProductDetail(Color color, Washing washing, Size size)
        {
            var productDetail = new ProductDetails
            {
                Color=color,
                Washing=washing,
                Size=size,
                Code = SgiHelper.GetProductDetailCode(_parentProduct.StockNumber,
                 color.Code,
                 washing.Code,
                 size.Code)
            };

            return productDetail;
        }

        private void AddMoreData()
        {
            var color = new Color { Code = "000", Name = "No Color" };
            var washing = new Washing { Code = "0", Name = "Biowashing" };
            var size = new Size { Code = "02", Name = "02" };
                      
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {                
                Id = 2,
                Quantity = 98,                
                Status = (int)ProductStatus.Goods,
                ProductDetail = CreateProductDetail(color, washing, size)//,
                //Product=_parentProduct
            });

             color = new Color { Code = "000", Name = "No Color" };
             washing = new Washing { Code = "0", Name = "Biowashing" };
             size = new Size { Code = "04", Name = "04" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {
             
                Id = 3,
                Quantity = 10,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product=_parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "000", Name = "No Color" };
            washing = new Washing { Code = "0", Name = "Biowashing" };
            size = new Size { Code = "06", Name = "06" };
            
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {               
                Id = 4,
                Quantity = 40,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "000", Name = "No Color" };
            washing = new Washing { Code = "0", Name = "Biowashing" };
            size = new Size { Code = "08", Name = "08" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {              
                Id = 5,
                Quantity = 50,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "000", Name = "No Color" };
            washing = new Washing { Code = "0", Name = "Biowashing" };
            size = new Size { Code = "10", Name = "10" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {              
                Id = 6,
                Quantity = 98,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "000", Name = "No Color" };
            washing = new Washing { Code = "0", Name = "Biowashing" };
            size = new Size { Code = "12", Name = "12" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {              
                Id = 7,
                Quantity = 65,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "001", Name = "Navy Blue" };
            washing = new Washing { Code = "1", Name = "M1" };
            size = new Size { Code = "02", Name = "02" };
            //row 3
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {            
                Id = 8,
                Quantity = 20,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            size = new Size { Code = "04", Name = "04" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {                
                Id = 9,
                Quantity = 30,
                ProductDetail = CreateProductDetail(color, washing, size),
               // Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            size = new Size { Code = "06", Name = "06" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {              
                Id = 10,
                Quantity = 40,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "001", Name = "Navy Blue" };
            washing = new Washing { Code = "1", Name = "M1" };
            size = new Size { Code = "08", Name = "08" };

            _entity.DeliveryDetails.Add(new DeliveryDetail
            {               
                Id = 11,
                Quantity = 50,
                ProductDetail = CreateProductDetail(color, washing, size),
               // Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "001", Name = "Navy Blue" };
            washing = new Washing { Code = "1", Name = "M1" };
            size = new Size { Code = "10", Name = "10" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {               
                Id = 12,
                Quantity = 60,
                ProductDetail = CreateProductDetail(color, washing, size),
               // Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "001", Name = "Navy Blue" };
            washing = new Washing { Code = "4", Name = "Expose Dark" };
            size = new Size { Code = "12", Name = "12" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {               
                Id = 13,
                Quantity = 70,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            color = new Color { Code = "001", Name = "Navy Blue" };
            washing = new Washing { Code = "1", Name = "M1" };
            size = new Size { Code = "12", Name = "12" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {
               
                Id = 14,
                Quantity = 45,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Goods
            });

            //damage
            color = new Color { Code = "002", Name = "Khaki" };
            washing = new Washing { Code = "1", Name = "M1" };
            size = new Size { Code = "01", Name = "12" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {               
                Id = 15,
                Quantity = 5,
                ProductDetail = CreateProductDetail(color, washing, size),
                //Product = _parentProduct,
                Status = (int)ProductStatus.Damaged,
                Damage = (int)Damage.Stain                
            });

            //damage
            color = new Color { Code = "003", Name = "White" };
            washing = new Washing { Code = "4", Name = "Expose Dark" };
            size = new Size { Code = "01", Name = "12" };
            _entity.DeliveryDetails.Add(new DeliveryDetail
            {                
                Id = 16,
                Quantity = 10,
                ProductDetail = CreateProductDetail(color, washing, size),
               // Product = _parentProduct,
                Status = (int)ProductStatus.Damaged,
                Damage = (int)Damage.Fabric   
            });
        }
    }
}
