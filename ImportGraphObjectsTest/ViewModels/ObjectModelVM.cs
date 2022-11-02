using ImportGraphObjectsTest.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportGraphObjectsTest.ViewModels
{
    public class ObjectModelVM : BaseNotifyPropertyChanged
    {
        private string m_mame;
        public string Name
        {
            get { return m_mame; }
            set
            {
                m_mame = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double m_Distance;
        public double Distance
        {
            get { return m_Distance; }
            set
            {
                m_Distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        private double m_Angle;
        public double Angle
        {
            get { return m_Angle; }
            set
            {
                m_Angle = value;
                OnPropertyChanged(nameof(Angle));
            }
        }

        private double m_width;
        public double Width
        {
            get { return m_width; }
            set
            {
                m_width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double m_Hegth;
        public double Hegth
        {
            get { return m_Hegth; }
            set
            {
                m_Hegth = value;
                OnPropertyChanged(nameof(Hegth));
            }
        }

        private bool m_isDefect;
        public bool IsDefect
        {
            get { return m_isDefect; }
            set
            {
                m_isDefect = value;
                OnPropertyChanged(nameof(IsDefect));
            }
        }

        public ObjectModelVM()
        {
        }

        public ObjectModelVM(string line)
        {
            try
            {
                var paramsModel = line.Split(';');
                Name = paramsModel[0];
                Distance = double.Parse(paramsModel[1]);
                Angle = double.Parse(paramsModel[2]);
                Width = double.Parse(paramsModel[3]);
                Hegth = double.Parse(paramsModel[4]);
                IsDefect = paramsModel[5].Equals("yes") ? true : false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error on init ObjectModelVM");
            }
        }
    }
}
