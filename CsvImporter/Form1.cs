using System;
using System.Windows.Forms;
using DataAccess; // namespace that Csv reader lives in

namespace CsvImporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TestRead();
        }

        public static void TestRead()
        {
            MutableDataTable dt = DataTable.New.ReadCsv(@"c:\Work\Project\CsvImporter\CsvImporter\csv\csv_example_utf8.txt");

            // Query via the DataTable.Rows enumeration.
            foreach (Row row in dt.Rows)
            {
                Console.WriteLine(row["ФИО"]);
            }
        }
      
    }
}
