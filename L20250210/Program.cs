namespace L20250210
{ 
    

    public class Monster
    {
        public static int Count = 0;
        public Monster()
        {
            Count++;
        }

        public enum EColor
        {
            Yellow,
            Green,
            Blue,
            Cyan,
            Red
        }

        public EColor color;
        public bool taste;
        public int shape;
        public int hp = 100;

        public void Damage()
        {
            hp -= 10;
            Console.WriteLine($"현재 HP {hp}");
        }

        

        public static void Die() //메모리에서 code영역에 존재
        {
            Console.WriteLine("죽었다.");
        }


    }

    struct Position
    {
        public int x; 
        public int y;
    }

    public class Image
    {
        //생성자
        public Image()
        {
            x = 0;
            y = 0;
            R = 255;
            G = 255;
            B = 255;
        }

        //소멸자
        ~Image()
        {
            Console.WriteLine("소멸자");
        }

        public int x;
        public int y;
        public int R;
        public int G;
        public int B;

   
    }


    public class World
    {
        public Floor[] floors;
        public Wall[] walls;
        public Player player;
        public Monster2[] monsters;
        public Destination destination;

        public World()
        {
            walls = new Wall[100];
            floors = new Floor[100];
            player = new Player();
            monsters = new Monster2[10];
            destination = new Destination();

        }

        
    }
    public class Wall
    {
        public void DisThrowable()
        {

        }
    }
    public class Floor
    {
        
    }
    public class Player
    {
        public Player()
        {

        }
        ~Player()
        {

        }
        public void Move()
        {

        }
    }
    public class Monster2
    {
        public Monster2()
        {

        }
        ~Monster2()
        {

        }
        public void Move()
        {

        }
    }
    public class Destination
    {
        public Destination()
        {

        }
        ~Destination()
        {

        }
        public bool IsFinish(Player player)
        {
            return true;
        }

        public void GameOver()
        {
            //if(IsFinish(player))
            //{

            //}
        }
    }

internal class Program
    {
        static void Main(string[] args)
        {
            //Monster[] apple = new Monster[3]; // stack에 참조 변수(heap을 가리킬)
            //for(int i = 0; i < apple.Length; i++)
            //{
            //    apple[i] = new Monster(); // heap에 apple형태 메모리 공간 확보
            //}

            Image[] img = new Image[14];
            for (int i = 0; i < img.Length; i++)
            {
                img[i] = new Image();
            }
            
            img[0].x = 0;
            img[0].y = 0;
            img[0].R = 165;
            img[0].G = 55;
            img[0].B = 128;

            img[1].x = 0;
            img[1].y = 1;
            img[1].R = 133;
            img[1].G = 28;
            img[1].B = 182;

            img[2].x = 0;
            img[2].y = 2;
            img[2].R = 115;
            img[2].G = 136;
            img[2].B = 63;



        }
    }
}
