using BookStoreApi.Model;

namespace BookStoreApi
{
    public interface IBook
    {
        public IEnumerable<T_BOOK> ShowBooks();
    }
}
