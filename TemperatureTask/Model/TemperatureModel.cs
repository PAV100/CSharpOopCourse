using System;
using System.Collections.Generic;
using System.Linq;

namespace TemperatureTask.Model
{
    public class TemperatureModel : IModel
    {
        private SortedDictionary<string, TemperatureScale> temperatureScales;

        public double SourceTemperature { get; private set; }

        public string SourceTemperatureUnit { get; private set; }

        public double TargetTemperature { get; private set; }

        public string TargetTemperatureUnit { get; private set; }

        public TemperatureModel()
        {
            temperatureScales = new();
            temperatureScales.Add("°C", new("Celsius scale", d => d + 273.15, d => d - 273.15));
            temperatureScales.Add("°K", new("Kelvin scale", d => d, d => d));
            temperatureScales.Add("°F", new("Fahrenheit scale", d => 5.0 / 9.0 * (d - 32) + 273.15, d => 9.0 / 5.0 * (d - 273.15) + 32.0));

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

        public bool ContainsScale(string scale)
        {
            return temperatureScales.ContainsKey(scale);
        }

        public string[] GetUnits()
        {
            return temperatureScales.Keys.ToArray();
        }
    }
}
