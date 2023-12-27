namespace E_CommerceProject.Models.ViewModels
{
    public class ShoppingCartIndexViewModel
    {
        public ShoppingCart? ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
