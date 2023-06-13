using AppDaTa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class HangSXController : Controller
    {
        private QLBG_Context _context = new QLBG_Context();
        public HangSXController() { }

        [HttpGet]
        public async Task<IActionResult> ShowAllHangSX()
        {
            string url = $"https://localhost:7119/api/HangSX";
            HttpClient client = new HttpClient();
            var respos = await client.GetAsync(url);
            var dataapi = await respos.Content.ReadAsStringAsync();
            var hangSX = JsonConvert.DeserializeObject<List<HangSX>>(dataapi);
            return View(hangSX);
        }
        [HttpGet]
        public async Task<IActionResult> CreateHangSX()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateHangSX(HangSX hsx)
        {
            string data = JsonConvert.SerializeObject(hsx);
            string url = $"https://localhost:7119/api/HangSX/create-HangSX{hsx.IDHangSx}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("ShowAllHangSX");
        }
        [HttpGet]
        public async Task<IActionResult> EditHangSX(Guid id)
        {
            string Url = $"https://localhost:7119/api/HangSX{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);
            string apiData = await response.Content.ReadAsStringAsync();
            HangSX hsx = JsonConvert.DeserializeObject<HangSX>(apiData);
            return View(hsx);
        }
        [HttpPost]
        public async Task<IActionResult> EditHangSX(HangSX hsx)
        {

            string url = $"https://localhost:7119/api/HangSX/edit-hangSX{hsx.IDHangSx}&mausac={hsx.TenHangSX}";

            var client = new HttpClient();
            string data = JsonConvert.SerializeObject(hsx);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PutAsync(url, content).Result;
            return RedirectToAction("ShowAllHangSX");
        }
        public async Task<IActionResult> DeleteHangSX(Guid id)
        {
            string Url = $"https://localhost:7119/api/HangSX/Delete-HangSX?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(Url);
            return RedirectToAction("ShowAllHangSX");
        }
    }
}
