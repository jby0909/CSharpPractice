using SDL2;
using System;

namespace L20250304_SDL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Unity 초기화
            //하드웨어 모든 장비를 초기화한게 0 이하면
            if(SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                //에러표시
                Console.WriteLine("Fail Init.");
            }


            //설정 파일 읽어오기

            //Unity 창만들기
            //창만들고(메모리에 공간 생성)
            IntPtr myWindow = SDL.SDL_CreateWindow(
                "Gane",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // window shown : 윈도우 보여달라는 뜻. 이부분 없으면 윈도우창이 보이지 않는다.

            //붓(renderer)
            IntPtr myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);


            

            //Unity 메세지 처리(사용자 처리가 추가 구조를 바꿈)
            SDL.SDL_Event myEvent;
            bool isRunning = true;
            while (isRunning) // Event Loop, Game Loop
            {
                //os한테 메세지 있냐고 물어보는 것
                SDL.SDL_PollEvent(out myEvent);

                switch(myEvent.type)
                {

                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                }

                //cpu가 작업할것들을 정함
                SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0); //붓 색깔 지정
                SDL.SDL_RenderClear(myRenderer); //해당 붓 색깔로 화면 지우기


                //f랜덤으로 100개 사각형 그리기(정답)
               

               

                //랜덤으로 100개 사각형 그리기
                Random random = new Random();
                SDL.SDL_Rect rect = new SDL.SDL_Rect();
                
                
                SDL.SDL_SetRenderDrawColor(myRenderer, (byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256), 0);

                for (int i = 0; i < 100; ++i)
                {
                    byte r = (byte)(random.Next() % 256);
                    byte g = (byte)(random.Next() % 256);
                    byte b = (byte)(random.Next() % 256);


                    SDL.SDL_Rect myRect;
                    myRect.x = random.Next() % 640 - 200;
                    myRect.y = random.Next() % 480 - 200;
                    myRect.w = random.Next() % 640;
                    myRect.h = random.Next() % 480;

                    SDL.SDL_SetRenderDrawColor(myRenderer, r, g, b, 0);

                    int type = random.Next() % 3;
                    switch (type)
                    {
                        case 0:
                            SDL.SDL_RenderDrawRect(myRenderer, ref myRect);
                            break;
                        case 1:
                            SDL.SDL_RenderFillRect(myRenderer, ref myRect);
                            break;
                        case 2:
                            int step = 10;
                            int x0 = myRect.x;
                            int y0 = myRect.y;

                            double radius = myRect.w;

                            //시작 값
                            int prevX = (int)(radius * Math.Cos(0 * (Math.PI / 180.0f)));
                            int prevY = (int)(radius * Math.Sin(0 * (Math.PI / 180.0f)));
                            for (int angle = 1; angle <= 360 + step; angle += step)
                            {
                                int x = (int)(radius * Math.Cos(angle * (Math.PI / 180.0f)));
                                int y = (int)(radius * Math.Sin(angle * (Math.PI / 180.0f)));

                                //SDL.SDL_RenderDrawPoint(myRenderer, x0 + x, y0 + y);
                                SDL.SDL_RenderDrawLine(myRenderer, x0 + prevX, y0 + prevY, x0 + x, y0 + y);
                                prevX = x;
                                prevY = y;
                            }
                            break;
                    }
                }

                //gpu한테 던져줘서 일시킴(gpu가 화면에 나타내기 작업을 함)
                SDL.SDL_RenderPresent(myRenderer);

            }

            //Unity종료
            //창 지우기(메모리에서 지우기)
            SDL.SDL_DestroyWindow(myWindow);

            //라이브러리 열었으니? 지워야 한다?
            SDL.SDL_Quit();
            
        }
    }
}
