using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Model
{
    internal interface IModel
    {
        double ConvertToKelvin(double celsiusTemperature);
    }
}
