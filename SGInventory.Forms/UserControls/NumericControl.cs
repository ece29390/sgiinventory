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
    public partial class NumericControl : UserControl
    {
        public NumericControl()
        {
            InitializeComponent();
        }

        public double Numeric
        {
            get { return Convert.ToDouble(NumericTextbox.Text.Trim()); }
            set { NumericTextbox.Text = value.ToString(); }
        }

        private void NumericTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (NumericTextbox.Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    return;
                }

                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

           

          
           
        }

      

       
    }
}
