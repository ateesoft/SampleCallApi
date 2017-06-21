using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace SampleCallApi
{
    class Log
    {
        public static readonly object LockerError = new object();
        public static readonly object LockerInfo = new object();

        private static void Init()
        {
            string logPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }
        private static void Init(string folderName)
        {
            string logPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + folderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }

        public static void Warning(string message)
        {
            new Thread(() => WriteWarning(message)).Start();
        }

        public static void Error(string message)
        {
            new Thread(() => WriteError(message)).Start();
        }

        public static void Info(string message)
        {
            new Thread(() => WriteInfo(message)).Start();
        }

        public static void More(string message, string fileName)
        {
            new Thread(() => WriteMore(message, fileName)).Start();
        }

        public static void More(string message, string folderName, string fileName)
        {
            new Thread(() => WriteMore(message, folderName, fileName)).Start();
        }

        private static void WriteWarning(string message)
        {
            try
            {
                lock (LockerError)
                {
                    Init();
                    var fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\" +
                                      DateTime.Now.ToString("yyyy-MM-dd") + "\\" + $"Warning-{DateTime.Now:yyyyMMdd}" + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write($"{DateTime.Now:dd/MM/yyyy-HH:mm:ss} | ");
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private static void WriteError(string message)
        {
            try
            {
                lock (LockerError)
                {
                    Init();
                    var fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\" +
                                      DateTime.Now.ToString("yyyy-MM-dd") + "\\" + $"Error-{DateTime.Now:yyyyMMdd}" + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write($"{DateTime.Now:dd/MM/yyyy-HH:mm:ss} | ");
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private static void WriteInfo(string message)
        {
            try
            {
                lock (LockerInfo)
                {
                    Init();
                    var fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + String.Format("Info-{0:yyyyMMdd}", DateTime.Now) + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write(String.Format("{0:dd/MM/yyyy-HH:mm:ss} | ", DateTime.Now));
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private static void WriteMore(string message, string fileName)
        {
            try
            {
                lock (LockerInfo)
                {
                    Init();
                    fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Logs\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + fileName + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write($"{DateTime.Now:dd/MM/yyyy-HH:mm:ss} | ");
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private static void WriteMore(string message, string folderName, string fileName)
        {
            try
            {
                lock (LockerInfo)
                {
                    Init(folderName);
                    fileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + folderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + fileName + ".txt";
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.Write($"{DateTime.Now:dd/MM/yyyy-HH:mm:ss} | ");
                        sw.WriteLine(message);
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}