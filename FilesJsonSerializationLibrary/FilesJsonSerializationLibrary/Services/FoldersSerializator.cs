using FilesJsonSerializationLibrary.Common;
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
            var selializator = new JavaScriptSerializer();
            path = path.Replace("\\", "/");
            var rootFolder = fileSystemCreator.Create(path);
            selializator.RegisterConverters(new[] { new FolderConverter() });
            var json = selializator.Serialize(rootFolder);
            return json;
        }
    }
}
