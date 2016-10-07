
namespace CsvImporter
{
    public interface IPersonRepository
    {
        Person GetElement(int elementId);

        void SavePerson(Person person);
    }
}

