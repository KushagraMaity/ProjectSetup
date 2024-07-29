using BookLib.Model;

namespace BookLib
{
    public interface IBook
    {
        public IEnumerable<T_BOOK> ShowBooks();
    }
}
