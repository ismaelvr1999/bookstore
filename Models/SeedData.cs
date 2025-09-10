using Microsoft.EntityFrameworkCore;
using bookstore.Data;
using bookstore.Models;


namespace bookstore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DBContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DBContext>>()))
        {
            if (context == null || context.Books == null)
            {
                throw new ArgumentNullException("Null DBContext");
            }

            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            context.Autors.AddRange(
                new Autor
                {
                    FirstName = "Franz",
                    LastName = "Kafka"
                }
            );

            context.SaveChanges();
        }
    }
}