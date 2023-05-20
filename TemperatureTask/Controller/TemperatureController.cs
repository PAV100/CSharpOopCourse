using System;
using System.Diagnostics.CodeAnalysis;
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
            CheckViewForNull(view);

            if (sourceScale is null)
            {
                throw new ArgumentNullException(nameof(sourceScale), "SourceScale must not be null");
            }

            if (targetScale is null)
            {
                throw new ArgumentNullException(nameof(targetScale), "TargetScale must not be null");
            }

            double targetTemperature = temperatureModel.ConvertTemperature(sourceTemperature, sourceScale, targetScale); // Throws ArgumentOutOfRangeException Exception                       

            view.UpdateTargetTemperature(targetTemperature);
        }

        public void LoadValuesToFields()
        {
            CheckViewForNull(view);

            view.UpdateAllFields(
                temperatureModel.SourceTemperature,
                temperatureModel.SourceScale,
                temperatureModel.TargetTemperature,
                temperatureModel.TargetScale,
                temperatureModel.GetScales());
        }

        private static void CheckViewForNull([NotNull] IView? view)
        {
            if (view is null)
            {
                throw new InvalidOperationException("View is null, but it must contain a not-null reference to created View object");
            }
        }
    }
}
