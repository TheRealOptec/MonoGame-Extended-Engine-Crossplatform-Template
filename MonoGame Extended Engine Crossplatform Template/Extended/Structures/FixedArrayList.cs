using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures
{
    public struct FixedArrayList<T> : IList<T>
    {
        // The internal array structure
        private T[] arr;
        // The index at which point the next element will be inserted
        private int appendIx = 0;
        public FixedArrayList(int maxSize) {
            arr = new T[maxSize];
        }

        public T this[int index] {
            get {
                if (index > this.appendIx) throw new IndexOutOfRangeException();
                return arr[index];
            }
            readonly set {
                if (index > this.appendIx) throw new IndexOutOfRangeException();
                arr[index] = value;
            }
        }

        public readonly int Count => this.appendIx;

        public readonly bool IsReadOnly => arr.IsReadOnly;

        public void Add(T item)
        {
            // Out of bounds case already covered by the setter
            this.arr[appendIx] = item;
            this.appendIx++;
        }

        public void Clear()
        {
            this.arr = new T[this.arr.Length];
        }

        public readonly bool Contains(T item)
        {
            // This has be done manually instead of by using this.arr.Contains to avoid checking elements with meaningless values (i.e. elements after the appendIx)
            for (int i = 0; i < this.appendIx; i++) {
                if (this.arr[i].Equals(item)) return true;
            }
            return false;
        }

        public readonly void CopyTo(T[] array, int arrayIndex)
        {
            // Again, this has been done manually to prevent copying meaningless values
            for (int i = 0; i < this.appendIx; i++) {
                array[arrayIndex + i] = this.arr[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // TODO - learn about IEnumerators and implement this
            throw new NotImplementedException();
        }

        /**
         * <inheritdoc/>
         * <remarks>Will return the index of the first instance. </remarks>
         */
        public readonly int IndexOf(T item)
        {
            for (int i = 0; i < this.appendIx; i++) {
                if (this.arr[i].Equals(item)) return i;
            }
            return -1;
        }

        /**
         * <inheritdoc/>
         * <remarks>This method should be avoided.</remarks>
         */
        public void Insert(int index, T item)
        {
            // Shift elements after the index right by 1
            // Weird backwards loop
            for (int i = this.appendIx; i > index; i--) {
                this.arr[i] = this.arr[i - 1];
            }
            this.appendIx++;
            this.arr[index] = item;
        }

        /**
         * <summary>
         *  Inserts an <paramref name="item"/> at a given <paramref name="index"/> and returns the overflow character. 
         * </summary>
         * <remarks>Assumes that there is overflow - so make sure to check that there will be overflow before running this. </remarks>
         * <returns>The element which has been deleted due to the overflow. </returns>
         */
        public readonly T OverflowInsert(int index, T item) {
            T overflowElem = this.arr[^1];
            for (int i = this.arr.Length - 1; i > index; i++) {
                this.arr[i] = this.arr[i - 1];
            }
            this.arr[index] = item;
            return overflowElem;
        }

        /**
         * <inheritdoc/>
         * <remarks>This method should be avoided.</remarks>
         */
        public bool Remove(T item)
        {
            // Get the index of removal
            int index = IndexOf(item);
            // If no item was found then fail
            if (index == -1) return false;
            // Otherwise remove the element
            RemoveAt(index);
            return true;
        }

        /**
         * <inheritdoc/>
         * <remarks>This method should be avoided.</remarks>
         */
        public void RemoveAt(int index)
        {
            // Shift all elements after the index left
            for (int i = index; i < this.appendIx; i++) {
                this.arr[i] = this.arr[i + 1];
            }
            this.appendIx--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // TODO - learn about IEnumerators and implement this
            throw new NotImplementedException();
        }

        /**
         * <summary>
         *  Calculates whether or not there is space remaining in this <see cref="FixedArrayList{T}"/> for adding or inserting an element. 
         * </summary>
         * <returns>
         *  True if there is space remaining (i.e. element can be added or inserted) and false if not. 
         * </returns>
         */
        public readonly bool IsSpaceRemaining() => this.appendIx < this.arr.Length;

        /**
         * <summary>
         *  Removes the first element (i.e. leftmost) from the <see cref="FixedArrayList{T}"/>
         * </summary>
         * <returns>
         *  The item that was popped. 
         * </returns>
         */
        public T PopLeft() {
            // TODO - implement IQueue (or whatever interface it is) and implement all required methods
            T poppedItem = this.arr[0];
            RemoveAt(0);
            return poppedItem;
        }
    }
}
