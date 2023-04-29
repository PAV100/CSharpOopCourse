using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Controller;
using TemperatureTask.Model;

namespace TemperatureTask
{
    public partial class MainWindow : Form
    {
        private readonly IController controller;

        public MainWindow(IController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            controller.LoadValuesToFields();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            ConvertTemperature();
        }

        private void sourceTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConvertTemperature();
            }
        }

        private void sourceTemperature_TextChanged(object sender, EventArgs e)
        {
            this.targetTemperature.Text = "";
        }

        private void sourceTemperatureUnit_TextChanged(object sender, EventArgs e)
        {
            this.targetTemperature.Text = "";
        }

        private void targetTemperatureUnit_TextChanged(object sender, EventArgs e)
        {
            this.targetTemperature.Text = "";
        }

        public void UpdateTargetTemperature(double targetTemperature)
        {
            this.targetTemperature.Text = targetTemperature.ToString();

            this.targetTemperature.Select();
            this.targetTemperature.Copy();
        }

        public void UpdateAllFields(
            double sourceTemperature,
            TemperatureScale sourceScale,
            double targetTemperature,
            TemperatureScale targetScale,
            List<TemperatureScale> scales)
        {
            List<TemperatureScale> scalesCopyForSourceTemperature = new(scales);
            this.sourceTemperatureUnit.DataSource = scalesCopyForSourceTemperature;
            this.sourceTemperatureUnit.DisplayMember = "Unit";
            this.sourceTemperatureUnit.SelectedItem = sourceScale;

            List<TemperatureScale> scalesCopyForTargetTemperature = new(scales);
            this.targetTemperatureUnit.DataSource = scalesCopyForTargetTemperature;
            this.targetTemperatureUnit.DisplayMember = "Unit";
            this.targetTemperatureUnit.SelectedItem = targetScale;

            this.sourceTemperature.Text = sourceTemperature.ToString();

            this.targetTemperature.Text = targetTemperature.ToString();

            this.targetTemperature.Select();
            this.targetTemperature.Copy();
            this.sourceTemperature.Select();
        }

        public void ConvertTemperature()
        {
            try
            {
                controller.ConvertTemperature(
                    Convert.ToDouble(this.sourceTemperature.Text),
                    (TemperatureScale)sourceTemperatureUnit.SelectedItem,
                    (TemperatureScale)targetTemperatureUnit.SelectedItem);
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
    }
}
