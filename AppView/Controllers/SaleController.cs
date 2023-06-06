using AppDaTa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowAllSale()
        {
            string url = $"https://localhost:7119/api/Sale";
            var client = new HttpClient();
            var respos = await client.GetAsync(url);
            var dataapi = await respos.Content.ReadAsStringAsync();

            var lstsale = JsonConvert.DeserializeObject<List<Sale>>(dataapi);

            return View(lstsale);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSale(Sale sale)
        {
            return View(sale);
        }
        [HttpGet]
        public async Task<IActionResult> EditSale()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditSale(Sale sale)
        {
            return View(sale);
        }

        public async Task<IActionResult> DeleteSale(Guid id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SaleDetail(Guid id)
        {
            return View();
        }
    }
}
