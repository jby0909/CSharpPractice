

namespace L20250211
{

    internal class Program
    {
       
        static void Main(string[] args)
        {
            Monster monster = new Gobline();
            int currentHp = monster.Hp;
            monster.Hp = 10;

            monster.GetHp();
            monster.SetHp(1);
        }
    }
}
