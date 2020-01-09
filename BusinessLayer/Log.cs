using System;
using System.Configuration;
using System.IO;

namespace BusinessLayer
{
    public static class Log
    {
        private static object locker = new object();

        public static void Write(string message)
        {
            lock (locker)
            {
                try
                {
                    File.AppendAllText(ConfigurationManager.AppSettings.Get("logFile"), DateTime.Now + " " + message + Environment.NewLine);
                }
                catch
                {

                }
            }
        }
    }
}
