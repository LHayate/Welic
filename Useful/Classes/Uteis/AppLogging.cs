using System;
using System.Diagnostics;
using System.Windows.Forms;
using NLog;

namespace UseFul.Uteis
{
    public static class AppLogging
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Log(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Debug:
                    Logger.Debug(message);
                    break;
                case LogType.Info:
                    Logger.Info(message);
                    break;
                case LogType.Warn:
                    Logger.Warn(message);
                    break;
                case LogType.Error:
                    Logger.Error(message);
                    break;
                case LogType.Fatal:
                    Logger.Fatal(message);
                    break;
                default:
                    Logger.Info(message);
                    break;
            }
        }

        public static void LogException(string message, Exception exception, LogType logType)
        {
            switch (logType)
            {
                case LogType.Debug:
                    Logger.Debug(message, exception, null);
                    break;
                case LogType.Info:
                    Logger.Info(message, exception, null);
                    break;
                case LogType.Warn:
                    Logger.Warn(message, exception, null);
                    break;
                case LogType.Error:
                    Logger.Error(message, exception, null);
                    break;
                case LogType.Fatal:
                    Logger.Fatal(message, exception, null);
                    break;
                default:
                    Logger.Debug(message, exception, null);
                    break;
            }
        }

        public static void OpenLogFolder()
        {
            string myDocspath = Application.StartupPath + @"\log";
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            Process process = new Process
            {
                StartInfo =
                {
                    FileName = windir + @"\explorer.exe",
                    Arguments = myDocspath
                }
            };
            process.Start();
        }
    }
}