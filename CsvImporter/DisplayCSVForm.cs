using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.Entity.Validation;

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
            try
            {
                db.OpenContext();
                BindGrid(ref dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            dataGridView.AutoResizeColumns();
            WinObjMethods.ResizeGrid(ref dataGridView);
            CorrectWindowSize();
        }

        public void ReadCSV(string filename)
        {
            int records_imported = 0;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                reader.OpenFile(filename);
                var records = reader.GetPersons();
                records_imported = db.SavePersons(records);
                MessageBox.Show("Загружено " + records_imported.ToString() + " записей");
            }
            catch (DbEntityValidationException ex)
            {
                string errValString="";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errValString += validationError.Entry.Entity.ToString();
                    errValString += "\n";
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errValString += err.ErrorMessage;
                        errValString += "\n";
                    }
                }
                MessageBox.Show(errValString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                reader.CloseFile();
            }
        }

        private void BindGrid(ref DataGridView dgv)
        {
            List<Person> persons = null;

            try { 
                persons = db.GetPersons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (persons == null || persons.Count > 0)
            {
                var bindsList = new BindingList<Person>(persons);
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
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Properties.Settings.Default.CSVPath;
            openFileDialog.Filter = "CSV файлы|*.csv|Текстовые файлы|*.txt";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                ReadCSV(openFileDialog.FileName);

                BindGrid(ref dataGridView);

                dataGridView.AutoResizeColumns();
                WinObjMethods.ResizeGrid(ref dataGridView);
                CorrectWindowSize();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try { 
                db.SaveChanges();
                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private void DisplayCSVForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
