using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IProductEditView : ICode, IEventEditView<Product>, IEditViewLoadData<Product>, IMessageBox, IEditViewUser
    {
        string GetDescription();

        Category GetGategory();

        void LoadAllCategories();

        double GetCost();

        double GetRegularPrice();

        double GetMarkdownPrice();

        void LoadAllColors();

        List<Color> Colors { get; }

        void LoadAllWashing();

        List<Washing> Washings { get; }

        Color SelectedColor { get; }

        Washing SelectedWashing { get; }

        void LoadAllSizes();

        List<Size> Sizes { get; }

        List<Size> SelectedSizes { get; }
        
        IList<ProductDetails> AttachProductDetails(Product _model, Color color, Washing washing);

        void LoadProductHistory(List<ProductPricesHistory> productHistoryDetails);
    }
}
