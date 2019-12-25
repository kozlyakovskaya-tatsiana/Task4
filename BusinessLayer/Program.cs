using BusinessLayer.Parsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLayer.WorkWithFiles;


namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler handler = new FileHandler();
            handler.StartHandle(@"E:\Универ\Epam\Task4\Files\Kotov_25.12.2019.txt", new CsvParser());
           
            FileSystemWatcher watcher = new FileSystemWatcher(@"E:\Универ\Epam\Task4\Files");
            watcher.Filter = "*.txt";
            watcher.Created += OnCreate;
            watcher.EnableRaisingEvents = true;
            var parser = new CsvParser();

            Console.WriteLine("Main start");

            Console.WriteLine("MAIN");
            Console.WriteLine("End main");
            Console.ReadKey();

        }

        public static void OnCreate(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine($"{args.FullPath} was {args.ChangeType}");
        }
    }
}
