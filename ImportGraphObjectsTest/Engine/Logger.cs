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

            //try
            //{
                lock (m_lock)
                {
                    using (StreamWriter streamWriter = new StreamWriter(LogPath, true))
                    {
                        streamWriter.WriteLine(message);
                        streamWriter.Close();
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error on save log:\n{ex.Message}\n\nSave log:\n{message}", "Error on FileLogger.Save", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private static void SaveTitle(ref string message)
        {
            //try
            //{
                //if (m_isLogCreateChecked)
                //    return;

                System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                string version = executingAssembly.GetName().Version.ToString();
                string appName = executingAssembly.GetName().Name;
                string splitter = new string('=', 100) + "\n";

                message = $"{splitter}ver: {version}\tPC: {Environment.MachineName}\n{message}";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error on save title log:\n{ex.Message}\n\nSave log:\n{message}", "Error on FileLogger.SaveTitle", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //finally
            //{
            //    m_isLogCreateChecked = true;
            //}
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
