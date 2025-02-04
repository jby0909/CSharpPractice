namespace L20250204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[52];
            int randNumber;
            Random rand = new Random();
            int[] randNumbers = new int[8];
           

            for(int i = 0; i < 52; i++)
            {
                array[i] = i + 1;
            }

            for(int i = 0; i < 8; )
            {
                randNumber = rand.Next(0, 52);
                for(int j = 0; j < 8; j++)
                {
                    if (randNumbers[j] == randNumber)
                    {
                        break;
                    }
                    else if (randNumbers[j] == 0)
                    {
                        randNumbers[j] = randNumber;
                        i++;
                        break;
                    }
                }
               

            }

            for(int i = 0; i < 8; i++)
            {
                Console.Write(array[randNumbers[i]] + ", ");
            }
            
        }
    }
}
