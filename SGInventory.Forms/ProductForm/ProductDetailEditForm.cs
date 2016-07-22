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
using SGInventory.Helpers;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.IO.IsolatedStorage;

namespace SGInventory.ProductForm
{
    public partial class ProductDetailEditForm : Form,IProductDetailEditView
    {
        private BusinessModelContainer _container;      
        private ProductDetailEditPresenter _productDetailEditPresenter;
        private ProductDetails _model;
        public ProductDetailEditForm(BusinessModelContainer container,ProductDetails model)
        {
            InitializeComponent();

            _productDetailEditPresenter = new ProductDetailEditPresenter
            (
                this
                ,container.ProductDetailBusinessModel
                ,model
            );

            ucSaveEditForm1.SaveButtonClick += new EventHandler<EventArgs>(ucSaveEditForm1_SaveButtonClick);   
            _container = container;
           

            ColorAutoComplete.AfterSelecting += new EventHandler<EventArgs>(ColorAutoComplete_AfterSelecting);
            WashingAutoComplete.AfterSelecting += new EventHandler<EventArgs>(WashingAutoComplete_AfterSelecting);
            SizeAutoComplete.AfterSelecting += new EventHandler<EventArgs>(SizeAutoComplete_AfterSelecting);

            if (!string.IsNullOrEmpty(model.Code))
            {               
                SizeAutoComplete.Enabled = false;
                ColorAutoComplete.Enabled = false;
                WashingAutoComplete.Enabled = false;
            }

            _model = model;
            QuantityTextbox.Text = _model.QuantityOnHand.ToString();
            lblStockNumber.Text = _model.Product.StockNumber;
            numericControl1.Numeric = _model.Product.Cost;                       
        }

        void SizeAutoComplete_AfterSelecting(object sender, EventArgs e)
        {
            _productDetailEditPresenter.LoadSelectedModel<Model.Size>(
                _productDetailEditPresenter.Sizes
                , SizeAutoComplete.AutoCompleteValue.Trim()
                , (model) =>
                    {
                       

                        if (model != null)
                        {
                            ucSaveEditForm1.EnabledButton(_productDetailEditPresenter.ShouldEnable());
                            
                        }
                       

                    });
        }

        void WashingAutoComplete_AfterSelecting(object sender, EventArgs e)
        {
            _productDetailEditPresenter.LoadSelectedModel<Model.Washing>(
                 _productDetailEditPresenter.Washings
                 , WashingAutoComplete.AutoCompleteValue.Trim()
                 , (model) =>
                 {
                     if (model != null)
                     {
                      
                         ucSaveEditForm1.EnabledButton(_productDetailEditPresenter.ShouldEnable());
                     }
                    
                 }
                );
        }

        void ColorAutoComplete_AfterSelecting(object sender, EventArgs e)
        {
            _productDetailEditPresenter.LoadSelectedModel<Model.Color>(
                _productDetailEditPresenter.Colors
                , ColorAutoComplete.AutoCompleteValue.Trim()
                , (model) =>
                {
                    if (model != null)
                    {
                      
                        ucSaveEditForm1.EnabledButton(_productDetailEditPresenter.ShouldEnable());
                    }
                   
                }
               );
        }
       
        void ucSaveEditForm1_SaveButtonClick(object sender, EventArgs e)
        {
            _productDetailEditPresenter.Save((response,list)=>
                {
                    if (list != null&&OnModelUpdateSuccessful!=null)
                    {
                        OnModelUpdateSuccessful(this, new CustomEventArgs.ModelEventArgs<ProductDetails>(list));
                    }
                    MessageBox.Show(response);
                    this.Close();
                }
            );
        }
    
        private void QuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if (e.KeyChar == '\b')
            {
                return;
            }

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void ProductDetailEditForm_Load(object sender, EventArgs e)
        {
            
                _productDetailEditPresenter.LoadColors(_container.ColorBusinessModel);
                _productDetailEditPresenter.LoadSizes(_container.SizeBusinessModel);
                _productDetailEditPresenter.LoadWashings(_container.WashingBusinessModel);

                if (!string.IsNullOrEmpty(_model.Code))
                {
                    _productDetailEditPresenter.LoadModels(_model);
                }
                                            
        }

        public Model.Color GetColor()
        {
            if (_productDetailEditPresenter.Colors.Count == 0)
            {
                return null;
            }
            
            var colorCode = ColorAutoComplete.AutoCompleteValue;
            if (string.IsNullOrEmpty(colorCode))
            {
                return null;
            }

            var colors = _productDetailEditPresenter.Colors.Where(m => m.Name == colorCode).ToList<Model.Color>();

            if (colors.Count == 0)
            {
                return null;
            }

            return colors[0];
        }

        public Model.Washing GetWashing()
        {
            if (_productDetailEditPresenter.Washings.Count == 0)
            {
                return null;
            }

            var washingCode = WashingAutoComplete.AutoCompleteValue;
            if (string.IsNullOrEmpty(washingCode))
            {
                return null;
            }

            var washings = _productDetailEditPresenter.Washings.Where(m => m.Name == washingCode).ToList<Model.Washing>();

            if (washings.Count == 0)
            {
                return null;
            }

            return washings[0];

          
        }

        public Model.Size GetSize()
        {
            if (_productDetailEditPresenter.Sizes.Count == 0)
            {
                return null;
            }

            var sizeCode = SizeAutoComplete.AutoCompleteValue;
            if (string.IsNullOrEmpty(sizeCode))
            {
                return null;
            }

            var sizes = _productDetailEditPresenter.Sizes.Where(m => m.Name == sizeCode).ToList<Model.Size>();

            if (sizes.Count == 0)
            {
                return null;
            }

            return sizes[0];

          
        }
       
        public int? GetQuantityOnHand()
        {
            if (QuantityTextbox.Text.Trim().Length == 0)
                return null;

            return Convert.ToInt32(QuantityTextbox.Text.Trim());
        }

        public void LoadSizes(List<Model.Size> sizes)
        {
            if (sizes.Count == 0)
            {
                return;
            }
            SizeAutoComplete.LoadAutoCompleteNameCodeSource<Model.Size>(sizes);
            
        }

        public void LoadColors(List<Model.Color> list)
        {
            if (list.Count== 0)
            {
                return;
            }
            ColorAutoComplete.LoadAutoCompleteNameCodeSource<Model.Color>(list);
           
        }

        public void LoadWashings(List<Model.Washing> list)
        {
            if (list.Count == 0)
            {
                return;
            }
            WashingAutoComplete.LoadAutoCompleteNameCodeSource<Model.Washing>(list);
            
        }
      
        public string GetCode()
        {
            return SgiHelper.GetProductDetailCode(_model.Product.StockNumber.Replace("-", "").Trim(), GetColor().Code, GetWashing().Code, GetSize().Code);                      
        }

        public event EventHandler<CustomEventArgs.ModelEventArgs<Model.ProductDetails>> OnModelUpdateSuccessful;
       
        public void LoadData(Model.ProductDetails model)
        {          
            ColorAutoComplete.AutoCompleteValue = model.Color.Name;          
            SizeAutoComplete.AutoCompleteValue = model.Size.Name;           
            WashingAutoComplete.AutoCompleteValue = model.Washing.Name;                                         
            QuantityTextbox.Text = model.QuantityOnHand.ToString();
            lblStockNumber.Text = model.Product.StockNumber;

            if (model.OverrideCost.HasValue)
            {
                numericControl1.Numeric = model.OverrideCost.Value;
            }
            else
            {
                numericControl1.Numeric = model.Product.Cost;
            }

            if (!string.IsNullOrEmpty(model.ImagePathName))
            {
                using (var isolatedStorage = IsolatedStorageFile.GetMachineStoreForDomain())
                {
                    using (var isolatedStorageStream = new IsolatedStorageFileStream(model.ImagePathName, FileMode.Open, isolatedStorage))
                    {
                        pictureBoxProductDetail.Image = Image.FromStream(isolatedStorageStream);
                        isolatedStorageStream.Close();
                    }
                    isolatedStorage.Close();
                }
            }
           
            ucSaveEditForm1.EnabledButton(true);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public string GetUser()
        {
            return SGInventory.Helpers.SgiHelper.GetIdentityUserName();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _productDetailEditPresenter.UploadToPictureBox();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            _productDetailEditPresenter.OpenFileDialog();
        }

        public void ShowOpenFileDialog()
        {
            openFileDialog1.ShowDialog();
        }

        public string GetFilePath()
        {
            return openFileDialog1.FileName;
        }
        
        public void LoadImageToPictureBox(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Image image = Image.FromStream(fs);
                pictureBoxProductDetail.Image = image;

            }
       
        }

        public string GetNewDestinationPath()
        {
            var folder = ConfigurationManager.AppSettings["ImageFolder"];
            var fileName = Path.GetFileName(openFileDialog1.FileName);
            var newDestination = string.Format("{0}{1}{2}", folder, Path.DirectorySeparatorChar,fileName);
            return newDestination;
        }

        public double? GetOverrideCost()
        {
            if (numericControl1.Numeric == 0.0)
            {
                return null;
            }
            return numericControl1.Numeric;
        }

        public void CopyToNewDestinationPath(string newDestinationPath)
        {
            using (var isolatedStorage = IsolatedStorageFile.GetMachineStoreForDomain())
            {
                var folder =ConfigurationManager.AppSettings["ImageFolder"];
                if (!isolatedStorage.DirectoryExists(folder))
                {
                    isolatedStorage.CreateDirectory(folder);
                }

                if (!isolatedStorage.FileExists(newDestinationPath))
                {
                    using (var isolatedStream = new IsolatedStorageFileStream(newDestinationPath, FileMode.Create, isolatedStorage))
                    {
                        using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                        {
                            fs.CopyTo(isolatedStream);
                            fs.Close();
                        }
                        isolatedStream.Close();
                    }        
                }

                      
                isolatedStorage.Close();
            }
           
        }

        private void QuantityTextbox_TextChanged(object sender, EventArgs e)
        {
            ucSaveEditForm1.EnabledButton(_productDetailEditPresenter.ShouldEnable());
        }


       
    }
}
