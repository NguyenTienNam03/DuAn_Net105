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
        private IAllRepositories<GioHangChiTiet> ireposghct;
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
            AllRepositories<GioHangChiTiet> reposghct = new AllRepositories<GioHangChiTiet>(context, context.gioHangCTs);
            IreposSPCT = reposSPCT;
            ireposhdct = reposhdct;
            irepos = repos;
            ireposghct = reposghct;
            ireposuser = reposuser;
            ireposvoucher = reposvoucher;
        }

        [HttpGet("[action]")]
        public IEnumerable<HoaDon> GetAllHoaDons()
        {
            return irepos.GetAll().OrderByDescending(c => c.NgayTao);
        }
        [HttpGet("[action]")]
        public HoaDon GetHoaDons(Guid id)
        {
            return irepos.GetAll().First(p => p.IdBill == id);
        }

        [HttpPost("{Create-HoaDon}")]
        public bool CreateHoaDon(Guid idkh, Guid idvc)
        {
            var kh = ireposuser.GetAll().FirstOrDefault(c => c.IDUser == idkh);
            if(kh.IDUser != null)
            {
                HoaDon hoadon = new HoaDon();
                hoadon.IdBill = Guid.NewGuid();
                hoadon.IDKhachHang = kh.IDUser;
                hoadon.IDVoucher = ireposvoucher.GetAll().First(c => c.IDVoucher == idvc).IDVoucher;
                hoadon.MaHD = Convert.ToString(hoadon.IdBill).Substring(0, 8).ToUpper();
                hoadon.SoLuong = 0;
                hoadon.ThanhTien = 0;
                hoadon.TongThanhToan = 0;
                hoadon.NgayTao = DateTime.Now;
                hoadon.NgayNhan = DateTime.Now.AddDays(4);
                hoadon.NgayShip = DateTime.Now.AddDays(1);
                hoadon.TenNguoiNhan = kh.TenKhachHang;
                hoadon.SDTNguoiNhan = kh.SDT;
                hoadon.DiaChiNguoiNhan = kh.DiaChi;
                hoadon.TrangThai = 1;
               
                irepos.CreateNewItem(hoadon);
                
                var cartdetail = ireposghct.GetAll().Where(c => c.IDGH == kh.IDUser).ToList();
                foreach(var item in cartdetail)
                {
                    HoaDonChiTiet hdct = new HoaDonChiTiet()
                    {
                        IDHDCT = Guid.NewGuid(),
                        IDHD = hoadon.IdBill,
                        IDSPCT = item.IDSPCT,
                        SoLuong = item.SoLuong,
                        Gia = item.Gia
                    };
                    ireposhdct.CreateNewItem(hdct);

                    ireposghct.DeleteItemByID(item.IDGHCT);
                }
                var voucher = ireposvoucher.GetAll().FirstOrDefault(c => c.IDVoucher == hoadon.IDVoucher).GiaTriVoucher;

				var hdct1 = ireposhdct.GetAll().Where(c => c.IDHD == hoadon.IdBill);
                HoaDon updatehoadon = irepos.GetAll().FirstOrDefault(c => c.IdBill == hoadon.IdBill);
                updatehoadon.IdBill = hoadon.IdBill;
                updatehoadon.IDKhachHang = hoadon.IDKhachHang;
                updatehoadon.IDVoucher = hoadon.IDVoucher;
                updatehoadon.MaHD = hoadon.MaHD;
                updatehoadon.SoLuong = hdct1.Sum(c => c.SoLuong);
                updatehoadon.ThanhTien = hdct1.Sum(c => c.SoLuong * c.Gia);
                updatehoadon.TongThanhToan = hdct1.Sum(c => c.SoLuong * c.Gia) - (hdct1.Sum(c => c.SoLuong * c.Gia) - voucher) / 100;
                updatehoadon.NgayTao = hoadon.NgayTao;
                updatehoadon.NgayNhan = hoadon.NgayNhan;
                updatehoadon.NgayShip = hoadon.NgayShip;
                updatehoadon.TenNguoiNhan = hoadon.TenNguoiNhan;
                updatehoadon.SDTNguoiNhan = hoadon.SDTNguoiNhan;
                updatehoadon.DiaChiNguoiNhan = hoadon.DiaChiNguoiNhan;
                updatehoadon.TrangThai = hoadon.TrangThai;
                irepos.UpdateItem(updatehoadon);
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet("[action]")]
        public HoaDon Lay1GiaTri()
        {
            var giatridautien = irepos.GetAll().OrderByDescending(c => c.NgayTao).First();
            return  giatridautien;
        }
        [HttpPut("{Update-HoaDon}")]
        public bool UpdateHoadon(Guid idhoadon, Guid idvoucher ,string tennguoinhan, string sdt, string dc)
        {
            var HDCT = ireposhdct.GetAll().FirstOrDefault(c => c.IDHD == idhoadon);
            HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
            if (hoadon.IdBill == idhoadon)
            {
                hoadon.IdBill = hoadon.IdBill;
                hoadon.IDKhachHang = hoadon.IDKhachHang;
                hoadon.IDVoucher = ireposvoucher.GetAll().First(c => c.IDVoucher == idvoucher).IDVoucher;
                hoadon.MaHD = hoadon.MaHD;
                hoadon.SoLuong = hoadon.SoLuong;
                hoadon.ThanhTien = hoadon.ThanhTien;
                hoadon.TongThanhToan = hoadon.ThanhTien - (hoadon.ThanhTien * ireposvoucher.GetAll().First(c => c.IDVoucher == idvoucher).GiaTriVoucher / 100);
                hoadon.NgayTao = hoadon.NgayTao;
                hoadon.NgayNhan = hoadon.NgayNhan;
                hoadon.NgayShip = hoadon.NgayShip;
                hoadon.TenNguoiNhan = tennguoinhan;
                hoadon.SDTNguoiNhan = sdt;
                hoadon.DiaChiNguoiNhan = dc;
                hoadon.TrangThai = 1;
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
