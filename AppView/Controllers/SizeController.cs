using AppDaTa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SizeController : Controller
    {
        private QLBG_Context _context = new QLBG_Context();
        public SizeController() { }

        [HttpGet]
        public async Task<IActionResult> ShowAllSize()
        {
            string url = $"https://localhost:7119/api/Size";
            HttpClient client = new HttpClient();
            var respos = await client.GetAsync(url);
            var dataapi = await respos.Content.ReadAsStringAsync();
            var s = JsonConvert.DeserializeObject<List<Size>>(dataapi);
            return View(s);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSize()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSize(Size s)
        {
            string data = JsonConvert.SerializeObject(s);
            string url = $"https://localhost:7119/api/Size/Create-size{s.IDSize}";
            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("ShowAllSize");
        }
        [HttpGet]
        public async Task<IActionResult> EditSize(Guid id)
        {
            string Url = $"https://localhost:7119/api/Size{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);
            string Dataapi = await response.Content.ReadAsStringAsync();
            Size s = JsonConvert.DeserializeObject<Size>(Dataapi);
            return View(s);
        }
        [HttpPost]
        public async Task<IActionResult> EditSize(Size s)
        {

            string url = $"https://localhost:7119/api/Size/Edit-size{s.IDSize}&mausac={s.SizeGiay}";

            var client = new HttpClient();
            string data = JsonConvert.SerializeObject(s);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PutAsync(url, content).Result;
            return RedirectToAction("ShowAllSize");
        }
        public async Task<IActionResult> DeleteSize(Guid id)
        {
            string Url = $"https://localhost:7119/api/Size/Delete-Size?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(Url);
            return RedirectToAction("ShowAllSize");
        }
    }
}
