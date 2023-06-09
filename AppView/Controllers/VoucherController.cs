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
        public VoucherController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetAllVoucher()
        {
            string url = $"https://localhost:7119/api/";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string a = await response.Content.ReadAsStringAsync();
            var listVoucher = JsonConvert.DeserializeObject<List<Voucher>>(a);
            return View(listVoucher);
        }



        //aaaa
    }
}
