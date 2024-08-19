using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Interfaces
{
    public interface IProductServices
    {
        public Task<Product> GetProductByIdAsync(int id);
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task CreateProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task RemoveProductAsync(int id);
    }
}