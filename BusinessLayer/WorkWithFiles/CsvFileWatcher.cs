using BusinessLayer.Parsers.Models;
using System;
using System.IO;
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

            var handleFileTask = Task.Run(() =>
             {
                 Console.WriteLine("watcherOnCreatted" + Task.CurrentId);

                 new FileHandler().StartHandle(args.FullPath, new CsvParser());

                // var name = args.Name.Split('_')[0] + DateTime.Now.ToShortDateString() + ".txt";

             new FileInfo(args.FullPath).MoveTo(@"E:\Универ\Epam\Task4\Files\ParsedFiles\" + Guid.NewGuid() + ".txt" );// args.Name + DateTime.Now.Date.TimeOfDay);

                 Console.WriteLine("watcherOnCreatted" + Task.CurrentId + "finished");

             });

        }


    }
}
