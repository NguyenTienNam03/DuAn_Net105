using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using AppDaTa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private IAllRepositories<BinhLuan> irepos;
        private IAllRepositories<NguoiDung> ireposuser;
        private IAllRepositories<SanPhamChiTiet> ireposspct;
        private QLBG_Context context = new QLBG_Context();
        public BinhLuanController()
        {
            AllRepositories<BinhLuan> repos = new AllRepositories<BinhLuan>(context, context.binhLuans);
            AllRepositories<NguoiDung> reposuser =
                new AllRepositories<NguoiDung>(context, context.nguoiDungs);
            AllRepositories<SanPhamChiTiet> reposspct =
              new AllRepositories<SanPhamChiTiet>(context, context.sanPhamCTs);
            irepos = repos;
            ireposuser = reposuser;
            ireposspct = reposspct;
        }
        // GET: api/<BinhLuan>
        [HttpGet]
        public IEnumerable<BinhLuan> GetAll()
        {
            return irepos.GetAll();
        }
        [HttpGet("[action]")]
        public BinhLuanViewModels GetAllOnlyProduct(Guid id)
        {
			SanPhamChiTietViewModels spct = GetByID(id);
            List<BinhLuan> comment = GetBinhluanForProduct(id);
            List<NguoiDung> User = GetUserForComment(comment);

			BinhLuanViewModels binhLuanViewModels = new BinhLuanViewModels()
            {
                sanPhamChiTietViewModels = spct,
                binhLuans = comment,
                nguoiDung = User
			};
            return binhLuanViewModels;
        }
        private SanPhamChiTietViewModels GetByID(Guid id)
        {
			var Spct = from a in context.sanPhamCTs
					   join b in context.sanPhams on a.IDSP equals b.IdSP
					   join c in context.maus on a.IDMau equals c.IDMau
					   join d in context.hangSXs on a.IDHang equals d.IDHangSx
					   join e in context.sizes on a.IDSize equals e.IDSize
					   join f in context.Sale on a.IDSale equals f.IDSale
					   join h in context.theLoai on a.IDTheLoai equals h.IDTheLoai
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
            return Spct.First(c => c.Id == id);
		}
        private List<BinhLuan> GetBinhluanForProduct(Guid idproduct)
        {
            return irepos.GetAll().Where(c => c.IDSPCT == idproduct).ToList();
        }
        private List<NguoiDung> GetUserForComment(List<BinhLuan> comment)
        {
            List<Guid> userid = comment.Select(c => c.IDNguoiDung).ToList();

            List<NguoiDung> lstuser = context.nguoiDungs.Where(c => userid.Contains(c.IDUser)).ToList();

			return lstuser;
        }
        // GET api/<BinhLuan>/5
        [HttpGet("{id}")]
        public BinhLuan Get(Guid id)
        {
            return irepos.GetAll().First(p => p.IDBinhLuan == id);
        }

        // POST api/<BinhLuan>
        [HttpPost("{create-binhluan}")]
        public bool CreateBL(Guid IDuser, Guid Idspct, string noidung, DateTime nbl)
        {
            BinhLuan BL = new BinhLuan();
            BL.NoiDung = noidung;
            BL.NgayBinh = nbl;
            BL.IDBinhLuan = Guid.NewGuid();
            BL.IDNguoiDung = ireposuser.GetAll().First(c => c.IDUser == IDuser).IDUser;
            BL.IDSPCT = ireposspct.GetAll().First(c => c.IDSPCT == Idspct).IDSPCT;

            return irepos.CreateNewItem(BL);
        }
        [HttpPut("{edit-binhluan}")]

        public bool UpdateBinhLuan(BinhLuan a)
        {
            // Trỏ đến màu sắc trong db để sửa

            BinhLuan BL = irepos.GetAll().FirstOrDefault(p => p.IDBinhLuan == a.IDBinhLuan && p.IDNguoiDung == a.IDNguoiDung);

            BL = a;


            return irepos.UpdateItem(BL);
        }
        [HttpDelete("{id}")]
        public bool DeleteBL(Guid id)
        {
            // Trỏ đến màu sắc trong db để sửa
            BinhLuan BL = irepos.GetAll().First(p => p.IDBinhLuan == id);
            return irepos.DeleteItem(BL);
        }

    }
}
