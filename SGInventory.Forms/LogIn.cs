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
using System.Threading;
using System.Security.Principal;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;

namespace SGInventory
{
    public partial class LogIn : Form,ILoginView
    {
        private readonly LoginPresenter _presenter;
        public event EventHandler<LogInEventArgs> SuccessfullLogin; 
        public LogIn(BusinessModelContainer container)
        {
            InitializeComponent();
            _presenter = new LoginPresenter(container.UserBusinessModel, this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            _presenter.LogIn(ucUserNamePassword1.UserName, ucUserNamePassword1.Password);
        }

        public void SetUserProfile(Model.User user)
        {
            var genericIdentity = new GenericIdentity(user.UserName);            
            Thread.CurrentPrincipal = new GenericPrincipal(genericIdentity, new string[]{SgiHelper.GetRoleName(user.Roletype)});            
        }

        public void SetUserSettings(Model.User user)
        {
            if (SuccessfullLogin != null)
            {
                SuccessfullLogin(this,new LogInEventArgs(user));
                ucUserNamePassword1.UserName = string.Empty;
                ucUserNamePassword1.Password = string.Empty;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void LogIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender,e);
            }
        }
    }
}
