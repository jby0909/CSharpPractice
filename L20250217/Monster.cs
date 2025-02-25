using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Monster : GameObject
    {
        private Random rand = new Random();

        private float elpasedTime = 0;
        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 5;
            isTrigger = true;
        }

        public override void Update()
        {
            if(elpasedTime > 0.005f)
            {
                elpasedTime = 0.0f;
                int Direction = rand.Next() % 4;
                if (Direction == 0)
                {
                    if (!PredictCollision(X, Y - 1))
                    {
                        Y--;
                    }
                }
                else if (Direction == 1)
                {
                    if (!PredictCollision(X, Y + 1))
                    {
                        Y++;
                    }
                }
                else if (Direction == 2)
                {
                    if (!PredictCollision(X - 1, Y))
                    {
                        X--;
                    }
                }
                else if (Direction == 3)
                {
                    if (!PredictCollision(X + 1, Y))
                    {
                        X++;
                    }
                }
            }
            elpasedTime += Time.deltaTime;
            

        }
    }
}
