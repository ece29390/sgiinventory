using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;
using SGInventory.Views;
using SGInventory.Helpers;

namespace SGInventory.Presenters
{
    public class OutletEditPresenter:EditPresenterBase<Outlet>
    {
        private IOutletEditView _iOutletEditView;
        private IOutletBusinessModel _iOutletBusinessModel;

        public OutletEditPresenter(IOutletEditView iOutletEditView
            , IOutletBusinessModel iOutletBusinessModel,
            Outlet model=null):base("Outlet")
        {
          
            this._iOutletEditView = iOutletEditView;
            this._iOutletBusinessModel = iOutletBusinessModel;
            base._model = model;
        }



        public override void Save(Action<string, List<Outlet>> callBackAfterSaving)
        {
            var name = this._iOutletEditView.GetName();
            var address = this._iOutletEditView.GetAddress();
            var user = _iOutletEditView.GetUser();

            if (base._model != null)
            {
                base._model.Name = name;
                base._model.Address = address;
                base._model.ModifiedDate = DateTime.Now;
                base._model.ModifiedBy = this._iOutletEditView.GetUser();
            }
            else
            {
                base._model = new Outlet 
                            { 
                                Name=name,
                                Address=address,
                                CreatedDate=DateTime.Now,
                                CreatedBy=user,
                                ModifiedBy=user,
                                ModifiedDate=DateTime.Now
                            };
            }

            if (name.Trim().Length > FormsHelper.NAME_MAXLENGTH ? true : false)
            {
                _iOutletEditView.ShowMessage(FormsHelper.NameValidationError);
                return;
            }

            if (address.Trim().Length > FormsHelper.ADDRESS_MAXLENGTH ? true : false)
            {
                _iOutletEditView.ShowMessage(FormsHelper.AddressValidationError);
                return;
            }

            base.PersistChanges<IOutletBusinessModel>(this._iOutletBusinessModel, callBackAfterSaving);
        }

        public override void LoadModels(Outlet model)
        {
            base._model = model;
            base.LoadEntity<IOutletEditView>(this._iOutletEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(_iOutletEditView.GetName());
        }
    }
}
