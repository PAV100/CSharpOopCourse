using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;

namespace TemperatureTask.View
{
    public class GuiView : IView
    {
        private readonly MainWindow mainWindow;

        public GuiView(IController controller)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindow = new MainWindow(controller);
        }

        public void Start()
        {
            Application.Run(mainWindow);
        }

        public void UpdateTargetTemperature(double targetTemperature)
        {
            mainWindow.UpdateTargetTemperature(Math.Round(targetTemperature, 2, MidpointRounding.AwayFromZero));
        }

        public void UpdateAllFields(
            double sourceTemperature,
            TemperatureScale sourceScale,
            double targetTemperature,
            TemperatureScale targetScale,
            List<TemperatureScale> scales)
        {
            mainWindow.UpdateAllFields(
                sourceTemperature,
                sourceScale,
                targetTemperature,
                targetScale,
                scales);
        }
    }
}
