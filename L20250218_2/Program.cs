namespace L20250218_2
{
    class DynamicArray<T>
    {
        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            
            count++;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(Object removObject)
        {
            for(int i = 0; i < count; i++)
            {
                if (removObject == objects[i])
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if(index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
                return true;
            }
            return false;
        }


        public void Insert(int insertIndex, Object value)
        {
            if(insertIndex < count)
            {
                if (objects.Length == count)
                {
                    ExtendSpace();
                    for(int i = count; i > insertIndex; i--)
                    {
                        objects[i] = objects[i - 1];
                    }
                    objects[insertIndex + 1] = value;
                    count++;
                }
                else
                {
                    for (int i = count; i > insertIndex; i--)
                    {
                        objects[i] = objects[i - 1];
                    }
                    objects[insertIndex + 1] = value;
                    count++;
                }
            }
            
            
        }

        protected Object[] objects = new Object[3];


        protected int CurrentPosition = 0;

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            //

            DynamicArrayPractice<int> a = new DynamicArrayPractice<int>();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            //a[1] = 11;
            //a[9] = 29;

            //a.RemoveAt(9);
            //a.RemoveAt(3);
            //a.RemoveAt(1);

            
            a.Insert(9, 99);
            //a.Insert(10, 99);

            //a.Remove(7);

            

            for (int i = 0; i < a.Count; ++i)
            {
                Console.Write(a.[i] + ", ");
            }
        }
    }
}
