using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using DirectoryUtility.AppConsole.Configuration;
using DirectoryUtility.Utilities;

namespace DirectoryUtility.AppConsole
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Renaming the files to lower-case if they are in upper-case");

            // Read the configuration from appsettings.json
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Prepare the vars from configuration
            string sourceFolderPath = Configuration.GetSection(Appsettings_Constants.SourceFolderPath).Value;
            List<string> ignoreFiles = Configuration.GetSection(Appsettings_Constants.IgnoreFolders).Value
                .Split(",").ToList<string>();

            DirectoryUtilities.TransformFileNamesToLower(sourceFolderPath, ignoreFiles);

            Console.ReadLine();
        }
    }
}
