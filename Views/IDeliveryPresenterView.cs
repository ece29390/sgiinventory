using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Enums;

namespace SGInventory.Views
{
    public interface IDeliveryPresenterView : IDeliveryBaseView
    {
        void LoadSuppliers(List<Model.Supplier> list);
                                                    
        void LoadDelivery(Delivery delivery);
                                       
        void LoadProductStatusIntoForm(List<ProductStatus> list);
        
        string GetSupplierName();

        string GetOrNumber();

        void EnableSaveDeliveryButton(bool shouldEnable);

        ProductStatus GetProductStatus();

        int GetQuantity();

        string GetStatusDescription();
        
        void LoadDelivery(DeliveryDetail deliveryDetails);

        DateTime GetDeliveryDate();

        void DisableDeliveryControls();

        double GetPrice();

        void EnableProductDetailsGroup(bool enable);

        void ResetPreviousControlState();

        Size GetSelectedSize();

        Washing GetSelectedWashing();

        Color GetSelectedColor();

        void SetDeliveryDetailItemCost(double? cost);
        
        void LoadDamageIntoForm(List<Damage> list);

        void ShouldEnableDamageDetailGroup(bool isEnable);

        void ShouldEnableStatusDescription(bool isEnable);

        Damage GetDamage();
                                                                                        
        void LoadToDeliveryDetailGrid(Delivery delivery);
        
        void EnableEditMenu(bool enable);

        bool DeliveryAlreadyExists(string barcodeNumber, int status,int? damageStatus);

        string Stocknumber { set; }
        int GetRowCount();
        void LoadResultToView(List<ProductDetails> result);
        
    }
}
