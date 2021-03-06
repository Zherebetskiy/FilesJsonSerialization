﻿using FilesJsonSerializationLibrary.Interfaces;
using FilesJsonSerializationLibrary.Models;
using System.Collections.Generic;

namespace FilesJsonSerializationLibrary.Services
{
    public class FileSystemCreator : ICreator
    {
        List<File> GetFiles(string folder)
        {
            List<File> currentFiles = new List<File>();
            var files = System.IO.Directory.GetFiles(folder);

            foreach (var file in files)
            {
                var info = new System.IO.FileInfo(file);
                currentFiles.Add(new File
                {
                    Name = info.Name,
                    Size = string.Concat(info.Length, "B"),
                    Path = info.FullName
                });
            }

            return currentFiles;
        }

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
                    DateCreated = info.CreationTimeUtc,
                    Files = GetFiles(directory),
                    Children = GetFolders(directory)
                });
            }

            return currentFolders;
        }

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
