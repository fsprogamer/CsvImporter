using System.Windows.Forms;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CsvImporter
{
    public partial class DisplayCSV : Form
    {
        private IPersonRepository db;

        public DisplayCSV(IPersonRepository dbparam)
        {
            db = dbparam;
            InitializeComponent();
            TestRead();
        }

        public void TestRead()
        {
            using (TextReader textReader = File.OpenText(@"..\..\csv\csv_example_utf8.txt"))
            {
                var csv = new CsvReader(textReader);
                csv.Configuration.Delimiter = "\t";

                csv.Configuration.RegisterClassMap<MyClassMap>();  
                csv.Configuration.CultureInfo = CultureInfo.GetCultureInfo("ru-RU");
                csv.Configuration.Encoding = Encoding.UTF8;

                #region by row
                //using (var dbContext = new AppDbContext())
                // {
                //    while (csv.Read())
                //    {
                //        var record = csv.GetRecord<Person>();
                //        var dbPerson = (Person)record;

                //        dbContext.Persons.Add(dbPerson);
                //        int recordsAffected = dbContext.SaveChanges();
                //    }
                //}
                #endregion

                #region by range
                //using (var dbContext = new AppDbContext())
                //{
                //    var records = csv.GetRecords<Person>();                    
                //    dbContext.Persons.AddRange(records);
                //    int recordsAffected = dbContext.SaveChanges();
                //}
                #endregion

                var records = csv.GetRecords<Person>();
                db.SavePersons(records);
            }           
        }

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
}
