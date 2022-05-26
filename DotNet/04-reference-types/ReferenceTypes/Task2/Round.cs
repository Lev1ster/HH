using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Round
    {
        public int CenterX
        {
            get;
        }
        public int CenterY
        {
            get;
        }
        private double _radius;
        public double Radius
        {
            get
            {
                if (_radius != 0)
                    return _radius;
                else
                    throw new Exception("Unable to get the value");
            }
            set
            {
                if (_radius < 0)
                {
                    throw new Exception("There is no such value for the radius");
                }
                else
                {
                    _radius = value;
                }
            }
        }

        public Round(int x, int y, double radius)
        {
			
            CenterX = x;
            CenterY = y;
            Radius = radius;
        }

        public virtual double Lenght()
        {
            return 2 * Math.PI * Radius;
        }

        public virtual double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
