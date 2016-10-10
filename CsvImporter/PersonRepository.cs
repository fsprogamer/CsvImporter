using System.Linq;
using System.Collections.Generic;

namespace CsvImporter
{
    class PersonRepository : IPersonRepository
    {
        //private AppDbContext dbContext;

        public Person GetPerson(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var person = dbContext.Persons.First(p => p.Id == id);
                return person;
            }
        }

        public List<Person> GetPersons()
        {
            using (var dbContext = new AppDbContext())
            {
                var person = dbContext.Persons.ToList();
                return person;
            }
        }

        public void SavePerson(Person person)
        {            
            using (var dbContext = new AppDbContext())
            {
                var dbPerson = dbContext.Persons.First(p => p.Id == person.Id);
                dbPerson.FIO = person.FIO;
                dbContext.SaveChanges();
            }
        }

        public int SavePersons(IEnumerable<Person> persons)
        {
            int recordsAffected;
            using (var dbContext = new AppDbContext())
            {
                dbContext.Persons.AddRange(persons);
                recordsAffected = dbContext.SaveChanges();
            }
            return recordsAffected;
        }
    }
}
