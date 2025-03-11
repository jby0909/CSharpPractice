using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameManager : Component
    {
        public bool isGameOver = false; //적과 닿으면
        public bool isFinish = false; //골 도착

        public override void Update()
        {
            if(isGameOver)
            {
                if(GameObject.Find("failObject") == null)
                {
                    //Console.WriteLine("Failed");
                    //Engine.Instance.Quit();
                    GameObject failObject = new GameObject();
                    TextRenderer textRenderer = failObject.AddComponent<TextRenderer>();
                    textRenderer.color.r = 255;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 0;
                    textRenderer.transform.X = 100;
                    textRenderer.transform.Y = 100;
                    textRenderer.SetText("실패");
                    Engine.Instance.world.Instantiate(failObject);
                }
                
            }
            if (isFinish)
            {
                if(GameObject.Find("successObject") == null)
                {
                    //Console.WriteLine("Success");
                    //Engine.Instance.Quit();
                    GameObject successObject = new GameObject();
                    TextRenderer textRenderer = successObject.AddComponent<TextRenderer>();
                    textRenderer.color.r = 0;
                    textRenderer.color.g = 0;
                    textRenderer.color.b = 255;
                    textRenderer.transform.X = 100;
                    textRenderer.transform.Y = 100;
                    textRenderer.SetText("성공");
                    Engine.Instance.world.Instantiate(successObject);
                }
               
            }
        }
    }
}
