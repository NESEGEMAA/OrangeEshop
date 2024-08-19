using Microsoft.EntityFrameworkCore;
using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL;
using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(EshopDbContext context)
        {
            _products = context.Set<Product>();
        }

        public async Task<Product?> FindAsync(int id)
        {
            return await _products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _products.ToListAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await _products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            _products.Update(product);
        }

        public async Task RemoveAsync(int id)
        {
            var product = await _products.FindAsync(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}