using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    interface IControl
    {
        int HP { get; set; }
        int Speed { get; set; }

        void Move(List<GameObject> listObjects);

        void Die();
    }
}
