using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Allocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers
{
    /**
     * <summary>
     *  Provides some base functionality for pointer reference objects (see <see cref="IPointerReference"/>). 
     *  This class should not be inherited from, but instead used as a property. 
     * </summary>
     */
    public class PointerReferenceBase : IPointerReference
    {
        
        // Create a dictionary mapping type to a hashset of misc objects
        // These objects will be casted as necessary when required
        // While this would be unsafe - only IPointer<T> types can be added so unchecked casts can be done
        private readonly Dictionary<Type, HashSet<Object>> pointers = new();

        public void OnDeallocate()
        {
            // Run every pointer's on deallocation behaviour
            foreach (var s in pointers.Values) {
                foreach (Object obj in s) {
                    IDeallocateable dealObj = (IDeallocateable) obj;
                    dealObj.OnDeallocate();
                }
            }
            // Clear pointer structure
            pointers.Clear();
        }

        public void AddPointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointers.TryGetValue(typeof(T), out HashSet<object> pSet);
            // If type set is not present them create a new one
            if (pSet == null) {
                pSet = new();
                pointers[typeof(T)] = pSet;
            }
            pSet.Add(p);
        }

        public void RemovePointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointers.TryGetValue(typeof(T), out HashSet<object> pSet);
            pSet?.Remove(p);
        }
    }
}
