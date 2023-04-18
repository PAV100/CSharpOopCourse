namespace TemperatureTask.View
{
    internal interface IView
    {
        public void Start();

        public void UpdateTargetTemperature(double temperature);
    }
}
