using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers
{
    /**
     * <summary>
     *  The interface <see cref="IPointerReference"/> allows for objects to be referenced by special pointers
     * </summary>
     */
    public interface IPointerReference : IDeallocateable
    {
        /**
         * <summary>
         *  Adds a special pointer to this pointer reference object
         * </summary>
         * <param name="p">The special pointer to be added</param>
         */
        public void AddPointer<T>(IPointer<T> p) where T : class, IPointerReference;

        /**
         * <summary>
         *  Removes the specified special pointer
         * </summary>
         * <param name="p">The special pointer to be removed</param>
         */
        public void RemovePointer<T>(IPointer<T> p) where T : class, IPointerReference;

    }
}
