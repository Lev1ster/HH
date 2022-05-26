using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Rectangle : Figure
    {
        public Point2D Dot1 { get; private set; }
        public Point2D Dot2 { get; private set; }
        private double a;
        private double b;


        public Rectangle(Point2D dot1, Point2D dot2)
        {
            Dot1 = dot1;
            Dot2 = dot2;
            a = Math.Abs(dot1.X - dot2.X);
            b = Math.Abs(dot1.Y - dot2.Y);
        }

        public double Perimeter()
        {
            return (a + b) * 2;
        }

        public double Area()
        {
            return a * b;
        }

        public override void Draw(IPrint print)
        {
            print.Print("Type figure: \tRectangle");
            print.Print($"Perimeter: \t{Perimeter():.##}");
            print.Print($"Area: \t\t{Area():.##}");
            print.Print($"Coords dots: \tDotFirstLeft: ({Dot1.X};{Dot1.Y})\n" +
                $"\t\tDotLastRight: ({Dot2.X};{Dot2.Y})");
        }
    }
}
