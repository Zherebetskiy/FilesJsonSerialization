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
            var rootFolder = fileSystemCreator.Create(path);
            var json = new JavaScriptSerializer().Serialize(rootFolder);
            return json;
        }
    }
}
