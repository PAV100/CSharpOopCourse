using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Model
{
    public record TemperatureScale(string Name, Func<double, double> ToKelvin, Func<double, double> FromKelvin)
    {
    }
}
