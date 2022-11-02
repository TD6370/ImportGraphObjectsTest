using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ImportGraphObjectsTest.Engine
{
    public class WpfHelper
    {
        public static void InvokeMethod(Action action, DispatcherPriority priority = DispatcherPriority.ApplicationIdle)
        {
            if (Application.Current == null)
                return;

            if (!Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.BeginInvoke(action, priority);
                return;
            }
            action();
        }

    }
}
