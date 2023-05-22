using AppDaTa.IRepositories;
using AppDaTa.Models;
using AppDaTa.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private IAllRepositories<Sale> irepossale;
        private QLBG_Context _context = new QLBG_Context();
        public SaleController()
        {
            AllRepositories<Sale> repossale = new AllRepositories<Sale>(_context , _context.Sale);
            irepossale = repossale;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<Sale> Getall()
        {
            return irepossale.GetAll();
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public Sale Get(Guid id)
        {
            return irepossale.GetAll().First(c => c.IDSale == id);
        }

        // POST api/<SaleController>
        [HttpPost]
        public bool CreteSale(string masale , DateTime nbd , DateTime nkt , int giatrisale)
        {
            Sale sale = new Sale();
            sale.IDSale = Guid.NewGuid();
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            sale.TrangThai = 1;
            return irepossale.CreateNewItem(sale);
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public bool EditSale(Guid id , string masale, DateTime nbd, DateTime nkt, int giatrisale , int trangthai)
        {
            Sale sale = irepossale.GetAll().First(c => c.IDSale == id);
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            sale.TrangThai = trangthai;

            return irepossale.UpdateItem(sale);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            Sale sale = irepossale.GetAll().First(c => c.IDSale == id);
            return irepossale.DeleteItem(sale);
        }
    }
}
