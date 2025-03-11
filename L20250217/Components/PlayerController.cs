using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace L20250217
{
    public class PlayerController : Component
    {
        public SpriteRenderer spriteRenderer;
        public CharacterController2D characterController;
        public override void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            characterController = GetComponent<CharacterController2D>();
        }
        public override void Update()
        {

            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                ////미리 가봄 -> 모든 게임오브젝트랑 다음에 갈 내 위치랑 비교하기
                //if (!PredictCollision(X, Y - 1))
                //{
                //    Y--;
                //}
                //spriteIndexY = 2;

                characterController.Move(0, -1);
                
                
                spriteRenderer.spriteIndexY = 2;

            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                //if (!PredictCollision(X, Y + 1))
                //{
                //    Y++;

                //}
                //spriteIndexY = 3;
                characterController.Move(0, 1);
               
                spriteRenderer.spriteIndexY = 3;

            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                //if (!PredictCollision(X - 1, Y))
                //{
                //    X--;

                //}
                //spriteIndexY = 0;

                characterController.Move(-1, 0);
                
                spriteRenderer.spriteIndexY = 0;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                //if (!PredictCollision(X + 1, Y))
                //{
                //    X++;

                //}
                //spriteIndexY = 1;
                characterController.Move(1, 0);
                
                
                spriteRenderer.spriteIndexY = 1;
            }

        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.Name.CompareTo("Goal") == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isFinish = true;
            }
            if (other.gameObject.Name.CompareTo("Monster") == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
            }
            Console.WriteLine($"겹침 감지 : {other.gameObject.Name}");
        }
    }
}
