using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            TemperatureModel model = new();

            TemperatureController controller = new(model);
            GuiView view = new(controller);
            controller.SetView(view);

            view.Start();
        }
    }
}
