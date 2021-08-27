using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAysnc(int id);
        Task<IReadOnlyList<Product>> GetAllProducsAysnc();
        Task<IReadOnlyList<ProductBrand>> GetAllProducBrandsAysnc();
        Task<IReadOnlyList<ProductType>> GetAllProducTypesAysnc();

    }
}
