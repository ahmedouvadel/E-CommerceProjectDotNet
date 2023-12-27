using E_CommerceProject.Models;

namespace E_CommerceProject.Work.Repository
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<Product> GetById(int id);
        Task<IList<Product>> GetProducts();
    }
}
