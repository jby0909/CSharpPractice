using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250224
{
    public class Map
    {
        public void GetMap(int n, int[] arr1, int[] arr2)
        {
          
            uint[] map = new uint[n];

            

            for(int i = 0; i < n; i++)
            {
                map[i] = (uint)(arr1[i] | arr2[i]);
            }


            int bitMask = 0;

            for(int i = 0; i < n; i++)
            {
                bitMask = 1 << (n - 1);
                for(int j = 0; j < n; j++)
                {
                    Console.Write((bitMask & map[i]) > 0 ? "#" : " ");
                    bitMask = bitMask >> 1;

                }
                Console.Write(", ");
            }

            
        }
    }
}
