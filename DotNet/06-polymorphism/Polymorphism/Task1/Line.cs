using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{

    class Line : Figure
    {
        public Point2D dot1 { get; private set; }
        public Point2D dot2 { get; private set; }

        public Line(Point2D dot1, Point2D dot2)
        {
            this.dot1 = dot1;
            this.dot2 = dot2;
        }

        public static double LenghtLine(Point2D dot1, Point2D dot2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(dot1.X - dot2.X), 2) + Math.Pow(Math.Abs(dot1.Y - dot2.Y), 2));
        }
        public override void Draw(IPrint print)
        {
            double lenght = Line.LenghtLine(dot1, dot2);

            print.Print("Type figure: \tLine");
            print.Print($"Lenght: \t{lenght:.##}");
            print.Print($"Coords dots: \tDot1: ({dot1.X};{dot1.Y})\n \t" +
                $"\tDot2: ({dot2.X};{dot2.Y})");
        }
    }
}
