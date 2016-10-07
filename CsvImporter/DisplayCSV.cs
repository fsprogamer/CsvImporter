using System.Windows.Forms;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

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

        public static void TestRead()
        {
            //MutableDataTable dt = DataTable.New.ReadCsv(@"c:\Work\Project\CsvImporter\CsvImporter\csv\csv_example_utf8.txt");

            //foreach (Row row in dt.Rows)
            //{
            //    Console.WriteLine(row["ФИО"]);
            //}

            using (TextReader textReader = File.OpenText(@"c:\Users\Сергей\Documents\Visual Studio 2015\Projects\CsvImporter\CsvImporter\csv\csv_example.txt"))
            {

                var csv = new CsvReader(textReader);
                csv.Configuration.RegisterClassMap<MyClassMap>();

                while (csv.Read())
                {
                    var record = csv.GetRecord<Person>();

                    using (var dbContext = new AppDbContext())
                    {
                        var dbPerson = (Person)record;                        
                        dbContext.SaveChanges();
                    }

                    //db.SavePerson(record);
                    //// Сохранить изменения в БД
                    //db.SaveChanges();
                    
                }

            }
            //db.SavePerson(Person person);

            //DbSet.AddRange
            //var dbContext = new MyDbContext();
            //Отключаем автоматическое слежение за изменениями
            //dbContext.Configuration.AutoDetectChangesEnabled = false;
            //Добавляем большое число записей в некоторую таблицу
            //for (var i = 0; i < 1000; i++)
            //{
            //    dbContext.People.Add(new Person());//теперь этот метод работает значительно быстрее
            //}
            //dbContext.ChangeTracker.DetectChanges(); //Обновляем сведения об изменениях. Работает быстро
            //Сохраняем изменения в БД
            //dbContext.SaveChanges();
        }


        public sealed class MyClassMap : CsvClassMap<Person>
        {
            public MyClassMap()
            {
                Map(m => m.FIO).Name("ФИО");
                Map(m => m.Phone).Name("Телефон");
            }
        }


    }
}
