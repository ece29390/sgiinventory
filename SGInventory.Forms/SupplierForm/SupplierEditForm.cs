using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Helpers;
using SGInventory.Model;
using SGInventory.Presenters;

namespace SGInventory.SupplierForm
{
    public partial class SupplierEditForm : Form,ISupplierEditView
    {
        private readonly Supplier _model;
        private readonly SupplierEditPresenter _presenter;
        
        public SupplierEditForm(BusinessModelContainer container,Supplier model=null)
        {
            InitializeComponent();

            FormsHelper.ApplyEditViewSettings(this);

            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);

            _model = model;
            _presenter = new SupplierEditPresenter(this, container.SupplierBusinessModel, model);

        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_presenter.ShouldEnable());
        }
              

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _presenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (OnModelUpdateSuccessful != null)
                    {
                        OnModelUpdateSuccessful(this
                            , new CustomEventArgs.ModelEventArgs<Supplier>(list));
                        this.Close();
                    }
                }
            });
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Model.Supplier>> OnModelUpdateSuccessful;

        public string GetName()
        {
            return ucName1.UniqueName;
        }

        public string GetAddress()
        {
            return ucAddress1.Address;
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }

        public void LoadData(Model.Supplier model)
        {
            ucName1.UniqueName = model.Name;
            ucAddress1.Address = model.Address;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void SupplierEditForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadModels(_model);
        }
    }
}
