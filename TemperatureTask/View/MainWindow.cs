using System;
using System.Windows.Forms;
using TemperatureTask.Controller;

namespace TemperatureTask
{
    public partial class MainWindow : Form
    {
        private readonly TemperatureController controller;

        public MainWindow(TemperatureController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            controller.LoadValuesToFields();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.ConvertTemperature(sourceTemperature.Text, sourceTemperatureUnit.Text, targetTemperatureUnit.Text);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Unit(s) of measure is not provided or incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Temperature value must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Temperature must be greater than absolute zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sourceTemperature.Focus();
            sourceTemperature.Select(0, sourceTemperature.Text.Length);
        }

        public void UpdateTargetTemperature(double targetTenperature)
        {
            targetTemperature.Text = targetTenperature.ToString();

            targetTemperature.Select();
            targetTemperature.Copy();
        }

        public void UpdateAllFields(double sourceTemperature, string sourceTemperatureUnit, double targetTemperature, string targetTemperatureUnit, string[] Units)
        {
            this.sourceTemperatureUnit.Items.AddRange(Units);
            this.targetTemperatureUnit.Items.AddRange(Units);

            this.sourceTemperature.Text = sourceTemperature.ToString();
            this.sourceTemperatureUnit.Text = sourceTemperatureUnit;
            this.targetTemperature.Text = targetTemperature.ToString();
            this.targetTemperatureUnit.Text = targetTemperatureUnit;

            this.targetTemperature.Select();
            this.targetTemperature.Copy();
            this.sourceTemperature.Select();
        }
    }
}
