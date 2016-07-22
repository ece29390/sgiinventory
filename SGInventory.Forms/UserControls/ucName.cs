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
    public partial class ucName : UserControl,ITextChanged
    {
       
        public ucName()
        {
            InitializeComponent();
        }

        public string UniqueName
        {
            get {return NameTextbox.Text.Trim(); }
            set { NameTextbox.Text = value; }
        }


        public new event EventHandler<EventArgs> OnTextChanged;

        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (OnTextChanged != null)
            {
                OnTextChanged(sender, e);
            }
        }

       
    }
}
