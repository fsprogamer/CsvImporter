using System.Linq;

namespace CsvImporter
{
    class PersonRepository : IPersonRepository
    {
        public Person GetElement(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                //var person = dbContext.Persons.First(p => p.Id == id);
                return null;//person;
            }
        }

        public void SavePerson(Person person)
        {            
            using (var dbContext = new AppDbContext())
            {
               // var dbPerson = dbContext.Persons.First(p => p.Id == person.Id);
                //dbPerson.FIO = person.FIO;
                dbContext.SaveChanges();
            }
        }
    }
}
