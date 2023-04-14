using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureTask.Controller;

namespace TemperatureTask.View
{
    public class GuiView : IView
    {
        private readonly TemperatureController controller;

        //private MainWindow mainWindow;

        public GuiView(TemperatureController controller)
        {
            this.controller = controller;
        }        

        public void Start()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //mainWindow = new MainWindow();
            Application.Run(new MainWindow());            
        }

        public void UpdateTargetTemperature(double tenperature)
        {
            throw new NotImplementedException();
        }

        public void ShowError(string message)
        {
            throw new NotImplementedException();
        }
    }
}
