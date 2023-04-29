using System;
using TemperatureTask.Model;
using TemperatureTask.View;
using TemperatureTask.Controller;

namespace TemperatureTask
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TemperatureModel model = new(new()
            {
                { new(0, "Celsius scale", "°C", d => d + 273.15, d => d - 273.15) },
                { new(1, "Kelvin scale", "°K", d => d, d => d) },
                { new(2, "Fahrenheit scale", "°F", d => 5.0 / 9.0 * (d - 32.0) + 273.15, d => 9.0 / 5.0 * (d - 273.15) + 32.0) }
            });

            TemperatureController controller = new(model);
            GuiView view = new(controller);
            controller.SetView(view);

            view.Start();
        }
    }
}
