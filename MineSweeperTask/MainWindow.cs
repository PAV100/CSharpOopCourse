using MinesweeperTask.Model.Game;
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
        private System.Windows.Forms.Button[,] minefield;
        private System.Windows.Forms.Label[,] m1;
        private System.Windows.Forms.Label L;

        private MinesweeperModel model;

        public MainWindow(MinesweeperModel model)
        {
            this.model = model;

            InitializeComponent();

            this.SuspendLayout();

            this.minefield = new System.Windows.Forms.Button[20, 20];
            //this.m1 = new System.Windows.Forms.Label[20, 20];

            //this.L = new System.Windows.Forms.Label();
            //this.L = new Label();
            //this.L.BackColor = System.Drawing.Color.Red;
            ////this.L.BackColor = System.Drawing.SystemColors.Control;
            //this.L.Location = new System.Drawing.Point(100, 100);
            //this.L.Name = "label100";
            //this.L.Size = new System.Drawing.Size(36, 36);
            //this.L.TabIndex = 0;
            //this.L.Text = "label100";
            //this.Controls.Add(this.L);

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    this.minefield[i, j] = new Button();
                    this.minefield[i, j].Location = new System.Drawing.Point(j * 16, i * 16);
                    this.minefield[i, j].Name = "button" + "_" + i + "_" + j;
                    this.minefield[i, j].Size = new System.Drawing.Size(16, 16);
                    //this.minefield[i, j].TabIndex = i;
                    //this.minefield[i, j].Text = "button"+ "_" + i + "_" + j;
                    //this.minefield[i, j].UseVisualStyleBackColor = true;
                    this.minefield[i, j].FlatStyle = FlatStyle.Flat;
                    this.minefield[i, j].FlatAppearance.BorderSize = 1;
                    if (this.model.gamefield.minefield[0, 0].isMined == true)
                    {
                        this.minefield[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        this.minefield[i, j].BackColor = Color.Green;
                    }
                    this.Controls.Add(this.minefield[i, j]);

                    //this.m1[i, j] = new Label();
                    //this.m1[i, j].BackColor = System.Drawing.Color.Green;
                    ////this.m1[i, j].BackColor = System.Drawing.SystemColors.Control;
                    //this.m1[i, j].Location = new System.Drawing.Point(330 + j * 16, 000 + i * 16);
                    ////this.m1[i, j].Name = "label1" + i + "_" + j;
                    //this.m1[i, j].Size = new System.Drawing.Size(16, 16);
                    //this.m1[i, j].TabIndex = 0;
                    ////this.m1[i, j].Text = "label1" + i + "_" + j;
                    //this.Controls.Add(this.m1[i, j]);
                }
            }

            this.ResumeLayout(false);
            //this.PerformLayout();
        }
    }
}
