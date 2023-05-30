using AppDaTa.Models;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllColor()
        {
            string url = $"https://localhost:7119/api/MauSac";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string dataapi = await response.Content.ReadAsStringAsync();

            var listcolor = JsonConvert.DeserializeObject<List<MauSac>>(dataapi);

            return View(listcolor);
        }
        [HttpGet]
        public IActionResult CreateColor()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult CreateColor(MauSac ms)
        {
            string data = JsonConvert.SerializeObject(ms);
            string url = $"https://localhost:7119/api/MauSac/create-mausac?mausac={ms.Mausac}";
            
            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("GetAllColor");
        }

        [HttpGet]
        public async Task<IActionResult> EditColor(Guid id)
        {
            string Url = $"https://localhost:7119/api/MauSac/{id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.GetAsync(Url); // lay du lieu tu api url 
                                                           // lay du lieu Json tra ve API duoc call dang String
            string apiData = await response.Content.ReadAsStringAsync();
            // lay ket qua tra ve tu API dang JSon
            // Doc tu string JSon vua thu duoc sang double
            MauSac color = JsonConvert.DeserializeObject<MauSac>(apiData);
            //ViewData["result"] = "Toc do chay trung binh cua ban la : " + col;
            return View(color);
        }

        [HttpPost]
        public async Task<IActionResult> EditColor(MauSac ms)
        {
            
            string url = $"https://localhost:7119/api/MauSac/Edit-color?id={ms.IDMau}&mausac={ms.Mausac}";
            
            var client = new HttpClient();
            string data = JsonConvert.SerializeObject(ms);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PutAsync(url, content).Result;

            return RedirectToAction("GetAllColor");
        }
        [HttpGet]
        public async Task<IActionResult> DetailColor(Guid id)
        {
            string Url = $"https://localhost:7119/api/MauSac/{id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.GetAsync(Url); // lay du lieu tu api url 
                                                           // lay du lieu Json tra ve API duoc call dang String
            string apiData = await response.Content.ReadAsStringAsync();
            // lay ket qua tra ve tu API dang JSon
            // Doc tu string JSon vua thu duoc sang double
            MauSac color = JsonConvert.DeserializeObject<MauSac>(apiData);
            //ViewData["result"] = "Toc do chay trung binh cua ban la : " + col;
            return View(color);
        }
        public async Task<IActionResult> DeleteColor(Guid id)
        {
            string Url = $"https://localhost:7119/api/MauSac/Delete-color?id={id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.DeleteAsync(Url);

            return RedirectToAction("GetAllColor");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}