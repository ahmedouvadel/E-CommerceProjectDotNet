namespace E_CommerceProject.Models.Dto
{
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string? CategoryName { get; set; }
        public byte[]? CategoryImage { get; set; }
        public int? ProductCount { get; set; }
    }
}
