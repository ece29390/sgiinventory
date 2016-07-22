using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Helpers;
using SGInventory.CustomEventArgs;
using System.Configuration;
using System.IO;
using System.IO.IsolatedStorage;

namespace SGInventory.ProductForm
{
    public partial class ProductEditForm : Form,IProductEditView
    {
        private readonly BusinessModelContainer _container;
        private Product _model;
        private ProductEditPresenter _presenter;
        private UploadPicForm _uploadPicForm;
        private string _stockNumber;
        private string _colorCode;
        private string _washingCode;

        public ProductEditForm(BusinessModelContainer container,string stockNumber,string colorCode,string washingCode)
        {
            InitializeComponent();
            _container = container;

            _stockNumber = stockNumber;
            _colorCode = colorCode;
            _washingCode = washingCode;

            ucCode1.OnCodeChanged += new EventHandler<EventArgs>(ucCode1_OnCodeChanged);
            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);
            ucCode1.CodeLabelField = "Stock #:";
            categoryComboBox.ValueMember = "Id";
            categoryComboBox.DisplayMember = "Name";

            if (_model != null)
            {
                ucCode1.Enabled = false;
            }                       
        }
      
        void ucAutoCompleteWashing_AfterSelecting(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucAutoCompleteWashing.AutoCompleteValue))
            {
                SelectedWashing = SgiHelper.SelectModelByNameInTheCollection<Washing>(Washings, ucAutoCompleteWashing.AutoCompleteValue.Trim());
            }
            else
            {
                SelectedWashing = null;
            }
        }

        void ucAutoCompleteColor_AfterSelecting(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucAutoCompleteColor.AutoCompleteValue))
            {
                SelectedColor = SgiHelper.SelectModelByNameInTheCollection<Model.Color>(Colors, ucAutoCompleteColor.AutoCompleteValue.Trim());
            }
            else
            {
                SelectedColor = null;
            }

        }

        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                _presenter.Save((message, list) =>
                {
                    MessageBox.Show(message);

                    if (!message.Contains("Already Exists"))
                    {
                        if (list != null)
                        {
                            if (OnModelUpdateSuccessful != null)
                            {
                                OnModelUpdateSuccessful(sender, new ModelEventArgs<Product>(list));

                                if (!string.IsNullOrEmpty(_uploadPicForm.PictureName))
                                {
                                    var imageFolderName = ConfigurationManager.AppSettings["ImageFolder"];
                                    var newDestination = SgiHelper.GetNewDestination(imageFolderName, _uploadPicForm.PictureName);
                                    if (!_uploadPicForm.PictureName.Equals(newDestination,
                                        StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        SgiHelper.LoadToFileSystemStorage(imageFolderName, _uploadPicForm.PictureName, newDestination);
                                    }
                                    
                                }

                                this.Close();
                            }
                        }
                    }                    
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _container.Logging.LogError("ucSaveEditForm1_SaveButtonClick", ex);
            }
            
        }

        void ucCode1_OnCodeChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_presenter.ShouldEnable());
        }

        public string GetDescription()
        {
            return ucDescription1.Description;
        }

        public Category GetGategory()
        {
            var category = (Category)categoryComboBox.SelectedItem;
            return category;
        }

        public string GetCode()
        {
            return ucCode1.Code;
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Product>> OnModelUpdateSuccessful;
       
        public void LoadData(Product model)
        {
            if (model == null)
                return;

            ucCode1.Code = model.StockNumber;
            ucDescription1.Description = model.Description;
            categoryComboBox.SelectedValue = model.Category.Id;
            markdownPriceControl.Numeric = model.MarkdownPrice;
            RegulaPriceControl.Numeric = model.RegularPrice;
            CostControl.Numeric = model.Cost;

            if (model.ProductDetails != null && model.ProductDetails.Count > 0)
            {
                var productDetail = model.ProductDetails.First();
                ucAutoCompleteColor.AutoCompleteValue = productDetail.Color.Name;
                ucAutoCompleteWashing.AutoCompleteValue = productDetail.Washing.Name;
                SelectedColor = productDetail.Color;
                SelectedWashing = productDetail.Washing;
            }
            
            List<ProductDetails> productDetails = model.ProductDetails.Where(pd => pd.IsActive == 1).ToList(); //_container.ProductDetailBusinessModel.SelectAllActiveByParent(model);
            model.ProductDetails = productDetails;
            if (productDetails.Count > 0)
            {
                var productDetail = productDetails.First();
                _uploadPicForm.PictureName = string.IsNullOrEmpty(productDetail.ImagePathName) ? "" : productDetail.ImagePathName;

                for (var i = 0; i < chkListboxSizes.Items.Count;i++)
                {
                    var size = chkListboxSizes.Items[i] as Model.Size;

                    var retrieveProductDetail = productDetails.GetProductDetails(size);

                    if (retrieveProductDetail != null)
                    {
                        chkListboxSizes.SetItemCheckState(i, CheckState.Checked);
                    }
                }

                List<DeliveryDetail> deliveries = _container.DeliveryBusinessModel.SelectDeliveryDetailByProduct(model);

                ucAutoCompleteColor.Enabled = deliveries.Count == 0 ? true : false;
                ucAutoCompleteWashing.Enabled = deliveries.Count == 0 ? true : false;
                categoryComboBox.Enabled = deliveries.Count == 0 ? true : false;       
            }                     
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public string GetUser()
        {
            return SgiHelper.GetIdentityUserName();
        }

        public void LoadAllCategories()
        {
            var categories = _container.CategoryBusinessModel.SelectAll();
            categoryComboBox.DataSource = categories;
            
        }

        private void ProductEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_stockNumber)&&!string.IsNullOrEmpty(_colorCode)&&!string.IsNullOrEmpty(_washingCode))
                {
                    _model = _container.ProductBusinessModel.SelectBothActiveAndNonActiveByPrimaryId(_stockNumber);
                    _model.ProductDetails = _model.ProductDetails.Where(pd => pd.Washing.Code == _washingCode && pd.Color.Code == _colorCode).ToList();
                }
               
                _presenter = new ProductEditPresenter(this, _container.ProductBusinessModel, _model);
                ucAutoCompleteColor = new UserControls.ucAutoComplete();
                ucAutoCompleteWashing = new UserControls.ucAutoComplete();
                ucAutoCompleteColor.Location = new Point(104, 31);
                ucAutoCompleteWashing.Location = new Point(104, 55);
                this.panel3.Controls.Add(ucAutoCompleteColor);
                this.panel3.Controls.Add(ucAutoCompleteWashing);
                ucAutoCompleteColor.AfterSelecting += new EventHandler<EventArgs>(ucAutoCompleteColor_AfterSelecting);
                ucAutoCompleteWashing.AfterSelecting += new EventHandler<EventArgs>(ucAutoCompleteWashing_AfterSelecting);
                _uploadPicForm = new UploadPicForm();
                _presenter.LoadAllReferenceModels();
                _presenter.LoadModels(_model);

                if (_model == null)
                {
                    priceHistoryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    ucAutoCompleteColor.Enabled = false;
                    ucAutoCompleteWashing.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _container.Logging.LogError("Error at ProductEditForm_Load", ex);
            }
          
        }

        public double GetCost()
        {
            return CostControl.Numeric;
        }

        public double GetRegularPrice()
        {
            return RegulaPriceControl.Numeric;
        }

        public double GetMarkdownPrice()
        {
            return markdownPriceControl.Numeric;
        }

        private void uploadPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _uploadPicForm.ShowDialog();
        }

        public void LoadAllColors()
        {
            Colors = _container.ColorBusinessModel.SelectAll();
            ucAutoCompleteColor.LoadAutoCompleteNameCodeSource<Model.Color>(Colors);
        }

        public void LoadAllWashing()
        {
            Washings = _container.WashingBusinessModel.SelectAll();
            ucAutoCompleteWashing.LoadAutoCompleteNameCodeSource<Washing>(Washings);
        }


        public Model.Color SelectedColor
        {
            get;
            private set;
        }

        public Washing SelectedWashing
        {
            get;
            private set;
        }


        public List<Model.Color> Colors
        {
            get;
            private set;
        }

        public List<Washing> Washings
        {
            get;
            private set;
        }

        public void LoadAllSizes()
        {
            Sizes = _container.SizeBusinessModel.SelectAll();
            chkListboxSizes.DataSource = Sizes;
            chkListboxSizes.DisplayMember = "Name";
            chkListboxSizes.ValueMember = "Code";
 
        }

        public List<Model.Size> Sizes
        {
            get;
            private set;
        }

        public List<Model.Size> SelectedSizes
        {
            get;
            private set;
        }

        public IList<ProductDetails> AttachProductDetails(Product model, Model.Color color, Washing washing)
        {
            if(chkListboxSizes.CheckedItems.Count==0)
            {
                throw new InvalidOperationException("No Sizes are selected");                
            }

            var productDetails = new List<ProductDetails>();

            var newDestination = string.Empty;

            if (!string.IsNullOrEmpty(_uploadPicForm.PictureName))
            {
                var imageFolderName = ConfigurationManager.AppSettings["ImageFolder"];
                newDestination = SgiHelper.GetNewDestination(imageFolderName, _uploadPicForm.PictureName);
            }

            foreach (var item in chkListboxSizes.CheckedItems)
            {
                var size = item as Model.Size;

                productDetails.Add(new ProductDetails
                {
                    Code = SgiHelper.GetProductDetailCode(model.StockNumber.Replace("-", "").Trim(), color.Code, washing.Code, size.Code),                  
                    Color = color,
                    CreatedBy = GetUser(),
                    CreatedDate = DateTime.Now,
                    ModifiedBy = GetUser(),
                    ModifiedDate = DateTime.Now,
                    OverrideCost = model.Cost,
                    Product= model,
                    QuantityOnHand =0,
                    Size = size,
                    Washing = washing,
                    ImagePathName = newDestination
                    
                });
            }
            
            return productDetails;
        }

        private void priceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.LoadPriceHistory();       
        }

        public void LoadProductHistory(List<ProductPricesHistory> productHistoryDetails)
        {
            var form = new PriceHistory(productHistoryDetails);
            form.ShowDialog();
        }
    }
}
