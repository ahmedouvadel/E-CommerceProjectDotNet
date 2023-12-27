using System.Globalization;

namespace E_CommerceProject.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public int? Id { get; set; }
        public string? ShortDescrip { get; set; }
        public string? LongDescrip { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public int? InStock { get; set; }
        public Category? Category { get; set; }
        public int Amount { get; set; } = 1;
        public string? Total { get => (Price * Amount).ToString("c", CultureInfo.CreateSpecificCulture("en-US")); }
    }
}
