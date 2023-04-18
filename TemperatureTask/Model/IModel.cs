﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Model
{
    internal interface IModel
    {
        double ConvertTemperature(double sourceTemperature, string sourceTemperatureUnit, string targetTemperatureUnit);
    }
}