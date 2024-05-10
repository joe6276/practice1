using AutoMapper;
using ProductAPIDB.Models;
using ProductAPIDB.Models.DTOS;

namespace ProductAPIDB.Profiles
{
    public class ProductProfiles:Profile
    {

        public ProductProfiles()
        {
            CreateMap<AddProduct, Product>();
            CreateMap<AddCategory, Category>();
            CreateMap<RegisterUser, User>().ForMember(

                dest => dest.UserName, u => u.MapFrom(src => src.Email));
            CreateMap<User, UserResponse>();
        }
    }
}
