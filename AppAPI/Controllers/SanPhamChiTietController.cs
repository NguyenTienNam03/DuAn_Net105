using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SanPhamChiTietController : ControllerBase
	{
		private IAllRepositories<SanPhamChiTiet> iresposspct;

		private IAllRepositories<MauSac> iresposmausac;
		private IAllRepositories<Size> irespossize;
		private IAllRepositories<SanPham> irespossp;
		private IAllRepositories<TheLoai> irespostheloai;
		private IAllRepositories<HangSX> iresponhangsx;
		private IAllRepositories<Sale> irespossale;

		private QLBG_Context _context = new QLBG_Context();
		public SanPhamChiTietController()
		{
			AllRepositories<SanPhamChiTiet> reposspct = new AllRepositories<SanPhamChiTiet>(_context, _context.sanPhamCTs);
			AllRepositories<MauSac> reposmausac = new AllRepositories<MauSac>(_context, _context.maus);
			AllRepositories<Size> repossize = new AllRepositories<Size>(_context, _context.sizes);
			AllRepositories<SanPham> repossanpham = new AllRepositories<SanPham>(_context, _context.sanPhams);
			AllRepositories<TheLoai> repostheloai = new AllRepositories<TheLoai>(_context, _context.theLoai);
			AllRepositories<HangSX> reposhangsx = new AllRepositories<HangSX>(_context, _context.hangSXs);
			AllRepositories<Sale> repossale = new AllRepositories<Sale>(_context, _context.Sale);

			iresposspct = reposspct;
			iresposmausac = reposmausac;
			irespossize = repossize;
			irespossp = repossanpham;
			irespostheloai = repostheloai;
			iresponhangsx = reposhangsx;
			irespossale = repossale;
		}
		// GET: api/<SanPhamChiTietController>
		[HttpGet]
		public IEnumerable<SanPhamChiTiet> GetAll()
		{
			return iresposspct.GetAll();
		}
		[HttpGet("[action]")]
		public IEnumerable<SanPhamChiTietViewModels> GetSanPhamChiTiet()
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
			if(Spct.Any(c => c.Soluong > 0))
			{
				return Spct.ToList();
			} else
			{
				//// nếu không có liệu thì sẽ trả về dữ liệu trống.
				return new List<SanPhamChiTietViewModels>();
			}
			//}
		}
		[HttpGet("[action]")]
		public List<SanPhamChiTietViewModels> SanPhamSale()
		{
			//foreach (var item in iresposspct.GetAll())
			//{
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
			if (Spct.Any(c => c.Soluong > 0 && c.GiaTriSale > 0))
			{
				return Spct.ToList();
			}
			else
			{
				//// nếu không có liệu thì sẽ trả về dữ liệu trống.
				return new List<SanPhamChiTietViewModels>();
			}
			// nếu không có liệu thì sẽ trả về dữ liệu trống.
			//}	
		}
		[HttpGet("[action]")]
		public SanPhamChiTietViewModels GetByIDSanPhamChiTiet(Guid id)
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
						   GiaSale = a.GiaBan - (a.GiaBan * f.GiaTriSale / 100),
						   Soluong = a.SoLuong,
						   Anh = a.Anh,
						   MoTa = a.MoTa
					   };
			return Spct.First(c => c.Id == id);

		}
		// GET api/<SanPhamChiTietController>/5
		[HttpGet("{id}")]
		public SanPhamChiTiet GetById(Guid id)
		{
			return iresposspct.GetAll().First(c => c.IDSPCT == id);
		}

		[HttpGet("[action]")]
		public Sale GetByIdSale(Guid id)
		{
			return irespossale.GetAll().First(c => c.IDSale == id);
		}

		// POST api/<SanPhamChiTietController>
		[HttpPost("{Create-spct}")]
		public bool CreateSPCT(Guid idms, Guid idsize, Guid idsp, Guid idtl, Guid idhangsx, Guid idsale, decimal giaban, int soluong, string anh, string mota) // 
		{
			SanPhamChiTiet spct = new SanPhamChiTiet();
			spct.IDSPCT = Guid.NewGuid();
			spct.IDMau = iresposmausac.GetAll().First(c => c.IDMau == idms).IDMau; // ID màu sắc phải có trong bảng màu sắc
			spct.IDSize = irespossize.GetAll().First(c => c.IDSize == idsize).IDSize; // ID Size phải có trong bảng Size
			spct.IDSP = irespossp.GetAll().First(c => c.IdSP == idsp).IdSP; // ID sản phẩm phải có trong bảng sản phẩm
			spct.IDTheLoai = irespostheloai.GetAll().First(c => c.IDTheLoai == idtl).IDTheLoai; // ID thể loại phải có trong bảng thể loại
			spct.IDHang = iresponhangsx.GetAll().First(c => c.IDHangSx == idhangsx).IDHangSx; // ID Hãng SX phải có trong bảng Hãng SX
			spct.IDSale = irespossale.GetAll().First(c => c.IDSale == idsale).IDSale; // ID Sale phải có trong bảng sale
			spct.GiaBan = giaban;
			spct.GiaSale = giaban - (giaban * irespossale.GetAll().First(c => c.IDSale == idsale).GiaTriSale / 100);
			spct.SoLuong = soluong;
			spct.Anh = anh;
			spct.MoTa = mota;
			if(soluong > 0)
			{
				spct.TrangThai = 1;
			} else
			{
				spct.TrangThai = 0;
			}
			return iresposspct.CreateNewItem(spct);
		}

		// PUT api/<SanPhamChiTietController>/5
		[HttpPut("{Upadte-SPCT}")]
		public bool UpdateSPCT(Guid idspct, Guid idms, Guid idsize, Guid idsp, Guid idtl, Guid idhangsx, Guid idsale, decimal giaban, int soluong, string anh, string mota, int trangthai)
		{
			SanPhamChiTiet spct = iresposspct.GetAll().FirstOrDefault(c => c.IDSPCT == idspct);
			spct.IDMau = iresposmausac.GetAll().First(c => c.IDMau == idms).IDMau;
			spct.IDSize = irespossize.GetAll().First(c => c.IDSize == idsize).IDSize;
			spct.IDSP = irespossp.GetAll().First(c => c.IdSP == idsp).IdSP;
			spct.IDTheLoai = irespostheloai.GetAll().First(c => c.IDTheLoai == idtl).IDTheLoai;
			spct.IDHang = iresponhangsx.GetAll().First(c => c.IDHangSx == idhangsx).IDHangSx;
			spct.IDSale = irespossale.GetAll().First(c => c.IDSale == idsale).IDSale;
			spct.GiaBan = giaban;
			spct.GiaSale = giaban - (giaban * irespossale.GetAll().First(c => c.IDSale == idsale).GiaTriSale / 100);
			spct.SoLuong = soluong;
			spct.Anh = anh;
			spct.MoTa = mota;
			if(soluong <= 0)
			{
				spct.TrangThai = 0;
			}
			return iresposspct.UpdateItem(spct);

		}

		// DELETE api/<SanPhamChiTietController>/5
		[HttpDelete("{Delete-SPCT}")]
		public bool DeleteSPCT(Guid idspct)
		{
			SanPhamChiTiet spct = iresposspct.GetAll().FirstOrDefault(c => c.IDSPCT == idspct);
			spct.TrangThai = 0;
			return iresposspct.UpdateItem(spct);
		}
	}
}
