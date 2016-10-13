using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvImporter;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod()]
        public void ReadFileTest()
        {
            ICSVReader reader = new CSVReader();
            reader.OpenFile("c:\\Work\\Project\\CsvImporter\\CsvImporter\\csv\\csv_example_utf8.csv");
            IEnumerable<Person> persons = reader.GetPersons();
            List<Person> list_person = new List<Person>();
            list_person.AddRange(persons);
            int record_count = list_person.Count;
            reader.CloseFile();
            Assert.AreNotEqual(0, record_count);
        }

    }
}
