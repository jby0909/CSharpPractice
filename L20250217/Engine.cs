using SDL2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
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

        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvent;
        public bool Init()
        {
            //Unity 초기화
            //하드웨어 모든 장비를 초기화한게 0 이하면
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                //에러표시
                Console.WriteLine("Fail Init.");
                return false;
            }


            //설정 파일 읽어오기

            //Unity 창만들기
            //창만들고(메모리에 공간 생성)
            myWindow = SDL.SDL_CreateWindow(
                "Gane",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // window shown : 윈도우 보여달라는 뜻. 이부분 없으면 윈도우창이 보이지 않는다.

            //붓(renderer)
            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);


            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            //Unity종료
            //창 지우기(메모리에서 지우기)
            SDL.SDL_DestroyWindow(myWindow);

            //라이브러리 열었으니? 지워야 한다?
            SDL.SDL_Quit();
            return true;
        }
       

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
                        //Player player = new Player(x, y, scene[y][x]);
                        //world.Instantiate(player);
                        GameObject player = new GameObject();
                        player.Name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;

                        player.AddComponent<PlayerController>(new PlayerController());
                        SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("player.bmp", true);
                        
                        spriteRenderer.Shape = 'P';

                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.Name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;

                        SpriteRenderer spriteRenderer = monster.AddComponent<SpriteRenderer>(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("monster.bmp");

                        spriteRenderer.Shape = 'M';

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
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0); //붓 색깔 지정
            SDL.SDL_RenderClear(myRenderer); //해당 붓 색깔로 화면 지우기

            //IO 제일 느림, 모니터 출력, 메모리
            //화면 지우는것도 느려지므로 뺀다
            //Console.Clear();
            world.Render();
           

            //메모리에 있는걸 한방에 붙여줌
            //back <-> front (flip)
            for (int Y = 0; Y < 20; Y++)
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
            SDL.SDL_RenderPresent(myRenderer);
        }



        internal void Run()
        {

            Console.CursorVisible = false;

            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);

                Time.Update();

                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                    
                }

                Update();
                Render();
            }
        }


        public World world;
    }
}
