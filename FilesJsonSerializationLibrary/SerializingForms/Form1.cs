using FilesJsonSerializationLibrary.Interfaces;
using System;
using System.Runtime.Serialization;
using System.Windows.Forms;


namespace SerializingForms
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog folderBrowserDialog;
        private readonly ISerializator serializator;

        public Form1(ISerializator serializator)
        {
            this.serializator = serializator;
            folderBrowserDialog = new FolderBrowserDialog();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                    string targetDirectory = folderBrowserDialog.SelectedPath.Replace("\\", "/");
                    textBox2.Text = serializator.Serialize(targetDirectory);
                }
                catch (SerializationException ex)
                {
                    MessageBox.Show($"Failed to serialize. Reason: {ex.Message}");
                }
            }
        }
    }
}
