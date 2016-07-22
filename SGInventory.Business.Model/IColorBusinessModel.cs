using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface IColorBusinessModel : IBusinessTransact<Color>, ISave<Color>, ISelectAll<Color>, ISelectByPrimary<Color, string>, IValidate<Color>, ISelectByProductDetail<Color>
    {
        
    }
}
