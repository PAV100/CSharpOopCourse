using System;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;

namespace TemperatureTask.View
{
    public class GuiView : IView
    {
        private readonly TemperatureController controller;        

        private MainWindow mainWindow;

        public GuiView(TemperatureController controller)
        {
            this.controller = controller;            
        }

        public void Start()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindow = new MainWindow(controller);
            Application.Run(mainWindow);
        }

        public void UpdateTargetTemperature(double targetTenperature)
        {
            mainWindow.UpdateTargetTemperature(Math.Round(targetTenperature, 2, MidpointRounding.AwayFromZero));
        }

        public void UpdateAllFields(double sourceTemperature, string sourceTemperatureUnit, double targetTemperature, string targetTemperatureUnit, string[] Units)
        {
            mainWindow.UpdateAllFields(sourceTemperature, sourceTemperatureUnit, targetTemperature, targetTemperatureUnit, Units);
        }
    }
}
