using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class LibraryContext : DbContext
    {
        internal object Files;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Products { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { Database.EnsureCreated(); }

    }
}
