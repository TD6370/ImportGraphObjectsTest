using ImportGraphObjects.ViewModels;
using ImportGraphObjectsTest.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImportGraphObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                InitApplication();
            };
        }

        private void InitApplication()
        {
            try
            {
                DataContext = new ApplicationViewModel();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error on MainApplication.InitApplication");
                MessageBox.Show(ex.Message, "Error on init ppplication", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
