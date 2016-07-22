using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface ISizeBusinessModel : IBusinessTransact<Size>, ISave<Size>, ISelectAll<Size>, ISelectByPrimary<Size, string>,IValidate<Size>,ISelectByProductDetail<Size>
    {
       
    }
}
