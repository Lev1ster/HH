using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class AttackObstacle : Obstacle
    {
        private int damage;
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 0)
                    damage = value;
                else
                    damage = 0;
            }
        }
        public AttackObstacle(Point3D point, RigidBody rigid, int damage) : base(point, rigid)
        {
            Damage = damage;
        }

        public void Attack(Player player)
        {

        }
    }
}
