using BusinessLayer.WorkWithFiles;
using System;
using System.Configuration;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var watchingDirectory = ConfigurationManager.AppSettings.Get("FilesToParseDirectory");

                using (var watcher = new CsvFileWatcher(watchingDirectory))
                {
                    watcher.StartHadleFileEvent += (obj, file) => Console.WriteLine($"Start handle {file}");

                    watcher.EndHadleFileEvent += (obj, file) => Console.WriteLine($"Finish handle {file}");

                    watcher.StartWatch();

                    while (true)
                    {
                        Console.WriteLine("Watcher is working");

                        Thread.Sleep(3000);
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine("Press any key to finish");

                Console.ReadKey();
            }

        }

    }
}
