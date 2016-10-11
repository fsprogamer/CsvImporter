using System.Collections.Generic;
using System.ComponentModel;

namespace CsvImporter
{
    public interface IPersonRepository
    {
        Person GetPerson(int elementId);
        List<Person> GetPersons();

        int SavePerson(Person person);

        int SavePersons(IEnumerable<Person> persons);
    }
}

