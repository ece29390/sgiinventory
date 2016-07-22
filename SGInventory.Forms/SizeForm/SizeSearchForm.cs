using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using SGInventory.Helpers;

namespace SGInventory.SizeForm
{
    public partial class SizeSearchForm : Form,ISizeSearchView
    {
        private SizeSearchPresenter _sizeSearchPresenter;
        private ISizeBusinessModel _businessModel;

        public SizeSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            FormsHelper.ApplySearchViewSetting(this);
            _sizeSearchPresenter = new SizeSearchPresenter(this, container.SizeBusinessModel);
            _businessModel = container.SizeBusinessModel;
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _sizeSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _sizeSearchPresenter.OpenEditForm();
        }

        public void LoadModel(List<Model.Size> list)
        {
            sizeSearchGrid.AutoGenerateColumns = false;
            sizeSearchGrid.DataSource = list;
        }

        public void OpenEditForm()
        {
            var form = new SizeEditForm(_businessModel);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Size>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Model.Size> e)
        {
            LoadModel(e.ModelList);
        }

        public Model.Size ConvertToModel(object dataBoundItem)
        {
            return (Model.Size)dataBoundItem;
        }

        public void OpenEditForm(Model.Size model)
        {
            var form = new SizeEditForm(_businessModel, model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Size>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.Size> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.Size>("colId", sizeSearchGrid);
        }

        private void SizeSearchForm_Load(object sender, EventArgs e)
        {
            _sizeSearchPresenter.LoadModels();
        }

        private void sizeSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = sizeSearchGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "colCode")
            {
                _sizeSearchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , sizeSearchGrid.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }
    }
}
