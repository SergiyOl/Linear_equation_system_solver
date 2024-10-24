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
        public static double[,] arr1 = { { 5, -1, -1, 10 }, { 1, 4, -2, 8 }, { 4, 2, 7, 14 } };
        LE_System equation = new LE_System(arr1, 0.001);


        public Form1()
        {
            InitializeComponent();
            SolveEquation();
        }


        void SolveEquation()
        {
            // Перевірка умов збіжності ітераційного процесу
            if (!CheckEquation())
            {
                label1.Text = "Рівняння не відповідає умовам ітераційного процесу";
            }
            // Ітерування (0 ітерація)
            IterateZero();
            // Ітерування (решта ітерацій)
            while(true)
            {
                Iterate();
                if (equation.iterations.Last().approx[0] < equation.target_approx &&
                    equation.iterations.Last().approx[1] < equation.target_approx &&
                    equation.iterations.Last().approx[2] < equation.target_approx )
                {
                    break;
                }
            }
            // Output to labels (TO DELETE)
            label1.Text = string.Join("   ", equation.iterations.ElementAt(0).variables);
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
            label12.Text = string.Join("   ", equation.iterations.ElementAt(5).approx);
        }

        // Перевірка умов збіжності ітераційного процесу
        // TO DO: make it possible to change order of equation
        bool CheckEquation()
        {
            for (int i = 0; i < equation.system.GetLength(0); i++)
            {
                double num1 = Abs(equation.system[i,i]); 
                double num2 = 0;
                for (int j = 0; j < equation.system.GetLength(0); j++)
                {
                    if (j != i)
                    {
                        num2 += Abs(equation.system[i, j]);
                    }
                }
                if (num1 <= num2)
                {
                    return false;
                }
            }
            return true;
        }

        // Ітерування (0 ітерація)
        void IterateZero()
        {
            double[] vararr = new double[equation.system.GetLength(0)];
            double[] apparr = Enumerable.Repeat(0, equation.system.GetLength(0)).Select(x => (double)x).ToArray(); //Заповнення значенням 0

            for (int i = 0; i < equation.system.GetLength(0); i++)
            {
                vararr[i] = equation.system[i, equation.system.GetLength(1)-1] / equation.system[i, i];
            }
            equation.iterations.Add(new Iteration(vararr, apparr));
        }

        // Ітерування (решта ітерацій)
        // TO DO: change from constant 3 to variable amount of variables
        void Iterate()
        {
            double[] vararr = new double[equation.system.GetLength(0)];
            double[] apparr = new double[equation.system.GetLength(0)]; //Заповнення значенням 0

            // Знаходження змінних (Метод Зейзеля)
            // TO DO
            vararr[0] = ( (-equation.system[0, 1] * equation.iterations.Last().variables[1]) +
                          (-equation.system[0, 2] * equation.iterations.Last().variables[2]) +
                          (equation.system[0, equation.system.GetLength(1) - 1])) /
                          (equation.system[0, 0]);
            vararr[1] = ( (-equation.system[1, 0] * vararr[0]) +
                          (-equation.system[1, 2] * equation.iterations.Last().variables[2]) +
                          (equation.system[1, equation.system.GetLength(1) - 1])) /
                          (equation.system[1, 1]);
            vararr[2] = ( (-equation.system[2, 0] * vararr[0]) +
                          (-equation.system[2, 1] * vararr[1]) +
                          (equation.system[2, equation.system.GetLength(1) - 1])) /
                          (equation.system[2, 2]);

            /* 
            // Знаходження змінних (Метод ітерацій)
            // TO DO
            vararr[0] = ( (-equation.system[0, 1] * equation.iterations.Last().variables[1]) +
                          (-equation.system[0, 2] * equation.iterations.Last().variables[2]) +
                          (equation.system[0, equation.system.GetLength(1) - 1])) /
                          (equation.system[0, 0]);
            vararr[1] = ( (-equation.system[1, 0] * equation.iterations.Last().variables[0]) +
                          (-equation.system[1, 2] * equation.iterations.Last().variables[2]) +
                          (equation.system[1, equation.system.GetLength(1) - 1])) /
                          (equation.system[1, 1]);
            vararr[2] = ( (-equation.system[2, 0] * equation.iterations.Last().variables[0]) +
                          (-equation.system[2, 1] * equation.iterations.Last().variables[1]) +
                          (equation.system[2, equation.system.GetLength(1) - 1])) /
                          (equation.system[2, 2]);
            */

            // Знаходження наближення
            for (int i = 0; i < equation.system.GetLength(0); i++)
            {
                apparr[i] = Abs(vararr[i] - equation.iterations.Last().variables[i]) / Abs(vararr[i]);
            }
            // Запис ітерації
            equation.iterations.Add(new Iteration(vararr, apparr));
        }
    }
}
