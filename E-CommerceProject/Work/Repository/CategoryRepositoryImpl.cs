using E_CommerceProject.Data;
using E_CommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceProject.Work.Repository
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly ECommerceDB _context;

        public CategoryRepositoryImpl(ECommerceDB context)
        {
            _context = context;
        }

        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case when the category is not found. You may want to throw an exception or handle this case accordingly.
                throw new DbUpdateConcurrencyException("The category to be deleted was not found in the database.");
            }
        }

        public async Task<Category> GetById(int id)
        {
            // Using FindAsync for getting the entity by primary key, or FirstOrDefaultAsync if you need to include child entities or expect null.
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Category>> GetCategoryList()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task Update(Category category)
        {
            var dbCategory = await _context.Categories.FindAsync(category.Id);
            if (dbCategory != null)
            {
                _context.Entry(dbCategory).CurrentValues.SetValues(category);
                if (category.Products != null && category.Products.Any())
                {
                    // Handle related entities like Products if necessary
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case when the category is not found. You may want to throw an exception or handle this case accordingly.
                throw new DbUpdateConcurrencyException("The category to be updated was not found in the database.");
            }
        }
    }
}