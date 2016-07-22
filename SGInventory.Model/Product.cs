using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class Product:IAuditHistory,IDescription,IPrices
    {
        public virtual string StockNumber { get; set; }

        public virtual Category Category { get; set; }

        public virtual string CreatedBy
        {
            get;
            set;
        }

        public virtual DateTime CreatedDate
        {
            get;
            set;
        }

        public virtual string ModifiedBy
        {
            get;
            set;
        }

        public virtual DateTime? ModifiedDate
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual IList<ProductDetails> ProductDetails { get; set; }

        public virtual double Cost
        {
            get;
            set;
        }

        public virtual double RegularPrice
        {
            get;
            set;
        }

        public virtual double MarkdownPrice
        {
            get;
            set;
        }

        public virtual IList<ProductPricesHistory> PriceHistory
        {
            get;
            set;
        }
        
    }
}
