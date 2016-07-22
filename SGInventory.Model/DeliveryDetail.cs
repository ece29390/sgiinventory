using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class DeliveryDetail:IIdentityIntEntity,IActive,IRemarks,IDelivery
    {
        public DeliveryDetail()
        {
            IsActive = 1;
        }
        public virtual int Id { get; set; }
       
        public virtual ProductDetails ProductDetail { get; set; }

        public virtual int Quantity { get; set; }

        public virtual int Status { get; set; }

        public virtual string StatusDescription { get; set; }

        public virtual int? Damage { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual double Price { get; set; }
        
        public virtual int IsActive { get; set; }

        public virtual string AdjustmentRemarks { get; set; }

        public virtual string Remarks
        {
            get;
            set;
        }

        public virtual DateTime? AdjustmentDate
        {
            get;
            set;
        }

        public virtual int? AdjustmentMode { get; set; }
    }
}
