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

namespace SGInventory.User
{
    public partial class ChangePassword : Form,IChangePasswordView
    {
        private readonly ChangePasswordPresenter _presenter;
        public ChangePassword(BusinessModelContainer container)
        {
            InitializeComponent();

            _presenter = new ChangePasswordPresenter(container.UserBusinessModel, this);
        }


        public string GetUserName()
        {
            return userNameTextbox.Text.Trim();
        }

        public string ConfirmationOldPassword()
        {
            return oldPasswordTextbox.Text.Trim();
        }

        public string NewPassword()
        {
            return newPasswordTextbox.Text.Trim();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            _presenter.ProcessNewPassword();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            userNameTextbox.Text = SgiHelper.GetIdentityUserName();
        }
    }
}
