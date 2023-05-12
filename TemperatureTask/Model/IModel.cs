using System.Collections.Generic;

namespace TemperatureTask.Model
{
    public interface IModel
    {
        TemperatureScale SourceScale { get; }

        TemperatureScale TargetScale { get; }

        double SourceTemperature { get; }

        double TargetTemperature { get; }

        double ConvertTemperature(double sourceTemperature, TemperatureScale sourceScale, TemperatureScale targetScale);

        List<TemperatureScale> GetScales();
    }
}
