using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;
using Size = AppDaTa.Models.Size;

namespace AppView.Controllers
{
    public class SanPhamChiTietController : Controller
    {
        // spct , 
        private QLBG_Context _context = new QLBG_Context();
		public SanPhamChiTietController() { }
		[HttpGet]
		public IActionResult TrangChu()
		{
			string url = $"https://localhost:7119/api/SanPhamChiTiet/GetSanPhamChiTiet";
			HttpClient httpClient = new HttpClient();
			var respons = httpClient.GetAsync(url).Result;
			string datapi = respons.Content.ReadAsStringAsync().Result;
			var SPCT = JsonConvert.DeserializeObject<List<SanPhamChiTietViewModels>>(datapi);
			return View(SPCT);
		}
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
			ViewBag.Sale = new SelectList(_context.Sale.ToList().Where(c => c.TrangThai == 1).OrderBy(c => c.GiaTriSale), "IDSale", "GiaTriSale");
			ViewBag.Hang = new SelectList(_context.hangSXs.ToList().OrderBy(c => c.TenHangSX), "IDHangSx", "TenHangSX");
			ViewBag.TheLoai = new SelectList(_context.theLoai.ToList().OrderBy(c => c.TenTheLoai), "IDTheLoai", "TenTheLoai");
			return View();
        }
        [HttpPost]
        public async Task< IActionResult> CreateProductDetail(SanPhamChiTiet spct)
        {
            string url = $"https://localhost:7119/api/SanPhamChiTiet/Create-spct?idms={spct.IDMau}&idsize={spct.IDSize}&idsp={spct.IDSP}&idtl={spct.IDTheLoai}&idhangsx={spct.IDHang}&idsale={spct.IDSale}&giaban={spct.GiaBan}&soluong={spct.SoLuong}&anh={spct.Anh}&mota={spct.MoTa}\r\n";
            var spct1 = JsonConvert.SerializeObject(spct);
            var client = new HttpClient();
            StringContent content = new StringContent(spct1 ,Encoding.UTF8, "application/json");
            HttpResponseMessage repons = await client.PostAsync(url, content);

			return RedirectToAction("ShowAllSPCT");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProDuctDetail(Guid id)
        {
            ViewBag.Color = new SelectList(_context.maus.ToList().OrderBy(c => c.Mausac), "IDMau", "Mausac");
            ViewBag.SanPham = new SelectList(_context.sanPhams.ToList().OrderBy(c => c.TenSP), "IdSP", "TenSP");
            ViewBag.Size = new SelectList(_context.sizes.ToList().OrderBy(c => c.SizeGiay), "IDSize", "SizeGiay");
            ViewBag.Sale = new SelectList(_context.Sale.ToList().Where(c => c.TrangThai == 1).OrderBy(c => c.GiaTriSale), "IDSale", "GiaTriSale");
            ViewBag.Hang = new SelectList(_context.hangSXs.ToList().OrderBy(c => c.TenHangSX), "IDHangSx", "TenHangSX");
            ViewBag.TheLoai = new SelectList(_context.theLoai.ToList().OrderBy(c => c.TenTheLoai), "IDTheLoai", "TenTheLoai");
            string url = $"https://localhost:7119/api/SanPhamChiTiet/{id}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var detail = await response.Content.ReadAsStringAsync();
            SanPhamChiTiet spct = JsonConvert.DeserializeObject<SanPhamChiTiet>(detail);
            return View(spct);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProDuctDetail(SanPhamChiTiet spct)
        {
            string url = $"https://localhost:7119/api/SanPhamChiTiet/1?idspct={spct.IDSPCT}&idms={spct.IDMau}&idsize={spct.IDSize}&idsp={spct.IDSP}&idtl={spct.IDTheLoai}&idhangsx={spct.IDHang}&idsale={spct.IDSale}&giaban={spct.GiaBan}&soluong={spct.SoLuong}&anh={spct.Anh}&mota={spct.MoTa}&trangthai={spct.TrangThai}";
            var spct1 = JsonConvert.SerializeObject(spct);
            var client = new HttpClient();
            StringContent content = new StringContent(spct1, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = await client.PutAsync(url, content);

            return RedirectToAction("ShowAllSPCT");
        }

        // MAU SAC
        [HttpGet]
        public async Task<IActionResult> GetAllColor()
        {
            string url = $"https://localhost:7119/api/MauSac/GetAllColor";

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

        // SAN PHAM
        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            string url = $"https://localhost:7119/api/SanPham/GetAllSanPhams";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string dataapi = await response.Content.ReadAsStringAsync();
            var listSP = JsonConvert.DeserializeObject<List<SanPham>>(dataapi);
            return View(listSP);
        }
        [HttpGet]
        public IActionResult CreateSanPham()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSanPham(SanPham sp)
        {
            string data = JsonConvert.SerializeObject(sp);
            string url = $"https://localhost:7119/api/SanPham/Create-SanPham?ten={sp.TenSP}";
            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;
            return RedirectToAction("GetAllSanPham");
        }
        [HttpGet]
        public async Task<IActionResult> EditSanPham(Guid id)
        {
            string Url = $"https://localhost:7119/api/SanPham/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);
            string apiData = await response.Content.ReadAsStringAsync();
            SanPham sp = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(sp);
        }

        [HttpPost]
        public async Task<IActionResult> EditSanPham(SanPham sp)
        {

            string url = $"https://localhost:7119/api/SanPham/edit-SanPham?id={sp.IdSP}&mausac={sp.TenSP}";

            var client = new HttpClient();
            string data = JsonConvert.SerializeObject(sp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PutAsync(url, content).Result;
            return RedirectToAction("GetAllSanPham");
        }

        // Size

        [HttpGet]
        public async Task<IActionResult> GetALlSize()
        {
            string url = $"https://localhost:7119/api/Size/GetAll";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string dataapi = await response.Content.ReadAsStringAsync();

            var listsize = JsonConvert.DeserializeObject<List<Size>>(dataapi);

            return View(listsize);
        }
        [HttpGet]
        public IActionResult CreateSize()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CreateSize(Size size)
        {
            string data = JsonConvert.SerializeObject(size);
            string url = $"https://localhost:7119/api/Size/1?sizegiay={size.SizeGiay}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("GetALlSize");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSize(Guid id)
        {
            string Url = $"https://localhost:7119/api/Size/{id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.GetAsync(Url); // lay du lieu tu api url 
                                                           // lay du lieu Json tra ve API duoc call dang String
            string apiData = await response.Content.ReadAsStringAsync();
            // lay ket qua tra ve tu API dang JSon
            // Doc tu string JSon vua thu duoc sang double
            Size size = JsonConvert.DeserializeObject<Size>(apiData);
            //ViewData["result"] = "Toc do chay trung binh cua ban la : " + col;
            return View(size);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSize(Size size)
        {

            string Url = $"https://localhost:7119/api/Size/1?id={size.IDSize}&sizegiay={size.SizeGiay}";

            var httpClient = new HttpClient(); // tao ra de call api
            string data = JsonConvert.SerializeObject(size);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(Url, content).Result; // lỗi null

            return RedirectToAction("GetALlSize");
        }
        //THE LOAI

        [HttpGet]
        public async Task<IActionResult> GetAllTheLoai()
        {
            string url = $"https://localhost:7119/api/controller";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string dataapi = await response.Content.ReadAsStringAsync();

            var listTheLoai = JsonConvert.DeserializeObject<List<TheLoai>>(dataapi);

            return View(listTheLoai);
        }
        [HttpGet]
        public IActionResult CreateTheLoai()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTheLoai(TheLoai tl)
        {
            string data = JsonConvert.SerializeObject(tl);
            string url = $"https://localhost:7119/api/controller/CreateTheLoai?tentheloai={tl.TenTheLoai}&mota={tl.MoTa}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("GetAllTheLoai");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTheLoai(Guid id)
        {
            string Url = $"https://localhost:7119/api/controller/Get?id={id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.GetAsync(Url); // lay du lieu tu api url 
                                                           // lay du lieu Json tra ve API duoc call dang String
            string apiData = await response.Content.ReadAsStringAsync();
            // lay ket qua tra ve tu API dang JSon
            // Doc tu string JSon vua thu duoc sang double
            TheLoai theloai = JsonConvert.DeserializeObject<TheLoai>(apiData);
            //ViewData["result"] = "Toc do chay trung binh cua ban la : " + col;
            return View(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTheLoai(TheLoai tl)
        {

            string Url = $"https://localhost:7119/api/controller/UpdateTheLoai?id={tl.IDTheLoai}&theloai={tl.TenTheLoai}&mota={tl.MoTa}";

            var httpClient = new HttpClient(); // tao ra de call api
            string data = JsonConvert.SerializeObject(tl);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(Url, content).Result; // lỗi null

            return RedirectToAction("GetAllTheLoai");
        }
        //// HANG SX

        [HttpGet]
        public async Task<IActionResult> GetallHangSX()
        {
            string url = $"https://localhost:7119/api/HangSX/GetAll";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string dataapi = await response.Content.ReadAsStringAsync();

            var listhangsx = JsonConvert.DeserializeObject<List<HangSX>>(dataapi);

            return View(listhangsx);
        }
        [HttpGet]
        public IActionResult CreateHangsx()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateHangsx(HangSX hsx)
        {
            string data = JsonConvert.SerializeObject(hsx);
            string url = $"https://localhost:7119/api/HangSX/CreateHangSX?tenHangSX={hsx.TenHangSX}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("GetallHangSX");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHangSX(Guid id)
        {
            string Url = $"https://localhost:7119/api/HangSX/Get?id={id}";
            var httpClient = new HttpClient(); // tao ra de call api

            var response = await httpClient.GetAsync(Url); // lay du lieu tu api url 
                                                           // lay du lieu Json tra ve API duoc call dang String
            string apiData = await response.Content.ReadAsStringAsync();
            // lay ket qua tra ve tu API dang JSon
            // Doc tu string JSon vua thu duoc sang double
            HangSX hsx = JsonConvert.DeserializeObject<HangSX>(apiData);
            //ViewData["result"] = "Toc do chay trung binh cua ban la : " + col;
            return View(hsx);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHangSX(HangSX hsx)
        {

            string Url = $"https://localhost:7119/api/HangSX/UpdateHangSX?id={hsx.IDHangSx}&tenHangSx={hsx.TenHangSX}";

            var httpClient = new HttpClient(); // tao ra de call api
            string data = JsonConvert.SerializeObject(hsx);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync(Url, content).Result; // lỗi null

            return RedirectToAction("GetallHangSX");
        }


        // ADDTOCART
        public IActionResult ThemVaoGioHang(GioHangChiTiet spct , Guid id)
        {
            string url = $"https://localhost:7119/api/GioHangCT/1?idgh=305f3d5a-3cf3-4af0-a4d7-807063b6ead0&idspct={id}";
            spct.IDSPCT = id;
            var data = JsonConvert.SerializeObject(spct);
            var client = new HttpClient();

			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			HttpResponseMessage repons = client.PostAsync(url, content).Result;

			return RedirectToAction("GioHangCT" ,"Account");
        }
    }
}
