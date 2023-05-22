
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
        public class UserController : ControllerBase
        {
            private IAllRepositories<NguoiDung> irepos;
            private QLBG_Context context = new QLBG_Context();
            public UserController()
            {
                AllRepositories<NguoiDung> repos = new AllRepositories<NguoiDung>(context, context.nguoiDungs);
              irepos=repos;
            }
            // GET: api/<ValuesController>
            [HttpGet]
            public IEnumerable<NguoiDung> GetAll()
            {
                return irepos.GetAll();
            }

            // GET api/<ValuesController>/5
            //[HttpGet("{id}")]
            //public bool NguoiDung Get(Guid id)
            //{
            //    return irepos.GetAll().First(p => p.Iduser == id);
            //}

            // POST api/<ValuesController>
            [HttpPost("create-người dùng")]
            public bool CreateUser(string Tkh, string sdt, string email, string matkhau, string diachi, int trangthai)
            {
                NguoiDung user = new NguoiDung();
                user.TenKhachHang = Tkh;
                user.SDT = sdt;
                user.MatKhau = matkhau;
                user.Email = email; 
                user.TrangThai = trangthai;
                user.DiaChi = diachi;
                user.IDUser = Guid.NewGuid();
                //user.IDRole=;
                return irepos.CreateNewItem(user);
            }

            // PUT api/<ValuesController>/5
            [HttpPut("{Update_user}")]
            public bool UpdateUser(Guid id, string Tkh, string sdt, string email, string matkhau, string diachi, int trangthai)
            {
                NguoiDung user = irepos.GetAll().First(p => p.IDUser == id);
                user.TenKhachHang = Tkh;
                user.SDT = sdt;
                user.MatKhau = matkhau;
                user.Email = email;
                user.TrangThai = trangthai;
                user.DiaChi = diachi;
                return irepos.UpdateItem(user);
            }

            // DELETE api/<ValuesController>/5
            [HttpDelete("{delete}")]
            public bool DeleteUser(Guid id)
            {
                NguoiDung user = irepos.GetAll().First(p => p.IDUser == id);
                return irepos.DeleteItem(user);
            }
        }
    }

