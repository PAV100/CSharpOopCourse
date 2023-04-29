using System.Collections.Generic;

namespace TemperatureTask.Model
{
    public interface IModel
    {
        TemperatureScale SourceScale { get; protected set; }

        TemperatureScale TargetScale { get; protected set; }

        double SourceTemperature { get; protected set; }

        double TargetTemperature { get; protected set; }

        double ConvertTemperature(double sourceTemperature, TemperatureScale sourceScale, TemperatureScale targetScale);

        List<TemperatureScale> GetScales();
    }
}
