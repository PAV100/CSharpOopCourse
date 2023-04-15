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

        private TemperatureController controller;

        public MainWindow(TemperatureController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }
        public void UpdateTargetTemperature(double targetTenperature)
        {
            targetTemperature.Text = targetTenperature.ToString();
        }

        public void UpdateAllFields(double sourceTemperature, string sourceTemperatureUnit, double targetTemperature, string targetTemperatureUnit, string[] Units)
        {
            this.sourceTemperature.Text = sourceTemperature.ToString();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //sourceTemperatureUnit.Items.AddRange(new string[] { "°C", "°F", "°K" });
            //sourceTemperatureUnit.Text = "°C";

            //targetTemperatureUnit.Items.AddRange(new string[] { "°C", "°F", "°K" });
            //targetTemperatureUnit.Text = "°K";

            //sourceTemperature.Text = "0";

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

            //controller.ConvertTemperature(sourceTemperature.Text, sourceTemperatureUnit.Text, targetTemperatureUnit.Text);

            try
            {
                controller.ConvertTemperature(sourceTemperature.Text, sourceTemperatureUnit.Text, targetTemperatureUnit.Text);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Not provided units of measure", "Error", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Temperature must be a number", "Error", MessageBoxButtons.OK);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Temperature must be > absolute zero", "Error", MessageBoxButtons.OK);
            }
        }

        private void sourceTemperature_TextChanged(object sender, EventArgs e)
        {
            //targetTemperature.Text = sourceTemperature.Text + "12";

        }
    }
}
