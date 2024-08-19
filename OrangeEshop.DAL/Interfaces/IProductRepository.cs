using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> FindAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(int id);
    }
}