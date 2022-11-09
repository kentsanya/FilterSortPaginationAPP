using Microsoft.EntityFrameworkCore;
using ValidModelAPP.Models;

namespace ValidModelAPP.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Publishing> Publishings { get; set; }  
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
