using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.DAL
{
    public class ProductInventoryView
    {
        public string StockNumber { get; set; }

        public string ProductDetailCode { get; set; }

        public string ColorName { get; set; }

        public string WashingName { get; set; }

        public string SizeName { get; set; }

        public int Quantity { get; set; }

        public string ViewHistory { get { return "View History"; } }
    }
}
