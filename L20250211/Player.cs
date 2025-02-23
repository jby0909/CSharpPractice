using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Player
    {
        public int hp;
        public int gold;
       
        public Player()
        {
            hp = 100;
            gold = -10;
            //Console.WriteLine("플레이어 생성자");
        }
        public Player(int inHp, int inGold)
        {
            this.hp = inHp;
            this.gold = inGold;
        }
        ~Player()
        {
            //Network, DB 종료
            Console.WriteLine("플레이어 소멸자");
        }
        public void Attack()
        {
            Console.WriteLine("플레이어가 공격");
            
        }

        public void Move()
        {
            Console.WriteLine("플레이어 이동");
        }

        public void PickUp()
        {
            Console.WriteLine("골드 줍기");
        }

        public void Die()
        {
            Console.WriteLine("플레이어 죽음");
        }
    }
}
