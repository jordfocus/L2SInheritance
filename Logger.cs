using System;
using System.IO;


namespace L2SInheritance
{
    public class Logger
    {
        private string _logFilePath;
        private static Logger _logger;
        public static Logger Instance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }
                return _logger;
            }
        }
        private Logger()
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"); ; //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["Log"]);
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            _logFilePath = Path.Combine(logPath, string.Format("log_{0}.txt", DateTime.Now.ToString("dd-MM-yyyy")));
        }

        public void WriteLog(object text)
        {
            File.AppendAllText(_logFilePath, string.Concat(string.Format("[{0}] ", DateTime.Now), text.ToString(), Environment.NewLine));
        }
      
        public void WriteLog(object text, params object[] args)
        {
            File.AppendAllText(_logFilePath, string.Concat(string.Format("[{0}] ", DateTime.Now), string.Format(text.ToString(), args), Environment.NewLine));
        }

       
        public void WriteError(object text)
        {
            WriteLog($"[ERROR] { text }");
        }

        public void WriteError(object text, params object[] args)
        {
            WriteLog($"[ERROR] { text }", args);
        }

        public void WriteWarning(object text)
        {
            WriteLog($"[WARNING] { text }");
        }

        public void WriteWarning(object text, params object[] args)
        {
            WriteLog($"[WARNING] { text }", args);
        }

        public void WriteInfo(object text)
        {
            WriteLog($"[INFO] { text }");
        }

        public void WriteInfo(object text, params object[] args)
        {
            WriteLog($"[INFO] { text }", args);
        }
    }
}
