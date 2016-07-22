using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Presenters;
using SGInventory.CustomEventArgs;
using SGInventory.Helpers;

namespace SGInventory.StoreForm
{
    public partial class StoreEditForm : Form, IStoreEditView
    {
        private Business.Model.IStoreBusinessModel _businessModel;
        private Model.Store _model;
        private StoreEditPresenter _storeEditPresenter;

        public StoreEditForm(Business.Model.IStoreBusinessModel businessModel, Model.Store model=null)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this._businessModel = businessModel;
            this._model = model;

            ucCode1.OnCodeChanged += new EventHandler<EventArgs>(ucCode1_OnCodeChanged);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            _storeEditPresenter = new StoreEditPresenter(this, businessModel, model);
        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _storeEditPresenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (this.OnModelUpdateSuccessful != null)
                    {
                        this.OnModelUpdateSuccessful(this, new ModelEventArgs<Model.Store>(list));
                        this.Close();
                    }
                }
            }
                                 );
        }

        void StoreEditForm_Load(object sender, System.EventArgs e)
        {
            ucCode1.ShouldEnableTextbox((_model == null) ? true : false);
            _storeEditPresenter.LoadModels(_model);
        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_storeEditPresenter.ShouldEnable());
        }

        void ucCode1_OnCodeChanged(object sender, EventArgs e)
        {
            ucName1_OnTextChanged(sender, e);
        }

        public string GetCode()
        {
            return ucCode1.Code.Trim();
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Model.Store>> OnModelUpdateSuccessful;
        
        public string GetName()
        {
            return ucName1.UniqueName.Trim();
        }

        public void LoadData(Model.Store model)
        {
            ucName1.UniqueName = model.Name;
            ucCode1.Code = model.Code;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }
    }
}
