using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsvImporter
{
    public partial class EditPersonForm : Form
    {
        public EditPersonForm()
        {
            InitializeComponent();
        }

        private void EditPersonForm_Load(object sender, EventArgs e)
        {

            MyClassMap maps = new MyClassMap();

            //Form_Ans form_answer in form_answer_list
            //int num = maps.PropertyMaps.Count;
            for (int i = 0; i < maps.PropertyMaps.Count; i++)
            {
                Label lbl = new Label();
                lbl.Name = maps.PropertyMaps[0].Data.Names[0];
                lbl.Text = maps.PropertyMaps[0].Data.Property.ToString();

                TextBox box = new TextBox();
                box.Name = maps.PropertyMaps[0].Data.Names[0];
            

                //    box.AutoSize = true;
                //    box.Dock = System.Windows.Forms.DockStyle.Fill;
                //    box.Tag = form_answer;
                //    flpanel.Controls.Add(box);
            }

        }
    }
}
