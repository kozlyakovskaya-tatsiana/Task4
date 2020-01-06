using BusinessLayer.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
using BusinessLayer.Parsers.Models;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var watchingDirectory = ConfigurationManager.AppSettings.Get("FilesToParseDirectory");

            var handleExistingFiles = Task.Run(() => HandleExistingFiles(watchingDirectory));

            using (var watcher = new CsvFileWatcher(watchingDirectory))
            {
                watcher.StartWatch();

                while (true)
                {
                    Console.WriteLine("main");

                    Thread.Sleep(5000);
                }

                Console.ReadKey();
            }

        }

        private static void HandleExistingFiles(string pathToDirectory)
        {
            if (!Directory.Exists(pathToDirectory))
                return;

            var files = Directory.GetFiles(pathToDirectory);

            foreach (var file in files)
            {
                var handleFileTask = Task.Run(() =>
                {

                    new FileHandler().StartHandle(file, new CsvParser());

                    Console.WriteLine($"{file} was successfully handled");

                });

            }
        }
    }
}
