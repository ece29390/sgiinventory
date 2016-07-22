using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface IStoreBusinessModel : IBusinessTransact<Store>, ISave<Store>, ISelectAll<Store>, ISelectByPrimary<Store, string>, IValidate<Store>
    {
    }
}
