using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class Sales : IIdentityIntEntity,ICreated,IModified
    {
        public Sales()
        {
            Quantity = 1;
        }
        public virtual ProductDetails ProductDetail { get; set; }

        public virtual int Quantity { get; set; }

        public virtual Outlet Outlet { get; set; }

        public virtual DateTime DateOfSales { get; set; }

        public virtual int Id
        {
            get;set;           
        }

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
        
        public virtual string TransactionNumber { get; set; } 
    }
}
