using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using SGInventory.Helpers;
using SGInventory.Views;
using SGInventory.Model;

namespace SGInventory.WashingForm
{
    public partial class WashingSearchForm : Form,IWashingSearchView
    {
        private WashingSearchPresenter _washingSearchPresenter;
        private IWashingBusinessModel _businessModel;

        public WashingSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            this.ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            this.ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            FormsHelper.ApplySearchViewSetting(this);

            _businessModel = container.WashingBusinessModel;
            _washingSearchPresenter = new WashingSearchPresenter(this, _businessModel);
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _washingSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _washingSearchPresenter.OpenEditForm();
        }

        public void LoadModel(List<Model.Washing> list)
        {
            washingSearchGrid.AutoGenerateColumns = false;
            washingSearchGrid.DataSource = list;
        }

        public void OpenEditForm()
        {
            var form = new WashingEditForm(_businessModel);
            form.OnModelUpdateSuccessful+=new EventHandler<CustomEventArgs.ModelEventArgs<Washing>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public Model.Washing ConvertToModel(object dataBoundItem)
        {
            return (Washing)dataBoundItem;
        }

        public void OpenEditForm(Model.Washing model)
        {
            var form = new WashingEditForm(_businessModel,model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Washing>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Washing> e)
        {
            LoadModel(e.ModelList);
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Washing> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.Washing>("colId", washingSearchGrid);
        }

        private void washingSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = washingSearchGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "colCode")
            {
                _washingSearchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , washingSearchGrid.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }

        private void WashingSearchForm_Load(object sender, EventArgs e)
        {
            _washingSearchPresenter.LoadModels();
        }
    }
}
