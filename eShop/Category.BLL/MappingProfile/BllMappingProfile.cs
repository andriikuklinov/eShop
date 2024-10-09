using AutoMapper;
using Catalog.BLL.DTO;
using Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.MappingProfile
{
    public class BllMappingProfile: Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
