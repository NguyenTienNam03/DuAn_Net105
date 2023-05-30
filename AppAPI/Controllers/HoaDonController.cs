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
        private IAllRepositories<SanPhamChiTiet> IreposSPCT;
        private IAllRepositories<NguoiDung> ireposuser;
        private IAllRepositories<Voucher> ireposvoucher;
        private QLBG_Context context = new QLBG_Context();
        public HoaDonController()
        {
            AllRepositories<HoaDon> repos = new AllRepositories<HoaDon>(context, context.hoaDons);
            AllRepositories<NguoiDung> reposuser = new AllRepositories<NguoiDung>(context, context.nguoiDungs);
            AllRepositories<Voucher> reposvoucher = new AllRepositories<Voucher>(context, context.voucher);
            AllRepositories<SanPhamChiTiet> reposSPCT = new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);

            IreposSPCT = reposSPCT;
            irepos = repos;
            ireposuser = reposuser;
            ireposvoucher = reposvoucher;
        }

        [HttpGet]
        public IEnumerable<HoaDon> GetHoaDons()
        {
            return irepos.GetAll();
        }
        [HttpGet("{id}")]
        public HoaDon GetHoaDons(Guid id)
        {
            return irepos.GetAll().First(p => p.IdBill == id);
        }

        [HttpPost("Create-HoaDon")]
        public bool CreateHoaDon(Guid idkh, Guid idvc, string ma, int sl, decimal gia, DateTime ngaytao, DateTime ngaynhan, DateTime ngayship, string sdt, string dc, int trangthai)
        {
            HoaDon hoadon = new HoaDon();
            hoadon.IdBill = Guid.NewGuid();
            hoadon.IDKhachHang = ireposuser.GetAll().First(c => c.IDUser == idkh).IDUser;
            hoadon.IDVoucher = ireposvoucher.GetAll().First(c => c.IDVoucher == idvc).IDVoucher;
            hoadon.MaHD = ma;
            hoadon.SoLuong = sl;
            hoadon.Gia = gia;
            hoadon.NgayTao = ngaytao;
            hoadon.NgayNhan = ngaynhan;
            hoadon.NgayShip = ngayship;
            hoadon.SDTNguoiNhan = sdt;
            hoadon.DiaChiNguoiNhan = dc;
            hoadon.TrangThai = trangthai;
            return irepos.CreateNewItem(hoadon);

        }

        [HttpPut("Update-HoaDon")]
        public bool UpdateHoadon(Guid idhoadon, Guid idkh, Guid idvc, string ma, int sl, decimal gia, DateTime ngaytao, DateTime ngaynhan, DateTime ngayship, string sdt, string dc, int trangthai)
        {
            HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
            hoadon.IDKhachHang = ireposuser.GetAll().First(c => c.IDUser == idkh).IDUser;
            hoadon.IDVoucher = ireposvoucher.GetAll().First(c => c.IDVoucher == idvc).IDVoucher;
            hoadon.MaHD = ma;
            hoadon.SoLuong = sl;
            hoadon.Gia = gia;
            hoadon.NgayTao = ngaytao;
            hoadon.NgayNhan = ngaynhan;
            hoadon.NgayShip = ngayship;
            hoadon.SDTNguoiNhan = sdt;
            hoadon.DiaChiNguoiNhan = dc;
            hoadon.TrangThai = trangthai;
            return irepos.UpdateItem(hoadon);
        }

        [HttpDelete("Delete-HoaDon")]
        public bool DeleteHoaDon(Guid idhoadon)
        {
            HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
            return irepos.DeleteItem(hoadon);
        }

    }
}
