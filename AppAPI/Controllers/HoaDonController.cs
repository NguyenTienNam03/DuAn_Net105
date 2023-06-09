using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HoaDonController : Controller
    {
        private IAllRepositories<HoaDon> irepos;
        private IAllRepositories<HoaDonChiTiet> ireposhdct;
        private IAllRepositories<SanPhamChiTiet> IreposSPCT;
        private IAllRepositories<NguoiDung> ireposuser;
        private IAllRepositories<Voucher> ireposvoucher;
        private QLBG_Context context = new QLBG_Context();
        public HoaDonController()
        {
            AllRepositories<HoaDon> repos = new AllRepositories<HoaDon>(context, context.hoaDons);
            AllRepositories<HoaDonChiTiet> reposhdct = new AllRepositories<HoaDonChiTiet>(context, context.hoaDoncts);
            AllRepositories<NguoiDung> reposuser = new AllRepositories<NguoiDung>(context, context.nguoiDungs);
            AllRepositories<Voucher> reposvoucher = new AllRepositories<Voucher>(context, context.voucher);
            AllRepositories<SanPhamChiTiet> reposSPCT = new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);

            IreposSPCT = reposSPCT;
            ireposhdct = reposhdct;
            irepos = repos;
            ireposuser = reposuser;
            ireposvoucher = reposvoucher;
        }

        [HttpGet("[action]")]
        public IEnumerable<HoaDon> GetAllHoaDons()
        {
            return irepos.GetAll();
        }
        [HttpGet("[action]")]
        public HoaDon GetHoaDons(Guid id)
        {
            return irepos.GetAll().First(p => p.IdBill == id);
        }

        [HttpPost("{Create-HoaDon}")]
        public bool CreateHoaDon(Guid idkh, Guid idvc, int trangthai)
        {
            var kh = ireposuser.GetAll().FirstOrDefault(c => c.IDUser == idkh);

            HoaDon hoadon = new HoaDon();
            hoadon.IdBill = Guid.NewGuid();
            hoadon.IDKhachHang = kh.IDUser;
            hoadon.IDVoucher = ireposvoucher.GetAll().First(c => c.IDVoucher == idvc).IDVoucher;
            hoadon.MaHD = "HD" + Convert.ToString(irepos.GetAll().Where(c => c.IDKhachHang == idkh).Count() + 1);
            hoadon.SoLuong = 0;
            hoadon.Gia = 0;
            hoadon.NgayTao = DateTime.Now;
            hoadon.NgayNhan = DateTime.Now.AddDays(4);
            hoadon.NgayShip = DateTime.Now.AddDays(1);
            hoadon.TenNguoiNhan = kh.TenKhachHang;
            hoadon.SDTNguoiNhan = kh.SDT;
            hoadon.DiaChiNguoiNhan = kh.DiaChi;
            hoadon.TrangThai = trangthai;
            return irepos.CreateNewItem(hoadon);

        }

        [HttpPut("{Update-HoaDon}")]
        public bool UpdateHoadon(Guid idhoadon, string tennguoinhan, string sdt, string dc, int trangthai)
        {
            var HDCT = ireposhdct.GetAll().FirstOrDefault(c => c.IDHD == idhoadon);
            HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
            if (HDCT.IDHD == hoadon.IdBill)
            {
                hoadon.SoLuong = ireposhdct.GetAll().Sum(c => c.SoLuong);
                hoadon.Gia = ireposhdct.GetAll().Sum(c => c.SoLuong * c.Gia);
                hoadon.TenNguoiNhan = tennguoinhan;
                hoadon.SDTNguoiNhan = sdt;
                hoadon.DiaChiNguoiNhan = dc;
                hoadon.TrangThai = trangthai;
                return irepos.UpdateItem(hoadon);
            }
            else
            {
                return false;
            }

        }

        [HttpDelete("{Delete-HoaDon}")]
        public bool DeleteHoaDon(Guid idhoadon)
        {
            HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
            return irepos.DeleteItem(hoadon);
        }

    }
}
