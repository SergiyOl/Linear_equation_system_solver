using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_equation_systems
{
    public class LE_System
    {
        public double[,] system;
        public double target_approx;
        public List<Iteration> iterations = new List<Iteration>();

        public LE_System(double[,] system, double target_approx)
        {
            this.system = system;
            this.target_approx = target_approx;
        }
    }
}

