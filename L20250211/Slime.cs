using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Slime
    {
        public int hp;
        public int gold;
        public Slime()
        {

        }
        ~Slime()
        {

        }
        public void Attack()
        {
            Console.WriteLine("슬라임 공격");
        }
        public void Move()
        {
            Console.WriteLine("슬라임 미끄러져 이동");
        }
        public void Die()
        {
            Console.WriteLine("슬라임 죽음");
        }
    }
}
