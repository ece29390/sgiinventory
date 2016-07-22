using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface IWashingBusinessModel : ISelectAll<Washing>, ISelectByPrimary<Washing, string>, IValidate<Washing>, IBusinessTransact<Washing>, ISave<Washing>,ISelectByProductDetail<Washing>
    {
        
    }
}
