using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Gobline : Monster
    {
        public Gobline()
        {
            Console.WriteLine("고블린 생성자");
        }
        ~Gobline()
        {
            Console.WriteLine("고블린 소멸자");
        }
       
        public override void Move()
        {
            Console.WriteLine("고블린 걸어서 이동");
        }
        
    }
}
