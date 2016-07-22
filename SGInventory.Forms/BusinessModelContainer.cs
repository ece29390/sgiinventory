using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Business.Model;
using Ninject;
using SGIInventory.Logger;

namespace SGInventory
{
    public class BusinessModelContainer
    {
        [Inject]
        public ICategoryBusinessModel CategoryBusinessModel { get; set; }

        [Inject]
        public IOutletBusinessModel OutletBusinessModel { get; set; }

        [Inject]
        public ISupplierBusinessModel SupplierBusinessModel { get; set; }

        [Inject]
        public IUserBusinessModel UserBusinessModel { get; set; }

        [Inject]
        public IWashingBusinessModel WashingBusinessModel { get; set; }

        [Inject]
        public ISizeBusinessModel SizeBusinessModel { get; set; }

        [Inject]
        public IColorBusinessModel ColorBusinessModel { get; set; }

        [Inject]
        public IProductDetailBusinessModel ProductDetailBusinessModel { get; set; }

        [Inject]
        public IProductBusinessModel ProductBusinessModel { get; set; }

        [Inject]
        public IDeliveryBusinessModel DeliveryBusinessModel { get; set; }

        [Inject]
        public ILogging Logging { get; set; }

        [Inject]
        public IDeliveryBusinessModelHelper DeliveryBusinessModelHelper { get; set; }

        [Inject]
        public IDeliveryToOutletBusinessModel DeliveryToOutletBusinessModel { get; set; }

        [Inject]
        public ISalesBusinessModel SalesBusinessModel { get; set; }
    }
}
