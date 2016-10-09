using System.Collections.Generic;

namespace CsvImporter
{
    public interface IPersonRepository
    {
        Person GetElement(int elementId);

        void SavePerson(Person person);

        void SavePersons(IEnumerable<Person> persons);
    }
}

