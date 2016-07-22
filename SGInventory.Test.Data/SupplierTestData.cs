using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class SupplierTestData : TestDataBase<Supplier>
    {
        public SupplierTestData()
        {
            _entities = new List<Supplier> { new Supplier { Name = "SupplierA", Address = "", Id = 1 }, new Supplier { Name = "SupplierB", Address = "", Id = 2 } };
            _entity = _entities[0];
        }
    }
}
