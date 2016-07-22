using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public  class Supplier:IIdentityIntEntity,IName,IAddress,IAuditHistory
    {
        public virtual int Id
        {
            get;
             set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Address
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
    }
}
