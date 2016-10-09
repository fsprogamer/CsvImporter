using System.Linq;
using System.Collections.Generic;

namespace CsvImporter
{
    class PersonRepository : IPersonRepository
    {
        public Person GetElement(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var person = dbContext.Persons.First(p => p.Id == id);
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

        public void SavePersons(IEnumerable<Person> persons)
        {
            using (var dbContext = new AppDbContext())
            {
                //var records = persons;
                dbContext.Persons.AddRange(persons);
                int recordsAffected = dbContext.SaveChanges();
            }
        }
    }
}
