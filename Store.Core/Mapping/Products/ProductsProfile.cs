using AutoMapper;
using Microsoft.Extensions.Options;
using Store.Core.Dtos.Products;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product , ProductDto>()
                .ForMember(d=>d.BrandName , Options => Options.MapFrom(s=> s.Brand.Name) )
                .ForMember(d => d.TypeName, Options => Options.MapFrom(s => s.Type.Name))
                ;
            CreateMap<ProductBrand , TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();


        }


    }
}
