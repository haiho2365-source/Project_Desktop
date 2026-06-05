using System;
using System.Collections.Generic;

namespace Project_OOP
{
    public static class Logger
    {
        private static List<string> _logs = new List<string>();

        public static void Log(string message)
        {
            string logEntry = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message;
            _logs.Add(logEntry);
        }

        public static List<string> GetLogs()
        {
            return _logs.ToList();
        }

        public static void PrintLogs()
        {
            _logs.ForEach(log => Console.WriteLine(log));
        }

        public static void ClearLogs()
        {
            _logs.Clear();
        }

        public static List<string> SearchLogs(string keyword)
        {
            return _logs.Where(log => log.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}
