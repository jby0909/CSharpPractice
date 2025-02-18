using System.Net;

namespace L20250204
{
    internal class Program
    {

        static void Initialize(int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
        }

        static void Shuffle(int[] deck)
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

        enum CardType
        {
            None = -1,
            Heart = 0,
            Diamond = 1,
            Clover = 2,
            Spade = 3,

            
        }

        static CardType CheckCardType(int cardNumber)
        {
            int valueType = (cardNumber - 1) / 13;
            CardType returnCardType = CardType.None;
            return (CardType)valueType;
            //switch((CardType)valueType)
            //{
            //    case CardType.Heart:
            //        returnCardType = CardType.Heart;
            //        break;
            //    case CardType.Diamond:
            //        returnCardType = CardType.Diamond;
            //        break;
            //    case CardType.Clover:
            //        returnCardType = CardType.Clover;
            //        break;
            //    case CardType.Spade:
            //        returnCardType =  CardType.Spade;
            //        break;
            //    default:
            //        returnCardType = CardType.None;
            //        break;
            //}
           
        }

        static string CheckCardName(int cardNumber)
        {
            int cardValue = ((cardNumber - 1) % 13 ) + 1;
            string cardName;
            switch (cardValue)
            {
                case 1:
                    cardName = "A";
                    break;
                case 11:
                    cardName = "J";
                    break;
                case 12:
                    cardName = "Q";
                    break;
                case 13:
                    cardName = "K";
                    break;
                default:
                    cardName = cardValue.ToString();
                    break;
            }

            return cardName;
        }

        static int CalculateScore(int[] deck, int startIndex, int lastIndex)
        {
            int score = 0;
            for(int i = startIndex; i < lastIndex; i++)
            {
                int cardScore = ((deck[i] - 1) % 13) + 1;
                if (cardScore > 10)
                {
                    score += 11;
                }
                else
                {
                    score +=  cardScore;
                }
            }
            return score;
            
        }

        

        static void Print(int[] deck)
        {
            int computerScore = CalculateScore(deck, 0, 3);
            int playerScore = CalculateScore(deck, 3, 6);

            Console.WriteLine("컴퓨터 카드");
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])} {deck[i]}") ;

            }
            Console.WriteLine($"컴퓨터 점수 : {computerScore}");
            Console.WriteLine("-------------------------");
            Console.WriteLine("내 카드");
            for (int i = 3; i < 6; i++)
            {
                Console.WriteLine($"{CheckCardType(deck[i]).ToString()} {CheckCardName(deck[i])} {deck[i]}");

            }
            Console.WriteLine($"내 점수 : {playerScore}");
            Console.WriteLine("-------------------------");

            if(computerScore > 21 && playerScore <= 21)
            {
                Console.WriteLine("플레이어 승리");
            }
            else if(playerScore > 21 && computerScore <= 21)
            {
                Console.WriteLine("컴퓨터 승리");
            }
            else if(playerScore >= computerScore)
            {
                
                Console.WriteLine("플레이어 승리");
            }
            else
            {
                Console.WriteLine("컴퓨터 승리");
            }
        }


        static void Main(string[] args)
        {
            //int[] deck = new int[52];

            //Initialize(deck);
            ////Shuffle
            //Shuffle(deck);

            ////Print
            //Print(deck);

            string name = "Hello";
            string message = String.Format("{0}님 {1}안녕안녕하세요",name, 1);
            string data = "a10, 20, 30, 40";

            string[] datas = data.Split(",");

            for(int i = 0; i < datas.Length; i++)
            {
                Console.WriteLine(datas[i].Trim());
            }

            int a = 2;
            float b = 3.5f;
            float.TryParse(datas[0],out b);
            
            
        }
    }
}
