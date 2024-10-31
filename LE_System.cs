using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static System.Math;

namespace Linear_equation_systems
{
    public class LE_System
    {
        public double[,] system_initial;
        public double[,] system;
        public double target_approx;
        public List<Iteration> iterations = new List<Iteration>();
        public bool isGaussSeidelMethod;
        public bool isSolvable;

        public LE_System(double[,] system, double target_approx, bool IsGaussSeidelMethod)
        {
            this.system_initial = system;
            this.target_approx = target_approx;
            this.isGaussSeidelMethod = IsGaussSeidelMethod;

            SolveEquation();
        }


        private void SolveEquation()
        {
            // Перевірка умов збіжності ітераційного процесу
            isSolvable = CheckEquation();
            if (!isSolvable)
                return;
            // Ітерування (0 ітерація)
            IterateZero();
            // Ітерування (решта ітерацій)
            while (true)
            {
                // Ітерування
                Iterate();
                // Перевірка наближення
                bool isSolved = true;
                for (int i = 0; i < system.GetLength(0); i++)
                    if (iterations.Last().approx[i] > target_approx)
                        isSolved = false;
                if (isSolved)
                    break;
            }
        }

        // Перевірка умов збіжності ітераційного процесу
        private bool CheckEquation()
        {
            // Масив індексів найбільших чисел в рядах
            int[] indexArr = new int[system_initial.GetLength(0)];
            // Знаходження найбільших чисел в рядах
            for (int i = 0; i < system_initial.GetLength(0); i++)
            {
                // Відбір всіх чисел біля невідомих
                double[] line = Enumerable.Range(0, system_initial.GetLength(0))
                                                .Select(x => system_initial[i, x]).ToArray();
                // Зведення всіх чисел до модуля
                for (int k = 0; k < line.GetLength(0); k++)
                    line[k] = Abs(line[k]);
                // Знаходження індексу найбільшого числа
                double maxValue = line.Max();
                indexArr[i] = line.ToList().IndexOf(maxValue);
                // Перевірка чи найбільше число більше суми модулів решти чисел
                double summ = 0;
                for (int n = 0; n < line.Length; n++)
                    if (n != line.ToList().IndexOf(maxValue))
                        summ += line[n];
                if (summ >= maxValue)
                    return false;
            }
            // Перевірка на неповторюваність значень в масиві
            bool isUnique = indexArr.ToList().Distinct().Count() == indexArr.Length;
            if (!isUnique)
                return false;
            // Зведення рівняння до розрахонкового вигляду
            system = new double[system_initial.GetLength(0), system_initial.GetLength(1)];
            for (int i = 0; i < system_initial.GetLength(0); i++)
                for (int j = 0; j < system_initial.GetLength(1); j++)
                    system[indexArr[i], j] = system_initial[i, j];
            return true;
        }

        // Ітерування (0 ітерація)
        private void IterateZero()
        {
            double[] vararr = new double[system.GetLength(0)];
            double[] apparr = Enumerable.Repeat(0, system.GetLength(0)).Select(x => (double)x).ToArray(); //Заповнення значенням 0

            for (int i = 0; i < system.GetLength(0); i++)
            {
                vararr[i] = system[i, system.GetLength(1) - 1] / system[i, i];
            }
            iterations.Add(new Iteration(vararr, apparr));
        }

        private void Iterate()
        {
            double[] varArr = new double[system.GetLength(0)];
            double[] approxArr = new double[system.GetLength(0)];

            // Знаходження змінних (Метод Зейделя) (Gauss-Seidel method)
            if (isGaussSeidelMethod)
            {
                for (int i = 0; i < system.GetLength(0); i++)
                {
                    double num = 0;

                    for (int j = 0; j < system.GetLength(0); j++)
                    {
                        if (j < i)
                        {
                            num += -system[i, j] * varArr[j];
                        }
                        if (j > i)
                        {
                            num += -system[i, j] * iterations.Last().variables[j];
                        }
                    }
                    num += system[i, system.GetLength(1) - 1];
                    num /= system[i, i];

                    varArr[i] = num;
                }
            }
            // Знаходження змінних (Метод ітерацій) (iterative method)
            else
            {
                for (int i = 0; i < system.GetLength(0); i++)
                {
                    double num = 0;

                    for (int j = 0; j < system.GetLength(0); j++)
                    {
                        if (j != i)
                        {
                            num += -system[i, j] * iterations.Last().variables[j];
                        }
                    }
                    num += system[i, system.GetLength(1) - 1];
                    num /= system[i, i];

                    varArr[i] = num;
                }
            }

            // Знаходження наближення
            for (int i = 0; i < system.GetLength(0); i++)
            {
                approxArr[i] = Abs(varArr[i] - iterations.Last().variables[i]) / Abs(varArr[i]);
            }
            // Запис ітерації
            iterations.Add(new Iteration(varArr, approxArr));
        }
    }
}

