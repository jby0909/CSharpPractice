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

        //더블 버퍼링
        static public char[,] backBuffer = new char[20,40];
        static public char[,] frontBuffer = new char[20, 40];


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
            //IO 제일 느림, 모니터 출력, 메모리
            //화면 지우는것도 느려지므로 뺀다
            //Console.Clear();
            world.Render();

            //메모리에 있는걸 한방에 붙여줌
            //back <-> front (flip)
            for(int Y = 0; Y < 20; Y++)
            {
                for(int X = 0; X < 40; X++)
                {
                    if (frontBuffer[Y, X] != backBuffer[Y, X])
                    {
                        frontBuffer[Y, X] = backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(frontBuffer[Y, X]);
                    }

                    //Console.SetCursorPosition(X, Y);
                    //Console.Write(backBuffer[Y, X]);
                }
            }
        }



        internal void Run()
        {
            float frameTime = 1000.0f / 60.0f;
            float elpaseTime = 0.0f;
            //마우스 커서 깜박이는거 끄기
            Console.CursorVisible = false;
            while(isRunning)
            {
                Time.Update();
                if (elpaseTime >= frameTime)
                {
                    InputProcess();
                    Update();
                    Render();
                    Input.ClearInput();
                    elpaseTime = 0;
                }
                else
                {
                    elpaseTime += Time.deltaTime;
                }

            }
        }

       

        public World world;
    }
}
