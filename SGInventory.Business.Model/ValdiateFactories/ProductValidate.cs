using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;
using System.Text.RegularExpressions;

namespace SGInventory.Business.Model.ValdiateFactories
{
    public class ProductValidate:IValid
    {
        public string Validate(List<object> arguments)
        {
            var retValue = string.Empty;

            var productTobeProcess = (Product)arguments[1];
            var queryProduct = arguments[2];

            if (productTobeProcess.StockNumber.Length > FormsHelper.DESC_MAXLENGTH)
            {
                retValue = FormsHelper.ValidationError("Stock Number", FormsHelper.DESC_MAXLENGTH);
                return retValue;
            }

            //var match = Regex.IsMatch(productTobeProcess.StockNumber, @"^[a-zA-Z0-9\-]+$");

            //if (!match)
            //{
            //    retValue = "Only accepts alphanumerics and a dash characters";
            //    return retValue;
            //}
           
            var selectedColor = arguments[3];

            if (selectedColor == null)
            {
                retValue = "Invalid Selected Color";
                return retValue;
            }

            var selectedWashing = arguments[4];

            if (selectedWashing == null)
            {
                retValue = "Invalid Selected Washing";
                return retValue;

            }
            
            var dbModelDetailExists = false;

            if (queryProduct != null)
            {
                var dbModel = (Product)queryProduct;
                var color = (Color)selectedColor;
                var washing = (Washing)selectedWashing;

                var dbModelDetails = dbModel.ProductDetails.Where(pd => pd.Color.Code.Equals(color.Code, StringComparison.InvariantCultureIgnoreCase) && pd.Washing.Code.Equals(washing.Code, StringComparison.InvariantCultureIgnoreCase));

                dbModelDetailExists = dbModelDetails.Count() > 0 ? true : false;
            }

            if (dbModelDetailExists)
            {
                retValue =  string.Format("{0} Already Exists", arguments[0].ToString());
                return retValue;
            }
           
            return retValue;
        }
    }
}
