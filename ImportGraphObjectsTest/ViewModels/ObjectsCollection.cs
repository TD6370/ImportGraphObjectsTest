using ImportGraphObjectsTest.Engine;
using ImportGraphObjectsTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectsCollection : ObservableCollection<ObjectModel>
    {
        public void AddRange(List<string> lines)
        {
            try
            {
                foreach (var item in lines)
                {
                    Add(ParseLine(item));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error on ObjectsCollection.AddRange");
            }
        }

        public void Update(List<string> lines)
        {
            if (!lines.Any())
                return;

            var linesNew = lines.ToList();
            WpfHelper.InvokeMethod(() =>
            {
                AddRange(linesNew);
            });
        }

        private ObjectModel ParseLine(string line)
        {
            return new ObjectModel(line);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}