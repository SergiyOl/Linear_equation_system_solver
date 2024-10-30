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
        Label[,] inputLabelReferences = new Label[0, 0];

        int pageIndex = 0;
        List<List<Control>> resultReferences = new List<List<Control>>();



        public Form1()
        {
            InitializeComponent();
            /*button_previous.Enabled = false;
            button_previous.Hide();
            button_next.Hide();
            button_backToMenu.Hide();*/

            CreateInputs();
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
            foreach (var item in inputLabelReferences)
            {
                this.Controls.Remove(item);
            }
            // Створення масивів для референсів
            inputReferences = new TextBox[Int32.Parse(textBox_varAmount.Text), Int32.Parse(textBox_varAmount.Text) + 1];
            inputLabelReferences = new Label[Int32.Parse(textBox_varAmount.Text), Int32.Parse(textBox_varAmount.Text)];
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
                            Text = $"X{j + 1} + "
                        };
                        this.Controls.Add(label);
                        inputLabelReferences[i, j] = label;
                    }
                    else
                    {
                        Label label = new Label
                        {
                            AutoSize = true,
                            Location = new Point(cordX + 55, cordY + 3),
                            Name = "label",
                            Size = new Size(20, 12),
                            Text = $"X{j + 1} = "
                        };
                        this.Controls.Add(label);
                        inputLabelReferences[i, j] = label;
                    }

                    cordX += 95;
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

        private void button_calculate_Click(object sender, EventArgs e)
        {
            // Збір даних необхідних для обчислення
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
                        if (!double.TryParse(inputReferences[i, j].Text, out system[i, j]))
                        {
                            MessageBox.Show("Поля вводу чисел системи приймають лише числові значення (дробові числа розділяються комою)", "Неправильно введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            double approx;
            if (!double.TryParse(textBox_approx.Text, out approx))
            {
                MessageBox.Show("Поле наближення приймає лише числові значення (дробові числа розділяються комою)", "Неправильно введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isGaussSeidelMethod = radioButton_isGaussSeidelMethodTrue.Checked;
            
            // Вимикаємо кнопку
            button_calculate.Enabled = false;
            button_calculate.Text = "Обчислюємо...";
            // Записуємо дані у систему та обчислюємо
            equation = new LE_System(system, approx, isGaussSeidelMethod);
            // Вмикаємо кнопку
            button_calculate.Enabled = true;
            button_calculate.Text = "Обчислити";
            // Перевірка можливості виконання
            if (equation.isSolvable)
                ShowEquation();
            else
                MessageBox.Show("Система із поданими значеннями немає рішення", "Система немає рішення", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ShowEquation()
        {
            // Приховування меню
            Control[] menuReferences = { groupBox_isGaussSeidelMethod, button_calculate,
                                        label1, label2, label3, label4, label5,
                                        textBox_approx, textBox_varAmount, button_varAmountApply };
            foreach (var item in menuReferences)
            {
                item.Hide();
            }
            foreach (var item in inputReferences)
            {
                item.Hide();
            }
            foreach (var item in inputLabelReferences)
            {
                item.Hide();
            }
            // Виведення керування сторінкою результатів
            Control[] resultControlReferences = { button_previous, button_next, button_backToMenu};
            foreach (var item in resultControlReferences)
            {
                item.Show();
            }
        }

        void CreateResultPages()
        {

        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            foreach (var item in resultReferences.ElementAt(pageIndex))
                item.Hide();
            pageIndex--;
            foreach (var item in resultReferences.ElementAt(pageIndex))
                item.Show();

            button_next.Enabled = true;
            if (pageIndex == 0)
                button_previous.Enabled = false;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            foreach (var item in resultReferences.ElementAt(pageIndex))
                item.Hide();
            pageIndex++;
            foreach (var item in resultReferences.ElementAt(pageIndex))
                item.Show();

            button_previous.Enabled = true;
            if (pageIndex == resultReferences.Count - 1)
                button_next.Enabled = false;
        }

        private void button_backToMenu_Click(object sender, EventArgs e)
        {
            // Приховування керування сторінкою результатів
            Control[] resultControlReferences = { button_previous, button_next, button_backToMenu};
            foreach (var item in resultControlReferences)
            {
                item.Hide();
            }
            // Приховування результатів
            foreach (var list in resultReferences)
                foreach (var item in list)
                {
                    this.Controls.Remove(item);
                }
            // Виведення меню
            Control[] menuReferences = { groupBox_isGaussSeidelMethod, button_calculate,
                                        label1, label2, label3, label4, label5,
                                        textBox_approx, textBox_varAmount, button_varAmountApply };
            foreach (var item in menuReferences)
            {
                item.Show();
            }
            foreach (var item in inputReferences)
            {
                item.Show();
            }
            foreach (var item in inputLabelReferences)
            {
                item.Show();
            }
        }
    }
}
