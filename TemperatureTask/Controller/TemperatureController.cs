using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Controller
{
    public class TemperatureController
    {
        private readonly TemperatureModel temperatureModel;

        private GuiView view;

        public TemperatureController(TemperatureModel temperatureModel)
        {
            this.temperatureModel = temperatureModel;
        }

        public void SetView(GuiView view)
        {
            this.view = view;
        }

        public void ConvertTemperature(string sourceTemperatureText, string sourceTemperatureUnit, string targetTemperatureUnit)
        {
            if (sourceTemperatureUnit is null || !temperatureModel.temperatureScales.ContainsKey(sourceTemperatureUnit))
            {
                throw new ArgumentNullException();
            }

            if (targetTemperatureUnit is null || !temperatureModel.temperatureScales.ContainsKey(targetTemperatureUnit))
            {
                throw new ArgumentNullException();
            }

            double sourceTemperature = Convert.ToDouble(sourceTemperatureText); // Trows Format Exception           

            double targetTemperature = temperatureModel.ConvertTemperature(sourceTemperature, sourceTemperatureUnit, targetTemperatureUnit);             // Trows ArgumentOutOfRangeException Exception           

            view.UpdateTargetTemperature(targetTemperature);
        }       
    }
}
