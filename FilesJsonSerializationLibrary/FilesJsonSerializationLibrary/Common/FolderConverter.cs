using FilesJsonSerializationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace FilesJsonSerializationLibrary.Common
{
    public class FolderConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[] { typeof(Folder) };
            }
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Folder folder = (Folder)obj;
            IDictionary<string, object> serialized = new Dictionary<string, object>();
            serialized["Name"] = folder.Name;
            serialized["DateCreated"] = folder.DateCreated.ToString();
            serialized["Files"] = folder.Files;
            serialized["Children"] = folder.Children;

            return serialized;
        }
    }
}
