using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    internal class Engine
    {
        private Engine()
        {

        }

        static protected Engine instance;

        static public Engine Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Engine();
                }
                return instance; 
            }
        }

        protected bool isRunning = true;
       

        public void Load()
        {
            //file에서 로딩
            string[] scene = {
            "**********",
            "*p       *",
            "*        *",
            "*        *",
            "*        *",
            "*    m   *",
            "*        *",
            "*        *",
            "*       g*",
            "**********"};

            world = new World();

            for (int y = 0; y < scene.Length; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if(scene[y][x] == '*')
                    {
                        Wall wall = new Wall(x, y, scene[y][x]);
                        world.Instantiate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {
                        Floor floor = new Floor(x, y, scene[y][x]);
                        world.Instantiate(floor);
                    }
                    else if (scene[y][x] == 'p')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'm')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'g')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instantiate(goal);
                    }

                }
            }
        }

        public void InputProcess()
        {
            Input.Process();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            Console.Clear();
            world.Render();
        }

        internal void Run()
        {
            while(isRunning)
            {
                InputProcess();
                Update();
                Render();
            }
        }

       

        public World world;
    }
}
