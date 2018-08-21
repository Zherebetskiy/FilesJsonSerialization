using FilesJsonSerializationLibrary.Interfaces;
using FilesJsonSerializationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesJsonSerializationLibrary.Services
{
    public class FileSystemCreator : ICreator
    {
        //public string NeedlessDirectory { get; set; }
        //public string RootFolder { get; set; }

        //public FileSystemCreator(string rootFolder)
        //{
        //    NeedlessDirectory = targetDirectory.Substring(0, targetDirectory.LastIndexOf("/")).Replace("/", "\\");
        //    RootFolder = rootFolder;
        //}

        //
        // return List of custom File instances in target directory 
        //
        List<File> GetFiles(string rootFolder)
        {
            List<File> currentFiles = new List<File>();
            var files = System.IO.Directory.GetFiles(rootFolder);

            foreach (var file in files)
            {
                var info = new System.IO.FileInfo(file);
                currentFiles.Add(new File
                {
                    Name = info.Name,
                    Size = info.Length,
                    Path = info.FullName
                });
            }

            return currentFiles;
        }

        //
        // recursively create folders' tree as custom Directory instances
        //
        List<Folder> GetFolders(string rootDirectory)
        {
            List<Folder> currentFolders = new List<Folder>();
            var directories = System.IO.Directory.GetDirectories(rootDirectory);

            foreach (var directory in directories)
            {
                var info = new System.IO.DirectoryInfo(directory);
                currentFolders.Add(new Folder
                {
                    Name = info.Name,
                    DateCreated = info.CreationTime,
                    Files = GetFiles(directory),
                    Children = GetFolders(directory)
                });
            }

            return currentFolders;
        }

        //
        // method for creating root directory and starting
        // creation folders' tree
        //
        public Folder Create(string rootFolder)
        {
            var info = new System.IO.DirectoryInfo(rootFolder);
            return new Folder
                {
                    Name = info.Name,
                    DateCreated = info.CreationTime,
                    Files = GetFiles(rootFolder),
                    Children = GetFolders(rootFolder)
                };
        }
    }
}
