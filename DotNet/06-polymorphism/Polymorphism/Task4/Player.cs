using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Player : GameObject, IControl
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
        public Player(Point3D point, RigidBody rigidBody, int speed, int HP) : base(point, rigidBody)
        {
            this.Speed = speed;
            this.HP = HP;
        }

        public void Move(List<GameObject> listObjects)
        {
            
        }

        public void Die()
        {

        }

        public GameObject[] FindObjects(List<GameObject> listObjects)
        {
            GameObject[] objects = new GameObject[0];

            return objects;
        }

        public void Reaction(Enemy enemy)
        {

        }
        public void Reaction(Bonus enemy)
        {

        }
        public void Reaction(Obstacle obstacle)
        {

        }
    }
}
