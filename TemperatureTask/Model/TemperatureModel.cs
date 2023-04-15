using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Model
{
    public class TemperatureModel : IModel
    {
        public SortedDictionary<string, TemperatureScale> temperatureScales;

        public double SourceTemperature { get; set; }

        public string SourceTemperatureUnit { get; set; }

        public double TargetTemperature { get; set; }

        public string TargetTemperatureUnit { get; set; }

        public TemperatureModel()
        {
            temperatureScales = new();
            temperatureScales.Add("°C", new("Celsius scale", d => d + 273.15, d => d - 273.15));
            temperatureScales.Add("°K", new("Kelvin scale", d => d, d => d));
            temperatureScales.Add("°F", new("Fahrenheit scale", d => 9.0 / 5 * d + 32 + 273.15, d => 5.0 / 9 * (d - 32) - 273.15));

            int initialSourceTemperature = 0;
            SourceTemperatureUnit = "°C";
            TargetTemperatureUnit = "°K";

            SourceTemperature = initialSourceTemperature;
            TargetTemperature = temperatureScales[SourceTemperatureUnit].ToKelvin(initialSourceTemperature);
        }

        public double ConvertTemperature(double sourceTemperature, string sourceTemperatureUnit, string targetTemperatureUnit)
        {
            double kelvinTemperature = temperatureScales[sourceTemperatureUnit].ToKelvin(sourceTemperature);

            if (kelvinTemperature < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            SourceTemperatureUnit = sourceTemperatureUnit;
            TargetTemperatureUnit = targetTemperatureUnit;
            SourceTemperature = sourceTemperature;
            TargetTemperature = temperatureScales[targetTemperatureUnit].FromKelvin(kelvinTemperature);

            return TargetTemperature;
        }
    }
}
