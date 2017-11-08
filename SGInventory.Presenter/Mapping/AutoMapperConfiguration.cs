using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SGInventory.Model;

namespace SGInventory.Presenters.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ProductInventoryView, ProductInventoryViewModel>();            
        }
    }
}
