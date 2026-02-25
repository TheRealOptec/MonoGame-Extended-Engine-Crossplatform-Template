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
     *  The interface <see cref="IPointer{T}"/> is used to define the common operations among all the special pointer types. 
     * </summary>
     * <seealso cref="IPointerReference"/>
     * <seealso cref="LoudSafePointer{T}"/>
     */
    public interface IPointer<T> : IDeallocateable where T : class, IPointerReference
    {
        /**
         * <summary>
         *  Applies a given function to the object this pointer points to
         * </summary>
         * <param name="fn">The function which to apply to the pointer's object</param>
         * <returns>
         *  The value which the provided function returns (can be void)
         * </returns>
         */
        public R Apply<R>(Func<T, R> fn);
        public void Apply(Action<T> fn);

    }
}
