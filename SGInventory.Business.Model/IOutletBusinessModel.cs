using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface IOutletBusinessModel:IBusinessTransact<Outlet>,IValidate<Outlet>,ISave<Outlet>,ISelectAll<Outlet>,ISelectByPrimary<Outlet,int>
    {

    }
}
