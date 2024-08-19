using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.CategoryRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.CreateAsync(category);
            await _unitOfWork.SubmitAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SubmitAsync();
        }

        public async Task RemoveCategoryAsync(int id)
        {
            await _unitOfWork.CategoryRepository.RemoveAsync(id);
            await _unitOfWork.SubmitAsync();
        }
    }
}