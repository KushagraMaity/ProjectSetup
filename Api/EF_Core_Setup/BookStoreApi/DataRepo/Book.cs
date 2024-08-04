using BookStoreApi.DataRepo;
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
        private ICurrency _currency;
        private IConfiguration _configuration;
        private readonly string conStr = "";//string.Empty;

        readonly string str = "";
        public Book(IConfiguration config) {
            _configuration = config;
            conStr = _configuration.GetConnectionString("BookDb").ToString();
        }
        public IEnumerable<T_BOOK> ShowBooks()
        {
            return new List<T_BOOK>();
        }
    }
}
