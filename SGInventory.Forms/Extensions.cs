using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory
{
    public static class Extensions
    {
        internal static void EnableOrDisableByList<T>(this UserControl userControl, List<T> list)
        {
            userControl.Enabled = list.Count > 0 ? true : false;
        }

        internal static ProductDetails GetProductDetails(this List<ProductDetails> productDetails, Size productDetail)
        {
            ProductDetails retValue = null;

            var query = productDetails.Where(pd => pd.Size.Code== productDetail.Code).ToList();

            retValue = query.Count == 0 ? null : query.First();

            return retValue;
        }

        internal static ProductStatus ToProductStatus(this int productStatusEquivalent)
        {
            var retValue = ProductStatus.Goods;

            if (productStatusEquivalent == (int)ProductStatus.Damaged)
            {
                retValue = ProductStatus.Damaged;
            }
            return retValue;
        }

        internal static Damage ToDamageEnum(this int damageEquivalent)
        {
            var retValue = Damage.Fabric;

            switch (damageEquivalent)
            {
                case (int)Damage.Holes:
                    retValue = Damage.Holes;
                    break;
                case (int)Damage.Others:
                    retValue = Damage.Others;
                    break;
                case (int)Damage.Stain:
                    retValue = Damage.Stain;
                    break;
                case (int)Damage.Washing:
                    retValue = Damage.Washing;
                    break;
            }

            return retValue;
        }
    }
}
