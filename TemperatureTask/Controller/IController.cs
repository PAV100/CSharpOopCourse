using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Controller
{
    public interface IController
    {
        void SetView(IView view);

        void ConvertTemperature(double sourceTemperature, TemperatureScale sourceScale, TemperatureScale targetScale);

        void LoadValuesToFields();
    }
}
