using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TemperatureTask.Model
{
    public class TemperatureModel : IModel
    {
        private readonly List<TemperatureScale> temperatureScales;

        public TemperatureScale SourceScale { get; private set; }

        public TemperatureScale TargetScale { get; private set; }

        public double SourceTemperature { get; private set; }

        public double TargetTemperature { get; private set; }

        public TemperatureModel(List<TemperatureScale> temperatureScales, double initialSourceTemperature = 0)
        {
            if (temperatureScales is null)
            {
                throw new ArgumentNullException(nameof(temperatureScales), "TemperatureScales must not be null");
            }

            if (temperatureScales.Count == 0)
            {
                throw new ArgumentException("TemperatureScales must contain at least one scale", nameof(temperatureScales));
            }

            this.temperatureScales = new(temperatureScales);

            int sourceScaleIndex = 0;
            int targetScaleIndex = this.temperatureScales.Count == 1 ? 0 : 1;

            ConvertTemperature(initialSourceTemperature, this.temperatureScales[sourceScaleIndex], this.temperatureScales[targetScaleIndex]);
        }

        [MemberNotNull(nameof(SourceScale), nameof(TargetScale))]
        public double ConvertTemperature(double sourceTemperature, TemperatureScale sourceScale, TemperatureScale targetScale)
        {
            if (sourceScale is null)
            {
                throw new ArgumentNullException(nameof(sourceScale), "SourceScale must not be null");
            }

            if (targetScale is null)
            {
                throw new ArgumentNullException(nameof(targetScale), "TargetScale must not be null");
            }

            if (!temperatureScales.Contains(sourceScale))
            {
                throw new ArgumentException("Scales not defined in the model are not allowed", nameof(sourceScale));
            }

            if (!temperatureScales.Contains(targetScale))
            {
                throw new ArgumentException("Scales not defined in the model are not allowed", nameof(targetScale));
            }

            double kelvinTemperature = sourceScale.ToKelvin(sourceTemperature);

            if (kelvinTemperature < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(sourceTemperature),
                    $"Source temperature is {sourceTemperature} {sourceScale.Unit} = {kelvinTemperature} °K. It must be greater than absolute zero 0 °K");
            }

            SourceScale = sourceScale;
            TargetScale = targetScale;

            SourceTemperature = sourceTemperature;
            TargetTemperature = TargetScale.FromKelvin(kelvinTemperature);

            return TargetTemperature;
        }

        public List<TemperatureScale> GetScales()
        {
            return temperatureScales;
        }
    }
}
