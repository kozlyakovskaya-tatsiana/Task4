using BusinessLayer.Parsers.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLayer.WorkWithFiles
{
    public class CsvFileWatcher : IDisposable
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

        public void Dispose()
        {
            _fileSystemWatcher.Dispose();

            GC.SuppressFinalize(this);
        }

        public void OnCreatedExecute(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine($"{args.Name} was {args.ChangeType}");

            var handleFileTask = Task.Run(() =>
             {
                 Console.WriteLine($"{args.Name} is handled");

                 new FileHandler().StartHandle(args.FullPath, new CsvParser());

                 Console.WriteLine($"{args.Name} was successfully handled");

             });

        }


    }
}
