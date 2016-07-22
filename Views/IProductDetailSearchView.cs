using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IProductDetailSearchView
    {
        void LoadModel(IList<Model.ProductDetails> list);
        void OpenEditForm();
        ProductDetails ConvertToModel(object databoundItem);        
        void OpenEditForm(ProductDetails productDetail);

        List<ProductDetails> GetSelectedModels();

        System.Windows.Forms.DialogResult ConfirmationPopUpYesNo(string p);

        void DeletedPopUpMessage(string message);
    }
}
