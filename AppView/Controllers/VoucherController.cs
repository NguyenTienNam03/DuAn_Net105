using Microsoft.AspNetCore.Mvc;
using AppDaTa.Models;
using AppView.Models;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class VoucherController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       HttpClient client;
        
        

        
        public VoucherController( ILogger<HomeController> logger)
        {
            client = new HttpClient();
            
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
        public async Task<IActionResult> ShowAllVoucher()
        {
			string url = $"https://localhost:7119/api/Voucher/GettAllVoucher";
			var response = client.GetAsync(url).Result;
			string a = response.Content.ReadAsStringAsync().Result;
			var listVoucher = JsonConvert.DeserializeObject<List<Voucher>>(a);
			return View(listVoucher);
		}
        [HttpGet]
        public IActionResult CreateVoucher()
        {
            return View();
           
        }
        [HttpPost]
        public IActionResult CreateVoucher(Voucher a)
        {
            string data = JsonConvert.SerializeObject(a);
            string url = $"https://localhost:7119/api/Voucher/CreateVoucher?MaVoucher={a.MaVoucher}&NgayTao={a.NgayTao}&" +
                $"Dieukien={a.Dieukien}&NgayBatDau={a.NgayBatDau}&" +
                $"NgayKetThuc={a.NgayKetThuc}&GiaTriVoucher={a.GiaTriVoucher}&Soluong={a.Soluong}";


            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage respon = client.PostAsync(url, content).Result;
            return RedirectToAction("GetAllVoucher");
        }
        [HttpGet]
        public async Task<IActionResult> EditVoucher(Guid ID)
        {
            string url = $"https://localhost:7119/api/Voucher/GettByIDVoucher?id={ID}";
            var respon=  client.GetAsync(url).Result;
            string data = await respon.Content.ReadAsStringAsync();
            Voucher kq= JsonConvert.DeserializeObject<Voucher>(data);
            return View(kq);


        }
        [HttpPost]
        public IActionResult EditVoucher(Voucher a1)
        {
            string data = JsonConvert.SerializeObject(a1);
            string url = $"https://localhost:7119/api/Voucher/UpdateVoucher?IDVoucher={a1.IDVoucher}&MaVoucher={a1.MaVoucher}&NgayTao={a1.NgayTao}&Dieukien={a1.Dieukien}&NgayBatDau={a1.NgayBatDau}&NgayKetThuc={a1.NgayKetThuc}&GiaTriVoucher={a1.GiaTriVoucher}&Soluong={a1.Soluong}";

			StringContent ct = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage respon= client.PutAsync(url,ct).Result;
            return RedirectToAction("GetAllVoucher");
        }
        public IActionResult DeleteVoucher(Guid a2)
        {
            var url = $"https://localhost:7119/api/Voucher/DeleteVoucher?Id={a2}";
            var respon = client.DeleteAsync(url);
            return RedirectToAction("GetAllVoucher");


        }         
        



        //aaaa
    }
}
