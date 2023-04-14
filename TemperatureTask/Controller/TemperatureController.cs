using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void ConvertTemperature(double celsiusTemperature)
        {
            try
            {
                double kelvinTemperature = temperatureModel.ConvertToKelvin(celsiusTemperature);
                view.UpdateTargetTemperature(kelvinTemperature);
            }
            catch (ArgumentException e)
            {
                //TODO messagebox(e.message);
            }
        }
    }
}
