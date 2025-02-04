namespace L20250204
{
    internal class Program
    {
        static int[] deck = new int[52];

        static void Initialize()
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
        }

        static void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < deck.Length; i++)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }
        }

        static void Print()
        {
            for (int i = 0; i < 8; i++)
            {
                //모양 정하기
                if ((deck[i] - 1) / 13 == 0)
                {
                    Console.Write("♥");
                }
                else if ((deck[i] - 1) / 13 == 1)
                {
                    Console.Write("◆");
                }
                else if ((deck[i] - 1) / 13 == 2)
                {
                    Console.Write("♣");
                }
                else
                {
                    Console.Write("♠");
                }

                //숫자 및 AJQK정하기
                if (deck[i] % 13 == 1)
                {
                    Console.WriteLine("A");
                }
                else if (deck[i] % 13 == 11)
                {
                    Console.WriteLine("J");
                }
                else if (deck[i] % 13 == 12)
                {
                    Console.WriteLine("Q");
                }
                else if (deck[i] % 13 == 0)
                {
                    Console.WriteLine("K");
                }
                else
                {
                    Console.WriteLine(deck[i] % 13);
                }


            }
        }
        static void Main(string[] args)
        {
            Initialize();
            //Shuffle
            Shuffle();
            //Print
            Print();


        }
    }
}
