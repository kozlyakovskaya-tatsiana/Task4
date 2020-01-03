using BusinessLayer.Parsers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.WorkWithFiles
{
    public class CsvFileWatcher
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public CsvFileWatcher(string directoryPath)
        {
            _fileSystemWatcher = new FileSystemWatcher(directoryPath);

            _fileSystemWatcher.Filter = "*.txt";
        }

        public void StartWatch()
        {
            _fileSystemWatcher.Created += OnCreatedExecute;

            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void StopWatch()
        {
            _fileSystemWatcher.Created -= OnCreatedExecute;

            _fileSystemWatcher.EnableRaisingEvents = false;
        }

        public void OnCreatedExecute(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine($"{args.FullPath} was {args.ChangeType}");

            var task = Task.Run(() =>
            {
                Console.WriteLine("watcherOnCreatted" + Task.CurrentId);

                new FileHandler().StartHandle(args.FullPath, new CsvParser());

                Console.WriteLine("watcherOnCreatted" + Task.CurrentId + "finished");

            });

        }


    }
}
