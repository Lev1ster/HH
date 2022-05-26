using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class RangeEnemy : Enemy
    {
        private int Range;

        public RangeEnemy (Point3D point3D, RigidBody rigidBody, int speed, int HP, int Range) : base(point3D, rigidBody, speed, HP)
        {
            if (Range < 0)
                this.Range = rigidBody.radius;
            else
            {
                this.Range = Range + rigidBody.radius;
            }
        }

        public override void Attack(Player player)
        {
            
        }
    }
}
