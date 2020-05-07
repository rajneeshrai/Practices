using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace console_app1
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            Console.WriteLine("Renaming the files to lower-case if they are in upper-case");

            // Read the configuration from appsettings.json
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Prepare the vars from configuration
            string sourceFolderPath = Configuration.GetSection(Appsettings_Constants.SourceFolderPath).Value;
            List<string> ignoreFiles = Configuration.GetSection(Appsettings_Constants.IgnoreFolders).Value
                .Split(",").ToList<string>();


            ShowFilesRecurse1(sourceFolderPath, ignoreFiles);

            Console.ReadLine();
        }

        /// <summary>
        /// Method to show content (files/folders) of a folder path
        /// </summary>
        /// <param name="path"></param>
        private static void ShowFilesRecurse(string path, List<string> ignoreFiles)
        {
            // Prepare the DirectoryInfo object from path string
            var directory = new DirectoryInfo(path);

            // Show all files in directory
            foreach (FileInfo file in directory.GetFiles())
            {
                Console.WriteLine(file.Name);
            }

            // Traverse all the directories
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                // traverse in allowed directory
                if (!ignoreFiles.Contains(dir.Name))
                {
                    ShowFilesRecurse(dir.FullName, ignoreFiles);
                }
            }
        }

        /// <summary>
        /// Method to show content (files/folders) of a folder path
        /// </summary>
        /// <param name="path"></param>
        private static void ShowFilesRecurse1(string path, List<string> ignoreFiles)
        {
            // Prepare the DirectoryInfo object from path string
            var directory = new DirectoryInfo(path);
            if (CanTransformToLower(directory.Name))
            {
                var newDirInLowerCase = TransformToLower(directory.FullName);
                var tmpDir = directory.FullName + "_tmp";
                directory.MoveTo(tmpDir);
                directory = new DirectoryInfo(tmpDir);
                directory.MoveTo(newDirInLowerCase);
                Console.WriteLine("{0}: {1}", "Directory", directory.Name);
            }

            // Show all files in directory
            foreach (FileInfo file in directory.GetFiles())
            {
                // Transform the file if needed
                if (CanTransformToLower(file.Name))
                {
                    var newFileName = TransformToLower(file.FullName);
                    file.MoveTo(newFileName, true);
                    Console.WriteLine("{0}: {1}", "File", newFileName);
                }
                // else
                // {
                //     Console.WriteLine(file.Name);
                // }
            }

            // Traverse all the directories
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                // traverse in allowed directory
                if (!ignoreFiles.Contains(dir.Name))
                {
                    ShowFilesRecurse1(dir.FullName, ignoreFiles);
                }
            }
        }

        /// <summary>
        /// Transform to Lower case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string TransformToLower(string fileName)
        {
            if (fileName.Any(c => char.IsUpper(c)))
            {
                fileName = fileName.ToLower();
            }
            return fileName;
        }

        /// <summary>
        /// Check if file can be transformed to Lower case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool CanTransformToLower(string fileName)
        {
            if (fileName.Any(c => char.IsUpper(c)))
            {
                return true;
            }
            return false;
        }
    }
}
