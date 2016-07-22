using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class ProductDetailTestData:TestDataBase<ProductDetails>
    {
        private string _stockNumber = "W-011",
                 _month = "C",
                 _year = "M",
                 _colorCode = "004",
                 _washingCode = "6",
                 _sizeCode = "S2";
        
        public ProductDetailTestData()
        {
            _entity = new ProductDetails
            {
                Code = string.Format("{0}{1}{2}{3}{4}{5}", "", "", _stockNumber.Replace("-",""), _colorCode, _washingCode, _sizeCode),
                Color = new Color { Code = _colorCode, Name = "Black", CreatedDate = DateTime.Now, CreatedBy = "sang", ModifiedBy = "sang", ModifiedDate = DateTime.Now },
                Washing = new Washing { Code = _washingCode, Name = "ORDINARY WASH / RAW WASH / RINSE WASH" },
                Size = new Size { Code = _sizeCode, Name = _sizeCode },
                QuantityOnHand = 250,             
                Product = new Product {StockNumber=_stockNumber }

            };

            _entities.Add(_entity);

        }

       
    }
}
