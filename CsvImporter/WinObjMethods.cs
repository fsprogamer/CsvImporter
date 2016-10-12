using System.Windows.Forms;
using System;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

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

        //public static string GetDisplayAttributeValue()
        //{
        //    System.Attribute[] attrs =
        //            System.Attribute.GetCustomAttributes(typeof(CsvImporter.Person));

        //    foreach (System.Attribute attr in attrs)
        //    {
        //        //var displayAttribute as Display;
        //        //if (displayAttribute == null)
        //        //    continue;
        //        //return displayAttribute.GetName();
        //        return null;
        //    }

        //    // throw not found exception or just return string.Empty
        //    return null;
        //}

        //private static string ColumnNameFactory(Type type, string propertyName)
        //{
        //    string columnName = propertyName;
        //    Type entityType = type.GetType(); //.GetEntityType();

        //    var columnAttribute = entityType..GetProperty(propertyName);

        //    bool isDef = Attribute.IsDefined(mInfo, typeof(ObsoleteAttribute));

        //    var columnAttribute = entityType.GetProperty(propertyName).GetCustomAttribute(false);
        //    if (columnAttribute != null && !string.IsNullOrEmpty(columnAttribute.Name))
        //    {
        //        columnName = columnAttribute.Name;
        //    }
        //    return columnName;
        //}

        public static string GetDisplayName<TSource, TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            var attribute = Attribute.GetCustomAttribute(((MemberExpression)expression.Body).Member, typeof(DisplayAttribute)) as DisplayAttribute;
            if (attribute == null)
            {
                return null;
            }
            return attribute.GetName();
        }

        public static void AddColumn(ref DataGridView dgv)
        {
            
            dgv.AutoGenerateColumns = false;

            //Type type = typeof(Person);
            //MemberInfo[] members = type.GetMembers();
            //PropertyInfo[] propinfolist = type.GetProperties();
            //var columnAttribute = propinfo.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().Single().Name;

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
            
            //create the column programatically
            //DataGridViewCell cell = new DataGridViewTextBoxCell();
            //DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn()
            //{
            //    CellTemplate = cell,
            //    Name = "FIO",
            //    HeaderText = "ФИО",
            //    DataPropertyName = "FIO", // Tell the column which property it should use
            //    AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells,                
            //};
            //dgv.Columns.Add(colName);

            //colName = new DataGridViewTextBoxColumn()
            //{
            //    CellTemplate = cell,
            //    Name = "Birthday",
            //    HeaderText = "Дата рождения",
            //    DataPropertyName = "Birthday", // Tell the column which property it should use
            //    AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells
            //};
            //dgv.Columns.Add(colName);

            //colName = new DataGridViewTextBoxColumn()
            //{
            //    CellTemplate = cell,
            //    Name = "Email",
            //    HeaderText = "Email",
            //    DataPropertyName = "Email", // Tell the column which property it should use
            //    AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.AllCells
            //};
            //dgv.Columns.Add(colName);

            //colName = new DataGridViewTextBoxColumn()
            //{
            //    CellTemplate = cell,
            //    Name = "Phone",
            //    HeaderText = "Телефон",
            //    DataPropertyName = "Phone", // Tell the column which property it should use
            //    AutoSizeMode = DataGridViewAutoSize‌​ColumnMode.Fill
            //};
            //dgv.Columns.Add(colName);

        }
      
    }
}
