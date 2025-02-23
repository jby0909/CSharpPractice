using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250211
{
    public class Pig : Monster
    {
        
        public Pig()
        {

        }
        ~Pig()
        {

        }
      
        public override void Move()
        {
            Console.WriteLine("멧돼지 뛰어서 이동");
        }
       
    }
}
