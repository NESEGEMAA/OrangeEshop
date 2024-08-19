using OrangeEshop.BLL.Interfaces;
using OrangeEshop.DAL;
using OrangeEshop.DAL.Interfaces;

namespace OrangeEshop.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EshopDbContext _context;

        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public UnitOfWork(EshopDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = context;

            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        public async Task<int> SubmitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}