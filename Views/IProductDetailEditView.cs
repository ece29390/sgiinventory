using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Views
{
    public interface IProductDetailEditView : ICode, IEventEditView<ProductDetails>, IEditViewLoadData<ProductDetails>, IMessageBox, IEditViewUser
    {
        Color GetColor();

        Washing GetWashing();

        Size GetSize();

        double? GetOverrideCost();
  
        int? GetQuantityOnHand();
        
        void LoadSizes(List<Size> sizes);

        void LoadColors(List<Color> list);

        void LoadWashings(List<Washing> list);

        void ShowOpenFileDialog();

        string GetFilePath();

        void LoadImageToPictureBox(string filePath);

        string GetNewDestinationPath();

        void CopyToNewDestinationPath(string newDestinationPath);
    }
}
