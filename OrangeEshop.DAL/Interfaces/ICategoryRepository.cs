using OrangeEshop.DAL.Entities;

namespace OrangeEshop.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> FindAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task RemoveAsync(int id);
    }
}