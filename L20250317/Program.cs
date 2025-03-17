using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace L20250317
{
    class GameObject
    {
        public GameObject(int inGold = 100, int inHP = 100, int inMP = 100)
        {
            Gold = inGold;
            HP = inHP;
            MP = inMP;
        }

        public int Gold;
        public int MP;
        public int HP;
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(new GameObject(10, 20, 30));
            gameObjects.Add(new GameObject(100, 200, 300));
            gameObjects.Add(new GameObject(50, 60, 70));
            gameObjects.Add(new GameObject(1, 2, 3));
            gameObjects.Add(new GameObject(5, 6, 7));

            string jsonData = JsonConvert.SerializeObject(gameObjects);

            Console.WriteLine(jsonData);
            List<GameObject> gameObjects2 = JsonConvert.DeserializeObject<List<GameObject>>(jsonData);

            foreach(var go in gameObjects)
            {
                Console.WriteLine(go.Gold);
            }

            
            //string Data = "{Gold : 10, HP : 20, MP : 30}";

            //JObject Json = JObject.Parse(Data);
            //Console.WriteLine(Json.Value<int>("Gold"));
            //Console.WriteLine(Json.Value<int>("HP"));
            //Console.WriteLine(Json.Value<int>("MP"));

        }
    }
}
