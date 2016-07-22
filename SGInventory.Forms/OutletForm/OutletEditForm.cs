using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using Ninject;

namespace SGInventory.OutletForm
{
    public partial class OutletEditForm : Form,IOutletEditView
    {
        
        private Outlet _model;
        private OutletEditPresenter _outletEditPresenter;

        public OutletEditForm(BusinessModelContainer container,Outlet model=null)
        {
            InitializeComponent();

            FormsHelper.ApplyEditViewSettings(this);
            
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
           

            _model = model;
         
            _outletEditPresenter = new OutletEditPresenter(
                this,
                container.OutletBusinessModel,
                model);
            
               

        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_outletEditPresenter.ShouldEnable());
        }
            
        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _outletEditPresenter.Save((response, list) => 
                                    {
                                        MessageBox.Show(response);

                                        if (list != null)
                                        {
                                            if (OnModelUpdateSuccessful != null)
                                            {
                                                OnModelUpdateSuccessful(this
                                                    , new CustomEventArgs.ModelEventArgs<Outlet>(list));
                                                this.Close();
                                            }
                                        }
                                    });
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Model.Outlet>> OnModelUpdateSuccessful;

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

        public void LoadData(Model.Outlet model)
        {
            ucName1.UniqueName = model.Name;
            ucAddress1.Address = model.Address;

        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void OutletEditForm_Load(object sender, EventArgs e)
        {
            _outletEditPresenter.LoadModels(_model);
        }
    }
}
