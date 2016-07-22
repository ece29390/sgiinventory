﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Business.Model
{
    public interface ICategoryBusinessModel:ISelectAll<Category>,ISelectByPrimary<Category,int>,IValidate<Category>,IBusinessTransact<Category>,ISave<Category>
    {
       
    }
}
