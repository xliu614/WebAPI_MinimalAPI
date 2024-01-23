using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        public IActionResult Index()
        {
            List<Shirt> shirts = new List<Shirt>() {
                new Shirt () { ShirtId = 1, Brand = "x", Color = "Yellow", Gender = "Men", Price = 10, Size = 8 },
                new Shirt () { ShirtId = 2, Brand = "y", Color = "Green", Gender = "Women", Price = 20, Size = 7}
            };
            return View(shirts);
        }
    }
}
