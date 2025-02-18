namespace L20250218
{
    public class Program
    {
        static public bool isRunning = true;
        static void Main(string[] args)
        {
            Engine engine = Engine.GetInstance();
            while(isRunning)
            {
                Engine.Input();
                engine.Update();
                if(isRunning)
                {
                    engine.Render();
                }
                
            }
            
        }
    }
}
