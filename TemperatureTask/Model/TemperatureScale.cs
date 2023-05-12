using System;

namespace TemperatureTask.Model
{
    public record TemperatureScale(string Name, string Unit, Func<double, double> ToKelvin, Func<double, double> FromKelvin);
}
