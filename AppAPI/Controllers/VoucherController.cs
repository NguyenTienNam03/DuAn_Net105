using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : Controller
    {
        private IAllRepositories<Voucher> _repos;
        private QLBG_Context _context = new QLBG_Context();
        public VoucherController()
        {
            AllRepositories<Voucher> repos = new AllRepositories<Voucher>(_context, _context.voucher);
            _repos = repos;
        }
        [HttpGet("[action]")]
        public IEnumerable<Voucher> GettAllVoucher()
        {
            return _repos.GetAll();
        }
		[HttpGet("[action]")]
		public Voucher GettByIDVoucher(Guid id)
		{
			return _repos.GetAll().First(c => c.IDVoucher == id);
		}
		[HttpPost("[action]")]
        public bool CreateVoucher(string MaVoucher, DateTime NgayTao, decimal Dieukien, DateTime NgayBatDau, DateTime NgayKetThuc, decimal GiaTriVoucher, int Soluong)
        {
            Voucher a1 = new Voucher();
            a1.IDVoucher = Guid.NewGuid();

            a1.MaVoucher = MaVoucher;
            a1.NgayTao = NgayTao;
            a1.Dieukien = Dieukien;
            a1.NgayBatDau = NgayBatDau;
            a1.NgayKetThuc = NgayKetThuc;
            a1.GiaTriVoucher = GiaTriVoucher;
            a1.Soluong = Soluong;
            if(a1.NgayBatDau.Date <=  DateTime.Now.Date && DateTime.Now.Date <= a1.NgayKetThuc.Date && a1.Soluong > 0)
            {
                a1.TrangThai = 1;
            } else
            {
                a1.TrangThai = 0;
            }
            return _repos.CreateNewItem(a1);
        }
        [HttpDelete("[action]")]
        public bool DeleteVoucher(Guid Id)
        {
            Voucher b = _repos.GetAll().First(p => p.IDVoucher == Id);
            b.TrangThai = 0;
            return _repos.UpdateItem(b);
        }
        [HttpPut("[action]")]
        public bool UpdateVoucher(Guid IDVoucher, string MaVoucher, DateTime NgayTao, decimal Dieukien, DateTime NgayBatDau, DateTime NgayKetThuc, decimal GiaTriVoucher, int Soluong)
        {
            Voucher b = _repos.GetAll().First(p => p.IDVoucher == IDVoucher);


            b.MaVoucher = MaVoucher;
            b.NgayTao = NgayTao;
            b.Dieukien = Dieukien;
            b.NgayBatDau = NgayBatDau;
            b.NgayKetThuc = NgayKetThuc;
            b.GiaTriVoucher = GiaTriVoucher;
            b.Soluong = Soluong;
			if (b.NgayBatDau.Date <= DateTime.Now.Date && DateTime.Now.Date <= b.NgayKetThuc.Date && b.Soluong > 0)
			{
				b.TrangThai = 1;
			}
			else
			{
				b.TrangThai = 0;
			}
			return _repos.UpdateItem(b);
        }
        
    }
}
