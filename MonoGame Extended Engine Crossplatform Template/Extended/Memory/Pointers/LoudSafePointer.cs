using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers
{
    /**
     * <summary>
     *  Class <see cref="LoudSafePointer{T}"/> maintain the memory safety by setting their internal pointer value to null when it needs deallocating
     *  However, any functions involving its internal value will not do any null checks and thus will fail loudly
     * </summary>
     * <seealso cref="IPointer{T}"/>
     */
    public readonly struct LoudSafePointer<T> : IPointer<T>
        where T : class
    {
        private readonly T val;
        public LoudSafePointer(T val) {
            this.val = val;
        }
        
        /**
         * <inheritdoc/>
         * <exception cref="NullReferenceException">
         *  Thrown when the pointer's object has been deallocated and the provided function attempts to make use of it. 
         * </exception>
         */
        public R Apply<R>(Func<T, R> fn) => fn(val);
    }
}
