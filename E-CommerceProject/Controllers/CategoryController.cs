using E_CommerceProject.Data;
using E_CommerceProject.Models;
using E_CommerceProject.Work.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProject.Controllers
{
    public class CategoryController : Controller
    {
        //TODO: Make project use unit of work and repository pattern
        //private UnitOfWork _unitOfWork;
        private CategoryManager _categoryManager;
        private ECommerceDB _context;

        public CategoryController(CategoryManager categoryManager, ECommerceDB context)
        {
            _categoryManager = categoryManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryManager.GetCategories());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            Category categ = new Category();

            if (category.Name != null)
            {
                categ.Name = category.Name;
            }

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    categ.ImageCategory = dataStream.ToArray();
                }
            }
            await _categoryManager.CreateCategory(categ);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = await _categoryManager.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    category.ImageCategory = dataStream.ToArray();
                }
            }
            await _categoryManager.EditCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryManager.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
