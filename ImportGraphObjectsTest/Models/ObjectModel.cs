using ImportGraphObjectsTest.Engine;
using System;

namespace ImportGraphObjectsTest.Models
{
    public class ObjectModel
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Angle { get; set; }
        public double Width { get; set; }
        public double Hegth { get; set; }
        public bool IsDefect { get; set; }

        public ObjectModel()
        {
        }

        public ObjectModel(string line)
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
            catch(Exception ex)
            {
                Logger.Error(ex, "Error on init ObjectModel");
            }
        }
    }
}
