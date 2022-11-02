using ImportGraphObjectsTest.Engine;
using ImportGraphObjectsTest.Models;
using ImportGraphObjectsTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImportGraphObjects.ViewModels
{
    class ApplicationViewModel : BaseNotifyPropertyChanged
    {
        public ObjectsCollection ObjectsImport { get; set; } = new ObjectsCollection();

        private ObjectParamsCollection m_selectedObjectParams = new ObjectParamsCollection();
        public ObjectParamsCollection SelectedObjectParams
        {
            get => m_selectedObjectParams;
            set
            {
                m_selectedObjectParams = value;
                OnPropertyChanged(nameof(SelectedObjectParams));
            }
        }

        private ObjectModelVM m_selectedObject;
        public ObjectModelVM SelectedObject
        {
            get => m_selectedObject;
            set
            {
                if (m_selectedObject != value)
                {
                    m_selectedObject = value;
                    SelectedObjectParams = new ObjectParamsCollection(m_selectedObject);
                }
            }
        }

        private int m_objectsCount;
        public int ObjectsCount
        {
            get => m_objectsCount;
            set
            {
                m_objectsCount = value;
                OnPropertyChanged(nameof(ObjectsCount));
            }
        }

        public ApplicationViewModel()
        {
        }

        public RelayCommand ImportCSV_Commmand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ImportObjectsCSV();
                });
            }
        }

        public RelayCommand ImportXLS_Commmand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ImportObjectsXLS();
                });
            }
        }

        private void ImportObjectsXLS()
        {

        }

        private void ImportObjectsCSV_()
        {
            bool isLineTittle = true;

            Action<List<string>> actoinLinesOut = lines =>
            {
                if (isLineTittle && lines.Any())
                {
                    lines.RemoveAt(0);
                    isLineTittle = false;
                }
                ObjectsImport.AddRange(lines);
                ObjectsCount = ObjectsImport.Count();
            };

            string path = Storage.GetPathFromSelectFile("CSV Files (*.csv)|*.csv");
            if(!string.IsNullOrEmpty(path))
                Storage.ReadFileAsync(path, actoinLinesOut, 1000);
        }

        private void ImportObjectsCSV()
        {
            bool isLineTittle = true;
            int count = 0;

            Action<List<string>> actoinLinesOut = lines =>
            {
                if(isLineTittle && lines.Any())
                {
                    lines.RemoveAt(0);
                    isLineTittle = false;
                }
                ObjectsImport.Update(lines);
                count += lines.Count;

                WpfHelper.InvokeMethod(() =>
                {
                    ObjectsCount = count;
                });
            };

            string path = Storage.GetPathFromSelectFile("CSV Files (*.csv)|*.csv");
            if (!string.IsNullOrEmpty(path))
                Storage.ReadFile(path, actoinLinesOut, 1000);
        }

    }
}
