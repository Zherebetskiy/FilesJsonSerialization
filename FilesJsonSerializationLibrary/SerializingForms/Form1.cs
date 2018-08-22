using FilesJsonSerializationLibrary.Interfaces;
using FilesJsonSerializationLibrary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SerializingForms
{
    public partial class Form1 : Form
    {
        OpenFileDialog openfiledialog = new OpenFileDialog();
        private readonly ISerializator serializator;

        public Form1()
        {
           serializator = new FoldersSerializator(new FileSystemCreator());
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openfiledialog.InitialDirectory = "c:\\";
            openfiledialog.Filter = "";
            openfiledialog.FilterIndex = 2;
            openfiledialog.RestoreDirectory = true;


            //if (openfiledialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
                   
            //        string targetDirectory = openfiledialog.FileName.Replace("\\", "/");
            //        df.Serialize(targetDirectory, fileName);
            //        var info = new FileInfo(fileName);
            //        MessageBox.Show($"Serialized data file is located on path:{info.FullName}");
            //    }
            //    catch (SerializationException ex)
            //    {
            //        MessageBox.Show($"Failed to serialize. Reason: {ex.Message}");
            //    }
            //}

            serializator.Serialize();
        }
    }
}
