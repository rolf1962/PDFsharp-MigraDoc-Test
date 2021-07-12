using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace PDFsharp_MigraDoc.WpfApp
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Einrichten von NLog
            // ---------------------
            string loggerDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name);

            LoggingConfiguration config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            FileTarget logfile = new FileTarget("logfile")
            {
                Layout = Layout.FromString(
                    "${longdate} " +
                    "${message} " +
                    "${exception:format=tostring,stacktrace:innerformat=tostring,stacktrace:maxInnerExceptionLevel=5}", true),
                CreateDirs = true,
                FileName = Path.Combine(loggerDirectory, "logger.txt")
            };
            ConsoleTarget logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;
            Logger.Info($"Logging in Datei {logfile.FileName}");
            // ---------------------
        }

        public static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
    }
}
