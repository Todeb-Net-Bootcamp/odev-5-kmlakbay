using AutoMapper;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductInsertDto, Product>();
            CreateMap<ProductDetailInsertDto, ProductDetail>();
        }
    }
}
