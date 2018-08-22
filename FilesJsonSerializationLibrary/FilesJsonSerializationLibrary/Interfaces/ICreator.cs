using FilesJsonSerializationLibrary.Models;

namespace FilesJsonSerializationLibrary.Interfaces
{
    public interface ICreator
    {
        Folder Create(string path);
    }
}
