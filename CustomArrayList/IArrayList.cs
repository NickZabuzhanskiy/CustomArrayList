using System.Collections;

namespace ArrayList
{
    public interface IArrayList : IEnumerable
    {
        void AddToEnd(int element);
        void AddToBegin(int element);
        void AddByIndex(int index, int element);
        void RemoveFromBegin();
        void RemoveFromEnd();
        void RemoveByIndex(int index);
        void RemoveRangeFromEnd(int count);
        void RemoveRangeFromBegin(int count);
        void RemoveRangeByIndex(int index, int count);
        int GetIndexByValue(int value);
        void Reverse();
        int Max();
        int Min();
        int IndexOfMax();
        int IndexOfMin();
        void SortFromMin();
        void SortFromMax();
        int RemoveByValue(int value);
        int RemoveAll(int value);
        void AddRangeToEnd(int[] range);
        void AddRangeToBegin(int[] range);
        void AddRangeToIndex(int index, int[] range);
    }
}
