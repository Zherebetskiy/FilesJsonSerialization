using FilesJsonSerializationLibrary.Interfaces;
using FilesJsonSerializationLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializingForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ICreator creator = new FileSystemCreator();
            ISerializator serializator = new FoldersSerializator(creator);
            Application.Run(new Form1(serializator));
        }
    }
}
