using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Inventory
{
    internal class ProductInventoryViewComparer:IComparer<ProductInventoryView>
    {
        public int Compare(ProductInventoryView x, ProductInventoryView y)
        {
            int sizeNumberX = 0;
            int sizeNumberY = 0;

            int? sizeNumberXNullable = null;
            int? sizeNumberYNullable = null;

            if (int.TryParse(x.SizeName, out sizeNumberX))
            {
                sizeNumberXNullable = sizeNumberX;
            }

            if (int.TryParse(y.SizeName, out sizeNumberY))
            {
                sizeNumberYNullable = sizeNumberY;
            }

            if (sizeNumberXNullable.HasValue && sizeNumberYNullable.HasValue)
            {
                return sizeNumberXNullable.Value.CompareTo(sizeNumberYNullable.Value);
            }
            else
            {
               return x.SizeName.CompareTo(y.SizeName);
            }


        }
    }
}
