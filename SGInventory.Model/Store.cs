using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public class Store:ICode,IName,IAuditHistory
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedBy { get; set; }
    }
}
