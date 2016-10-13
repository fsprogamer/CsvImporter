using System.Windows.Forms;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

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
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            var properties = typeof(Person).GetProperties()
                                           .Where(p => p.IsDefined(typeof(DisplayAttribute), false))
                                           .Select(p => new
                                           {
                                               PropertyName = p.Name,
                                               p.GetCustomAttributes(typeof(DisplayAttribute),
                                              false).Cast<DisplayAttribute>().Single().Name
                                           });
            foreach (var propinfo in properties)
            {
                    DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn()
                    {
                        CellTemplate = cell,
                        Name = propinfo.PropertyName,
                        HeaderText = propinfo.Name.ToString(),
                        DataPropertyName = propinfo.PropertyName, 
                        AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells,
                    };
                    dgv.Columns.Add(colName);
            }
            dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.Fill;                       
        }
      
    }
}
