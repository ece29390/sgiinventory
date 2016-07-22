using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class ProductDetails : IAuditHistory, IQuantity, ICode, IActive
    {
        public ProductDetails()
        {
            IsActive = 1;
        }
                           
        public virtual Color Color { get; set; }

        public virtual Washing Washing { get; set; }

        public virtual Size Size { get; set; }
     
        public virtual int QuantityOnHand { get; set; }

        public virtual Product Product { get; set; }
       
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

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string ImagePathName
        { get; set; }

        public virtual double? OverrideCost { get; set; }

        public virtual int IsActive { get; set; }

        public virtual IList<DeliveryDetail> DeliveryDetails { get; set; }

        public virtual IList<DeliveryToOutletDetail> DeliveryToOutletDetails { get; set; }

        public virtual IList<Sales> Sales { get; set; }

    }
}
