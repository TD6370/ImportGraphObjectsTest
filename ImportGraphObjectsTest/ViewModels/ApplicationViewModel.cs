using ImportGraphObjectsTest.Engine;
using ImportGraphObjectsTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
                    ObjectsImport.SelectedObject = m_selectedObject;
                    SelectedObjectParams = new ObjectParamsCollection(m_selectedObject);
                }
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
                    try 
                    { 
                        ImportObjectsCSV();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex, "Error on ImportObjectsCSV");
                        MessageBox.Show(ex.Message, "Error on ImportObjectsCSV", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
            });
            }
        }

        public RelayCommand ImportXLS_Commmand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try 
                    {
                        ImportObjectsExcelAsync();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex, "Error on ImportObjectsExcelAsync");
                        MessageBox.Show(ex.Message, "Error on ImportObjectsExcelAsync", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        private void ImportObjectsCSV()
        {
            ObjectsImport.Clear();
            bool isLineTitle = true;

            Action<List<string>> actoinLinesOut = lines =>
            {
                if (isLineTitle && lines.Any())
                {
                    lines.RemoveAt(0);
                    isLineTitle = false;
                }
                ObjectsImport.AddRange(lines);
            };

            string path = Storage.GetPathFromSelectedFile("CSV Files (*.csv)|*.csv");
            if(!string.IsNullOrEmpty(path))
                Storage.ReadFileAsync(path, actoinLinesOut, 1000);
        }


        private async Task ImportObjectsExcelAsync()
        {
            Exception exeptionResult = null;
            ObjectsImport.Clear();

            var lines = await Task.Run(() =>
            {
                try
                {
                    return Storage.ReadExcel();
                }
                catch (Exception ex)
                {
                    exeptionResult = ex;
                    Logger.Error(ex, "Error on ImportObjectsExcelAsync");
                }
                return null;
            });
            if (lines != null)
                ObjectsImport.AddRange(lines);
            if (exeptionResult != null)
                MessageBox.Show(exeptionResult.Message, "Error on ImportObjectsExcelAsync", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
