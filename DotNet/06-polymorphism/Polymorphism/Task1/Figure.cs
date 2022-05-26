using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    struct Point2D
    {
        public int X;
        public int Y;
    }

    abstract class Figure
    {
        public abstract void Draw(IPrint print);
    }
}
