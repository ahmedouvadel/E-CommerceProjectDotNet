using System.ComponentModel.DataAnnotations;

namespace E_CommerceProject.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public byte[]? ImageCategory { get; set; }
        // Assuming there's a navigation property set up like this
        public ICollection<Product>? Products { get; set; }
    }
}


