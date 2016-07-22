using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IScanBarcodeDisplay:IGetStockNumber,IGetColorWashingSize
    {
        void LoadProducts(List<Model.Product> list);
        
        Model.Product GetSelectedProduct();

        void LoadColors(List<Model.Color> list);

        void LoadWashings(List<Model.Washing> list);

        void LoadSizes(List<Model.Size> list);
        
        bool GetSelectByProductCode();

        void DisabledProductDetail(bool disable);

        void RenameStockOrCodeLabel(string label);

        void LoadProducts(List<ProductDetails> list);

        ProductDetails GetSelectedProductDetails();

        void ClearProductDetailControls();

        void SetSelectByBarcodeTo(bool selectByBarcode);                        
    }
}
