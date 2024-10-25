﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;


namespace Linear_equation_systems
{
    public partial class Form1 : Form
    {
        //public static double[,] arr1 = { { 20, 1, 1, 23 }, { 0.5, -5, 3, -6.5 }, { 2, -2, 10, 8 } };
        public static double[,] arr1 = { { 5, -1, -1, 10 }, { 1, 4, -2, 8 }, { 4, 2, 7, 14 } };
        LE_System equation = new LE_System(arr1, 0.001, true);


        public Form1()
        {
            InitializeComponent();
            CreateInputs();
            ShowEquation();
        }


        void CreateInputs()
        {
            const int cordXStart = 50;
            const int cordYStart = 130;

            int cordX = cordXStart;
            int cordY = cordYStart;
            for (int i = 0; i < Int32.Parse(textBox_varAmount.Text) ; i++)
            {
                for (int j = 0; j < Int32.Parse(textBox_varAmount.Text); j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Location = new Point(cordX, cordY),
                        Name = "textBox",
                        Size = new Size(50, 22)
                    };
                    this.Controls.Add(textBox);

                    if (j != Int32.Parse(textBox_varAmount.Text) - 1)
                    {
                        Label label = new Label
                        {
                            AutoSize = true,
                            Location = new Point(cordX + 55, cordY + 3),
                            Name = "label",
                            Size = new Size(20, 12),
                            Text = "X1 + "
                        };
                        this.Controls.Add(label);
                    }
                    else
                    {
                        Label label = new Label
                        {
                            AutoSize = true,
                            Location = new Point(cordX + 50, cordY + 3),
                            Name = "label",
                            Size = new Size(20, 12),
                            Text = "X1 = "
                        };
                        this.Controls.Add(label);
                    }

                    cordX += 90;
                }

                TextBox textBoxResult = new TextBox
                {
                    Location = new Point(cordX, cordY),
                    Name = "textBox",
                    Size = new Size(50, 22)
                };
                this.Controls.Add(textBoxResult);

                cordX = cordXStart;
                cordY += 30;
            }
        }

        void ShowEquation()
        {
            // Output to labels (TO DELETE)
            /*label1.Text = string.Join("   ", equation.iterations.ElementAt(0).variables);
            label2.Text = string.Join("   ", equation.iterations.ElementAt(1).variables);
            label3.Text = string.Join("   ", equation.iterations.ElementAt(2).variables);
            label4.Text = string.Join("   ", equation.iterations.ElementAt(3).variables);
            label5.Text = string.Join("   ", equation.iterations.ElementAt(4).variables);
            label6.Text = string.Join("   ", equation.iterations.ElementAt(5).variables);
            label7.Text = string.Join("   ", equation.iterations.ElementAt(0).approx);
            label8.Text = string.Join("   ", equation.iterations.ElementAt(1).approx);
            label9.Text = string.Join("   ", equation.iterations.ElementAt(2).approx);
            label10.Text = string.Join("   ", equation.iterations.ElementAt(3).approx);
            label11.Text = string.Join("   ", equation.iterations.ElementAt(4).approx);
            label12.Text = string.Join("   ", equation.iterations.ElementAt(5).approx);*/
        }
    }
}
