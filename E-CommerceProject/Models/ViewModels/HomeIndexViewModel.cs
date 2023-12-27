using E_CommerceProject.Models.Dto;

namespace E_CommerceProject.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IList<CategoryDto>? Categories { get; set; } // Notice it's CategoryDto now
        public IList<Product>? Products { get; set; }
    }
}