using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;

namespace TemperatureTask.View
{
    public class GuiView : IView
    {
        private readonly IController controller;

        private MainWindow? mainWindow;

        public GuiView(IController controller)
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

        public void UpdateTargetTemperature(double targetTemperature)
        {
            //CheckMainWindowForNull();
            if (mainWindow is null)
            {
                throw new ArgumentNullException(nameof(mainWindow), "MainWindow must not be null");
            }

            mainWindow.UpdateTargetTemperature(Math.Round(targetTemperature, 2, MidpointRounding.AwayFromZero));
        }

        public void UpdateAllFields(
            double sourceTemperature,
            TemperatureScale sourceScale,
            double targetTemperature,
            TemperatureScale targetScale,
            List<TemperatureScale> scales)
        {
            //CheckMainWindowForNull();
            if (mainWindow is null)
            {
                throw new ArgumentNullException(nameof(mainWindow), "MainWindow must not be null");
            }

            mainWindow.UpdateAllFields(
                sourceTemperature,
                sourceScale,
                targetTemperature,
                targetScale,
                scales);
        }

        private void CheckMainWindowForNull()
        {
            if (mainWindow is null)
            {
                throw new ArgumentNullException(nameof(mainWindow), "MainWindow must not be null");
            }
        }
    }
}
