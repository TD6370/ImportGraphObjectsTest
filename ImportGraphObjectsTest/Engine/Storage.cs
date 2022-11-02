using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportGraphObjectsTest.Engine
{
    class Storage
    {
        public static async Task ReadFileAsync(string path, Action<List<string>> actionOut, int limitLines = 10)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                List<string> outLines = new List<string>();
                string? line;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    outLines.Add(line);
                    if (outLines.Count >= limitLines)
                    {
                        actionOut(outLines);
                        outLines.Clear();
                    }
                }
                if (outLines.Any())
                    actionOut(outLines);
            }
        }

        public static void ReadFile(string path, Action<List<string>> actionOut, int limitLines = 10)
        {
            Task.Run(() =>
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    List<string> outLines = new List<string>();
                    string? line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        outLines.Add(line);
                        if (outLines.Count >= limitLines)
                        {
                            actionOut(outLines);
                            outLines.Clear();
                        }
                    }
                    if (outLines.Any())
                        actionOut(outLines);
                }
            });
        }

        public static string GetPathFromSelectFile(string filter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog() { Filter = filter };
            var result = openFileDialog.ShowDialog();
            if (result == false) return string.Empty;
            return openFileDialog.FileName;
        }

        //var result = await Task.Run(() =>
        //{
        //}
    }
}