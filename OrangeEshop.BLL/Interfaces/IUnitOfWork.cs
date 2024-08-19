using OrangeEshop.DAL.Interfaces;

namespace OrangeEshop.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        Task<int> SubmitAsync();
    }
}