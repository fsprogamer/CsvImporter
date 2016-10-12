using System.Linq;
using System.Collections.Generic;

namespace CsvImporter
{
    class PersonRepository : IPersonRepository
    {
        private AppDbContext dbContext;

        public void OpenContext()
        {
            dbContext = new AppDbContext();
        }
        public void CloseContext()
        {
            dbContext.Dispose();
        }

        public Person GetPerson(int id)
        {
            if (dbContext != null)
            {
                var person = dbContext.Persons.First(p => p.Id == id);
                return person;
            }
            return null;
        }

        public List<Person> GetPersons()
        {
            if (dbContext != null)
            {
                var person = dbContext.Persons.ToList();
                return person;
            }
            return null;
        }

        public int SavePerson(Person person)
        {
            int recordsAffected = 0;
            if (dbContext != null)
            {
                var dbPerson = dbContext.Persons.First(p => p.Id == person.Id);
                dbPerson.FIO = person.FIO;
                dbPerson.Phone = person.Phone;
                dbPerson.Email = person.Email;
                dbPerson.Birthday = person.Birthday;
                recordsAffected = dbContext.SaveChanges();
            }
            return recordsAffected;
        }

        public int SavePersons(IEnumerable<Person> persons)
        {
            int recordsAffected = 0;
            if (dbContext != null)
            {
                dbContext.Persons.AddRange(persons);
                recordsAffected = dbContext.SaveChanges();
            }
            return recordsAffected;
        }
        public int SaveChanges()
        {
            int recordsAffected = 0;
            if (dbContext != null)
            {
                recordsAffected = dbContext.SaveChanges();
            }
            return recordsAffected;
        }
    }
}
