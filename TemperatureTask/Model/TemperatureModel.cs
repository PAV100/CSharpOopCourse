using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Model
{
    public class TemperatureModel : IModel
    {
        private const double InitialSourceTemperature = 0;

        private double sourceTemperature;

        private double targetTemperature;

        private string sourceTemperatureUnit;

        private string targetTemperatureUnit;

        public TemperatureModel()
        {
            sourceTemperature = InitialSourceTemperature;
            sourceTemperatureUnit = "°C";
            targetTemperature = ConvertToKelvin(InitialSourceTemperature);
            targetTemperatureUnit = "°K";
        }

        public double ConvertToKelvin(double celsiusTemperature)
        {
            double result = celsiusTemperature + 273.15;

            if (result < 0)
            {
                throw new ArgumentException("sssss");
            }

            return result;
        }
    }
}
