using BookLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book : IBook
    {
        public IEnumerable<T_BOOK> ShowBooks()
        {
            List<T_BOOK> bookList = new List<T_BOOK>();
            try
            {
                bookList.Add(new T_BOOK
                {
                    AUTHOR = "V.S Naipaul",
                    BOOK_ID = 1,
                    BOOK_NAME = "A Bend in the river",
                    PUBLISH_DATE = DateTime.Now,
                    SUBMIT_DATE = DateTime.Now
                }) ;
                bookList.Add(new T_BOOK
                {
                    AUTHOR = "Satish Gujral",
                    BOOK_ID = 2,
                    BOOK_NAME = "A Brush with Life",
                    PUBLISH_DATE = DateTime.Now,
                    SUBMIT_DATE = DateTime.Now
                });
                bookList.Add(new T_BOOK
                {
                    AUTHOR = "S.S Kohli",
                    BOOK_ID = 3,
                    BOOK_NAME = "A conceptual Encyclopaedia of Guru Granth Sahib",
                    PUBLISH_DATE = DateTime.Now,
                    SUBMIT_DATE = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookList;
        }
    }
}
