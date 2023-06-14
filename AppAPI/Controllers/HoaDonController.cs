using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Components.Web;

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
		private IAllRepositories<Sale> irepossale;
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
			AllRepositories<Sale> repossale = new AllRepositories<Sale>(context, context.Sale);
			IreposSPCT = reposSPCT;
			ireposhdct = reposhdct;
			irepos = repos;
			irepossale = repossale;
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
			if (kh.IDUser != null)
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
				foreach (var item in cartdetail)
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
			return giatridautien;
		}
		[HttpPut("[action]")]
		public bool ApDungVoucher(Guid idhoadon, Guid idvoucher)
		{
			HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
			var dk = ireposvoucher.GetAll().FirstOrDefault(c => c.IDVoucher == idvoucher);
			if (hoadon.ThanhTien > dk.Dieukien)
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
				hoadon.TenNguoiNhan = hoadon.TenNguoiNhan;
				hoadon.SDTNguoiNhan = hoadon.SDTNguoiNhan;
				hoadon.DiaChiNguoiNhan = hoadon.DiaChiNguoiNhan;
				hoadon.TrangThai = 1;
			}
			return irepos.UpdateItem(hoadon);

		}
		[HttpPut("{Update-HoaDon}")]
		public bool UpdateHoadon(Guid idhoadon, Guid idvoucher, string tennguoinhan, string sdt, string dc)
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
				irepos.UpdateItem(hoadon);

				foreach (var item in ireposhdct.GetAll())
				{
					SanPhamChiTiet updatesspct = IreposSPCT.GetAll().FirstOrDefault(c => c.IDSPCT == HDCT.IDSPCT);
					var soluong = updatesspct.SoLuong - item.SoLuong;
					if (updatesspct.IDSPCT == item.IDSPCT)
					{
						updatesspct.IDSPCT = updatesspct.IDSPCT;
						updatesspct.IDMau = updatesspct.IDMau;
						updatesspct.IDSP = updatesspct.IDSP;
						updatesspct.IDSale = updatesspct.IDSale;
						updatesspct.IDSize = updatesspct.IDSize;
						updatesspct.IDHang = updatesspct.IDHang;
						updatesspct.IDTheLoai = updatesspct.IDTheLoai;
						updatesspct.Anh = updatesspct.Anh;
						updatesspct.GiaBan = updatesspct.GiaBan;
						updatesspct.GiaSale = updatesspct.GiaSale;
						updatesspct.MoTa = updatesspct.MoTa;
						if (soluong > 0)
						{
							updatesspct.SoLuong = updatesspct.SoLuong - item.SoLuong;
							updatesspct.TrangThai = updatesspct.TrangThai;
						}
						else
						{
							updatesspct.SoLuong = 0;
							updatesspct.TrangThai = 0;
						}

					}
					IreposSPCT.UpdateItem(updatesspct);
				}
				return true;
			}
			else
			{
				return false;
			}

		}

		[HttpPut("[action]")]
		public bool NhanHang(Guid idhd)
		{
			var hoadon = irepos.GetAll().First(c => c.IdBill == idhd);
			HoaDon hd = irepos.GetAll().FirstOrDefault(c => c.IdBill == hoadon.IdBill);
			hd.IdBill = hoadon.IdBill;
			hd.IDKhachHang = hoadon.IDKhachHang;
			hd.IDVoucher = hoadon.IDVoucher;
			hd.MaHD = hoadon.MaHD;
			hd.SoLuong = hoadon.SoLuong;
			hd.ThanhTien = hoadon.ThanhTien;
			hd.TongThanhToan = hoadon.ThanhTien;
			hd.NgayTao = hoadon.NgayTao;
			hd.NgayNhan = hoadon.NgayNhan;
			hd.NgayShip = hoadon.NgayShip;
			hd.TenNguoiNhan = hoadon.TenNguoiNhan;
			hd.SDTNguoiNhan = hoadon.SDTNguoiNhan;
			hd.DiaChiNguoiNhan = hoadon.DiaChiNguoiNhan;
			hd.TrangThai = 2;
			return irepos.UpdateItem(hd);

		}
		[HttpPut("[action]")]
		public bool HuyHang(Guid idhd)
		{
			HoaDon hoadon = irepos.GetAll().First(c => c.IdBill == idhd);
			hoadon.IdBill = hoadon.IdBill;
			hoadon.IDKhachHang = hoadon.IDKhachHang;
			hoadon.IDVoucher = hoadon.IDVoucher;
			hoadon.MaHD = hoadon.MaHD;
			hoadon.SoLuong = hoadon.SoLuong;
			hoadon.ThanhTien = hoadon.ThanhTien;
			hoadon.TongThanhToan = hoadon.ThanhTien;
			hoadon.NgayTao = hoadon.NgayTao;
			hoadon.NgayNhan = hoadon.NgayNhan;
			hoadon.NgayShip = hoadon.NgayShip;
			hoadon.TenNguoiNhan = hoadon.TenNguoiNhan;
			hoadon.SDTNguoiNhan = hoadon.SDTNguoiNhan;
			hoadon.DiaChiNguoiNhan = hoadon.DiaChiNguoiNhan;
			hoadon.TrangThai = 0;
			irepos.UpdateItem(hoadon);
			var idhdct = ireposhdct.GetAll().FirstOrDefault(c => c.IDHD == hoadon.IdBill);
			foreach (var item in IreposSPCT.GetAll().Where(c => c.IDSPCT == idhdct.IDSPCT).ToList())
			{
				var sp = ireposhdct.GetAll().FirstOrDefault(c => c.IDSPCT == item.IDSPCT);
				SanPhamChiTiet spct = new SanPhamChiTiet();

				spct.IDSPCT = Guid.NewGuid();
				spct.IDHang = item.IDHang;
				spct.IDMau = item.IDMau;
				spct.IDSale = Guid.Parse("a06bceec-49b1-4a8e-a19b-dac2051d2f1d");
				spct.IDSize = item.IDSize;
				spct.IDSP = item.IDSP;
				spct.IDTheLoai = item.IDTheLoai;
				spct.SoLuong = sp.SoLuong;
				spct.GiaBan = item.GiaBan;
				spct.GiaSale = item.GiaBan - (item.GiaBan * irepossale.GetAll().FirstOrDefault(c => c.IDSale == Guid.Parse("a06bceec-49b1-4a8e-a19b-dac2051d2f1d")).GiaTriSale / 100);
				spct.Anh = item.Anh;
				spct.MoTa = "Hàng Sale";
				spct.TrangThai = 0;

				IreposSPCT.CreateNewItem(spct);
			}
			return true;

		}

		[HttpDelete("{Delete-HoaDon}")]
		public bool DeleteHoaDon(Guid idhoadon)
		{
			HoaDon hoadon = irepos.GetAll().FirstOrDefault(p => p.IdBill == idhoadon);
			return irepos.DeleteItem(hoadon);
		}

	}
}
