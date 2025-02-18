using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Monster : GameObject
    {
        Random rand = new Random();
        int preX;
        int preY;
        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            shape = inShape;
        }

        public override void Update()
        {
            Move();

        }
        public void Move()
        {
            preX = X;
            preY = Y;
            int randMove = rand.Next(0, 4);
            if(randMove == 0 && X < 8)
            {
                X++;
            }
            else if(randMove == 1 && X > 1)
            {
                X--;
            }
            else if(randMove == 2 && Y < 8)
            {
                Y++;
            }
            else if(randMove == 3 && Y > 1)
            {
                Y--;
            }

        }

        public override void Collide(GameObject[] others)
        {
            for(int i = 0; i < others.Length; i++)
            {
                if (others[i].X == X && others[i].Y == Y && others[i] is Goal)
                {
                    X = preX;
                    Y = preY;
                }
            }
        }


    }
}
