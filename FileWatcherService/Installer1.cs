using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FileWatcherService
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;

        ServiceProcessInstaller serviceProcessInstaller;

        public Installer1()
        {
            InitializeComponent();

            serviceInstaller = new ServiceInstaller();

            serviceProcessInstaller = new ServiceProcessInstaller();

            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.StartType = ServiceStartMode.Manual;

            serviceInstaller.ServiceName = "MyFileWatcherService";

            Installers.Add(serviceInstaller);

            Installers.Add(serviceProcessInstaller);

        }
    }
}
