using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace CsvImporter
{
    public partial class DisplayCSVForm : Form
    {
        private IPersonRepository db;
        private ICSVReader reader;

        public DisplayCSVForm(IPersonRepository dbparam, ICSVReader readerparam)
        {
            db = dbparam;
            reader = readerparam;
            InitializeComponent();
        }

        private void DisplayCSV_Load(object sender, System.EventArgs e)
        {
            WinObjMethods.AddColumn(ref dataGridView);
            BindConnectionGrid(ref dataGridView);            
            dataGridView.AutoResizeColumns();
            WinObjMethods.ResizeGrid(ref dataGridView);
            CorrectWindowSize();
        }

        public void ReadCSV()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                reader.OpenFile();
                var records = reader.GetPersons();          
                db.SavePersons(records);
                reader.CloseFile();
            }
           catch (Exception ex)
           {
              MessageBox.Show(ex.ToString());
           }
           finally
           {
            this.Cursor = Cursors.Default;
           }
        }


        private void BindConnectionGrid(ref DataGridView dgv)
        {
            List<Person> persons = db.GetPersons();

            if (persons.Count > 0)
            {
                var bindsList = new BindingList<Person>(persons);
                //Bind BindingList directly to the DataGrid
                var source = new BindingSource(bindsList, null);
                dgv.DataSource = source;
            }
        }

        private void CorrectWindowSize()
        {
            int width = WinObjMethods.CountGridWidth(dataGridView);
            ClientSize = new Size(width, ClientSize.Height);
            MinimumSize = new Size(width, ClientSize.Height);
        }

        private void importToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ReadCSV();            
            BindConnectionGrid(ref dataGridView);            
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditPersonForm editForm = new EditPersonForm();
            editForm.Show();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPersonForm editForm = new EditPersonForm();
            editForm.Show();
        }
    }
}
