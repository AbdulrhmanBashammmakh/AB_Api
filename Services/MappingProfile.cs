using AB_Api.Dto;
using AB_Api.Models;
using AB_Api.ViewModels;
using AutoMapper;

namespace AB_Api.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.IdProduct, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.UnitsNum, act => act.MapFrom(src => src.UnitId))
                .ForMember(dest => dest.CategoriesNum, src => src.MapFrom(src => src.CateId)).ReverseMap();
         
        }
    }
}
