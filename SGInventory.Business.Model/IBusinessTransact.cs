﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model
{
    public interface IBusinessTransact<T>
    {
        void Delete(T model);
        void CreateOrUpdate(T model);
    }
}
