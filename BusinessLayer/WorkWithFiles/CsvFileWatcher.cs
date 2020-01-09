using BusinessLayer.Parsers.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLayer.WorkWithFiles
{
    public class CsvFileWatcher : IDisposable
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public event EventHandler<string> StartHadleFileEvent;

        public event EventHandler<string> EndHadleFileEvent;

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
        }

        public void OnCreatedExecute(object sender, FileSystemEventArgs args)
        {
            var handleFileTask = Task.Run(() =>
             {
                 StartHadleFileEvent?.Invoke(this, args.Name);

                 new FileHandler().StartHandle(args.FullPath, new CsvParser());

                 EndHadleFileEvent?.Invoke(this, args.Name);

             });

        }

    }
}
