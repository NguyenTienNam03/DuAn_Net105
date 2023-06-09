using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDaTa.IRepositories
{
    public interface IAllRepositories<T>
    {
        public IEnumerable<T> GetAll();
        public bool CreateNewItem (T item);
        public bool DeleteItem (T item);
        public bool UpdateItem (T item);
        
    }
}
