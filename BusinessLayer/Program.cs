using BusinessLayer.Parsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLayer.WorkWithFiles;
using System.Configuration;
using System.Threading;
using DataAccessLayer.Repositories.Models;
using DataAccessLayer.EntityModels;

namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
         
            
            Console.WriteLine("Main start");

            var watcher = new FileSystemWatcher(ConfigurationManager.AppSettings.Get("pathToFilesDirectory"));
            watcher.Filter = "*.txt";
            watcher.Created += OnCreate;
            watcher.EnableRaisingEvents = true;
            
            while(true)
            {
                Console.WriteLine("xxxxx");
                Thread.Sleep(1000);
            }
            Console.WriteLine("End main");
            Console.ReadKey();

        }

        public static  void OnCreate(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine($"{args.FullPath} was {args.ChangeType}");
            //Task.Run(() =>
           // {
                Console.WriteLine(Task.CurrentId);
                FileHandler handler = new FileHandler();
                handler.StartHandle(args.FullPath, new CsvParser());
                Console.WriteLine($"{args.FullPath} was parsed");
           // });
        }
    }
}
