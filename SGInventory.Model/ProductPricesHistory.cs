using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class ProductPricesHistory:ICreated,IIdentityIntEntity,IPrices
    {      
      
        public virtual int Id { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual Product StockNumber { get; set; }

        public virtual double Cost { get; set; }

        public virtual double RegularPrice { get; set; }

        public virtual double MarkdownPrice { get; set; }
    }
}
