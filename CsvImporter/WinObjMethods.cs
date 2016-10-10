using System.Windows.Forms;

namespace CsvImporter
{
    public static class WinObjMethods
    {        
        public static int CountGridWidth(DataGridView dgv)
            {
                int width = 0;
                foreach (DataGridViewColumn column in dgv.Columns)
                    if (column.Visible == true)
                        width += column.Width;
                return width;
        }

        public static void ResizeGrid(ref DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                int colw = dgv.Columns[i].Width;
                dgv.Colum‌​ns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[i].Width = colw;
            }
        }

        public static void AddColumn(ref DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;

            //create the column programatically
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "FIO",
                HeaderText = "ФИО",
                DataPropertyName = "FIO", // Tell the column which property it should use
                AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells,                
            };
            dgv.Columns.Add(colName);

            colName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Birthday",
                HeaderText = "Дата рождения",
                DataPropertyName = "Birthday", // Tell the column which property it should use
                AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells
            };
            dgv.Columns.Add(colName);

            colName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email", // Tell the column which property it should use
                AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells
            };
            dgv.Columns.Add(colName);

            colName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Phone",
                HeaderText = "Телефон",
                DataPropertyName = "Phone", // Tell the column which property it should use
                AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.Fill
            };
            dgv.Columns.Add(colName);

        }
      
    }
}
