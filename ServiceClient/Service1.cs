using BusinessLayer;
using BusinessLayer.WorkWithFiles;
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceClient
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                try
                {
                    Log.Write("Service works");

                    var watchingDirectory = ConfigurationManager.AppSettings.Get("FilesToParseDirectory");

                    using (var watcher = new CsvFileWatcher(watchingDirectory))
                    {
                        watcher.StartHadleFileEvent += (obj, file) => Log.Write($"Start handle {file}");

                        watcher.EndHadleFileEvent += (obj, file) => Log.Write($"Finish handle {file}");

                        watcher.StartWatch();

                        while (true)
                        {
                            Log.Write("Watcher is working");

                            Thread.Sleep(3000);
                        }

                    }
                }

                catch (Exception ex)
                {
                    Log.Write(ex.Message);
                }
            });
        }

        protected override void OnStop()
        {
            Log.Write("Service stopped");
        }
    }
}
