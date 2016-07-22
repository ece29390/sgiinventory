using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class Delivery:IIdentityIntEntity,ICreated
    {
        public Delivery()
        {
            DeliveryDetails = new List<DeliveryDetail>();
        }

        public virtual int Id { get; set; }

        public virtual string OrNumber { get; set; }

        public virtual DateTime DeliveryDate { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual IList<DeliveryDetail> DeliveryDetails { get; set; }
       
        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}
