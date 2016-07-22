using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Business.Model;
using ModelSize = SGInventory.Model.Size;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;
namespace SGInventory.SizeForm
{
    public partial class SizeEditForm : Form,ISizeEditView
    {
        private SizeEditPresenter _sizeEditPresenter;
        private ModelSize _model;

        public SizeEditForm(ISizeBusinessModel businessModel, ModelSize model = null)
        {
            InitializeComponent();
            _model = model;

            ucCode1.OnCodeChanged += new EventHandler<EventArgs>(ucCode1_OnCodeChanged);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);

            _sizeEditPresenter = new SizeEditPresenter(this, businessModel, model);
        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _sizeEditPresenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (this.OnModelUpdateSuccessful != null)
                    {
                        this.OnModelUpdateSuccessful(this, new ModelEventArgs<Model.Size>(list));
                        this.Close();
                    }
                }
            }
                                   );
        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_sizeEditPresenter.ShouldEnable());
        }

        void ucCode1_OnCodeChanged(object sender, EventArgs e)
        {
            ucName1_OnTextChanged(sender, e);
        }


        public string GetCode()
        {
            return ucCode1.Code.Trim();
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Model.Size>> OnModelUpdateSuccessful;

        public string GetName()
        {
            return ucName1.UniqueName.Trim();
        }

        public void LoadData(Model.Size model)
        {
            ucCode1.Code = model.Code;
            ucName1.UniqueName = model.Name;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }

        private void SizeEditForm_Load(object sender, EventArgs e)
        {
            ucCode1.ShouldEnableTextbox((_model == null) ? true : false);
            _sizeEditPresenter.LoadModels(_model);
        }
    }
}
