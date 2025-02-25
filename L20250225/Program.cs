using System.Collections;

namespace L20250225
{
    public class DynamicArray<T> : IEnumerable
    {
        protected T[] arr;
        protected int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                if(i < count)
                {
                    arr[i] = value;
                }
                
            }
            
        }

        public DynamicArray()
        {
            arr = new T[3];
            count = 0;
        }

        ~DynamicArray()
        {

        }

        public void Add(T value)
        {
            if(arr.Length <= count)
            {
                T[] newArr = new T[arr.Length * 2];
                //for문대신 배열 복사하는 함수(이게 for문보다 빠름)
                Array.Copy(arr, newArr, arr.Length);
                arr = newArr;
                
            }
            arr[count] = value;
            count++;
        }

        public void RemoveAt(int indexValue)
        {
            if(indexValue < count)
            {
                for (int i = indexValue; i < count; i++)
                {
                    arr[i] = arr[i + 1];
                }
                count--;
            }
            
        }

        public void Insert(int indexValue, T value)
        {
            if(indexValue < count)
            {
                if(count >= arr.Length -1)
                {
                    T[] newArr = new T[arr.Length * 2];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        newArr[i] = arr[i];
                    }
                    arr = null;
                    arr = newArr;
                }
                for (int i = count - 1; i >= indexValue; i--)
                {
                    arr[i + 1] = arr[i];
                }
                arr[indexValue + 1] = value;
                count++;
               
            }
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return arr[i];
            }
        }

        
    }


    internal class Program
    {
        static int[] data = { 1, 2, 3, 4, 5 };
        static int Current = 0;

        static IEnumerable GetNumbers()
        {
            while(Current < data.Length)
            {
                yield return data[Current++];
            }
            
            
        }

        static void Main(string[] args)
        {
            

            DynamicArray<int> dynamicArr = new DynamicArray<int>();
            dynamicArr.Add(1);
            dynamicArr.Add(2);
            dynamicArr.Add(3);
            dynamicArr.Add(4);
            dynamicArr.Add(5);

            dynamicArr[2] = 99;

            dynamicArr.Insert(0, 100);
            dynamicArr.Insert(5, 111);

            dynamicArr.RemoveAt(0);
            dynamicArr.RemoveAt(5);
            
            foreach(var value in dynamicArr)
            {
                Console.WriteLine(value);
            }

           
            
        }

        static void Main2(string[] args)
        {
            List<IItem> items = new List<IItem>();
            items.Add(new Potion());
            items.Add(new Sword());

            foreach(var item in items)
            {
                item.Use();
            }

            Object potion = new Potion();
            Type type = potion.GetType();
            if(typeof(Potion) == type.GetInterface("IItem"))
            {
                (potion as Potion).Use();
            }
        }
    }

    public interface IItem
    {
        void Use();
    }

    public class Potion : IItem
    {
        public void Use()
        {
            Console.WriteLine("포션 사용");
        }
    }

    public class Sword : IItem
    {
        public void Use()
        {
            Console.WriteLine("검 사용");
        }
    }
}
