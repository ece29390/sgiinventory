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

namespace SGInventory.ColorForm
{
    public partial class ColorSearchForm : Form, IColorSearchView
    {
        private ColorSearchPresenter _colorSearchPresenter;
        private IColorBusinessModel _businessModel;

        public ColorSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);

            FormsHelper.ApplySearchViewSetting(this);
            _colorSearchPresenter = new ColorSearchPresenter(this, container.ColorBusinessModel);
            _businessModel = container.ColorBusinessModel;
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _colorSearchPresenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _colorSearchPresenter.OpenEditForm();
        }

        private void ColorSearchForm_Load(object sender, EventArgs e)
        {
            _colorSearchPresenter.LoadModels();
        }

        public void LoadModel(List<Model.Color> list)
        {
            colorSearchGrid.AutoGenerateColumns = false;
            colorSearchGrid.DataSource = list;
        }

        public void OpenEditForm()
        {
            var form = new ColorEditForm(_businessModel);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Color>>(form_OnModelUpdateSuccessful);
            form.Show();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Model.Color> e)
        {
            LoadModel(e.ModelList);
        }

        public Model.Color ConvertToModel(object dataBoundItem)
        {
            return (Model.Color)dataBoundItem;
        }

        public void OpenEditForm(Model.Color model)
        {
            var form = new ColorEditForm(_businessModel, model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.Color>>(form_OnModelUpdateSuccessful);
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

        public List<Model.Color> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.Color>("colId", colorSearchGrid);
        }

        private void colorSearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = colorSearchGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "colCode")
            {
                _colorSearchPresenter.PopulateModelToEditForm
                    (
                        columnName
                        , colorSearchGrid.Rows[e.RowIndex].DataBoundItem
                    );
            }
        }
    }
}
