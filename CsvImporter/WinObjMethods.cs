using System.Windows.Forms;
using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
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

        //private static string ColumnNameFactory(this Type type, string propertyName)
        //{
        //    string columnName = propertyName;
        //    Type entityType = type.GetEntityType();
        //    var columnAttribute = entityType.GetProperty(propertyName).GetCustomAttribute<ColumnAttribute>(false);
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

            Type type = typeof(Person);
            MemberInfo[] members = type.GetMembers();
            string[] localizedName = new string[members.Length];
            for (int num = 0; num < members.Length; num++)
            {                
                localizedName[num] = GetDisplayName<Person, string>(i => members[num].Name);
            }

            //var attribute = Attribute.GetCustomAttribute(((MemberExpression)expression.Body).Member, typeof(DisplayAttribute)) as DisplayAttribute;

            //Person person = new Person();

            //Type type = typeof(Person);
            //MemberInfo[] members = type.GetMembers();

            //// Display the attributes for each of the members of MyClass1.
            //for (int i = 0; i < members.Length; i++)
            //{
            //    Object[] myAttributes = members[i].GetCustomAttributes(true);
            //    if (myAttributes.Length > 0)
            //    {
            //        Console.WriteLine("\nThe attributes for the member {0} are: \n", members[i]);
            //        for (int j = 0; j < myAttributes.Length; j++)
            //            Console.WriteLine("The type of the attribute is {0}.", myAttributes[j]);
            //    }
            //}

           // var barProperty = person.GetType().GetProperty("FIO").GetCustomAttributes(false);
            //string s = barProperty.GetValue(person, null) as string;
                      
            //typeof(Person)
            //.GetProperties()
            //.Select(x => x.GetCustomAttribute(true)())
            //.Where(x => x != null)
            //.Select(x => x.Name);


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
