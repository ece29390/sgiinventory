using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Extensions;
namespace SGInventory.Presenters
{
   
    public class ScannerPresenter
    {
        public event EventHandler<ScannerResponse> OnScanAction;         
        private Views.IScannerView _iScannerView;
        
        public ScannerPresenter(Views.IScannerView iScannerView)
        {
            
            this._iScannerView = iScannerView;
        }

        public ScannerResponse VerifyTheInput(string barcode)
        {
            var barcodeCharacters = barcode.ToCharArray();            
            var returnValue = new ScannerResponse();            
            returnValue.ItemCode = barcode.Substring(2).Trim();
            return returnValue;

        }

        public void ProcessAfterScan(ScannerResponse scannerResponse)
        {
            if (string.IsNullOrEmpty(scannerResponse.Message))
            {
                if (OnScanAction != null)
                {
                    OnScanAction(null, scannerResponse);
                }
            }
            else
            {
                _iScannerView.ShowMessage(scannerResponse.Message);
            }
            _iScannerView.ClearInputText();
        }
    }
}
