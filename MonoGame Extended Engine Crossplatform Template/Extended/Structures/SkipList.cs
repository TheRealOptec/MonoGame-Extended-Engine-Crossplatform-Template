using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures
{
    /**
     * <summary>
     *  The class <see cref="SkipList{T}"/> is an implementation of linked lists which uses large arrays to speed up the speed of random indexing
     *  while keeping this array expandable. 
     * </summary>
     */
    public class SkipList<T> : IList<T>, ICollection<T>
    {
        // The internal linked list
        private readonly LinkedList<FixedArrayList<T>> linkedList = new();
        // The size of each fixed array list
        private readonly int maxSize;

        public SkipList(int maxSize) {
            this.maxSize = maxSize;
            this.linkedList.AddLast(new FixedArrayList<T>(maxSize));
        }

        public T this[int index] {
            get {
                int upperIx = index / maxSize;
                FixedArrayList<T> innerArr = linkedList.ElementAt(upperIx);
                int lowerIx = index - upperIx * maxSize;
                return innerArr[lowerIx];
            }
            set {
                int upperIx = index / maxSize;
                FixedArrayList<T> innerArr = linkedList.ElementAt(upperIx);
                int lowerIx = index - upperIx * maxSize;
                innerArr[lowerIx] = value;
            }
        }

        /**
         * <summary>
         *  Calculates the count (size) of this <see cref="SkipList{T}"/>
         * </summary>
         * <remarks>A potentially more efficient way of this could be done where the count is stored and changed with the addition and removal of elements. </remarks>
         * <returns>The count (size) of this <see cref="SkipList{T}"/></returns>
         */
        private int CalculateCount() {
            int totalCount = 0;
            foreach (var fixedList in this.linkedList) {
                totalCount += fixedList.Count;
            }
            return totalCount;
        }

        public int Count => CalculateCount();

        // TODO - check if this is in fact IsReadOnly
        public bool IsReadOnly => true;

        public void Add(T item)
        {
            // The fixed array list which the new item will be appended to
            FixedArrayList<T> appendArr = this.linkedList.Last();
            // If the element can be added to this fixed array list then add it, otherwise create a new array list with
            // the provided item as its only element and append this new fixed array list to the internal linked list
            if (appendArr.IsSpaceRemaining()) appendArr.Add(item);
            else {
                appendArr = new FixedArrayList<T>(maxSize);
                appendArr.Add(item);
                this.linkedList.AddLast(appendArr);
            }
        }

        public void Clear()
        {
            this.linkedList.Clear();
            // Not a true clear
            this.linkedList.AddLast(new FixedArrayList<T>(maxSize));
        }

        public bool Contains(T item)
        {
            foreach (var fixedList in this.linkedList) {
                if (fixedList.Contains(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var fixedList in this.linkedList)
            {
                fixedList.CopyTo(array, arrayIndex);
                // Increase the array index so that the next copy does not overwrite this copy
                arrayIndex += fixedList.Count;
            }
        }

        public IEnumerator<T> GetEnumerator() => new SkipListEnumerator<T>(this);

        /**
         * <inheritdoc/>
         * <remarks>Will return the index of the first instance of the provided <paramref name="item"/></remarks>
         */
        public int IndexOf(T item)
        {
            foreach (var fixedList in this.linkedList) {
                int index = fixedList.IndexOf(item);
                // If the index has been found then return it
                if (index > -1) return index;
            }
            return -1;
        }

        /**
         * <inheritdoc/>
         * <remarks>Avoid this method at all costs - very very very inefficient</remarks>
         */
        public void Insert(int index, T item)
        {
            int upperIx = index / maxSize;
            int lowerIx = index - upperIx * maxSize;
            // Check if a new element needs to be added
            FixedArrayList<T> fixedArrList;
            if (upperIx == this.linkedList.Count) {
                if (lowerIx != 0) throw new IndexOutOfRangeException();
                fixedArrList = this.linkedList.AddLast(new FixedArrayList<T>(maxSize)).Value;
            }
            else fixedArrList = this.linkedList.ElementAt(upperIx);
            // Attempt to insert the element at the lower index into the fixed array list at this upper index
            try
            {
                fixedArrList.Insert(lowerIx, item);
            }
            catch (IndexOutOfRangeException)
            {
                // If element cannot be inserted then an index out of range exception is thrown
                T overflowElem = fixedArrList.OverflowInsert(lowerIx, item);
                // Attempt an insertion at the next element. 
                Insert((upperIx + 1) * maxSize, overflowElem);
            }
        }

        /**
         * <inheritdoc/>
         * <remarks>Avoid this method</remarks>
         */
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            // If the item was not found then fail
            if (index == -1) return false;
            // Otherwise remove the element and return success
            RemoveAt(index);
            return true;
        }

        /**
         * <inheritdoc/>
         * <remarks>Avoid this method</remarks>
         */
        public void RemoveAt(int index)
        {
            int upperIx = index / maxSize;
            int lowerIx = index - upperIx * maxSize;
            // Remove current element (will leave a gap with meaningless data at the end)
            FixedArrayList<T> fixedArrList = this.linkedList.ElementAt(upperIx);
            fixedArrList.RemoveAt(lowerIx);
            // Left shift next elements
            while (++upperIx < this.linkedList.Count)
            {
                FixedArrayList<T> nextFixedArrList = this.linkedList.ElementAt(upperIx);
                T poppedElem = nextFixedArrList.PopLeft();
                fixedArrList.Add(poppedElem);
                fixedArrList = nextFixedArrList;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /**
         * <summary>
         *  Gets the first <see cref="LinkedListNode{S}"/>
         * </summary>
         * <returns>The first node of the internal <see cref="LinkedList{S}"/></returns>
         */
        public LinkedListNode<FixedArrayList<T>> GetFirstNode() => this.linkedList.First;
    }
}
