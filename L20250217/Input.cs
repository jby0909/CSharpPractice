using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace L20250217
{
    internal class Input
    {
        public Input()
        {

        }
        static protected ConsoleKeyInfo keyInfo;
        static public bool GetKeyDown(ConsoleKey key)
        {
            return (keyInfo.Key == key);
        }
        static public bool GetKeyDown(SDL.SDL_Keycode key)
        {
            if(Engine.Instance.myEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                return (Engine.Instance.myEvent.key.keysym.sym == key);
            }
            return false;
        }

        static public bool GetKey(SDL.SDL_Keycode key)
        {
            return (Engine.Instance.myEvent.key.keysym.sym == key);
        }

        static public void Process()
        {
            ////키입력이 있는지
            //if(Console.KeyAvailable)
            //{
            //    //키 입력이 있으면 입력받음
            //    //(true)넣으면 내가 입력한 값이 화면에 그려지지 않는다
            //    keyInfo = Console.ReadKey(true);
            //}
            
        }

       
        public static void ClearInput()
        {
            //한번 누를 때마다 초기화(기존에 누른 키가 계속 저장되어있는걸 방지)
            keyInfo = new ConsoleKeyInfo();
        }
    }
}
