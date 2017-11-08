using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using SGInventory;
using SGInventory.Helpers;
using SGInventory.Business.Model;
using SGInventory.Presenters;
using SGInventory.Dal;
using SGInventory.Model;
using SGIInventory.Logger;
using SGInventory.Presenters.Mapping;

namespace SGInventory.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ninject setup
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IDataHelper>().To<DataHelper>();
                kernel.Bind<ISgiHelper>().To<SgiHelper>();

                kernel.Bind<ICategoryDal>().To<CategoryDal>();
                kernel.Bind<IOutletDal>().To<OutletDal>();
                kernel.Bind<ISupplierDal>().To<SupplierDal>();
                kernel.Bind<IUserDal>().To<UserDal>();
                kernel.Bind<IWashingDal>().To<WashingDal>();
                kernel.Bind<ISizeDal>().To<SizeDal>();
                kernel.Bind<IColorDal>().To<ColorDal>();
                kernel.Bind<IProductDetailDal>().To<ProductDetailDal>();
                kernel.Bind<IProductDal>().To<ProductDal>();
                kernel.Bind<IDeliveryDal>().To<DeliveryDal>();
                //kernel.Bind<IStoreDal>().To<StoreDal>();
                kernel.Bind<IDeliveryToOutletDal>().To<DeliveryToOutletDal>();
                kernel.Bind<ISalesDal>().To<SalesDal>();

                kernel.Bind<ICategoryBusinessModel>().To<CategoryBusinessModel>();
                kernel.Bind<IOutletBusinessModel>().To<OutletBusinessModel>();
                kernel.Bind<ISupplierBusinessModel>().To<SupplierBusinessModel>();
                kernel.Bind<IUserBusinessModel>().To<UserBusinessModel>();
                kernel.Bind<IWashingBusinessModel>().To<WashingBusinessModel>();
                kernel.Bind<ISizeBusinessModel>().To<SizeBusinessModel>();
                kernel.Bind<IColorBusinessModel>().To<ColorBusinessModel>();
                kernel.Bind<IProductDetailBusinessModel>().To<ProductDetailBusinessModel>();
                kernel.Bind<IProductBusinessModel>().To<ProductBusinessModel>();
                kernel.Bind<IDeliveryBusinessModel>().To<DeliveryBusinessModel>();
                kernel.Bind<IDeliveryToOutletBusinessModel>().To<DeliveryToOutletBusinessModel>();
                kernel.Bind<IDeliveryBusinessModelHelper>().To<DeliveryBusinessModelHelper>();
                kernel.Bind<ISalesBusinessModel>().To<SalesBusinessModel>();

                kernel.Bind<ILogging>().To<Logging>();

                kernel.Bind<BusinessModelContainer>().ToSelf();

                log4net.Config.XmlConfigurator.Configure();

                AutoMapperConfiguration.RegisterMappings();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SGInventory.Forms.InventoryMainForm(kernel.Get<BusinessModelContainer>()));
            }
        }
    }
}
