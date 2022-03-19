using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Practice_DynamicArray
    {
        class DynamicArray<T>
        {
            const int DEFAULT_SIZE = 1;
            T[] _data = new T[DEFAULT_SIZE];

            public int count;
            public int capacity
            {
                get 
                { 
                    return _data.Length; 
                }
            }

            public void Add(T item)
            {
                if(count >= capacity)
                {
                    T[]newArray = new T[count * 2];
                    for (int i = 0; i < count; i++)
                    {
                        newArray[i] = _data[i];
                    }
                    _data = newArray;
                }
                _data[count] = item;
                count++;
            }

            public T this[int index]
            {
                get
                {
                    return _data[index];
                }

                set
                {
                    _data[index] = value;
                }
            }

            public void RemoveAt(int index)
            {
                for (int i = index; i < count - 1; i++)
                {
                    _data[i] = _data[i + 1];
                }
                _data[count - 1] = default(T);
                count--;
            }

            public bool Remove(T item)
            {
                bool isFounded = false;
                for (int i = count - 1; i > - 1; i++)
                {
                    if(Comparer<T>.Default.Compare(_data[i], item) == 0)
                    {
                        RemoveAt(i);
                        isFounded = true;
                        break;
                    }   
                }
                
                return isFounded;
            }

            public void Clear()
            {
                for (int i = 0; i < count - 1; i++)
                {
                    _data[i] = default(T);
                }
                _data = new T[DEFAULT_SIZE];
                count = 0;
            }
        }

        public void DoExample()
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();

            dynamicArray.Add(1);
            dynamicArray.Add(2);
            dynamicArray.Add(3);
            Console.WriteLine($"count : {dynamicArray.count}");
            Console.WriteLine($"last item : {dynamicArray[dynamicArray.count - 1]}");
            dynamicArray.RemoveAt(dynamicArray.count - 1);
            Console.WriteLine($"last item removed");
            Console.WriteLine($"count : {dynamicArray.count}");
            dynamicArray.Clear();
            Console.WriteLine($"Cleared");
            Console.WriteLine($"count : {dynamicArray.count}");
        }
    }
}
