using AutoMapper;
using MarketPlaceBLL.DTOs;
using MarketPlaceBLL.Models;
using MarketPlaceDAL.Entities;

namespace MarketPlaceBLL.Mapper
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductDto, Product>();
            CreateMap<User, UserDto>();
            CreateMap<ProductCreateModel, Product>();
            CreateMap<ShopCreateModel,  Shop>();
        }
    }
}
