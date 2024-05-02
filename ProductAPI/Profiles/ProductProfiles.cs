using AutoMapper;
using ProductAPI.Models;

namespace ProductAPI.Profiles
{
    public class ProductProfiles:Profile
    {

        public ProductProfiles()
        {
            CreateMap<AddProduct, Product>().ReverseMap();
        }
    }
}
