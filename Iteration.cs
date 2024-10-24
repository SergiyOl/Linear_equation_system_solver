using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_equation_systems
{
    public class Iteration
    {
        public double[] variables;
        public double[] approx;

        public Iteration(double[] variables, double[] approx)
        {
            this.variables = variables;
            this.approx = approx;
        }
    }
}
