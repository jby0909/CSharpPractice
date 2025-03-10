using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class SpriteRenderer : Component
    {
        public char Shape; // Mesh, Sprite
        public SDL.SDL_Color color;
        public int spriteSize = 30;

        public int orderLayer;

        protected bool isAnimation = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        protected int spriteIndexX = 0;
        protected int spriteIndexY = 0;


        public SDL.SDL_Color colorKey;

        protected string filename;

        private float elpasedTime = 0;

        private SDL.SDL_Rect sourceRect;         //source image
        private SDL.SDL_Rect destinationRect;    //screen size

        public float precessTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;

        public SpriteRenderer()
        {

        }
        public SpriteRenderer(string inFilename, bool inIsAnimation = false)
        {
            
        }
        public override void Update()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;
            //x,y 위치에 shape 출력
            //Console.SetCursorPosition(X, Y);
            //Console.Write(Shape);
            
            //Console
            Engine.backBuffer[Y, X] = Shape;

            //Screen bitmap
            destinationRect.x = X * spriteSize;
            destinationRect.y = Y * spriteSize;
            destinationRect.w = spriteSize;
            destinationRect.h = spriteSize;
            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            //SDL.SDL_RenderDrawPoint(Engine.Instance.myRenderer, X, Y);

            //SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref myRect);

            unsafe
            {
                //이미지 정보 가져와서 할 일이 있어서 사용
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                //SDL_Surface 안에 이미지 크기 등의 정보가 들어있음

                
                if (isAnimation)
                {
                    if (elpasedTime >= precessTime)
                    {
                        spriteIndexX++;
                        spriteIndexX = spriteIndexX % maxCellCountX;
                        elpasedTime = 0;
                    }
                    else
                    {
                        elpasedTime += Time.deltaTime;
                    }
                    int cellSizeX = surface->w / maxCellCountX;
                    int cellSizeY = surface->h / maxCellCountY;
                    sourceRect.x = cellSizeX * spriteIndexX;
                    sourceRect.y = cellSizeY * spriteIndexY;
                    sourceRect.w = cellSizeX;
                    sourceRect.h = cellSizeY;


                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }
            }
        }

        public virtual void Render()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;
            
            //Console
            Engine.backBuffer[Y, X] = Shape;

            SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                myTexture,
                ref sourceRect, //원본사이즈를
                ref destinationRect);    //설정한값에 맞게 복제
            
        }

        public void LoadBmp(string inFilename, bool inIsAnimation = false)
        {
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // 현재 실행파일이 있는 곳의 부모 폴더까지 가져옴

            isAnimation = inIsAnimation;
            filename = inFilename;

            //SDL은 C. 접근할 수 있는게 없어서 밑의 코드를 사용
            mySurface = SDL.SDL_LoadBMP(projectFolder + "/data/" + filename);
            //SDL.SDL_LoadBMP(filename)//ssd에 있는 파일을 메모리에 올리는 과정
            //스택 영역에 tempSurface변수가 힙영역에 올린 저 파일을 가리킨다
            unsafe
            {
                //이미지 정보 가져와서 할 일이 있어서 사용
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);
                //SDL_Surface 안에 이미지 크기 등의 정보가 들어있음

                //로드할 때 모든 흰색은 다 안그림(투명으로)
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format, colorKey.r, colorKey.g, colorKey.b));

            }
            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);

            //cpu - Ram (surface)
            //gpu - VRam (texture)
        }

    }
}
