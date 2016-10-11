using CsvHelper.Configuration;
 
namespace CsvImporter
{
    public sealed class MyClassMap : CsvClassMap<Person>
    {
        public MyClassMap()
        {
            Map(m => m.FIO).Name("ФИО");
            Map(m => m.Phone).Name("Телефон");
            Map(m => m.Birthday).Name("Дата рождения");
            Map(m => m.Email).Name("Email");
        }
    }
}
