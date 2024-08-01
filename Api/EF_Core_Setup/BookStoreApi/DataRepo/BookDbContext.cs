using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Model
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //add data to T_CurrencyType table
            modelBuilder.Entity<T_CurrencyType>().HasData(
                new T_CurrencyType() { ID = 1, TITLE = "INR", DESCRIPTION = "Indian INR" },
                new T_CurrencyType() { ID = 2, TITLE = "Dollar", DESCRIPTION = "Dollar" },
                new T_CurrencyType() { ID = 3, TITLE = "Euro", DESCRIPTION = "Euro" },
                new T_CurrencyType() { ID = 4, TITLE = "Dinar", DESCRIPTION = "Dinar" }
                );

            modelBuilder.Entity<T_Language>().HasData(
                new T_Language() { ID = 1, TITLE = "Hindi", DESCRIPTION = "Hindi" },
                new T_Language() { ID = 2, TITLE = "Tamil", DESCRIPTION = "Tamil" },
                new T_Language() { ID = 3, TITLE = "Panjabi", DESCRIPTION = "Panjabi" },
                new T_Language() { ID = 4, TITLE = "Urdu", DESCRIPTION = "Urdu" }
                );
        }

        public DbSet<T_BOOK> T_Books { get; set; }
        public DbSet<T_Language> T_Languages { get; set; }
        public DbSet<T_BookPrice> T_BookPrices { get; set; }
        public DbSet<T_CurrencyType> T_CurrencyTypes { get; set; }
    }
}
