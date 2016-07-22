using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters.Model
{
    public class ProductSearchDisplayModel
    {
        public string StockNumber { get; set; }

        public double Cost { get; set; }

        public double RegularPrice { get; set; }

        public double MarkdownPrice { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string ColorCode { get; set; }

        public string WashingCode { get; set; }

        public string WashingName { get; set; }

        public string ColorName { get; set; }
    }
}
