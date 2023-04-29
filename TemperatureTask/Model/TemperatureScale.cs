using System;

namespace TemperatureTask.Model
{
    public record TemperatureScale(int Id, string Name, string Unit, Func<double, double> ToKelvin, Func<double, double> FromKelvin)
    {
    }
}
