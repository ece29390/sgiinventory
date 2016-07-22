using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IProductSearchView : IModelSearchView<Product>
    {
        bool IsActive { get; set; }
        void DeactivateProductDetail(ProductDetails pd);
        string SearchText { get; }
        string SearchBy { get; }
    }
}
