using System.Data.Entity;

namespace CsvImporter
{
   public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext")
        { }

        public DbSet<Person> Persons { get; set; }

    }
}
