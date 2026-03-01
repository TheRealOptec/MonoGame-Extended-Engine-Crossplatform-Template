using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures
{
    public class SkipListEnumerator<T> : IEnumerator<T>
    {
        public T Current => nodeEnumerator.Current;

        object IEnumerator.Current => throw new NotImplementedException();

        // The skip list to enumerate over
        private readonly SkipList<T> skipList;
        // The current node in the underlying skip list's linked list
        private LinkedListNode<FixedArrayList<T>> currentNode = null;
        private IEnumerator<T> nodeEnumerator = null;

        public SkipListEnumerator(SkipList<T> skipList) {
            this.skipList = skipList;
        }

        public void Dispose()
        {
            // TODO - find out what this is used for
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (currentNode == null)
            {
                currentNode = skipList.GetFirstNode();
                nodeEnumerator = currentNode.Value.GetEnumerator();
            }
            bool validEnumerator = nodeEnumerator.MoveNext();
            while (!validEnumerator) {
                currentNode = currentNode.Next;
                if (currentNode == null) return false;

                nodeEnumerator = currentNode.Value.GetEnumerator();
                validEnumerator = nodeEnumerator.MoveNext();
            }

            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
        }
    }
}
