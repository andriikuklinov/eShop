using AutoMapper;
using Catalog.API.Models;
using Catalog.BLL.DTO;

namespace Catalog.API.MappingProfile
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<ProductModel, ProductDTO>();
            CreateMap<ProductDTO, ProductModel>();
        }
    }
}
