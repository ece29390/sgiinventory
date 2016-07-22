using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;

namespace SGInventory.UserControls
{
    public partial class ucAddress : UserControl,ITextChanged
    {
        public ucAddress()
        {
            InitializeComponent();
        }

        public string Address
        {
            get { return AddressTextbox.Text.Trim(); }
            set { AddressTextbox.Text = value.Trim(); }
        
        }

     
      

        private void AddressTextbox_TextChanged(object sender, EventArgs e)
        {
            if (OnTextChanged != null)
            {
                OnTextChanged(sender, e);
            }
        }



        public new event EventHandler<EventArgs> OnTextChanged;
    }
}
