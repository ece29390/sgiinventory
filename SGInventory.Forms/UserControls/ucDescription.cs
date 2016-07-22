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
    public partial class ucDescription : UserControl,ITextChanged
    {
        
        public ucDescription()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return DescriptionTextBox.Text.Trim(); }
            set { DescriptionTextBox.Text = value; }
        }
       
        public new event EventHandler<EventArgs> OnTextChanged;

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OnTextChanged != null)
            {
                OnTextChanged(sender, e);
            }

            
            
        }
    }
}
