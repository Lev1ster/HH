using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Ring : Round
    {
        private double _radiusOuter;
       public double RadiusOuter 
       {
            get
            {
                {
                    if (_radiusOuter != 0)
                        return _radiusOuter;
                    else
                        throw new Exception("Unable to get the value");
                }
            }
            set
            {
                if (_radiusOuter < 0)
                {
                    throw new Exception("There is no such value for the radius");
                }
                else
                {
                    _radiusOuter = value;
                }
            }
        }

        public Ring(int x, int y, double radiusInner, double radiusOuter) : base(x, y, radiusInner)
        {
            if (radiusOuter < 0)
            {
                throw new Exception("There is no such value for the radius");
            }

            RadiusOuter = radiusOuter;
            
        }

        public override double Area()
        {
            return Math.PI * RadiusOuter * RadiusOuter - base.Area();
        }

        public override double Lenght()
        {
            return 2 * Math.PI * RadiusOuter + base.Lenght();
        }


    }
}
