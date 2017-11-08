using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class ProductInventoryView
    {
        public ProductInventoryView()
        {            
        }
        public virtual string StockNumber { get; set; }

        public virtual string ProductDetailCode { get; set; }

        public virtual string ColorName { get; set; }

        public virtual string WashingName { get; set; }

        public virtual string SizeName { get; set; }

        public virtual int Quantity { get; set; }

        
    }
}
