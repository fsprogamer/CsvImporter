using System;
using System.Windows.Forms;

namespace CsvImporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PersonRepository db = new PersonRepository();
            CSVReader reader = new CSVReader();

            Application.Run(new DisplayCSVForm(db, reader));
        }
       
    }
}
