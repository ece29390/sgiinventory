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
    public partial class ucSaveEditForm : UserControl
    {
        public event EventHandler<EventArgs> SaveButtonClick;

        public bool SaveButtonEnabled
        {
            get { return SaveButton.Enabled; }
            set { SaveButton.Enabled = value; }
        }
        
        public ucSaveEditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveButtonClick != null)
            {
                SaveButtonClick(sender, e);
            }
        }

        internal void EnabledButton(bool shouldEnabled)
        {
            SaveButton.Enabled = shouldEnabled;
        }

      
        public  Button Button
        {
            get
            {
                return SaveButton;
            }
           
        }
    }
}
