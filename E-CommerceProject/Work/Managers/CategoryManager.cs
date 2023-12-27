using E_CommerceProject.Models.Dto;
using E_CommerceProject.Models;
using E_CommerceProject.Work.Repository;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_CommerceProject.Work.Managers
{
    public class CategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IList<CategoryDto>> GetCategories()
        {
            IList<Category> categories = await _categoryRepository.GetCategoryList();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                CategoryName = c.Name,
                CategoryImage = c.ImageCategory,
                ProductCount = c.Products?.Count
            }).ToList();
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryRepository.Add(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task EditCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task<IList<CategoryDto>> GetCategoriesForHomePage()
        {
            // Fetch the categories with the product count included
            IList<Category> categories = await _categoryRepository.GetCategoryList();
            // Map from Category to CategoryDto, preserving the eager loaded product count
            return categories.OrderByDescending(c => c.Id)
                            .Take(5)
                            .Select(c => new CategoryDto
                            {
                                Id = c.Id,
                                CategoryName = c.Name,
                                CategoryImage = c.ImageCategory,
                                ProductCount = c.Products.Count
                            }).ToList();
        }
    }
}