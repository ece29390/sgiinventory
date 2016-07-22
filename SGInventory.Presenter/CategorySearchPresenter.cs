using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using System.Windows.Forms;
using SGInventory.Helpers;
using SGInventory.Business.Model;
using SGInventory.Views;
namespace SGInventory.Presenters
{
    public class CategorySearchPresenter : SearchPresenterBase<Category, ICategoryBusinessModel, int>
    {
        

        public CategorySearchPresenter(IModelSearchView<Category> iCategorySearchView, Business.Model.ICategoryBusinessModel iCategoryBusinessModel):base(iCategorySearchView,iCategoryBusinessModel)
        {          
           
            
        }


    }
}
