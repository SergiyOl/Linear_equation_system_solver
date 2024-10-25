using System;
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
        //public static double[,] arr1 = { { 5, -1, -1, 10 }, { 1, 4, -2, 8 }, { 4, 2, 7, 14 } };
        //LE_System equation = new LE_System(arr1, 0.001, true);

        LE_System equation;

        TextBox[,] inputReferences = new TextBox[0, 0];
        Label[,] labelReferences = new Label[0, 0];


        public Form1()
        {
            InitializeComponent();
            CreateInputs();
            ShowEquation();
        }

        private void button_varAmountApply_Click(object sender, EventArgs e)
        {
            // Перевірка на правильність вводу даних
            try
            {
                Int32.Parse(textBox_varAmount.Text);
            }
            catch
            {
                MessageBox.Show("Поле приймає лише цілі числові значення із мінімальним значенням 3", "Неправильно введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Int32.Parse(textBox_varAmount.Text) < 3)
            {
                MessageBox.Show("Поле приймає лише цілі числові значення із мінімальним значенням 3", "Неправильно введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Створення полів введення
            CreateInputs();
        }

        // Створення полів введення
        void CreateInputs()
        {
            // Початкове розміщення поля введення
            const int cordXStart = 50;
            const int cordYStart = 130;
            // Очищення референсів
            foreach (var item in inputReferences)
            {
                this.Controls.Remove(item);
            }
            foreach (var item in labelReferences)
            {
                this.Controls.Remove(item);
            }
            // Створення масивів для референсів
            inputReferences = new TextBox[Int32.Parse(textBox_varAmount.Text), Int32.Parse(textBox_varAmount.Text) + 1];
            labelReferences = new Label[Int32.Parse(textBox_varAmount.Text), Int32.Parse(textBox_varAmount.Text)];
            // Створення полів введення
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
                    inputReferences[i, j] = textBox;

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
                        labelReferences[i, j] = label;
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
                        labelReferences[i, j] = label;
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
                inputReferences[i, inputReferences.GetLength(1) - 1] = textBoxResult;

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

        private void button_calculate_Click(object sender, EventArgs e)
        {
            double[,] system = new double[inputReferences.GetLength(0), inputReferences.GetLength(1)];
            for (int i = 0; i < inputReferences.GetLength(0); i++)
            {
                for (int j = 0; j < inputReferences.GetLength(1); j++)
                {
                    if (inputReferences[i, j].Text == "")
                    {
                        system[i, j] = 0;
                    }
                    else
                    {
                        double.TryParse(inputReferences[i, j].Text, out system[i, j]);
                    }
                }
            }

            double approx;
            if (double.TryParse(textBox_approx.Text, out approx))
            {
                MessageBox.Show("Поле наближення приймає лише числові значення (дробові числа розділяються крапкою)", "Неправильно введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isGaussSeidelMethod = radioButton_isGaussSeidelMethodTrue.Checked;

            equation = new LE_System(system, approx, isGaussSeidelMethod);
        }
    }
}
