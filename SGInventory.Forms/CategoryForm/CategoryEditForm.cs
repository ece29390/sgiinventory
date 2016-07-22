using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Views;
using SGInventory.Model;
using SGInventory.Presenters;
using Ninject;
using SGInventory.Business.Model;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;
namespace SGInventory.CategoryForm
{
    public partial class CategoryEditForm : Form,ICategoryEditView
    {

        public event EventHandler<ModelEventArgs<Model.Category>> OnModelUpdateSuccessful;

        private SGInventory.Model.Category _category;
        private CategoryEditPresenter _categoryPresenter;


        public CategoryEditForm(ICategoryBusinessModel categoryBusinessModel, SGInventory.Model.Category category = null)
        {
            InitializeComponent();

            FormsHelper.ApplyEditViewSettings(this);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            ucName1.OnTextChanged += new EventHandler<EventArgs>(ucName1_OnTextChanged);
            _category=category;
            
            _categoryPresenter = new CategoryEditPresenter(this, categoryBusinessModel, category);
        }

        void ucName1_OnTextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_categoryPresenter.ShouldEnable());
        }
              
        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _categoryPresenter.Save((response, list) => 
                                    {
                                        MessageBox.Show(response);

                                        if (list != null)
                                        {
                                            if (this.OnModelUpdateSuccessful != null)
                                            {
                                                this.OnModelUpdateSuccessful(this, new ModelEventArgs<Model.Category>(list));
                                                this.Close();
                                            }
                                        }
                                    }
                                    );
        }

        private void CategoryEditForm_Load(object sender, EventArgs e)
        {
            _categoryPresenter.LoadModels(_category);
        }

        public string GetName()
        {
            return ucName1.UniqueName;
        }

        public string GetDescription()
        {
            return ucDescription1.Description;
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }

        public void ShowMessage(string successfulResponse)
        {
            MessageBox.Show(successfulResponse);
        }

        public void LoadData(Model.Category category)
        {
            ucName1.UniqueName = category.Name;
            ucDescription1.Description = category.Description;
        }
       
    }
}
