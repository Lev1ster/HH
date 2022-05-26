using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Circle : Figure
    {
        public Point2D DotCener { get; private set; }
        public double Radius { get; private set; }

        public Circle(Point2D center, double radius)
        {
            DotCener = center;
            this.Radius = radius;
            
            if (radius < 0)
            {
                throw new Exception("Can't create circle");
            }
        }

        public double LenghtCircle()
        {
            return 2 * Math.PI * Radius;
        }

        public double AreaCircle()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Draw(IPrint a)
        {
            a.Print("Type figure: \tCircle");
            a.Print($"LenghtCricle: \t{LenghtCircle():.##}");
            a.Print($"AreaCircle: \t{AreaCircle():.##}");
            a.Print($"Coords dots: \tDotCenter: ({DotCener.X};{DotCener.Y})");
        }
    }
}
