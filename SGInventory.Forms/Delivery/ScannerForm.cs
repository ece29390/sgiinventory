using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;
using SGInventory.Views;

namespace SGInventory.Delivery
{
    public partial class ScannerForm : Form, IScannerView
    {
        public event EventHandler<EventArgs> OnScannerFormClosing;
        public ScannerPresenter Presenter
        {
            get;
            private set;
        }
        
        public ScannerForm()
        {
            InitializeComponent();
            Presenter = new ScannerPresenter(this);
            textBox1.ReadOnly = false;
            textBox1.Focus();
        }

       

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseForm()
        {
            this.Close();
        }


        public void ClearInputText()
        {
            textBox1.Clear();
            textBox1.Focus();
        }
       
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    var scannerResponse = Presenter.VerifyTheInput(textBox1.Text.Trim());
                    Presenter.ProcessAfterScan(scannerResponse);                 
                }
            }
            
        }

        private void ScannerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OnScannerFormClosing != null)
            {
                OnScannerFormClosing(sender, e);
            }
        }
    }
}
