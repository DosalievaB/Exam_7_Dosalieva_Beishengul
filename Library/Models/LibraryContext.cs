using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        internal object Files;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { Database.EnsureCreated(); }

    }
}
