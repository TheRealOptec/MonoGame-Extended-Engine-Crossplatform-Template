using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers.Tests
{
    /**
     * <summary>
     *  A class designed to be similar to how pointer reference objects would be made. This is purely for tests. 
     * </summary>
     */
    public class TestPointerReference : IPointerReference
    {
        private readonly PointerReferenceBase pointerReferenceBase = new();

        public void OnDeallocate()
        {
            pointerReferenceBase.OnDeallocate();
        }

        public void AddPointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointerReferenceBase.AddPointer(p);
        }

        public void RemovePointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointerReferenceBase.RemovePointer(p);
        }
    }
}
