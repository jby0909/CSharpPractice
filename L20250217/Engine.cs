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
       

        public void Load(string filename)
        {
            //file에서 읽기 1
            //string tempScene = "";
            //byte[] buffer = new byte[1024];

            //FileStream fs = new FileStream("level01.map", FileMode.Open);
            //int offset = 0;
            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;

            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene = tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");


            //file에서 읽기 2
            List<string> scene = new List<string>();
            StreamReader sr = new StreamReader(filename);

            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();
           
           



            world = new World();

            for (int y = 0; y < scene.Count; y++)
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
                        //Floor floor = new Floor(x, y, scene[y][x]);
                        //world.Instantiate(floor);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        Player player = new Player(x, y, scene[y][x]);
                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        Monster monster = new Monster(x, y, scene[y][x]);
                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        Goal goal = new Goal(x, y, scene[y][x]);
                        world.Instantiate(goal);
                    }
                    Floor floor = new Floor(x, y, ' ');
                    world.Instantiate(floor);
                }
            }

            //loading complete
            //sort
            world.Sort();
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
