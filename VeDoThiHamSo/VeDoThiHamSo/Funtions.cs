using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeDoThiHamSo
{
    class Funtions
    {
        public double a;
        public double b;
        public double c;
        public double d;
        public Funtions()
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0;
        }
        public Funtions(double a1, double b1, double c1, double d1)
        {
            a = a1;
            b = b1;
            c = c1;
            d = d1;
        }
        public double f(double x)
        {
            return (a * x + b);
            //return (a * (Math.Pow(x, 2)) + b * x + c);
            //return (a * (Math.Pow(x, 3)) + b * (Math.Pow(x, 2)) + c * x + d);
            //return ((a * x + b) / (c * x + d));

        }
    }
}
