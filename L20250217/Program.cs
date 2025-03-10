using System.Reflection;
using System.Text;

namespace L20250217
{
    internal class Program
    {
        class Singleton
        {
            private Singleton()
            {
            }

            static Singleton instance;

            static public Singleton GetInstance()
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        class CustomException : Exception
        {
            public CustomException() : base("이건 내가 만든 예외")
            {
                
            }
        }

        

        static void Main(string[] args)
        {
            Engine.Instance.Init();

            Engine.Instance.Load("level01.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();

            //StreamReader sr = null;
            //try
            //{
            //    List<string> scene = new List<string>();
            //    sr = new StreamReader("level02.map");

            //    while (!sr.EndOfStream)
            //    {
            //        scene.Add(sr.ReadLine());
            //        throw new CustomException();
            //    }

            //}
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine(e.FileName);
            //    Console.WriteLine(e.Source);
            //    Console.WriteLine(e.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    //network, file 입출력
            //    Console.WriteLine("finally");
            //    sr.Close();
            //}




            //while (fs.CanRead)
            //{
            //    int readCount = fs.Read(buffer, offset, 80);
            //    offset += 80;
            //    scene = scene + Encoding.UTF8.GetString(buffer);
            //}



            ////1 --> 10 : 오름차순, ascending
            ////10 --> 1 : 내림차순, descending
            //int[] numbers = { 1, 5, 2, 3, 6, 7, 8, 10, 9 };


            ////Big O n ^ 2
            //for(int i = 0;  i < numbers.Length; i++)
            //{
            //    for(int j = 0; j < numbers.Length; j++)
            //    {
            //        if (numbers[i] < numbers[j])
            //        {
            //            int temp = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.Write(numbers[i] + ", ");
            //}


        }
    }
}
