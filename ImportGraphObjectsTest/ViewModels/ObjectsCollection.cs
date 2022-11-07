using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectsCollection : ObservableCollection<ObjectModelVM>
    {
        public void AddRange(List<string> lines)
        {
            try
            {
                foreach (var line in lines)
                {
                    Add(new ObjectModelVM(line));
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on Filling ObjectsCollection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}