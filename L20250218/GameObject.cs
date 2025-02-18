using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class GameObject
    {
        public GameObject()
        {

        }
        

        public int X;
        public int Y;
        public char shape;

        public virtual void Render()
        {
            if(X >= 0 && X < 10 && Y >= 0 && Y < 10)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(shape);
            }
            
        }

        public virtual void Update()
        {

        }

        public virtual void Collide(GameObject[] others)
        {
            
           
        }
    }
}
