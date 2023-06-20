using AppDaTa.IRepositories;
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
      

       

		[HttpGet]
        public async Task<IActionResult> GioHangCT()
        {
      
			var Spct = from a in _context.sanPhamCTs
					   join b in _context.sanPhams on a.IDSP equals b.IdSP
					   join c in _context.maus on a.IDMau equals c.IDMau
					   join d in _context.hangSXs on a.IDHang equals d.IDHangSx
					   join e in _context.sizes on a.IDSize equals e.IDSize
					   join f in _context.Sale on a.IDSale equals f.IDSale
					   join h in _context.theLoai on a.IDTheLoai equals h.IDTheLoai
					   select new SanPhamChiTietViewModels
					   {
						   Id = a.IDSPCT,
						   MauSac = c.Mausac,
						   TenSanPham = b.TenSP,
						   HangGiay = d.TenHangSX,
						   Size = e.SizeGiay,
						   TheLoai = h.TenTheLoai,
						   GiaTriSale = f.GiaTriSale,
						   GiaBan = a.GiaBan,
						   GiaSale = a.GiaSale,
						   Soluong = a.SoLuong,
						   Anh = a.Anh,
						   MoTa = a.MoTa,
						   TrangThai = a.TrangThai,
					   };
			ViewBag.Anh = new SelectList(_context.sanPhamCTs.ToList(), "IDSPCT", "Anh");
			ViewBag.Tebsp = new SelectList(Spct.ToList(), "Id", "TenSanPham");
			ViewBag.IDUser = Guid.Parse("305f3d5a-3cf3-4af0-a4d7-807063b6ead0");
         
            string url = $"https://localhost:7119/api/GioHangCT/GetAll";
            var httpClient = new HttpClient();
            var repos = await httpClient.GetAsync(url);
            string dataapi = await repos.Content.ReadAsStringAsync();
            var ghct = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(dataapi);
            return View(ghct);
        }
        public IActionResult MoForm()
        {
            return View();
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
            var listbill = JsonConvert.DeserializeObject<List<HoaDonViewModels>>(dataapi);
            //var idvh = listbill.Select(c => c.IDVoucher).ToList();
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
            ViewBag.lstvocher = _context.voucher.ToList();
			ViewBag.voucher = new SelectList(_context.voucher.ToList().Where(c => c.TrangThai > 0).OrderBy(c => c.GiaTriVoucher), "IDVoucher", "GiaTriVoucher");
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
        [HttpPut]
        public IActionResult ApDungVoucher(HoaDon hoaDon)
        {
			var client = new HttpClient();
			
            string urlvh = $"https://localhost:7119/api/Voucher/GettByIDVoucher?id={hoaDon.IDVoucher}";
            
            var repos = client.GetAsync(urlvh);
            Voucher voucher = JsonConvert.DeserializeObject<Voucher>(urlvh);
            ViewBag.Giatri = voucher.GiaTriVoucher;

			string url = $"https://localhost:7119/api/HoaDon/ApDungVoucher?idhoadon={hoaDon.IdBill}&idvoucher={hoaDon.IDVoucher}";
			var apdungvoucher = JsonConvert.SerializeObject(hoaDon);

            StringContent stringContent = new StringContent(apdungvoucher, Encoding.UTF8, "application/json");
            HttpResponseMessage ApDung = client.PutAsync(url, stringContent).Result;
            return View("EditBill");
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
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> NhanHang(HoaDon hoaDon)
        {
            string url = $"https://localhost:7119/api/HoaDon/NhanHang?idhd={hoaDon.IdBill}";
            var client = new HttpClient();
            var obj = JsonConvert.SerializeObject(hoaDon);

            StringContent stringContent = new StringContent(obj ,Encoding.UTF8 , "application/json");
            HttpResponseMessage httpResponseMessage =  await client.PutAsync(url, stringContent);
            return RedirectToAction("GetAllBill");
        }
		[HttpGet]
		[HttpPost]
		public async Task<IActionResult> HuyHang(HoaDon hoaDon)
		{
			string url = $"https://localhost:7119/api/HoaDon/HuyHang?idhd={hoaDon.IdBill}";
			var client = new HttpClient();
			var obj = JsonConvert.SerializeObject(hoaDon);

			StringContent stringContent = new StringContent(obj, Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = await client.PutAsync(url, stringContent);

			return RedirectToAction("GetAllBill");
		}
	}
}
