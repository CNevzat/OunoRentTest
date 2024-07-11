using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EntityLayer;
using EntityLayer.Dto;
using EntityLayer.Dto.Category;
using EntityLayer.Entities;

namespace OunoRentApi.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();

            CreateMap<Category, CategoryDto>()
            .ReverseMap();

            CreateMap<CreateCategoryDto, Category>()
            .ReverseMap();

            CreateMap<UpdateCategoryDto,Category>()
            .ReverseMap();
        }
    }
}