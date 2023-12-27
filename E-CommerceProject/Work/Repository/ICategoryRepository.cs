using E_CommerceProject.Models;

namespace E_CommerceProject.Work.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);
        Task Add(Category category);
        Task Delete(int categoryId);
        Task<IList<Category>> GetCategoryList();
        Task Update(Category category);
    }
}
