using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Type)
            .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IReadOnlyCollection<Brand>> GetProductBrandsAsync()
        {
            var brands = await _context.Brands.ToListAsync();
            return brands;
        }

        public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
        {
            var products = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Type)
            .ToListAsync();
            return products;
        }

        public async Task<IReadOnlyCollection<Type>> GetProductTypesAsync()
        {
            var types = await _context.Types.ToListAsync();
            return types;
        }
    }
}