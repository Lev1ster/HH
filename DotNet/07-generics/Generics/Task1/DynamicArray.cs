using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class DynamicArray<T> where T : new() 
    {
        private T[] _items;
        private int _size;

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
        }

        public int Lenght
        {
            get
            {
                return _size;
            }
        }

        static readonly T[] _emptyArray = new T[0];
        public DynamicArray()
        {
            _size = 8;
            _items = new T[_size];            
        }
        public DynamicArray(int size)
        {
            if (size > 0)
            {
                _size = size;
                _items = new T[_size];
            }
            else
            {
                if (size == 0)
                {
                    _items = _emptyArray;
                    _size = 0;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public DynamicArray(T[] array)
        {
            if (array == null)
            {
                _items = _emptyArray;
                _size = 0;
            }
            else
            {
                _size = array.Length;
                _items = new T[_size];
                array.CopyTo(_items, 0);
            }    
        }
        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        public class MyEnumerator
        {
            int nIndex;
            DynamicArray<T> array;
            public MyEnumerator(DynamicArray<T> arr)
            {
                array = arr;
                nIndex = -1;
            }

            public bool MoveNext()
            {
                nIndex++;
                return nIndex < array._size;
            }
            public T Current
            {
                get
                { 
                    return array._items[nIndex]; 
                }
            }
        }

        

        public void Add(T element)
        {
            if(_items.Length == _size)
            {
                Array.Resize(ref _items, _items.Length * 2);
                _size++;
                _items[_size - 1] = element;
            }
            else
            {
                _size++;
                _items[_size - 1] = element;
            }
        }

        public void AddRange(T[] array)
        {
            if (_items.Length < _size + array.Length)
            {
                Array.Resize(ref _items, _items.Length + array.Length);
                array.CopyTo(_items, _size);
                _size += array.Length;
            }
            else
            {
                array.CopyTo(_items, _size);
                _size += array.Length;
            }
        }

        public bool Remove(T element)
        {
            bool isCheck = false;
            for (int i = 0; i < Capacity; i++)
            {
                if (Equals(_items[i], element))
                {
                    Array.Clear(_items, i, 1);
                    LeftShift(i);
                    _size--;
                    isCheck = true;
                }
            }
            return isCheck;
        }

        public void Insert(T element, int index)
        {
            if (index < Capacity)
            {
                if ((Lenght + 1) > Capacity && index < Lenght)
                {
                    Array.Resize(ref _items, _items.Length + 1);
                }
                RightShift(index);
                _items[index] = element;
                _size++;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        private void LeftShift(int index)
        {
            for (int i = index; i < Lenght - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            Array.Clear(_items, Capacity - 1, 1);
        }

        private void RightShift(int index)
        {
            for (int i = Lenght; i > index; i--)
            {
                _items[i] = _items[i-1];
            }
            Array.Clear(_items, index, 1);
        }

        public T this[int index]
        {
            get
            {
                if (index < Lenght)
                {
                    return _items[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (index < Lenght)
                {
                    _items[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
