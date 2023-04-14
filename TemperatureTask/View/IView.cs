using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.View
{
    internal interface IView
    {
        public void Start();

        public void UpdateTargetTemperature(double temperature);

        public void ShowError(string message);
    }
}
