using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures
{
    public class FixedArrayListEnumerator<T> : IEnumerator<T>
    {
        public T Current => this.list[index];

        object IEnumerator.Current => this.Current;

        // The fixed array list for this enumeratir
        private FixedArrayList<T> list;
        // The index of this enumerator (starts at -1)
        private int index = -1;

        public FixedArrayListEnumerator(FixedArrayList<T> list) {
            this.list = list;
        }

        public void Dispose()
        {
            // TODO - find out what this is used for
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            index++;
            return index < list.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
