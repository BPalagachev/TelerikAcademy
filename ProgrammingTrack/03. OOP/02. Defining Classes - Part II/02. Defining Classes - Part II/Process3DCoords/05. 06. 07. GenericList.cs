using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GenericList<T> where T : IComparable
    {
        // Task 6 
        private const int DEFAULT_CAPACITY = 4;
        // Task 5 
        private int capacity;
        private T[] storage;

        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity must not be negavite number!");
                }
                this.capacity = value;
            }
        }

        public GenericList(int aCapacity)
        {
            this.Capacity = aCapacity;
            storage = new T[this.Capacity];
            Count = 0;
        }
        // Task 6 - Default Capacity constructor
        public GenericList()
            : this(DEFAULT_CAPACITY)
        {
        }

        public void Add(T newItem)
        {
            // task 6 - Implement Resizing
            if (Capacity == Count)
            {
                Capacity *= 2;
                T[] newArray = new T[Capacity];
                Array.Copy(this.storage, newArray, storage.Length);
                this.storage = newArray;
            }
            storage[Count] = newItem;
            Count++;
        }
        public void RemoveAt(int index)
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("Cannot remove an element from empty list!");
            }
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index element! Index must be between 0 and Count-1.");
            }
            for (int i = index; i < Count; i++)
            {
                this.storage[i] = this.storage[i + 1];
            }
            this.Count--;
        }
        public void InsertAt(int index, T newItem)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index element! Index must be between 0 and Count-1.");
            }
            for (int i = Count; i > index; i--)
            {
                this.storage[i] = this.storage[i - 1];
            }
            this.storage[index] = newItem;
            this.Count++;
        }
        public void ClearAll()
        {
            this.Count = 0;
            this.storage = new T[this.Capacity];
        }
        public int Find( T itemToLookFor)
        {
            for (int i = 0; i < Count; i++)
            {
                if (storage[i].CompareTo(itemToLookFor) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "List is empty!";
            }
            StringBuilder pathTextRepresentation = new StringBuilder();
            StringFormater.IsIndent = false;
            StringFormater.LineLength = 50;
            string title = String.Format("List of {0} elements", this.Count);
            pathTextRepresentation.Append(StringFormater.CenterTitle(title) + "\n\r");
            for (int i = 0; i < this.Count; i++)
            {
                pathTextRepresentation.Append(StringFormater.FormatLine<string>(
                    String.Format("element {0}", i), storage[i].ToString()));
            }
            return pathTextRepresentation.ToString();
        }
        public T this[int index]
        {
            get
            {
                return storage[index];
            }
        }
        // Task 7 
        public T GetMin()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty!");
            }
            dynamic temp = this.storage[0];
            for (int i = 1; i < Count; i++)
            {
                if (this.storage[i].CompareTo(temp) < 0)
                {
                    temp = storage[i];
                }
            }
            return temp;
        }
        public T GetMax()
        {
            if (Count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty!");
            }
            dynamic temp = this.storage[0];
            for (int i = 1; i < Count; i++)
            {
                if (this.storage[i].CompareTo(temp) > 0)
                {
                    temp = storage[i];
                }
            }
            return temp;
        }
    }
}
