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
    public class LE_System
    {
        public double[,] system_initial;
        public double[,] system;
        public double target_approx;
        public List<Iteration> iterations = new List<Iteration>();
        public bool IsGaussSeidelMethod;

        public LE_System(double[,] system, double target_approx, bool IsGaussSeidelMethod)
        {
            this.system_initial = system;
            this.target_approx = target_approx;
            this.IsGaussSeidelMethod = IsGaussSeidelMethod;
        }

        void SolveEquation()
        {

        }

        // Перевірка умов збіжності ітераційного процесу
        bool CheckEquation()
        {
            // Масив індексів найбільших чисел в рядах
            int[] indexArr = new int[system_initial.GetLength(0)];
            // Знаходження найбільших чисел в рядах
            for (int i = 0; i < system_initial.GetLength(1); i++)
            {
                // Відбір всіх чисел біля невідомих
                double[] line = Enumerable.Range(0, system_initial.GetLength(0))
                                                .Select(x => system_initial[i, x]).ToArray();
                // Знаходження індексу найбільшого числа
                double maxValue = line.Max();
                indexArr[i] = line.ToList().IndexOf(maxValue);
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
    }
}

