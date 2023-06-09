using AppDaTa.Models;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;

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

        public async Task<IActionResult> DeleteItem(Guid id)
        {
            string url = $"https://localhost:7119/api/GioHangCT/DeleteGHCT?id={id}";
            var client = new HttpClient();
            var repos = await client.DeleteAsync(url);
            return RedirectToAction("GioHangCT", "Account");
        }
    }
}
