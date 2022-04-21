using System;

namespace Figures
{
    public static class FindAreaClass
    {
        public static double FindAreaTriangle(int a, int b, int c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Triangle not exists");

            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static double FindAreaCircle(int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius <= 0");

            return Math.PI * radius * radius;
        }
    }
}
