using System;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Controller
{
    public class TemperatureController : IController
    {
        private readonly IModel temperatureModel;

        private IView? view;

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
                throw new ArgumentNullException(nameof(sourceScale), "SourceScale must not be null");
            }

            if (targetScale is null)
            {
                throw new ArgumentNullException(nameof(targetScale), "TargetScale must not be null");
            }

            double targetTemperature = temperatureModel.ConvertTemperature(sourceTemperature, sourceScale, targetScale); // Throws ArgumentOutOfRangeException Exception           

            //CheckViewForNull();
            if (view is null)
            {
                throw new ArgumentNullException(nameof(view), "View must not be null");
            }

            view.UpdateTargetTemperature(targetTemperature);
        }

        public void LoadValuesToFields()
        {
            //CheckViewForNull();
            if (view is null)
            {
                throw new ArgumentNullException(nameof(view), "View must not be null");
            }

            view.UpdateAllFields(
                temperatureModel.SourceTemperature,
                temperatureModel.SourceScale,
                temperatureModel.TargetTemperature,
                temperatureModel.TargetScale,
                temperatureModel.GetScales());
        }

        private void CheckViewForNull()
        {
            if (view is null)
            {
                throw new ArgumentNullException(nameof(view), "View must not be null");
            }
        }
    }
}
