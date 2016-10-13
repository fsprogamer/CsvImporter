using CsvHelper.Configuration;
using System.Globalization;
 
namespace CsvImporter
{
    public sealed class MyClassMap : CsvClassMap<Person>
    {
        public MyClassMap()
        {
            Map(m => m.FIO).Name("ФИО");
            Map(m => m.Phone).Name("Телефон");
            Map(m => m.Birthday).Name("Дата рождения").TypeConverterOption(DateTimeStyles.AdjustToUniversal); 
            Map(m => m.Email).Name("Email");
        }
    }
}
