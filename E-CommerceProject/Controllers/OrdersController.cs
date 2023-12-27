using E_CommerceProject.Models;
using E_CommerceProject.Work.Managers;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceProject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ProductManager _productManager;
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
