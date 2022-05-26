using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Triangle
    {
        private double a;
        private double b;
        private double c;
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (!(value + B > C && C + B > value && value + C > B) || value <= 0)
                    throw new Exception("Invalid parameters triangle");
                else
                {
                    a = value;
                }
            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (!(A + value > C && C + value > A && A + C > value) || value <= 0)
                    throw new Exception("Invalid parameters triangle");
                else
                {
                    b = value;
                }
            }
        }
        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if (!(A + B > value && value + B > A && A + value > B) || value <= 0)
                    throw new Exception("Invalid parameters triangle");
                else
                {
                    c = value;
                }
            }
        }
        public double AreaTriangle()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public Triangle(double a, double b, double c)
        {
            if (a + b > c && c + b > a && a + c > b)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                throw new Exception("Invalid parameters triangle");
            }
        }
    }
}
