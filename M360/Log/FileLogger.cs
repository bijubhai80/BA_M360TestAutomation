using System;
using System.IO;

namespace Log
{
    public class FileLogger
    {
        private const string SYSTEM_LOG_FILE_START_PATH = @"C:\Windows\system";
        private const string DEFAULT_LOG_FILE_PATH = "C:\\JbsTemp";

        private static FileLogger instance;
        private string _filePath;

        public static FileLogger Instance => instance ?? (instance = new FileLogger());

        public void Configure(string logFullPath = null)
        {
            global::Log.Log.WriteLogMessage -= LogOnWriteLogMessage;
            if (!string.IsNullOrEmpty(logFullPath) && File.Exists(logFullPath))
            {
                _filePath = logFullPath;
            }
            else
            {
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (dirPath.StartsWith(SYSTEM_LOG_FILE_START_PATH) || !Environment.UserInteractive)
                {
                    // This occurs when there is no user profile (eg Internet Interface or Task Processor).
                    dirPath = DEFAULT_LOG_FILE_PATH;
                }
                dirPath = dirPath + @"\M360Automation";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                _filePath = $@"{dirPath}\Log_{DateTime.Now.ToString("s").Replace(':', '_')}.log";
            }

            global::Log.Log.WriteLogMessage += LogOnWriteLogMessage;
        }

        private void LogOnWriteLogMessage(object sender, string message)
        {
            Instance.Log(message);
        }

        public void Log(string message)
        {
            using (var streamWriter = new StreamWriter(_filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}