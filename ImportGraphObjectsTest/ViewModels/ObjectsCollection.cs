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
    public class ObjectsCollection : ObservableCollection<ObjectModelVM>
    {
        public ObjectModelVM SelectedObject { get; set; }

        public void AddRange(List<string> lines)
        {
            foreach (var line in lines)
            {
                Add(new ObjectModelVM(line));
            }
        }
    }
}