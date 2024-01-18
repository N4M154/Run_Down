using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreboard
{
    public class CustomList<T>
    {
        private T[] items;
        private int count;

        public CustomList()
        {
            items = new T[0];
            count = 0;
        }

        public void Add(T item)
        {
            EnsureCapacity(count + 1);
            items[count] = item;
            count++;
        }

        private void EnsureCapacity(int min)
        {
            if (items.Length < min)
            {
                int newCapacity = items.Length == 0 ? 4 : items.Length * 2;
                if (newCapacity < min)
                    newCapacity = min;
                ResizeArray(newCapacity);
            }
        }

        private void ResizeArray(int newCapacity)
        {
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }

        public T[] ToArray()
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = items[i];
            }
            return result;
        }
    }

}
