using AppDaTa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllSale()
        {
            string url = $"https://localhost:7119/api/Sale/Getall";
            var client = new HttpClient();
            var respos = await client.GetAsync(url);
            var dataapi = await respos.Content.ReadAsStringAsync();

            var lstsale = JsonConvert.DeserializeObject<List<Sale>>(dataapi);

            return View(lstsale);
        }
        [HttpGet]
        public IActionResult CreateSale()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult CreateSale(Sale sale)
        {
			
			string url = $"https://localhost:7119/api/Sale/CreateSale?masale={sale.MaSale}&nbd={sale.NgayBatDau}&nkt={sale.NgayKetThuc}&giatrisale={sale.GiaTriSale}";
			var client = new HttpClient();
			var sale1 = JsonConvert.SerializeObject(sale);
			StringContent content = new StringContent(sale1, Encoding.UTF8, "application/json");
			HttpResponseMessage create =  client.PostAsync(url, content).Result;
            return RedirectToAction("ShowAllSale");
        }
        [HttpGet]
        public async Task<IActionResult> EditSale(Guid id)
        {

            string url = $"https://localhost:7119/api/Sale/Get?id={id}";
            var client = new HttpClient();
            var repos = await client.GetAsync(url);
            var datapi = await repos.Content.ReadAsStringAsync();
            Sale sale = JsonConvert.DeserializeObject<Sale>(datapi);
            return View(sale);

        }
        [HttpPost]
        public async Task<IActionResult> EditSale(Sale sale)
        {
            string url = $"https://localhost:7119/api/Sale/EditSale?id={sale.IDSale}&masale={sale.MaSale}&nbd={sale.NgayBatDau}&nkt={sale.NgayKetThuc}&giatrisale={sale.GiaTriSale}";
		
			var client = new HttpClient();
            var sale1 = JsonConvert.SerializeObject(sale);
            StringContent content = new StringContent(sale1, Encoding.UTF8, "application/json");
			HttpResponseMessage Update = await client.PutAsync(url, content);
            return RedirectToAction("ShowAllSale");
        }

        public async Task<IActionResult> SaleDetail(Guid id)
        {
            string url = $"https://localhost:7119/api/Sale/Get?id={id}";
            var client = new HttpClient();
            var repos = await client.GetAsync(url);
            var datapi = await repos.Content.ReadAsStringAsync();
            Sale sale = JsonConvert.DeserializeObject<Sale>(datapi);
            return View(sale);
        }

       
        public async Task<IActionResult> DeleteSale(Sale sale)
        {
            string url = $"https://localhost:7119/api/Sale/Delete?id={sale.IDSale}";
            var client = new HttpClient();
            var sale1 = JsonConvert.SerializeObject(sale);
            StringContent content = new StringContent(sale1, Encoding.UTF8, "application/json");
			HttpResponseMessage Update = await client.PutAsync(url, content);
            return RedirectToAction("ShowAllSale");
        }
    }
}
