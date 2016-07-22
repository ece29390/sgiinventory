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
    public partial class ucCode : UserControl
    {
        public ucCode()
        {
            InitializeComponent();
        }

        public string Code
        {
            get { return CodeTextbox.Text.Trim(); }
            set { CodeTextbox.Text = value; }
        }

        public string CodeLabelField
        {
            set { CodeLabel.Text = value; }
        }

        public event EventHandler<EventArgs> OnCodeChanged;
        private void CodeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (OnCodeChanged != null)
            {
                OnCodeChanged(sender, e);
            }
        }

        internal void ShouldEnableTextbox(bool enable)
        {
            CodeTextbox.Enabled = enable;
        }
       
    }
}
