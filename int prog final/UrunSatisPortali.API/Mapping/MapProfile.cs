using AutoMapper;
using UrunSatisPortali.API.Dtos;
using UrunSatisPortali.API.Models;
using UrunSatisPortali.Dtos;
using UrunSatisPortali.Models;
using UrunSatiSPortali.Models;

namespace UrunSatisPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Urun, UrunDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
