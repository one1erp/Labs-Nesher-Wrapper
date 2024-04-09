using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace WindowsFormsApplication1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Descrioption { get; set; }
    }

    internal class GridSaveLoadGroupForm
    {
        private readonly RadGridView gridView = new RadGridView();
        private readonly List<Person> persons = new List<Person>();
        private bool flag;
        public Action onClientChanged;

        public GridSaveLoadGroupForm()
        {
            var dd = new GridViewTextBoxColumn();
            dd.HeaderText = "C1";
            dd.Name = "c1";
            dd.FieldName = "Name";
            gridView.Columns.Add(dd);

            var dc = new GridViewTextBoxColumn();
            dd.HeaderText = "C2";
            dd.Name = "c2";
            dd.FieldName = "Age";
            gridView.Columns.Add(dc);

            foreach (Person item in persons)
            {
                var p = new Person {Age = 12, Name = "bla", Descrioption = "asd"};

                persons.Add(p);
            }
            //    this.gridView.DataSource = table;

            gridView.MasterTemplate.SummaryRowGroupHeaders.Add(
                new GridViewSummaryRowItem(new[]
                                               {
                                                   new GridViewSummaryItem("ID", "FormatString: {0}",
                                                                           GridAggregateFunction.Count)
                                               }));
            gridView.XmlSerializationInfo.SerializationMetadata.Add(typeof (GridViewTemplate),
                                                                    "SummaryRowGroupHeaders",
                                                                    DesignerSerializationVisibilityAttribute
                                                                        .Content);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                gridView.LoadLayout("c:\\temp\\test-123_2.xml");
            }
            else
            {
                gridView.LoadLayout("c:\\temp\\test-123_1.xml");
            }
            flag = !flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridView.SaveLayout("c:\\temp\\test-123_2.xml");
            if (onClientChanged != null) onClientChanged();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            onClientChanged += Bla;
        }

        private void Bla()
        {
            MessageBox.Show("Test");
        }
    }
}