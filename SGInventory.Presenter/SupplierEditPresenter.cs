using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Helpers;
using SGInventory.Business.Model;
using SGInventory.Views;

namespace SGInventory.Presenters
{
    public class SupplierEditPresenter:EditPresenterBase<Supplier>
    {
        private Views.ISupplierEditView iSupplierEditView;
        private Business.Model.ISupplierBusinessModel iSupplierBusinessModel;
        private Supplier _model;

        public SupplierEditPresenter(Views.ISupplierEditView iSupplierEditView
            , Business.Model.ISupplierBusinessModel iSupplierBusinessModel
            , Supplier model=null)
            :base("Supplier")
        {
            // TODO: Complete member initialization
            this.iSupplierEditView = iSupplierEditView;
            this.iSupplierBusinessModel = iSupplierBusinessModel;
            this._model = model;
        }

        public override void Save(Action<string, List<Supplier>> callBackAfterSaving)
        {
            var name = this.iSupplierEditView.GetName();
            var address = this.iSupplierEditView.GetAddress();
            var user = iSupplierEditView.GetUser();

            if (base._model != null)
            {
                base._model.Name = name;
                base._model.Address = address;
                base._model.ModifiedDate = DateTime.Now;
                base._model.ModifiedBy = this.iSupplierEditView.GetUser();
            }
            else
            {
                base._model = new Supplier
                {
                    Name = name,
                    Address = address,
                    CreatedDate = DateTime.Now,
                    CreatedBy = user,
                    ModifiedBy = user,
                    ModifiedDate = DateTime.Now
                };
            }
            if (name.Trim().Length > FormsHelper.NAME_MAXLENGTH ? true : false)
            {
                iSupplierEditView.ShowMessage(FormsHelper.NameValidationError);
                return;                
            }

            if (address.Trim().Length > FormsHelper.ADDRESS_MAXLENGTH ? true : false)
            {
                iSupplierEditView.ShowMessage(FormsHelper.AddressValidationError);
                return;
            }

            base.PersistChanges<ISupplierBusinessModel>(this.iSupplierBusinessModel, callBackAfterSaving);
        }

        public override void LoadModels(Supplier model)
        {
            base._model = model;
            base.LoadEntity<ISupplierEditView>(this.iSupplierEditView);
        }

        public override bool ShouldEnable()
        {
            return base.ShouldEnable(this.iSupplierEditView.GetName());
        }
    }
}
