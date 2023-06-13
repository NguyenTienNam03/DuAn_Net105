
using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Claims;
using System.Xml;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NguoiDungController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IAllRepositories<NguoiDung> ireposUser;
        private IAllRepositories<ChucVu> ireposRole;

        private QLBG_Context context = new QLBG_Context();
        public NguoiDungController(IConfiguration configuration)
        {
            AllRepositories<NguoiDung> reposuser = new AllRepositories<NguoiDung>(context, context.nguoiDungs);
            AllRepositories<ChucVu> reposrole = new AllRepositories<ChucVu>(context, context.chucVus);
            _configuration = configuration;
            ireposUser = reposuser;
            ireposRole = reposrole;

        }
        // GET: api/<ValuesController>
        [HttpGet("[action]")]
        public IEnumerable<NguoiDung> GetAll()
        {
            return ireposUser.GetAll();
        }


        [HttpGet("[action]")]
        public NguoiDung GetById(Guid id)
        {
            return ireposUser.GetAll().First(c => c.IDUser == id);
        }

        // POST api/<ValuesController>
        [HttpPost("{create-user}")]
        public bool CreateUser(Guid idrole, string Tkh, string sdt, string email, string matkhau, string diachi)
        {
            NguoiDung user = new NguoiDung();
            user.IDUser = Guid.NewGuid();
            user.IDRole = ireposRole.GetAll().First(c => c.IDRole == idrole).IDRole;
            user.TenKhachHang = Tkh;
            user.SDT = sdt;
            user.MatKhau = matkhau;
            user.Email = email;
            user.TrangThai = 1;
            user.DiaChi = diachi;
            return ireposUser.CreateNewItem(user);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{Update_user}")]
        public bool UpdateUser(Guid id, Guid idrole, string Tkh, string sdt, string email, string matkhau, string diachi, int trangthai)
        {
            NguoiDung user = ireposUser.GetAll().FirstOrDefault(p => p.IDUser == id);
            user.IDRole = ireposRole.GetAll().First(c => c.IDRole == idrole).IDRole;
            user.TenKhachHang = Tkh;
            user.SDT = sdt;
            user.MatKhau = matkhau;
            user.Email = email;
            user.TrangThai = trangthai;
            user.DiaChi = diachi;
            return ireposUser.UpdateItem(user);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{delete-user}")]
        public bool DeleteUser(Guid id)
        {
            NguoiDung user = ireposUser.GetAll().First(p => p.IDUser == id);
            return ireposUser.DeleteItem(user);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(NguoiDung nguoidung)
        {
          if(nguoidung == null || string.IsNullOrEmpty(nguoidung.Email) || string.IsNullOrEmpty(nguoidung.MatKhau))
            {
                return BadRequest("Vui lòng nhập tên đăng nhập và mật khẩu.");
            }
          if(await IsValidUser(nguoidung.Email , nguoidung.MatKhau))
            {
                return Ok();
            }
            return Unauthorized();
        }
        private async Task<bool> IsValidUser(string email , string pass)
        {
            var email1 = ireposUser.GetAll().FirstOrDefault(c => c.Email == email);
            if(email1.Email == email && email1.MatKhau == pass)
            {
                var id = ireposUser.GetAll().FirstOrDefault(c => c.Email == email).IDUser;
                GetById(id);
            }
            return false;   
        }
    }
}

