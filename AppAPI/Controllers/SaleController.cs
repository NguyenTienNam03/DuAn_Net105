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
            AllRepositories<Sale> repossale = new AllRepositories<Sale>(_context, _context.Sale);
            irepossale = repossale;
        }
        // GET: api/<SaleController>
        [HttpGet("[action]")]
        public IEnumerable<Sale> Getall()
        {
            return irepossale.GetAll().OrderBy(c => c.GiaTriSale);
        }

        // GET api/<SaleController>/5
        [HttpGet("[action]")]
        public Sale Get(Guid id)
        {
            return irepossale.GetAll().First(c => c.IDSale == id);
        }

        // POST api/<SaleController>
        [HttpPost("[action]")]
        public bool CreateSale(string masale, DateTime nbd, DateTime nkt, int giatrisale)
        {
            Sale sale = new Sale();
            sale.IDSale = Guid.NewGuid();
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            if (nbd.Date <= DateTime.Now.Date && DateTime.Now.Date <= nkt.Date)
            {
                sale.TrangThai = 1;
            }
            else
            {
                sale.TrangThai = 0;
            }
            return irepossale.CreateNewItem(sale);
        }

        [HttpPut("[action]")]
        public IEnumerable<Sale> Refresh()
        {
            foreach(var item in irepossale.GetAll())
            {
                if(item.NgayBatDau.Date <= DateTime.Now.Date && DateTime.Now.Date <= item.NgayKetThuc.Date)
                {
                    item.TrangThai = 1;
                } else
                {
                    item.TrangThai = 0;
                }
                irepossale.UpdateItem(item);
            }
            return irepossale.GetAll().OrderBy(c => c.GiaTriSale);
        }
        // PUT api/<SaleController>/5
        [HttpPut("[action]")]
        public bool EditSale(Guid id, string masale, DateTime nbd, DateTime nkt, int giatrisale)
        {
            Sale sale = irepossale.GetAll().First(c => c.IDSale == id);
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            if (nbd.Date <= DateTime.Now.Date && DateTime.Now.Date <= nkt.Date)
            { 
                sale.TrangThai = 1;
            }
            else
            {
                sale.TrangThai = 0;
            }
            return irepossale.UpdateItem(sale);
        }

        // DELETE api/<SaleController>/5
        [HttpPut("[action]")]
        public bool Delete(Guid id)
        {
            Sale sale = irepossale.GetAll().First(c => c.IDSale == id);
            sale.TrangThai = 0;
            return irepossale.UpdateItem(sale);
        }
    }
}
