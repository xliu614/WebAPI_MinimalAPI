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
            if (ModelState.IsValid) {
                var response = await _webApiExecuter.InvokePost("shirts", shirt);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(shirt);
        }

        public async Task<IActionResult> UpdateShirt(int shirtId) {
            var shirt = await _webApiExecuter.InvokeGet<Shirt>($"shirts/{shirtId}");
            if (shirt != null) {
                return View(shirt);
            }
            return NotFound();
        }
        [HttpPost]
		public async Task<IActionResult> UpdateShirt(Shirt shirt)
		{
            if (ModelState.IsValid)
            {
                await _webApiExecuter.InvokePut<Shirt>($"shirts/{shirt.ShirtId}", shirt);
                return RedirectToAction(nameof(Index));
            }
            return View(shirt);
		}
	}
}
