using BusinessLayer.WorkWithFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new CsvFileWatcher(ConfigurationManager.AppSettings.Get("pathToFilesDirectory"));

            watcher.StartWatch();

            Console.WriteLine("main");

            Console.ReadKey();
        }
    }
}
