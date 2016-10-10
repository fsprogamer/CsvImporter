using System.Collections.Generic;

namespace CsvImporter
{
    public interface ICSVReader
    {
        IEnumerable<Person> GetPersons();
        void OpenFile();
        void CloseFile();
    }
}
