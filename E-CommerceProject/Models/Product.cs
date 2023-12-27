using System.ComponentModel.DataAnnotations;

namespace E_CommerceProject.Models
{
    public class Product
    {
        internal int inStock;

        [Key]
        public int Id { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public decimal? Price { get; set; }
        public byte[]? PreviewIage { get; set; }
        public int? InStock { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        internal Category GetCategory()
        {
            throw new NotImplementedException();
        }

        public static implicit operator Product(Category v)
        {
            throw new NotImplementedException();
        }
    }
}
