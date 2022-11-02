using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportGraphObjectsTest.Engine
{
    public class Logger
    {
        private static Object m_lock = new object();
        private static string LogPath = string.Concat(Environment.CurrentDirectory, "\\", "Log.txt");  

        private static void Log(string message, string title = "")
        {
            string date = DateTime.Now.ToString();
            message = $"[{date}] {title}: {message}";

            SaveTitle(ref message);

            lock (m_lock)
            {
                using (StreamWriter streamWriter = new StreamWriter(LogPath, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }

        private static void SaveTitle(ref string message)
        {
            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            string version = executingAssembly.GetName().Version.ToString();
            string appName = executingAssembly.GetName().Name;
            string splitter = new string('=', 100) + "\n";

            message = $"{splitter}ver: {version}\tPC: {Environment.MachineName}\n{message}";
        }

        public static void Error(Exception ex, string title = "", string description = "")
        {
            string strErr = ex.ToString();

            if (string.IsNullOrEmpty(title))
                title = "Error:";

            if (!string.IsNullOrEmpty(description))
                strErr = $"\n{description}\n{strErr}";

            strErr = $"{strErr}\n{Environment.StackTrace}";

            Log(strErr, title);
        }
    }
}
