using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Presenters;
using SGInventory.Model;
using SGInventory.Test.Data;
using SGInventory.Business.Model;
using SGInventory.Enums;
using SGInventory.Views;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class SupplierSearchDeliveryPresenterTest
    {
        private Mock<ISupplierSearchDeliveryView> _supplierSearchDeliveryViewMock;
        private Mock<ISupplierBusinessModel> _supplierBusinessModelMock;
        private Mock<IDeliveryBusinessModel> _deliveryBusinessModelMock;

        private SupplierSearchDeliveryPresenter _supplierSearchDeliveryPresenter;
        private List<Supplier> _suppliers;
        private List<Delivery> _deliveries;

        public SupplierSearchDeliveryPresenterTest()
        {
            _supplierSearchDeliveryViewMock = new Mock<ISupplierSearchDeliveryView>(MockBehavior.Strict);
            _supplierBusinessModelMock = new Mock<ISupplierBusinessModel>(MockBehavior.Strict);
            _deliveryBusinessModelMock = new Mock<IDeliveryBusinessModel>(MockBehavior.Strict);

            _supplierSearchDeliveryPresenter = new SupplierSearchDeliveryPresenter(
                _supplierSearchDeliveryViewMock.Object
                , _supplierBusinessModelMock.Object
                , _deliveryBusinessModelMock.Object
                );
            _suppliers = new SupplierTestData().GetEntities();
            _deliveries = new DeliveryTestData().GetEntities();
        }

        [TestMethod]
        public void InitialLoad_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.LoadSuppliers(It.IsAny<List<Supplier>>()));
            _supplierBusinessModelMock.Setup(v => v.SelectAll()).Returns(_suppliers);
            _supplierSearchDeliveryViewMock.Setup(v => v.LoadSearchMode(It.IsAny<List<SupplierSearchDeliveryMode>>()));

            _supplierSearchDeliveryPresenter.InitialLoad();

            _supplierSearchDeliveryViewMock.VerifyAll();
            _supplierBusinessModelMock.VerifyAll();
        }

        [TestMethod]
        public void SearchDeliveryBySupplier_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns("RTP");
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSearchMode()).Returns(SupplierSearchDeliveryMode.Supplier);
            _deliveryBusinessModelMock.Setup(d => d.SelectBySupplier(It.IsAny<string>())).Returns(_deliveries);
            _supplierSearchDeliveryViewMock.Setup(v => v.LoadSearchDeliveries(It.IsAny<List<Delivery>>()));

            _supplierSearchDeliveryPresenter.Search();

            _supplierSearchDeliveryViewMock.VerifyAll();
            _deliveryBusinessModelMock.VerifyAll();
            
        }

        [TestMethod]
        public void SearchDeliveryByDeliveryDate_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetDeliveryDateFrom()).Returns(DateTime.Now);
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns("RTP");
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSearchMode()).Returns(SupplierSearchDeliveryMode.Both);
            _deliveryBusinessModelMock.Setup(d => d.SelectByBoth(It.IsAny<string>(),It.IsAny<DateTime>())).Returns(_deliveries);
            _supplierSearchDeliveryViewMock.Setup(v => v.LoadSearchDeliveries(It.IsAny<List<Delivery>>()));

            _supplierSearchDeliveryPresenter.Search();

            _supplierSearchDeliveryViewMock.VerifyAll();
            _deliveryBusinessModelMock.VerifyAll();

        }

        [TestMethod]
        public void SearchDeliveryByBoth_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetDeliveryDateFrom()).Returns(DateTime.Now);
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSearchMode()).Returns(SupplierSearchDeliveryMode.DeliveryDate);
            _deliveryBusinessModelMock.Setup(d => d.SelectByDeliveryDate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_deliveries);
            _supplierSearchDeliveryViewMock.Setup(v => v.LoadSearchDeliveries(It.IsAny<List<Delivery>>()));

            _supplierSearchDeliveryPresenter.Search();

            _supplierSearchDeliveryViewMock.VerifyAll();
            _deliveryBusinessModelMock.VerifyAll();

        }

        [TestMethod]
        public void LoadSelectedDelivery_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSelectedDelivery(1)).Returns(_deliveries[0]);
            //_supplierSearchDeliveryViewMock.Setup(v => v.OpenSupplierDeliveryEditForm(It.IsAny<Delivery>()));

            //_supplierSearchDeliveryPresenter.LoadSelectedDelivery(1);

            _supplierSearchDeliveryViewMock.VerifyAll();
        }


        [TestMethod]
        public void OnSelectedSearchMode_SupplierIsEmpty_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns(string.Empty);
            _supplierSearchDeliveryViewMock.Setup(v => v.EnableSearchButton(false));
            _supplierSearchDeliveryPresenter.OnSelectedSearchModeChange(SupplierSearchDeliveryMode.Supplier);

            _supplierSearchDeliveryViewMock.VerifyAll();
        }

        [TestMethod]
        public void OnSelectedSearchMode_SupplierIsNotEmpty_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns("RTP");
            _supplierSearchDeliveryViewMock.Setup(v => v.EnableSearchButton(true));
            _supplierSearchDeliveryPresenter.OnSelectedSearchModeChange(SupplierSearchDeliveryMode.Supplier);
            _supplierSearchDeliveryViewMock.VerifyAll();
        }

        [TestMethod]
        public void OnSelectedSearchMode_DeliveryDate_Test()
        {            
            _supplierSearchDeliveryViewMock.Setup(v => v.EnableSearchButton(true));
            _supplierSearchDeliveryPresenter.OnSelectedSearchModeChange(SupplierSearchDeliveryMode.DeliveryDate);
            _supplierSearchDeliveryViewMock.VerifyAll();
        }

        [TestMethod]
        public void OnSelectedSearchMode_DeliveryDateAndSupplierIsEmpty_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns(string.Empty);
            _supplierSearchDeliveryViewMock.Setup(v => v.EnableSearchButton(false));
            _supplierSearchDeliveryPresenter.OnSelectedSearchModeChange(SupplierSearchDeliveryMode.Both);
            _supplierSearchDeliveryViewMock.VerifyAll();
        }

        [TestMethod]
        public void OnSelectedSearchMode_DeliveryDateAndSupplierIsNotEmpty_Test()
        {
            _supplierSearchDeliveryViewMock.Setup(v => v.GetSupplierName()).Returns("RTP");
            _supplierSearchDeliveryViewMock.Setup(v => v.EnableSearchButton(true));
            _supplierSearchDeliveryPresenter.OnSelectedSearchModeChange(SupplierSearchDeliveryMode.Both);
            _supplierSearchDeliveryViewMock.VerifyAll();
        }
    }
}
