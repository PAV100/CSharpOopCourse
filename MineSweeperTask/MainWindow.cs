using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperTask
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.SuspendLayout();

            this.tableLayoutPanelGameField = new();

            this.tableLayoutPanelGameField.ColumnCount = 10;
            this.tableLayoutPanelGameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelGameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelGameField.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGameField.Name = "tableLayoutPanel1";
            this.tableLayoutPanelGameField.RowCount = 10;
            this.tableLayoutPanelGameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelGameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelGameField.Size = new System.Drawing.Size(441, 100);
            this.tableLayoutPanelGameField.TabIndex = 0;





            this.ResumeLayout(false);
        }
    }
}
