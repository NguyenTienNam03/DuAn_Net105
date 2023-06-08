using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SanPhamChiTietController : Controller
    {
        private QLBG_Context _context = new QLBG_Context();
		public SanPhamChiTietController() { }
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
        public async Task<IActionResult> CreateProductDetail()
        {
			ViewBag.Color = new SelectList(_context.maus.ToList().OrderBy(c => c.Mausac), "IDMau", "Mausac");
			ViewBag.SanPham = new SelectList(_context.sanPhams.ToList().OrderBy(c => c.TenSP), "IdSP", "TenSP");
			ViewBag.Size = new SelectList(_context.sizes.ToList().OrderBy(c => c.SizeGiay), "IDSize", "SizeGiay");
			ViewBag.Sale = new SelectList(_context.Sale.ToList().OrderBy(c => c.GiaTriSale), "IDSale", "GiaTriSale");
			ViewBag.Hang = new SelectList(_context.hangSXs.ToList().OrderBy(c => c.TenHangSX), "IDHangSx", "TenHangSX");
			ViewBag.TheLoai = new SelectList(_context.theLoai.ToList().OrderBy(c => c.TenTheLoai), "IDTheLoai", "TenTheLoai");
			return View();
        }
        [HttpPost]
        public IActionResult CreateProductDetail(SanPhamChiTiet spct)
        {
            string url = $"https://localhost:7119/api/SanPhamChiTiet/Create-spct?idms={spct.IDMau}&idsize={spct.IDSize}&idsp={spct.IDSP}&idtl={spct.IDTheLoai}&idhangsx={spct.IDHang}&idsale={spct.IDSale}&giaban={spct.GiaBan}&soluong={spct.SoLuong}&anh={spct.Anh}&mota={spct.MoTa}\r\n";
            var spct1 = JsonConvert.SerializeObject(spct);
            var client = new HttpClient();
            StringContent content = new StringContent(spct1 ,Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

			return RedirectToAction("ShowAllSPCT");
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
