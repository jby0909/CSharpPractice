using System.Reflection;

namespace L20250224
{
    internal class Program
    {
        class BitArray32
        {
            public uint Data;

            public void On(int position)
            {
                if(position > 0 && position <= 32)
                {
                    Data = Data | (uint)(1 << position - 1);
                }
                
            }

            public void Off(int position)
            {
                if (position > 0 && position <= 32)
                {
                    Data = Data & ~(uint)(1 << position - 1);
                }
            }

            public bool Check(uint other)
            {
                return (int)(Data & other) > 0? true : false;
            }
        }


        static void Main(string[] args)
        {
            //BitArray32 bitArray = new BitArray32();
            ////0101
            //bitArray.On(3);
            //Console.WriteLine(Convert.ToString(bitArray.Data, 2));
            ////0100
            //bitArray.On(1);
            //Console.WriteLine(Convert.ToString(bitArray.Data, 2));


            ////byte a = 0; // 0000 0000
            ////a = 1 << 7; // 0000 0010
            ////Console.WriteLine(a);

            //// >> , <<  (shift연산자

            //// 0001
            //// 0011 & (논리곱
            //// 0001

            //// 0001
            //// 0011 | (논리합
            //// 0011

            //// 0001 ~ (부정
            //// 1110

            //// 0101 
            //// 0011 ^ XOR
            //// 0110

            //// 0000 0000 -> 16진수
            //// F    F
            //// 0xFF
            //// 255

            //uint Player = 1; // 0b0000 0001
            //uint Camera = 2; // 0b0000 0010
            //uint UI = 4; // 0b0000 0100
            //uint Water = 8; // 0b0000 1000

            ////Player
            //uint playerlayer = 0b00000000;
            //                 //0b00000001 |
            //                 //0b00000001

            //playerlayer = (uint)(playerlayer | Player);

            ////모든 게임 오브젝트에서 Player와 Camera찾기
            //// bit masking
            //if((playerlayer & (Player | Camera)) > (uint)0)
            //{

            //}


            //int R = 255;
            //R = 0xFF; //16진수 (2진수보단 사람이 보기 편한 값)
            //R = 0b11111111; //2진수 (컴퓨터가 계산하는 값)

            //int b = 256; // 00000000 00000000 00000001 000000000
            //b = b >> 1;
            //Console.WriteLine(Convert.ToString(b, 2)); //b를 2진수형식으로 출력하라
            //Console.WriteLine(b);


            //Map map = new Map();
            //int[] arr1 = { 9, 20, 28, 18, 11 };
            //int[] arr2 = { 30, 1, 21, 17, 28 };
            //map.GetMap(5, arr1, arr2);
            //Console.WriteLine();
            //int[] arr3 = { 46, 33, 33, 22, 31, 50 };
            //int[] arr4 = { 27, 56, 19, 14, 14, 10 };
            //map.GetMap(6, arr3, arr4);

            uint N = 3;
            uint.TryParse(Console.ReadLine(), out N);
            ulong[] X = new ulong[N];

            for(int i = 0; i < N; i++)
            {
                ulong.TryParse(Console.ReadLine(), out X[i]);
            }

            
            ulong result = 0;
            for(int i = 0; i < N; i++)
            {
                ulong value = 1;
                for (int n = 1; n < 64; n++)
                {
                    value = value << 1;
                    if (X[i] < value)
                    {
                        result = result ^ value;
                        break;
                    }
                }
            }
            Console.WriteLine(result);

            
            

        }

        
        public static ulong NPOT(ulong number)
        {
            for(int i = 0; i < 64; i++)
            {
                ulong check = (ulong)(1 << i);
                if(check >= number)
                {
                    return check;
                }
            }
            return 0;
        }
    }
}
