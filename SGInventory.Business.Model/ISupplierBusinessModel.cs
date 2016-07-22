using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface ISupplierBusinessModel : IBusinessTransact<Supplier>, IValidate<Supplier>, ISave<Supplier>, ISelectAll<Supplier>, ISelectByPrimary<Supplier, int>
    {
       
    }
}
