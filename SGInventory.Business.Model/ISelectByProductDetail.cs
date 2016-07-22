using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface ISelectByProductDetail<T>
    {
       List<T> SelectByProductDetails(List<ProductDetails> list);
    }
}
