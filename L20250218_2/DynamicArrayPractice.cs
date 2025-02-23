using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218_2
{
    public class DynamicArrayPractice<T>
    {
        T[] objects = new T[3];
        int count = 0;

        public int Count
        {
            get { return count; }
        }

        public T this[int i]
        {
            get { return objects[i]; }
        }

        public void Add(T inValue)
        {
            if(count >= objects.Length)
            {
                T[] newObjects = new T[objects.Length * 2];
                for(int i = 0; i < count; i++)
                {
                    newObjects[i] = objects[i];
                }
                newObjects[count] = inValue;
                objects = null;
                objects = newObjects;
                
            }
            else
            {
                objects[count] = inValue;
                
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if(index >= 0 && index < count)
            {
                for(int i = index; i <  count - 1; i++)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
            }
        }

        public void Remove(T value)
        {
            for( int i = 0; i < count; i++)
            {
                if(objects[i].Equals(value))
                {
                    RemoveAt(i);
                }
            }
        }


        public void Insert(int index, T value)
        {
            if( index >= 0 && index < count)
            {
                if (count == objects.Length)
                {
                    T[] newObjects = new T[objects.Length * 2];
                    for (int i = 0; i < count; i++)
                    {
                        newObjects[i] = objects[i];
                    }
                    objects = null;
                    objects = newObjects;
                }

                // [0][1][2][value][]
                //          3            2    
                for (int i = count; i > index + 1; i--)
                {
                    objects[i] = objects[i - 1];
                }
                objects[index + 1] = value;
                count++;
            }
        }

    }
}
