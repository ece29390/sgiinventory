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
    public partial class ucUserNamePassword : UserControl
    {
        public event EventHandler<EventArgs> OnUserNameTextChanged;
        public event EventHandler<EventArgs> OnPasswordTextChanged;
        public event EventHandler<KeyEventArgs> OnTextPressEnter;
        public ucUserNamePassword()
        {
            InitializeComponent();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OnUserNameTextChanged != null)
            {
                OnUserNameTextChanged(sender, e);
            }
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (OnPasswordTextChanged != null)
            {
                OnPasswordTextChanged(sender, e);
            }
        }

        public string UserName
        {
            get { return userNameTextBox.Text.Trim(); }
            set { userNameTextBox.Text = value; }
        }

        public string Password
        {
            get { return passwordTextbox.Text.Trim(); }
            set { passwordTextbox.Text = value; }
        }

        private void userNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyupEnter(sender, e);
        }

        private void passwordTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyupEnter(sender, e);
        }
        private void OnKeyupEnter(object sender, KeyEventArgs e)
        {
            if (OnTextPressEnter != null && e.KeyCode == Keys.Enter)
            {
                OnTextPressEnter(sender, e);
            }
        }
    }
}
