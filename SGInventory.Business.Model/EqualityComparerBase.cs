using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    internal class EqualityComparerBase<T>:IEqualityComparer<T> where T:class,ICode,IName,new()
    {
        public bool Equals(T x, T y)
        {
            return x.Code == y.Code;
        }

        public int GetHashCode(T obj)
        {
            var model = (T)obj;
            return model.Code.GetHashCode();
        }
    }
}
