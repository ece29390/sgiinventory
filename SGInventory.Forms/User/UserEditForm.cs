using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.CustomEventArgs;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Enums;
using SGInventory.Helpers;

namespace SGInventory.User
{
    public partial class UserEditForm : Form,IUserEditView
    {
        public event EventHandler<ModelEventArgs<Model.User>> OnModelUpdateSuccessful;

        private readonly Model.User _model;
        private readonly UserEditPresenter _presenter;

        public UserEditForm(IUserBusinessModel businessModel,Model.User model=null)
        {
            InitializeComponent();
            _presenter = new UserEditPresenter(this, businessModel, model);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            ucUserNamePassword1.OnUserNameTextChanged += new EventHandler<EventArgs>(ucUserNamePassword1_OnUserNameTextChanged);
            ucUserNamePassword1.OnPasswordTextChanged += new EventHandler<EventArgs>(ucUserNamePassword1_OnPasswordTextChanged);
            _model = model;
        }

        void ucUserNamePassword1_OnPasswordTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_presenter.ShouldEnable());
        }

        void ucUserNamePassword1_OnUserNameTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_presenter.ShouldEnable());
        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _presenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (OnModelUpdateSuccessful != null)
                    {
                        OnModelUpdateSuccessful(this
                            , new CustomEventArgs.ModelEventArgs<Model.User>(list));
                        this.Close();
                    }
                }
            });
        }

        public string GetPassword()
        {
            return ucUserNamePassword1.Password;
        }

        public string UserName()
        {
            return ucUserNamePassword1.UserName;
        }

        public string GetName()
        {
            return fullNameTextbox.Text.Trim();
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }

        public void LoadData(Model.User model)
        {
            fullNameTextbox.Text = model.Name;
            ucUserNamePassword1.Password = model.Password;
            ucUserNamePassword1.UserName = model.UserName;
            roleTypeComboBox.SelectedValue = model.Roletype;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
       
        private void fullNameTextbox_TextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_presenter.ShouldEnable());
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadRoleTypes();
            _presenter.LoadModels(_model);           
        }

        public void LoadRoleTypes()
        {
            var roleTypeList = new List<Role>();
            var roleTypeNames = Enum.GetNames(typeof(RoleType));
            var roleTypeValues = Enum.GetValues(typeof(RoleType));
                        
            for (int i = 0; i < roleTypeValues.Length; i++)
            {
                roleTypeList.Add(new Role { Id = (int)roleTypeValues.GetValue(i), RoleName = roleTypeNames[i] });
            }

            roleTypeComboBox.DataSource = roleTypeList;
            roleTypeComboBox.DisplayMember = "RoleName";
            roleTypeComboBox.ValueMember = "Id";

        }


        public int GetRoleTypeValue()
        {
            return (int)roleTypeComboBox.SelectedValue;
        }
    }
}
