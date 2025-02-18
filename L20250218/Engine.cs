using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    public class Engine
    {
        private Engine() 
        {
            Create();
        }

        ~Engine()
        {

        }

        private static Engine instance = new Engine();
        public static Engine GetInstance()
        {
            return instance;
        }

        GameObject[] gameObjects = new GameObject[100];
        string[] gameMap =
        {
            "**********",
            "*        *",
            "* P      *",
            "*        *",
            "*        *",
            "*     M  *",
            "*        *",
            "*        *",
            "*       G*",
            "**********"
        };

        

        public static ConsoleKeyInfo keyInfo;

        public static void Input()
        {
            keyInfo = Console.ReadKey();
        }

        public static bool GetKeyDown(ConsoleKey inKey)
        {
            if(keyInfo.Key == inKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create()
        {
            gameObjects = new GameObject[100];
            int countIndex = 0;
            for (int y = 0; y < gameMap.Length; y++)
            {
                for (int x = 0; x < gameMap[y].Length; x++)
                {
                    if(gameMap[y][x] == '*')
                    {
                        gameObjects[countIndex] = new Wall(x, y, gameMap[y][x]);
                    }
                    else if(gameMap[y][x] == ' ')
                    {
                        gameObjects[countIndex] = new Floor(x, y, gameMap[y][x]);
                    }
                    else if(gameMap[y][x] == 'P')
                    {
                        gameObjects[countIndex] = new Player(x, y, gameMap[y][x]);
                    }
                    else if(gameMap[y][x] == 'M')
                    {
                        gameObjects[countIndex] = new Monster(x, y, gameMap[y][x]);
                    }
                    else if(gameMap[y][x] == 'G')
                    {
                        gameObjects[countIndex] = new Goal(x, y, gameMap[y][x]);
                    }
                   
                    countIndex++;
                }
            }
        }

        public void Update()
        {
            for(int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Update();
                gameObjects[i].Collide(gameObjects);
                
            }
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].Render();
            }
        }

    }
}
