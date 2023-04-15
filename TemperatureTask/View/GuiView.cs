using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;

namespace TemperatureTask.View
{
    public class GuiView : IView
    {
        private readonly TemperatureController controller;

        private TemperatureModel temperatureModel;

        private MainWindow mainWindow;

        public GuiView(TemperatureController controller, TemperatureModel temperatureModel)
        {
            this.controller = controller;
            this.temperatureModel = temperatureModel;
        }

        public void Start()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindow = new MainWindow(controller);
            Application.Run(mainWindow);

            UpdateAllFields(temperatureModel.SourceTemperature,
                temperatureModel.SourceTemperatureUnit,
                temperatureModel.TargetTemperature,
                temperatureModel.TargetTemperatureUnit,
                new[] { "°C", "°F", "°K" });
        }

        public void UpdateTargetTemperature(double targetTenperature)
        {
            mainWindow.UpdateTargetTemperature(targetTenperature);
        }

        public void ShowError(string message)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllFields(double sourceTemperature, string sourceTemperatureUnit, double targetTemperature, string targetTemperatureUnit, string[] Units)
        {
            mainWindow.UpdateAllFields(sourceTemperature, sourceTemperatureUnit, targetTemperature, targetTemperatureUnit, Units);
        }
    }
}
