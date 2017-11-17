using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SGInventory.Model;
using SGInventory.Presenters.Model;

namespace SGInventory.Presenters.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ProductInventoryView, ProductInventoryViewModel>();
            Mapper.CreateMap<Sales, SalesDisplayModel>()
                .ForMember(dest => dest.Code, src => src.MapFrom(opt => opt.ProductDetail.Product.StockNumber))
                .ForMember(dest=>dest.Size,src=>src.MapFrom(opt=>opt.ProductDetail.Size.Code))
                .ForMember(dest => dest.Color, src => src.MapFrom(opt => opt.ProductDetail.Color.Code))
                .ForMember(dest => dest.Washing, src => src.MapFrom(opt => opt.ProductDetail.Washing.Code))
                ;
                  
        }
    }
}
