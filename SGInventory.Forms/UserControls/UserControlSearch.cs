using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGInventory.UserControls
{
    public partial class UserControlSearch : UserControl
    {
        internal event EventHandler<SeachArgs> _OnSearch;

        public string GetSearchBy()
        {
            var result = comboBoxSearchBy.SelectedValue == null ? "" : comboBoxSearchBy.SelectedValue.ToString();
            return result;
        }

        public string GetSearchTextValue()
        {
            var result = textBoxSearchValue.Text.Trim();
            return result;
        }

        public UserControlSearch()
        {
            InitializeComponent();
        }

        internal void LoadToSearchByComboBox(List<SearchModel> searchModels)
        {
            comboBoxSearchBy.DataSource = searchModels;
            comboBoxSearchBy.DisplayMember = "Description";
            comboBoxSearchBy.ValueMember = "Code";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (_OnSearch != null)
            {
                var searchBy = GetSearchBy();
                var searchValue = GetSearchTextValue();
                var searchParam = new SearchParam { SeachParamBy = searchBy, SearchParamValue = searchValue };
                _OnSearch(sender, new SeachArgs(searchParam));
            }
        }
    }

    internal struct SearchParam
    {
        public string SearchParamValue{get;set;}

        public string SeachParamBy{get;set;}
    }

    internal  class SeachArgs:EventArgs
    {
        public SearchParam SearchParams { get; private set; }

        public SeachArgs(SearchParam searchParam)
        {
            SearchParams = searchParam;
        }
    }

    public class SearchModel
    {
        public string Code{get;set;}
        public string Description{get;set;}
    }
}
