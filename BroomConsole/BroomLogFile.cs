using System;
using System.Globalization;
using System.IO;
using System.Text;

using static System.Console;

namespace BroomConsole
{
    public static class BroomLogFile
    {
        private const string logFilePath = @"broom.log";

        private static void WriteLogFile(string message)
        {
            try
            {
                using var logFile = new StreamWriter(logFilePath, true, Encoding.Default);
                logFile.WriteLine(message);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public static void LogFileStart()
        {
            var msg = "=============== " + DateTime.Today + " ===============";
            WriteLogFile(msg);
        }
        public static void LogFileEnd()
        {
            const string msg = "=============== END ===============";
            WriteLogFile(msg);
        }
        public static void SuccessfullyMessage(string message)
        {
            var msg = DateTime.Now.ToString() + " - Successfully : " + message;
            WriteLogFile(msg);
        }
        public static void ErrorMessage(string message)
        {
            var msg = DateTime.Now.ToString() + " - Error : " + message;
            WriteLogFile(msg);
        }
        public static void InfoMessage(string message)
        {
            var msg = DateTime.Now.ToString() + " - Info : " + message;
            WriteLogFile(msg);
        }
    }
}
