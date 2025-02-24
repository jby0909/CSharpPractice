using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 4;
            isTrigger = true;
        }

       

        public override void Update()
        {
            if(Input.GetKeyDown(ConsoleKey.W) || Input.GetKeyDown(ConsoleKey.UpArrow))
            {
                //미리 가봄 -> 모든 게임오브젝트랑 다음에 갈 내 위치랑 비교하기
                if(!PredictCollision(X, Y - 1))
                {
                    Y--;
                }
                
            }
            else if(Input.GetKeyDown(ConsoleKey.S) || Input.GetKeyDown(ConsoleKey.DownArrow))
            {
                if (!PredictCollision(X, Y + 1))
                {
                    Y++;
                }
               
            }
            else if(Input.GetKeyDown(ConsoleKey.A) || Input.GetKeyDown(ConsoleKey.LeftArrow))
            {
                if (!PredictCollision(X - 1, Y))
                {
                    X--;
                }
                
            }
            else if(Input.GetKeyDown(ConsoleKey.D) || Input.GetKeyDown(ConsoleKey.RightArrow))
            {
                if (!PredictCollision(X + 1, Y))
                {
                    X++;
                }
            }

        }
    }
}
