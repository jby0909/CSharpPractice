using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            shape = inShape;
        }
        public void Dead()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Program.isRunning = false;
        }

        public override void Update()
        {
            Move();

        }

        public void Move()
        {
            //플레이어 움직임
            if(Engine.GetKeyDown(ConsoleKey.W))
            {
                Y--;
            }
            else if(Engine.GetKeyDown(ConsoleKey.S))
            {
                Y++;
            }
            else if( Engine.GetKeyDown(ConsoleKey.D))
            {
                X++;
            }
            else if(Engine.GetKeyDown(ConsoleKey.A))
            {
                X--;
            }
        }

        public void GoalIn()
        {
            //다음 단계로 가도록 만들기
            Engine.GetInstance().Create();
            
        }

        public override void Collide(GameObject[] others)
        {
            for (int i = 0; i < others.Length; i++)
            {
                if (others[i].X == X && others[i].Y == Y && others[i] is Wall)
                {
                    StopMove();
                }
                else if (others[i].X == X && others[i].Y == Y && others[i] is Monster)
                {
                    Dead();
                }
                else if (others[i].X == X && others[i].Y == Y && others[i] is Goal)
                {
                    GoalIn();
                }
            }
           
        }

        private void StopMove()
        {
            if(X == 0)
            {
                X = 1;
            }
            if(X == 9)
            {
                X = 8;
            }
            if(Y == 0)
            {
                Y = 1;
            }
            if(Y == 9)
            {
                Y = 8;
            }
        }
    }
}
