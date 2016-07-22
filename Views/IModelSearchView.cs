using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.Views
{
    public interface IModelSearchView<T>
    {
        void LoadModel(List<T> list);

        void OpenEditForm();

        T ConvertToModel(object dataBoundItem);

        void OpenEditForm(T model);

        DialogResult ConfirmationPopUpYesNo(string message);

        void DeletedPopUpMessage(string message);

        List<T> GetSelectedModels();
    }
}
