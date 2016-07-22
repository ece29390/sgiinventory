using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Dal
{
    public interface IWashingDal:ICrud<Washing>
    {
        List<Washing> SelectBy(string columnName,string criteria);
    }
}
