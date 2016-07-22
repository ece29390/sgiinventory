using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;

namespace SGInventory.Model
{
    public class DeliveryToOutlet : IIdentityIntEntity,IActive,ICreated,IModified
    {
        public virtual Outlet Outlet { get; set; }

        public virtual DateTime DeliveryDate { get; set; }

        public virtual string PackingListNumber { get; set; }

        public virtual IList<DeliveryToOutletDetail> DeliveryToOutletDetails { get; set; }

        public virtual int Id { get; set; }

        public virtual int IsActive
        {
            get;
            set;
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
      
        public DeliveryToOutlet()
        {
            IsActive = 1;
        }


    }
}
