using Microsoft.EntityFrameworkCore;
using OrangeEshop.DAL.Entities;
using OrangeEshop.DAL.Interfaces;

namespace OrangeEshop.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepository(EshopDbContext context)
        {
            _categories = context.Set<Category>();
        }

        public async Task<Category?> FindAsync(int id)
        {
            return await _categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categories.ToListAsync();
        }

        public async Task CreateAsync(Category category)
        {
            await _categories.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            _categories.Update(category);
        }

        public async Task RemoveAsync(int id)
        {
            var category = await _categories.FindAsync(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}