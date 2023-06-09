using AppDaTa.IRepositories;
using AppDaTa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        QLBG_Context _contex;
        DbSet<T> _dbSet;
        public AllRepositories(QLBG_Context contex, DbSet<T> dbSet)
        {
            _contex = contex;
            _dbSet = dbSet;
        }
        public AllRepositories()
        {

        }

        public bool CreateNewItem(T item)
        {
            try
            {
                _dbSet.Add(item);
                _contex.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                _dbSet.Remove(item);
                _contex.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                _dbSet.Update(item);
                _contex.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
