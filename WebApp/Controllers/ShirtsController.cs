using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
		private readonly IWebApiExecuter _webApiExecuter;

		public ShirtsController(IWebApiExecuter webApiExecuter)
        {
			this._webApiExecuter = webApiExecuter;
		}
        public async Task<IActionResult> Index()
        {
            //List<Shirt> shirts = new List<Shirt>() {
            //    new Shirt () { ShirtId = 1, Brand = "x", Color = "Yellow", Gender = "Men", Price = 10, Size = 8 },
            //    new Shirt () { ShirtId = 2, Brand = "y", Color = "Green", Gender = "Women", Price = 20, Size = 7}
            //};
            return View(await _webApiExecuter.InvokeGet<List<Shirt>>("shirts"));
        }

        public IActionResult CreateShirt() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateShirt(Shirt shirt) {
            return View(shirt);
        }
    }
}
