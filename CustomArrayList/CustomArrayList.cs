using System.Collections;

namespace ArrayList
{
    public class CustomArrayList : IArrayList
    {
        private const double IncreaseCoef = 1.33;
        private const int DefaultSize = 4;
        private int[] _array;
        private int _currentCount = 0;

        public int Capacity => _array.Length;
        public int Length => _currentCount;

        public CustomArrayList() : this(DefaultSize) { }

        public CustomArrayList(int[] array)
        {
            _array = array ?? throw new NullReferenceException ("array is null");
            _currentCount = array.Length;
        }

        public CustomArrayList(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("size is negative");
            }

            _array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < _array.Length)
                {
                    return _array[index];
                }
                else
                {
                    throw new ArgumentException("Incorrect index");
                }
            }
            set
            {
                if (index >= 0 && index < _array.Length)
                {
                    _array[index] = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect index");
                }
            }
        }

        public void AddByIndex(int index, int element)
        {
            if (index < 0 || index > _array.Length)
            {
                throw new ArgumentException("Incorrect index");
            }

            if (Length == Capacity)
            {
                Resize(Convert.ToInt32(Capacity * IncreaseCoef));
            }
            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = element;
            _currentCount++;
        }

        public void AddRangeToBegin(int[] range) => AddRangeToIndex(0, range);

        public void AddRangeToEnd(int[] range) => AddRangeToIndex(Length, range);

        public void AddRangeToIndex(int index, int[] range)
        {
            if (index < 0 || index > _array.Length)
            {
                throw new ArgumentException("Incorrect index");
            }

            if (Length + range.Length >= Capacity)
            {
                Resize(Capacity + range.Length);
            }

            var tempArray = Copy(_array);
            for (int i = index, j = 0; j < range.Length; ++i, ++j)
            {
                tempArray[i] = range[j];
            }

            for (int i = index + range.Length; i < Capacity; i++)
            {
                tempArray[i] = _array[i - range.Length];
            }

            _currentCount += range.Length;
            _array = tempArray;
        }

        public void AddToBegin(int element) => AddByIndex(0, element);

        public void AddToEnd(int element)
        {
            if (Length == Capacity)
            {
                Resize(Convert.ToInt32(Capacity * IncreaseCoef));
            }

            _array[_currentCount++] = element;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        public int GetIndexByValue(int value)
        {
            var index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                }
            }
            return index;
        }

        public int IndexOfMax()
        {
            int maxIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                maxIndex = _array[i] > _array[maxIndex] ? i : maxIndex;
            }
            return maxIndex;
        }

        public int IndexOfMin()
        {
            int minIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                minIndex = _array[i] < _array[minIndex] ? i : minIndex;
            }
            return minIndex;
        }

        public int Max() => _array[IndexOfMax()];

        public int Min() => _array[IndexOfMin()];

        public int RemoveAll(int value)
        {
            var count = 0;
            while (RemoveByValue(value) != -1)
            {
                count++;
            }
            return count;
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[--_currentCount] = default;
        }

        public int RemoveByValue(int value)
        {
            var index = GetIndexByValue(value);
            RemoveByIndex(index);
            return index;
        }

        public void RemoveFromBegin() => RemoveByIndex(0);

        public void RemoveFromEnd() => RemoveByIndex(Length);

        public void RemoveRangeByIndex(int index, int count)
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new ArgumentException("Incorrect index");
            }

            if (count + index > Length)
            {
                throw new ArgumentException("Invalid combination of index and count");
            }

            for (int i = index; i < Length - count; i++)
            {
                _array[i] = _array[i + count];
            }
            _currentCount -= count;
        }

        public void RemoveRangeFromBegin(int count)
        {
            RemoveRangeByIndex(0, count);
        }

        public void RemoveRangeFromEnd(int count)
        {
            RemoveRangeByIndex(Length, count);
        }

        public void Reverse()
        {
            for (int i = 0, j = Length - 1; i < j; ++i, --j)
            {
                Swap(ref _array[i], ref _array[j]);
            }
        }

        public void SortFromMax()
        {
            Sort(false);
        }

        public void SortFromMin()
        {
            Sort(true);
        }

        private void Resize(int newSize)
        {
            var tempArray = new int[newSize];
            for (int i = 0; i < Length; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        public void Sort(bool ascending)
        {
            var coef = ascending ? 1 : -1;
            for (int i = 0; i < Length; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == coef)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }
        private static int[] Copy(int[] array)
        {
            var temp = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            return temp;
        }
    }
}
