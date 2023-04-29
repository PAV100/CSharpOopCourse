using System;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Controller
{
    public class TemperatureController : IController
    {
        private readonly IModel temperatureModel;

        private IView view;

        public TemperatureController(IModel temperatureModel)
        {
            this.temperatureModel = temperatureModel;
        }

        public void SetView(IView view)
        {
            this.view = view;
        }

        public void ConvertTemperature(double sourceTemperature, TemperatureScale sourceScale, TemperatureScale targetScale)
        {
            if (sourceScale is null)
            {
                throw new ArgumentNullException();
            }

            if (targetScale is null)
            {
                throw new ArgumentNullException();
            }

            double targetTemperature = temperatureModel.ConvertTemperature(sourceTemperature, sourceScale, targetScale); // Throws ArgumentOutOfRangeException Exception           

            view.UpdateTargetTemperature(targetTemperature);
        }

        public void LoadValuesToFields()
        {
            view.UpdateAllFields(
                temperatureModel.SourceTemperature,
                temperatureModel.SourceScale,
                temperatureModel.TargetTemperature,
                temperatureModel.TargetScale,
                temperatureModel.GetScales());
        }
    }
}
