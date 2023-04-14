using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask
{
    public partial class MainWindow : Form
    {
        private GuiView view;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            sourceTemperatureUom.Items.AddRange(new string[] { "°C", "°F", "°K" });
            sourceTemperatureUom.Text = "°C";

            targetTemperatureUom.Items.AddRange(new string[] { "°C", "°F", "°K" });
            targetTemperatureUom.Text = "°K";

            sourceTemperature.Text = "0.0";

            //targetTemperature.Text = sourceTemperature.Text;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Button clicked!", "Info", MessageBoxButtons.OK);
            //targetTemperature.Text = "qwer";
            //targetTemperature = sourceTemperature;            

            //string sourceTemperatureText = sourceTemperature.Text;

            //try
            //{
            //    double sourceTemperature = Convert.ToDouble(sourceTemperatureText);
            //    targetTemperature.Text = TemperatureController.ConvertTemperature(sourceTemperature);                

            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("Temperature must be a number!", "Error", MessageBoxButtons.OK);
            //}



        }

        private void sourceTemperature_TextChanged(object sender, EventArgs e)
        {
            //targetTemperature.Text = sourceTemperature.Text + "12";

        }
    }
}
