using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Text.Json;


using TypeInfoClasses;
using BindingTool;

namespace WindowsFormsApp1
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }


        private void readCSVBotton_Click(object sender, EventArgs e)
        {
            var path = "Input.csv";
            try
            {
                var result = from line in File.ReadAllLines(path)
                             let elements = line.Split(';')
                             select elements;

                List<string[]> tagList = result.ToList();
            


                csvDataViewer.Rows.Clear();


                // Add column to DataGridView named like in first line of CSV file
                csvDataViewer.ColumnCount = tagList[1].Count();
                for (int i = 0; i < tagList[1].Count(); i++)
                    csvDataViewer.Columns[i].Name = (string)tagList[0].GetValue(i);

                csvDataViewer.Columns[0].Width = 300;

                // Filling the DataGridView from CSV file
                foreach (string[] i in tagList.Skip(1))
                    csvDataViewer.Rows.Add(i);

                tagList = null;

            }
            catch (FileNotFoundException) { MessageBox.Show("File "+path+" not found in current folder"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnToXMLConvert_Click(object sender, EventArgs e)
        {
            var toXML = from DataGridViewRow data in csvDataViewer.SelectedRows
                        let row = data.Cells
                        orderby data.Index
                        select row;
            
            // Read types collection from JSON file
            string path = "TypeInfos.json";
            string jsonString="";
            try 
            { 
                jsonString = File.ReadAllText(path);
            }
            catch (FileNotFoundException) { MessageBox.Show("File " + path + " not found in current folder"); }

            TypeList typeList = JsonSerializer.Deserialize<TypeList>(jsonString);
                       
            string tmpName = "";
            string tmpType = "";
            int tmpAddres = 0;

            BinderList binder = new BinderList();

            foreach (var tag in toXML)
            {
                tmpName = tag[0].Value.ToString();
                tmpType = tag[1].Value.ToString();
                tmpAddres = 0;
                if (tag[2].Value.ToString() != "")
                            tmpAddres = Int32.Parse(tag[2].Value.ToString());

                try
                {
                    binder.AddBinder(tmpName, tmpType, tmpAddres, ref typeList);
                }
                catch (UndefinedTypeNameExcpeption) { MessageBox.Show("Type " + tmpType + " is wrong. Check JSON file"); }
                catch (UndefinedPropertyExcpeption) { MessageBox.Show("Type " + tmpType + " id not found in JSON file"); }

            }

            path = "result.xml";
            try
            {
                var Doc = binder.ToXML();
                Doc.Save(path);
            }
            catch (IOException) { MessageBox.Show("Error when saving result in XML file"); }
            MessageBox.Show("Selected rows are saved in "+path);

        }
    }
}
