using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Presenters;
using SGInventory.Test.Data;
using SGInventory.Model;
using SGInventory.Helpers;
using System.Windows.Forms;
namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ProductDetailEditPresenterTest
    {
        private readonly ProductDetailEditPresenter _presenter;
        private readonly Mock<IProductDetailEditView> _view;
        private readonly Mock<IProductDetailBusinessModel> _businessModel;
        private ProductDetails _model;
        public ProductDetailEditPresenterTest()
        {
            _view = new Mock<IProductDetailEditView>(MockBehavior.Strict);
            _businessModel = new Mock<IProductDetailBusinessModel>(MockBehavior.Strict);
            
            var testData=new ProductDetailTestData();
            _model=testData.GetEntity();
            var productTestData = new ProductTestData();
            _model.Product = productTestData.GetEntity();
            _presenter = new ProductDetailEditPresenter(_view.Object, _businessModel.Object, _model);
        }

        private void SetUpInputs()
        {
     
            _view.Setup(v => v.GetColor()).Returns(_model.Color);
            _view.Setup(v => v.GetWashing()).Returns(_model.Washing);
            _view.Setup(v => v.GetSize()).Returns(_model.Size);     
            _view.Setup(v => v.GetQuantityOnHand()).Returns(_model.QuantityOnHand);
            _view.Setup(v => v.GetUser()).Returns("sang");
            _view.Setup(v => v.GetFilePath()).Returns(@"C:\Picture\Sample.jpg");
            _view.Setup(v => v.GetNewDestinationPath()).Returns(@"Pictures\Sample.jpg");
            _view.Setup(v => v.GetOverrideCost()).Returns(200.50);
        }

        [TestMethod]
        public void Save_GiveModelIsNew_Successfull_Test()
        {

            _view.Setup(v => v.GetCode()).Returns(_model.Code);
            _model.Code = null;
            SetUpInputs();
            _businessModel.Setup(b => b.Save(It.IsAny<ProductDetails>())).Returns("A Product Detail has been saved");
            _businessModel.Setup(b => b.SelectByParent(It.IsAny<Product>())).Returns(new List<ProductDetails>{_model});
            _view.Setup(v => v.CopyToNewDestinationPath(@"Pictures\Sample.jpg"));
            var hasBeenCalled=false;
            _presenter.Save((response,list)=>{hasBeenCalled=true;}
                );

            _businessModel.VerifyAll();
            _view.VerifyAll();
          
        }

        [TestMethod]
        public void Save_GiveModelIsNotNew_Successfull_Test()
        {
            _model.QuantityOnHand = 1500;
            SetUpInputs();            
            _businessModel.Setup(b => b.CreateOrUpdate(_model));
            _businessModel.Setup(b => b.SelectByParent(It.IsAny<Product>())).Returns(new List<ProductDetails> { _model });
            _view.Setup(v => v.CopyToNewDestinationPath(@"Pictures\Sample.jpg"));
            var presenter = new ProductDetailEditPresenter(_view.Object, _businessModel.Object,_model);

            var hasBeenCalled = false;
            presenter.Save((response, list) => { hasBeenCalled = true; }
                );

            _businessModel.VerifyAll();
            _view.VerifyAll();

        }

        [TestMethod]
        public void LoadAllSizes_Test()
        {
            var sizeMoq=new Mock<ISizeBusinessModel>(MockBehavior.Strict);           
            var sizeTestData=new SizeTestData();   
    
            sizeMoq.Setup(s => s.SelectAll()).Returns(sizeTestData.GetEntities());
            _view.Setup(v => v.LoadSizes(It.IsAny<List<Size>>()));

            _presenter.LoadSizes(sizeMoq.Object);

            _view.VerifyAll();
            sizeMoq.VerifyAll();


        }

        [TestMethod]
        public void LoadAllColors_Test()
        {           
            var colorMoq = new Mock<IColorBusinessModel>(MockBehavior.Strict);        
            var colorTestData = new ColorTestData();
           
            colorMoq.Setup(s => s.SelectAll()).Returns(colorTestData.GetEntities());
            _view.Setup(v => v.LoadColors(It.IsAny<List<Color>>()));

            _presenter.LoadColors(colorMoq.Object);

            _view.VerifyAll();
            colorMoq.VerifyAll();                      
        }


        [TestMethod]
        public void LoadAllWashings_Test()
        {
            var washingMoq = new Mock<IWashingBusinessModel>(MockBehavior.Strict);
            var washingTestData = new WashingTestData();

            washingMoq.Setup(s => s.SelectAll()).Returns(washingTestData.GetEntities());
            _view.Setup(v => v.LoadWashings(It.IsAny<List<Washing>>()));

            _presenter.LoadWashings(washingMoq.Object);

            _view.VerifyAll();
            washingMoq.VerifyAll();

        }

        [TestMethod]
        public void Keypress_Complete_Result_True()
        {
            var color =(new ColorTestData()).GetEntity();
            var size = new SizeTestData().GetEntity();
            var washing=new WashingTestData().GetEntity();           
            _view.Setup(v => v.GetColor()).Returns(color);            
            _view.Setup(v => v.GetSize()).Returns(size);          
            _view.Setup(v => v.GetWashing()).Returns(washing);
            _view.Setup(v => v.GetQuantityOnHand()).Returns(10);
            Assert.IsTrue(_presenter.ShouldEnable());

            _view.VerifyAll();
        }

      

        [TestMethod]
        public void Keypress_InCompleteColor_Result_False()
        {
            Color color = null;           
            _view.Setup(v => v.GetColor()).Returns(color);
         
            Assert.IsFalse(_presenter.ShouldEnable());

            _view.VerifyAll();
        }

        [TestMethod]
        public void Keypress_InCompleteSize_Result_False()
        {
            Size size = null;
            
            _view.Setup(v => v.GetColor()).Returns((new ColorTestData().GetEntity()));
            _view.Setup(v => v.GetSize()).Returns(size);
            

            Assert.IsFalse(_presenter.ShouldEnable());

            _view.VerifyAll();
        }

        [TestMethod]
        public void Keypress_InCompleteWashing_Result_False()
        {
            Washing washing = null;         
            _view.Setup(v => v.GetColor()).Returns((new ColorTestData().GetEntity()));
            _view.Setup(v => v.GetSize()).Returns(new SizeTestData().GetEntity());
            _view.Setup(v => v.GetWashing()).Returns(washing);
            Assert.IsFalse(_presenter.ShouldEnable());

            _view.VerifyAll();
        }

        [TestMethod]
        public void Keypress_InCompleteQuantity_Result_False()
        {
            
            _view.Setup(v => v.GetColor()).Returns((new ColorTestData().GetEntity()));
            _view.Setup(v => v.GetSize()).Returns(new SizeTestData().GetEntity());
            _view.Setup(v => v.GetWashing()).Returns(new WashingTestData().GetEntity());
            int? mockResult = null;
            _view.Setup(v => v.GetQuantityOnHand()).Returns(mockResult);
            Assert.IsFalse(_presenter.ShouldEnable());

            _view.VerifyAll();
        }

        [TestMethod]
        public void SelectModelByName_ModelExists_Test()
        {
            var colorTestData=new ColorTestData();
            var color = colorTestData.GetEntity();
           
           var actualColor= SgiHelper.SelectModelByNameInTheCollection<Color>(colorTestData.GetEntities(),color.Name);

           Assert.AreEqual(actualColor.Code, color.Code);
           Assert.AreEqual(actualColor.Name, color.Name);
            
          

        }

        [TestMethod]
        public void SelectModelByName_ModelNotExists_Test()
        {
            var colorTestData = new ColorTestData();
            var color = colorTestData.GetEntity();

            var actualColor = SgiHelper.SelectModelByNameInTheCollection<Color>(colorTestData.GetEntities(), "zx");

            Assert.IsNull(actualColor);



        }

        [TestMethod]
        public void AfterSelectingColor_AutoComplete_Test()
        {

            var colorTestData = new ColorTestData();
            var color = colorTestData.GetEntity();
       
            bool hasCalled=false;   
            _presenter.LoadSelectedModel<Color>(colorTestData.GetEntities(),color.Name,(m)=>hasCalled=true);

            Assert.IsTrue(hasCalled);
        


        }

        [TestMethod]
        public void LoadModel_GivenTheModelIsNotNull()
        {       
            _view.Setup(v => v.LoadData(It.IsAny<ProductDetails>()));
            _presenter.LoadModels(_model);
            _view.VerifyAll();
        }

        [TestMethod]
        public void UploadPicTest()
        {
            _view.Setup(v => v.ShowOpenFileDialog());
            _presenter.OpenFileDialog();
            _view.VerifyAll();
        }

        [TestMethod]
        public void FileOkTest()
        {
            var mockPath = @"C:\Picture\Sample.jpg";
            _view.Setup(v => v.GetFilePath()).Returns(mockPath);
            _view.Setup(v => v.LoadImageToPictureBox(mockPath));

            _presenter.UploadToPictureBox();

            _view.VerifyAll();
        }

      
    }
}
