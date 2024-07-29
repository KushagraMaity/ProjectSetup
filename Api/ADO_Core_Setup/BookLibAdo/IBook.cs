using BookLibAdo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibAdo
{
    public interface IBook
    {
        public IEnumerable<T_BOOK> ShowBooks();
        public string GetBDbConnect();

    }
}
