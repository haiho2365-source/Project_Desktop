using System;
using System.Collections.Generic;

namespace Project_OOP
{
    public static class Logger
    {
        private static List<string> _logs = new List<string>();

        public static void Log(string message)
        {
            string logEntry = DateTime.Now.ToString() + " - " + message;
            _logs.Add(logEntry);
        }

        public static void PrintLogs()
        {
            int i;
            for (i = 0; i < _logs.Count; i++)
            {
                Console.WriteLine(_logs[i]);
            }
        }
    }
}