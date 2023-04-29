using System.Collections.Generic;
using TemperatureTask.Model;

namespace TemperatureTask.View
{
    public interface IView
    {
        void Start();

        void UpdateTargetTemperature(double temperature);

        void UpdateAllFields(
            double sourceTemperature,
            TemperatureScale sourceScale,
            double targetTemperature,
            TemperatureScale targetScale,
            List<TemperatureScale> scales);
    }
}
