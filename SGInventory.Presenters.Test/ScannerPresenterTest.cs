using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGInventory.Views;
using SGInventory.Presenters;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class ScannerPresenterTest
    {
        private Mock<IScannerView> _scannerView;
        private ScannerPresenter _scannerPresenter;
        
        public ScannerPresenterTest()
        {
            _scannerView = new Mock<IScannerView>(MockBehavior.Strict);
            _scannerPresenter = new ScannerPresenter(_scannerView.Object);
        }

        [TestMethod]
        public void ScannerResponseNotOkTest()
        {
            var scannerResponse = new ScannerResponse();
            var message = "Invalid barcode the month or year is not matched with the delivery date";
    
            scannerResponse = _scannerPresenter.VerifyTheInput("CMW0110046S2");

            Assert.AreEqual(scannerResponse.Message, message);
            Assert.IsNull(scannerResponse.ItemCode);          
        }

        [TestMethod]
        public void ScannerResponseOkTest()
        {
            var scannerResponse = new ScannerResponse();
           
            scannerResponse = _scannerPresenter.VerifyTheInput("ANW0110046S2");

            Assert.IsTrue(string.IsNullOrEmpty(scannerResponse.Message));
            Assert.AreEqual("W0110046S2", scannerResponse.ItemCode);
        }

        [TestMethod]
        public void AfterSuccessfulScanTest()
        {
            var scannerResponse = new ScannerResponse { ItemCode = "W0110046S2" };
            _scannerView.Setup(v => v.ClearInputText());
            var wasTriggered = false;
            _scannerPresenter.OnScanAction += (obj,response) => wasTriggered = true;
            _scannerPresenter.ProcessAfterScan(scannerResponse);

            Assert.IsTrue(wasTriggered);

           _scannerView.VerifyAll();
        }

        [TestMethod]
        public void AfterUnSuccessfulScanTest()
        {
            var scannerResponse = new ScannerResponse { Message = "Invalid barcode the month or year is not matched with the delivery date" };
            _scannerView.Setup(v => v.ClearInputText());
            _scannerView.Setup(v => v.ShowMessage(scannerResponse.Message));
            var wasTriggered = false;
            _scannerPresenter.OnScanAction += (obj, response) => wasTriggered = true;
            _scannerPresenter.ProcessAfterScan(scannerResponse);

            Assert.IsFalse(wasTriggered);

            _scannerView.VerifyAll();
        }
    }
}
