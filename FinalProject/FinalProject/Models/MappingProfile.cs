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
            // .ReverseMap(); map 2 chiều
        }
    }
}
