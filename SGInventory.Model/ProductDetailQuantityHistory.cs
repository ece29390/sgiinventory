using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class ProductDetailQuantityHistory:IIdentityIntEntity,IBarcode,ICreated
    {
        public virtual int Id { get; set; }

        public virtual string Barcode { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string StockNumber { get; set; }
    }
}
