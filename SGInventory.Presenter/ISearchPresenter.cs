using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Presenters
{
    public interface ISearchPresenter
    {
        void LoadModels();
        void OpenEditForm();
        void PopulateModelToEditForm(string columnName, object dataBoundItem);
        void DeleteSelectedModels();
    }
}
