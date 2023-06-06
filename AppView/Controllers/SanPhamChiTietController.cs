using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SanPhamChiTietController : Controller
    {
        [HttpGet]
        public IActionResult ShowAllSPCT()
        {
            string url = $"https://localhost:7119/api/SanPhamChiTiet/GetSanPhamChiTiet";
            HttpClient httpClient = new HttpClient();
            var respons = httpClient.GetAsync(url).Result;
            string datapi = respons.Content.ReadAsStringAsync().Result;
            var SPCT = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModels>>(datapi);
            return View(SPCT);
        }
        [HttpGet]
        public IActionResult ShowAllSpSale()
        {
            string url = $"https://localhost:7119/api/SanPhamChiTiet/SanPhamSale";
            HttpClient httpClient = new HttpClient();
            var respons = httpClient.GetAsync(url).Result;
            string datapi = respons.Content.ReadAsStringAsync().Result;
            var SPCT = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModels>>(datapi);
            return View(SPCT);
        }
        [HttpGet] 
        public async Task<IActionResult> CreateDetailProDuct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDetalProduct(SanPhamChiTiet spct)
        {
            return View(spct);
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
        public IActionResult CreateColor(MauSac ms)
        {
            string data = JsonConvert.SerializeObject(ms);
            string url = $"https://localhost:7119/api/MauSac/create-mausac?mausac={ms.Mausac}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("GetAllColor");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMauSac(Guid id)
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
        public async Task<IActionResult> UpdateMauSac(MauSac ms)
        {

            string Url = $"https://localhost:7119/api/MauSac/Edit-color?id={ms.IDMau}&ms={ms.Mausac}";

            var httpClient = new HttpClient(); // tao ra de call api
            string data = JsonConvert.SerializeObject(ms);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(Url, content).Result; // lỗi null

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
    }
}
