using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Enemy : GameObject, IControl
    {
        private int hp;
        private int speed;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                if (value > 0)
                    hp = value;
                else
                    hp = 0;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value > 0)
                    speed = value;
                else
                    speed = 0;
            }
        }
        private int range;
        public Enemy(Point3D point, RigidBody rigidBody, int speed, int HP) : base(point, rigidBody)
        {
            range = rigidBody.radius;
            this.Speed = speed;
            this.HP = HP;
        }

        public virtual void Attack(Player player)
        {

        }

        public void Move(List<GameObject> listObjects)
        {

        }
        public void Die()
        {

        }
    }
}
