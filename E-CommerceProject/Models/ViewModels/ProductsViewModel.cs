namespace E_CommerceProject.Models.ViewModels
{
    public class ProductsViewModel
    {
        public Category? Category { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
