using E_CommerceProject.Models;
using E_CommerceProject.Work.Repository;

namespace E_CommerceProject.Work.Managers
{
    public class ProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await _productRepository.Delete(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<IList<Product>> GetProductList()
        {
            return await _productRepository.GetProducts();
        }
    }
}
