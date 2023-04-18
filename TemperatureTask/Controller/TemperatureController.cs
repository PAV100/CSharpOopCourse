using System;
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
            if (sourceTemperatureUnit is null || !temperatureModel.ContainsScale(sourceTemperatureUnit))
            {
                throw new ArgumentNullException();
            }

            if (targetTemperatureUnit is null || !temperatureModel.ContainsScale(targetTemperatureUnit))
            {
                throw new ArgumentNullException();
            }

            double sourceTemperature = Convert.ToDouble(sourceTemperatureText); // Trows Format Exception           

            double targetTemperature = temperatureModel.ConvertTemperature(sourceTemperature, sourceTemperatureUnit, targetTemperatureUnit); // Trows ArgumentOutOfRangeException Exception           

            view.UpdateTargetTemperature(targetTemperature);
        }

        public void LoadValuesToFields()
        {
            view.UpdateAllFields(temperatureModel.SourceTemperature, temperatureModel.SourceTemperatureUnit,
                temperatureModel.TargetTemperature, temperatureModel.TargetTemperatureUnit,
                temperatureModel.GetUnits());
        }
    }
}
