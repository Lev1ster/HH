using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Triangle : Figure
    {
        public Point2D Dot1 { get; private set; }
        public Point2D Dot2 { get; private set; }
        public Point2D Dot3 { get; private set; }

        private double A;
        private double B;
        private double C;

        public Triangle(Point2D dot1, Point2D dot2, Point2D dot3)
        {
            Dot1 = dot1;
            Dot2 = dot2;
            Dot3 = dot3;

            A = Line.LenghtLine(dot1, dot2);
            B = Line.LenghtLine(dot2, dot3);
            C = Line.LenghtLine(dot3, dot1);

            if (A + B < C | A + C < B | B + C < A)
            {
                throw new Exception("Can't create triangle");
            }
        }


        public double Perimeter()
        {
            return A + B + C;
        }


        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
        public override void Draw(IPrint print)
        {
            print.Print("Type figure: \tTriangle");
            print.Print($"Perimeter: \t{Perimeter():.##}");
            print.Print($"Area: \t\t{Area():.##}");
            print.Print($"Coords dots: \tDot1: ({Dot1.X};{Dot1.Y}) \n" +
                $"\t\tDot2: ({Dot2.X};{Dot2.Y})" +
                $"\n\t\tDot3: ({Dot3.X};{Dot3.Y})");
        }
    }
}
