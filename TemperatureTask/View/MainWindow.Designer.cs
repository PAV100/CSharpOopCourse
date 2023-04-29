namespace TemperatureTask
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sourceTemperature = new System.Windows.Forms.TextBox();
            this.sourceTemperatureUnit = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.targetTemperature = new System.Windows.Forms.TextBox();
            this.targetTemperatureUnit = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.convertButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 55);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source temperature";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.sourceTemperature);
            this.flowLayoutPanel1.Controls.Add(this.sourceTemperatureUnit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(134, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // sourceTemperature
            // 
            this.sourceTemperature.Location = new System.Drawing.Point(3, 3);
            this.sourceTemperature.Name = "sourceTemperature";
            this.sourceTemperature.Size = new System.Drawing.Size(70, 23);
            this.sourceTemperature.TabIndex = 0;
            this.sourceTemperature.TextChanged += new System.EventHandler(this.sourceTemperature_TextChanged);
            this.sourceTemperature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sourceTemperature_KeyDown);
            // 
            // sourceTemperatureUnit
            // 
            this.sourceTemperatureUnit.FormattingEnabled = true;
            this.sourceTemperatureUnit.Location = new System.Drawing.Point(79, 3);
            this.sourceTemperatureUnit.Name = "sourceTemperatureUnit";
            this.sourceTemperatureUnit.Size = new System.Drawing.Size(52, 23);
            this.sourceTemperatureUnit.TabIndex = 1;
            this.sourceTemperatureUnit.TextChanged += new System.EventHandler(this.sourceTemperatureUnit_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(221, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target temperature";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.targetTemperature);
            this.flowLayoutPanel2.Controls.Add(this.targetTemperatureUnit);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(134, 27);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // targetTemperature
            // 
            this.targetTemperature.Location = new System.Drawing.Point(3, 3);
            this.targetTemperature.Name = "targetTemperature";
            this.targetTemperature.ReadOnly = true;
            this.targetTemperature.Size = new System.Drawing.Size(70, 23);
            this.targetTemperature.TabIndex = 3;
            // 
            // targetTemperatureUnit
            // 
            this.targetTemperatureUnit.FormattingEnabled = true;
            this.targetTemperatureUnit.Location = new System.Drawing.Point(79, 3);
            this.targetTemperatureUnit.Name = "targetTemperatureUnit";
            this.targetTemperatureUnit.Size = new System.Drawing.Size(52, 23);
            this.targetTemperatureUnit.TabIndex = 4;
            this.targetTemperatureUnit.TextChanged += new System.EventHandler(this.targetTemperatureUnit_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.convertButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(149, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 49);
            this.panel1.TabIndex = 1;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(3, 22);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(60, 23);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 55);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(380, 94);
            this.MinimumSize = new System.Drawing.Size(265, 94);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature Converter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox sourceTemperature;
        private System.Windows.Forms.ComboBox sourceTemperatureUnit;
        private System.Windows.Forms.TextBox targetTemperature;
        private System.Windows.Forms.ComboBox targetTemperatureUnit;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
    }
}
