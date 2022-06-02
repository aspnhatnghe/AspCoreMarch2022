using AutoMapper;
using FinalProject.Data;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //định nghĩa các bộ map
            CreateMap<Product, ProductVM>();
            //.ForMember(pvm => pvm.SoldPrice, b => b.MapFrom(p => p.ProductPrices.FirstOrDefault().Price));
            // .ReverseMap(); map 2 chiều

            CreateMap<RegisterVM, Customer>();
        }
    }
}
