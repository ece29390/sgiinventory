using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class ProductTestData:TestDataBase<Product>
    {
        public ProductTestData()
        {
            _entity = new Product
            {
                StockNumber = "W-011",
                Description = "Sample",
                Category = new Category { Id = 2, Name = "Tops", Description = "Sample desc" },
                CreatedBy = "sang",
                CreatedDate = DateTime.Now,
                Cost = 50.50,
                RegularPrice = 55.50,
                MarkdownPrice = 51.50,
                ModifiedBy="sang",
                ModifiedDate=DateTime.Now
            };
            _entities = new List<Product> { _entity };
        }
    }
}
