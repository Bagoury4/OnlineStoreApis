using Store.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.contract
{
    public interface IProductService
    {
       Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();

        Task<ProductDto>  GetProductById(int id);


    }
}
