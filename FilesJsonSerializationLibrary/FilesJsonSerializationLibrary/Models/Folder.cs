using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesJsonSerializationLibrary.Models
{
    public class Folder
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Children { get; set; }
    }
}
