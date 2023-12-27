using E_CommerceProject.Data;
using E_CommerceProject.Models;
using E_CommerceProject.Work.Repository;

namespace E_CommerceProject.Work
{
    public class UnitOfWork
    {
        private ECommerceDB _context;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Product> productRepository;

        public UnitOfWork(ECommerceDB context)
        {
            _context = context;
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                return new GenericRepository<Category>(_context);
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
