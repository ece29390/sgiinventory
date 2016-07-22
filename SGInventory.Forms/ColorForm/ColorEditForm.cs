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
using ModelColor = SGInventory.Model.Color;
using SGInventory.Business.Model;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;
namespace SGInventory.ColorForm
{
    public partial class ColorEditForm : Form,IColorEditView
    {
        private ColorEditPresenter _colorEditPresenter;
        private ModelColor _model;

        public ColorEditForm(IColorBusinessModel businessModel, ModelColor model = null)
        {
            InitializeComponent();
            _model = model;

            ucCode1.OnCodeChanged += new EventHandler<EventArgs>(ucCode1_OnCodeChanged);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            _colorEditPresenter = new ColorEditPresenter(this, businessModel, model);
        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _colorEditPresenter.Save((response, list) =>
            {
                MessageBox.Show(response);

                if (list != null)
                {
                    if (this.OnModelUpdateSuccessful != null)
                    {
                        this.OnModelUpdateSuccessful(this, new ModelEventArgs<Model.Color>(list));
                        this.Close();
                    }
                }
            }
                                 );
        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_colorEditPresenter.ShouldEnable());
        }

        void ucCode1_OnCodeChanged(object sender, EventArgs e)
        {
            ucName1_OnTextChanged(sender, e);
        }

        public string GetCode()
        {
            return ucCode1.Code.Trim();
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<ModelColor>> OnModelUpdateSuccessful;

        public string GetName()
        {
            return ucName1.UniqueName.Trim();
        }

        public void LoadData(ModelColor model)
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

        private void ColorEditForm_Load(object sender, EventArgs e)
        {
            ucCode1.ShouldEnableTextbox((_model == null) ? true : false);
            _colorEditPresenter.LoadModels(_model);
        }
    }
}
