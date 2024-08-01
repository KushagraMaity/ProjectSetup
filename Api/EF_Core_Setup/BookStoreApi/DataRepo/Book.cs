using BookStoreApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApi
{
    public class Book : IBook
    {
        public IEnumerable<T_BOOK> ShowBooks()
        {
            return new List<T_BOOK>();
        }
    }
}
