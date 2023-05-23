﻿using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TheLoaiController
    {
        private IAllRepositories<TheLoai> irepostheloai;
        private QLBG_Context _context = new QLBG_Context();
        public TheLoaiController()
        {
            AllRepositories<TheLoai> repostheloai = new AllRepositories<TheLoai>(_context, _context.theLoai);
            irepostheloai = repostheloai;
        }
        [HttpGet]
        public IEnumerable<TheLoai> GetAll()
        {
            return irepostheloai.GetAll();
        }
        [HttpGet("{id}")]
        public TheLoai Get(Guid id)
        {
            return irepostheloai.GetAll().First(c => c.IDTheLoai == id);
        }

        // POST api/<SaleController>
        [HttpPost("create-theloai")]
        public bool CreateTheLoai(string theloai, string mota)
        {
            TheLoai theLoai = new TheLoai();
            theLoai.IDTheLoai = Guid.NewGuid();
            theLoai.TenTheLoai = theloai;
            theLoai.MoTa = mota;
            return irepostheloai.CreateNewItem(theLoai);
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public bool UpdateTheLoai(Guid id, string theloai, string mota)
        {
            TheLoai theLoai = irepostheloai.GetAll().First(c => c.IDTheLoai == id);
            theLoai.TenTheLoai = theloai;
            return irepostheloai.UpdateItem(theLoai);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public bool DeleteTheLoai(Guid id)
        {
            TheLoai theLoai = irepostheloai.GetAll().First(c => c.IDTheLoai == id);
            return irepostheloai.DeleteItem(theLoai);
        }
    }
}
