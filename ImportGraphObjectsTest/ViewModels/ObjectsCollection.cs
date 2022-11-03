using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectsCollection : ObservableCollection<ObjectModelVM>
    {
        public void AddRange(List<string> lines)
        {
            foreach (var line in lines)
            {
                Add(new ObjectModelVM(line));
            }
        }
    }
}