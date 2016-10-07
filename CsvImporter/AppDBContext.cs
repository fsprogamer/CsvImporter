using System.Data.Entity;

namespace CsvImporter
{
   public class AppDbContext : DbContext
    {
        public AppDbContext() : base("PersonDB")
        { }

        public DbSet<Person> Persons { get; set; }        
    }
}
