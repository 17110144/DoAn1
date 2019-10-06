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
        public double w;

        public int mess;
        public delegate void SendMessage(string Message);
        public SendMessage Sender;
        public Funtions()
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            w = 0;
            Sender = new SendMessage(GetMessage);

        }
        private void GetMessage(string Message)
        {
            this.mess = Convert.ToInt32(Message);
        }
        public Funtions(double a1)
        {
            a = a1;
        }
        public Funtions(double a1, double w1)
        {
            a = a1;
            w = w1;
        }
        public Funtions(double a1, double b1, double c1)
        {
            a = a1;
            b = b1;
            c = c1;
        }

        public Funtions(double a1, double b1, double c1, double d1)
        {
            a = a1;
            b = b1;
            c = c1;
            d = d1;
        }
        public void InPut(double a1, double b1, double c1, double d1)
        {
            a = a1;
            b = b1;
            c = c1;
            d = d1;
        }
        public double f(double x)
        {
            double fx = -1;
            switch (mess)
            {
                case 2:
                    {
                        fx = (a * (Math.Pow(x, 2)) + b * x + c);
                    }
                    break;
                case 3:
                    {
                        fx = (a * (Math.Pow(x, 3)) + b * (Math.Pow(x, 2)) + c * x + d);
                    }
                    break;
                case 4:
                    {
                        fx = ((a * x + b) / (c * x + d));
                    }
                    break;
                case 6:
                    {

                    }
                    break;
                case 7:
                    {
                        fx = (a / x);
                    }
                    break;
                case 8:
                    {
                        fx = (a * (Math.Sin(b * x)));
                    }
                    break;
                case 9:
                    {
                        fx = (a * (Math.Tan(b * x)));
                    }
                    break;
                case 10:
                    {
                        fx = (Math.Log(x, a));
                    }
                    break;
                case 11:
                    {
                        fx = (Math.Pow(a, x));
                    }
                    break;

                default:
                    break;
            }
            return fx;
        }
    }
}
