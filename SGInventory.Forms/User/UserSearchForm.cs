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
using SGInventory.Helpers;
using SGInventory.Model;

namespace SGInventory.User
{
    public partial class UserSearchForm : Form,IUserSearchView
    {
        private readonly BusinessModelContainer _container;
        private readonly UserSearchPresenter _presenter;
        public UserSearchForm(BusinessModelContainer container)
        {
            InitializeComponent();

            _container = container;
            FormsHelper.ApplySearchViewSetting(this);
            _presenter = new UserSearchPresenter(this, container.UserBusinessModel);
            ucAddDelete1.AddButtonClick += new EventHandler<EventArgs>(ucAddDelete1_AddButtonClick);
            ucAddDelete1.DeleteButtonClick += new EventHandler<EventArgs>(ucAddDelete1_DeleteButtonClick);
            userDataGridView.AutoGenerateColumns = false;
        }

        void ucAddDelete1_DeleteButtonClick(object sender, EventArgs e)
        {
            _presenter.DeleteSelectedModels();
        }

        void ucAddDelete1_AddButtonClick(object sender, EventArgs e)
        {
            _presenter.OpenEditForm();
        }

        private void UserSearchForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadModels();
        }

        public void LoadModel(List<Model.User> list)
        {
            userDataGridView.DataSource = list;
        }

        public void OpenEditForm()
        {
            var form = new UserEditForm(_container.UserBusinessModel);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.User>>(form_OnModelUpdateSuccessful);
            form.ShowDialog();
        }

        void form_OnModelUpdateSuccessful(object sender, CustomEventArgs.ModelEventArgs<Model.User> e)
        {
            LoadModel(e.ModelList);
        }

        public Model.User ConvertToModel(object dataBoundItem)
        {
            return (Model.User)dataBoundItem;
        }

        public void OpenEditForm(Model.User model)
        {
            var form = new UserEditForm(_container.UserBusinessModel,model);
            form.OnModelUpdateSuccessful += new EventHandler<CustomEventArgs.ModelEventArgs<Model.User>>(form_OnModelUpdateSuccessful);
            form.ShowDialog();
        }

        public DialogResult ConfirmationPopUpYesNo(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
        }

        public void DeletedPopUpMessage(string message)
        {
            MessageBox.Show(message);
        }

        public List<Model.User> GetSelectedModels()
        {
            return FormsHelper.GetSelectedModel<Model.User>("colId", userDataGridView);
        }

        private void userDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = userDataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "colUserName")
            {
                _presenter.PopulateModelToEditForm(columnName, userDataGridView.Rows[e.RowIndex].DataBoundItem);
            }
        }

        private void userDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in userDataGridView.Rows)
            {
                var roleTypeId = ((Model.User)row.DataBoundItem).Roletype;
                row.Cells["colRoleName"].Value = SgiHelper.GetRoleName(roleTypeId);
            }
        }
    }
}
