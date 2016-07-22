using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Business.Model;
using SGInventory.CustomEventArgs;
using SGInventory.Presenters;
using SGInventory.Helpers;
using SGInventory.Views;

namespace SGInventory.WashingForm
{
    public partial class WashingEditForm : Form,IWashingEditView
    {
        public event EventHandler<ModelEventArgs<Model.Washing>> OnModelUpdateSuccessful;

        private SGInventory.Model.Washing _washing;
        private WashingEditPresenter _washingPresenter;

        public WashingEditForm(IWashingBusinessModel washingBusinessModel, SGInventory.Model.Washing washing = null)
        {
            InitializeComponent();
            
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
            ucCode1.OnCodeChanged += new EventHandler<EventArgs>(ucCode1_OnCodeChanged);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);

            _washing = washing;
            _washingPresenter = new WashingEditPresenter(this, washingBusinessModel, washing);

        }

        void ucCode1_OnCodeChanged(object sender, EventArgs e)
        {
            ucName1_OnTextChanged(sender, e);
        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _washingPresenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (this.OnModelUpdateSuccessful != null)
                    {
                        this.OnModelUpdateSuccessful(this, new ModelEventArgs<Model.Washing>(list));
                        this.Close();
                    }
                }
            }
                                    );
        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_washingPresenter.ShouldEnable());
        }

      

        public string GetName()
        {
            return ucName1.UniqueName;
        }

        public void LoadData(Model.Washing model)
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

        private void WashingEditForm_Load(object sender, EventArgs e)
        {
            ucCode1.ShouldEnableTextbox((_washing == null) ? true : false);
            _washingPresenter.LoadModels(_washing);
        }

        public string GetCode()
        {
            return ucCode1.Code.Trim();
        }
    }
}
