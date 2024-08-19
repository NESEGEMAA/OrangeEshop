using OrangeEshop.DAL.Entities;

namespace OrangeEshop.BLL.Interfaces
{
    public interface ICategoryServices
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task RemoveCategoryAsync(int id);
    }
}