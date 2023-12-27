using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceProject.Work.Repository
{
    public class ProductRepositoryImpl: IProductRepository
    {
        private readonly ECommerceDB _context;
        public ProductRepositoryImpl(ECommerceDB context)
        {
            _context = context;
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            return product;
        }

        public async Task<IList<Product>> GetProducts()
        {
            var products = _context.Products.Include(p => p.Category);
            return await products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
