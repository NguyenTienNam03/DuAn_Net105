using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class AccountController : Controller
    {
        //login , đăng kí, mau , bill, hóa đơn chi tiết , giỏ hàng , giỏ hàng chi tiết.
        private QLBG_Context _context = new QLBG_Context();
        private List<SanPhamChiTietViewModels> spctviewmodel = new List<SanPhamChiTietViewModels>();

        [HttpGet]
        public async Task<IActionResult> GioHangCT()
        {
            
            ViewBag.IDUser = Guid.Parse("305f3d5a-3cf3-4af0-a4d7-807063b6ead0");
            ViewBag.lstspctmodel = spctviewmodel.ToList();
            string url = $"https://localhost:7119/api/GioHangCT/GetAll";
            var httpClient = new HttpClient();
            var repos = await httpClient.GetAsync(url);
            string dataapi = await repos.Content.ReadAsStringAsync();
            var ghct = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(dataapi);
            return View(ghct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuatity(GioHangChiTiet ghct)
        {
            string url = $"https://localhost:7119/api/GioHangCT/UpdateGHCT?idspct={ghct.IDSPCT}&soluong={ghct.SoLuong}";
            var obj = JsonConvert.SerializeObject(ghct);
            var httpClient = new HttpClient();
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var repos = await httpClient.PutAsync(url, content);
            return RedirectToAction("GioHangCT", "Account");
        }

        public async Task<IActionResult> DeleteItem(Guid id)
        {
            string url = $"https://localhost:7119/api/GioHangCT/DeleteGHCT?id={id}";
            var client = new HttpClient();
            var repos = await client.DeleteAsync(url);
            return RedirectToAction("GioHangCT", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBill()
        {
            string url = $"https://localhost:7119/api/HoaDon/GetAllHoaDons";
            var client = new HttpClient();
            var repons = await client.GetAsync(url);
            var dataapi = await repons.Content.ReadAsStringAsync();
            var listbill = JsonConvert.DeserializeObject<List<HoaDon>>(dataapi);
            return View(listbill);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> CreateBill(HoaDon hoaDon)
        {
            // CreateBill
            string urlcreatebill = $"https://localhost:7119/api/HoaDon/1?idkh=305f3d5a-3cf3-4af0-a4d7-807063b6ead0&idvc=1d9e182f-690a-4ce8-9b21-bef1f43cf407";
            var client = new HttpClient();
            var bill = JsonConvert.SerializeObject(hoaDon);
            StringContent content = new StringContent(bill, Encoding.UTF8, "application/json");
            HttpResponseMessage createbill = await client.PostAsync(urlcreatebill, content);

            //return RedirectToAction("BillDetail", "Account", new { id = hoaDon.IdBill });
            return RedirectToAction("EditBill");
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> EditBill(HoaDon hoaDon)
        {
			ViewBag.voucher = new SelectList(_context.voucher.ToList().OrderBy(c => c.GiaTriVoucher), "IDVoucher", "GiaTriVoucher");
			var client = new HttpClient();
            string UrlID = $"https://localhost:7119/api/HoaDon/Lay1GiaTri";
            var repons1 = await client.GetAsync(UrlID);
            var dataapi1 = await repons1.Content.ReadAsStringAsync();
            HoaDon billdt1 = JsonConvert.DeserializeObject<HoaDon>(dataapi1);
            Guid id = billdt1.IdBill;



            // BillDetail
            string urlbildetail = $"https://localhost:7119/api/HoaDon/1?idhoadon={id}&idvoucher={hoaDon.IDVoucher}&tennguoinhan={hoaDon.TenNguoiNhan}&sdt={hoaDon.SDTNguoiNhan}&dc={hoaDon.DiaChiNguoiNhan}";

            var update = JsonConvert.SerializeObject(hoaDon);
            StringContent content = new StringContent (update, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = await client.PutAsync(urlbildetail , content);
            if (repons.IsSuccessStatusCode)
            {
                return RedirectToAction("BillDetail" , "Account" , new {id = id});
            }else
            {
                return View(billdt1);
            }
        }
        public async Task<IActionResult> BillDetail(Guid id)
        {
            var client = new HttpClient();
            string urlonlybill = $"https://localhost:7119/api/HoaDonCT/GetHoaDonChiTiets?id={id}";
            var repons1 = await client.GetAsync(urlonlybill);
            var dataapi1 = await repons1.Content.ReadAsStringAsync();
            var billdt1 = JsonConvert.DeserializeObject<List<HoaDonChiTiet>>(dataapi1);
            return View(billdt1);
        }
        [HttpGet]

        [HttpPost]
        public async Task<IActionResult> Login(NguoiDung nguoiDung)
        {
            string url = $"https://localhost:7119/api/NguoiDung?email={nguoiDung.Email}&pass={nguoiDung.MatKhau}";
            var client = new HttpClient();
            var user = JsonConvert.SerializeObject(nguoiDung);
            StringContent content = new StringContent(user,Encoding.UTF8 , "application/json");
            var repos = await client.PostAsync(url, content);

            if(repos.IsSuccessStatusCode)
            {
                return RedirectToAction("TrangChu", "SanPhamChiTiet");
            }
			return View();
        }
    }
}
