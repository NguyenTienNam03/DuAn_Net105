using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
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

            ViewBag.lstspctmodel = spctviewmodel.ToList();
			string url = $"https://localhost:7119/api/GioHangCT/GetAll";
            var httpClient = new HttpClient();
            var repos = await httpClient.GetAsync(url);
            string dataapi = await repos.Content.ReadAsStringAsync();
            var ghct =JsonConvert.DeserializeObject<List<GioHangChiTiet>>(dataapi);
            return View(ghct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuatity(GioHangChiTiet ghct)
        {
            string url = $"https://localhost:7119/api/GioHangCT/UpdateGHCT?idspct={ghct.IDSPCT}&soluong={ghct.SoLuong}";
            var obj = JsonConvert.SerializeObject(ghct);
            var httpClient = new HttpClient();
            StringContent content = new StringContent(obj, Encoding.UTF8 , "application/json");
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

        [HttpPost]
        public async Task<IActionResult> CreateBill()
        {
            string url = $"https://localhost:7119/api/HoaDon/1?idkh=305f3d5a-3cf3-4af0-a4d7-807063b6ead0&idvc=1d9e182f-690a-4ce8-9b21-bef1f43cf407";
            return View();
        }
        public async Task<IActionResult> GetAllBill()
        {
            string url = $"https://localhost:7119/api/HoaDon/GetAllHoaDons";
            var client = new HttpClient();
            var repons = await client.GetAsync(url);
            var dataapi = await repons.Content.ReadAsStringAsync();
            var listbill = JsonConvert.DeserializeObject<List<HoaDon>>(dataapi);
            return View(listbill);
        }
    }
}
