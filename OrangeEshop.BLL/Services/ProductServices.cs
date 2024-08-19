using Microsoft.EntityFrameworkCore;
using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task CreateProductAsync(Product product)
        {
            await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.SubmitAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SubmitAsync();
        }

        public async Task RemoveProductAsync(int id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SubmitAsync();
        }
    }
}