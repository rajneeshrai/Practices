using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryUtility.Utilities
{
    public class DirectoryUtilities
    {
        /// <summary>
        /// Method to show content (files/folders) of a folder path
        /// </summary>
        /// <param name="path"></param>
        public static void ShowFilesRecurse1(string path, List<string> ignoreFiles)
        {
            // Prepare the DirectoryInfo object from path string
            var directory = new DirectoryInfo(path);
            if (StringUtilities.CanTransformToLower(directory.Name))
            {
                var newDirInLowerCase = StringUtilities.TransformToLower(directory.FullName);
                var tmpDir = directory.FullName + "_tmp";
                directory.MoveTo(tmpDir);
                directory = new DirectoryInfo(tmpDir);
                directory.MoveTo(newDirInLowerCase);
                Console.WriteLine("{0}: {1}", "Directory", newDirInLowerCase);
            }

            // Show all files in directory
            foreach (FileInfo file in directory.GetFiles())
            {
                // Transform the file if needed
                if (StringUtilities.CanTransformToLower(file.Name))
                {
                    var newFileNameInLower = StringUtilities.TransformToLower(file.FullName);
                    var tempFileNameInLower = file.FullName + "_tmp";
                    file.MoveTo(tempFileNameInLower);
                    var tmpFile = new FileInfo(tempFileNameInLower);
                    tmpFile.MoveTo(newFileNameInLower);
                    Console.WriteLine("{0}: {1}", "File", newFileNameInLower);
                }
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
        /// Method to show content (files/folders) of a folder path
        /// </summary>
        /// <param name="path"></param>
        public static void ShowFilesRecurse(string path, List<string> ignoreFiles)
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
    }
}