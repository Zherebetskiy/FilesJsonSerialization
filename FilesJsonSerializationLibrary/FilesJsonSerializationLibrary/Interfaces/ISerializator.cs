using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesJsonSerializationLibrary.Interfaces
{
    public interface ISerializator
    {
        string Serialize(string path);
    }
}
