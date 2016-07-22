using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model.Exception
{
    public class InvalidSupplierException:System.Exception
    {
        public InvalidSupplierException(string supplierName)
            : base(string.Format("Invalid selected supplier ({0})", supplierName))
        {
        }
    }
}
