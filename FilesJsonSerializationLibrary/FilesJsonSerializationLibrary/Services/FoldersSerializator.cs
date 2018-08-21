using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesJsonSerializationLibrary.Models;
using FilesJsonSerializationLibrary.Interfaces;
using System.Web.Script.Serialization;

namespace FilesJsonSerializationLibrary.Services
{
    public class FoldersSerializator : ISerializator
    {
        private readonly ICreator fileSystemCreator;
        public FoldersSerializator(ICreator fileSystemCreator)
        {
            this.fileSystemCreator = fileSystemCreator;
        }

        public string Serialize(string path)
        {
            path = "C: /Users/zhere/OneDrive/Документи/GitHub/BS_Linq/BS_Linq/AcademyDataStructureLINQ/AcademyDataStructureLINQ/bin";
             var rootFolder = fileSystemCreator.Create(path);
            var json = new JavaScriptSerializer().Serialize(rootFolder);
            return json;
        }
    }
}
