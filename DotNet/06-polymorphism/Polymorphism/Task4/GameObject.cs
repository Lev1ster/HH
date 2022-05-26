using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public enum Area : uint
    {
        Width = 2000,
        Height = 2000
    }

    public abstract class GameObject
    {
        public Point3D coords;
        public RigidBody rigidBody;

        public GameObject(Point3D coords, RigidBody rigid)
        {
            this.coords = coords;
            rigidBody = rigid;
        }
    }

    public class Point3D
    {
        private int _x;
        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                if (value <= (int)Area.Width)
                {
                    if (value >= 0)
                    {
                        _x = value;
                    }
                    else
                    {
                        _x = 0;
                    }
                }
                else
                {
                    _x = (int)Area.Width;
                }
            }
        }
        private int _y;
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value <= (int)Area.Height)
                {
                    if (value >= 0)
                    {
                        _y = value;
                    }
                    else
                    {
                        _y = 0;
                    }
                }
                else
                {
                    _y = (int)Area.Height;
                }
            }
        }
        public int z;

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public class RigidBody
    {
        public readonly int x;
        public readonly int y;
        public readonly int radius;
        public RigidBody(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
    }
}
