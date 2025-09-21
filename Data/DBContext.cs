using Microsoft.EntityFrameworkCore;
using bookstore.Models;
namespace bookstore.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<User> Users { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
/*         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        } */

    }
}