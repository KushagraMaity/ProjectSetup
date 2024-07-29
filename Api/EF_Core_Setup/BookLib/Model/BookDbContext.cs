using Microsoft.EntityFrameworkCore;

namespace BookLib.Model
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
    }
}
