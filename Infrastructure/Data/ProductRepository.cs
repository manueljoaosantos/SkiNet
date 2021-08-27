using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        private readonly StoreContext _context;

        public async Task<IReadOnlyList<Product>> GetAllProducsAysnc()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAysnc(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProducBrandsAysnc()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProducTypesAysnc()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
