using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class DeliveryToOutletDetail : IIdentityIntEntity, IActive,IRemarks,IDelivery
    {
        public virtual int Id
        {
            get;
            set;
        }

        public virtual int IsActive
        {
            get;
            set;
        }

        public virtual DeliveryToOutlet DeliveryToOutlet { get; set; }

        public virtual ProductDetails ProductDetail { get; set; }

        public virtual double SuggestedRetailPrice { get; set; }

        public virtual int Quantity { get; set; }

        public DeliveryToOutletDetail()
        {
            IsActive = 1;
        }

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

        public virtual string AdjustmentRemarks { get; set; }

        public virtual int Status { get; set; }

        public virtual int? AdjustmentMode { get; set; }
    }
}
