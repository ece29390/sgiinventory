using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Model
{
    public  class User:IIdentityIntEntity,IName,IAuditHistory
    {
        public virtual int Id
        {
            get;
             set;
        }

        public virtual string UserName
        {
            get;
            set;
        }

        public virtual string Password
        {
            get;
            set;
        }


        public virtual string Name
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


        public virtual int Roletype
        {
            get;
            set;
        }
    }
}
