using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;

namespace CsvImporter
{
    class CSVReader : ICSVReader
    {
        private TextReader _textReader;

        public void OpenFile()
        {
            _textReader = File.OpenText(Properties.Settings.Default.CSVPath);
        }

        public void CloseFile()
        {
            _textReader.Close();
        }
        public IEnumerable<Person> GetPersons()
        {
            var csv = new CsvReader(_textReader);
            csv.Configuration.Delimiter = "\t";

            csv.Configuration.RegisterClassMap<MyClassMap>();
            csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            csv.Configuration.Encoding = Encoding.UTF8;

            var records = csv.GetRecords<Person>();
            return records;
        }

    }

}