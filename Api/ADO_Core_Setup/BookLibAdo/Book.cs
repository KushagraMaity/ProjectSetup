using BookLibAdo.Model;
using Microsoft.Data.SqlClient;

namespace BookLibAdo
{
    public class Book : IBook
    {
        public static string connectionString = string.Empty;
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
                });
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

        public string GetBDbConnect()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return "OK";
                }
            }catch(Exception ex)
            {
                return string.Format("Failed: {0}", ex.Message);
            }
        }
    }
}
