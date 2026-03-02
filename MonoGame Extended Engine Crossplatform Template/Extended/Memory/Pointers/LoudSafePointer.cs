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
     * <seealso cref="IPointerReference"/>
     * <seealso cref="IPointer{T}"/>
     */
    public struct LoudSafePointer<T> : IPointer<T>
        where T : class, IPointerReference
    {
        private T val;

        public LoudSafePointer(T val) {
            this.val = val;
        }

        /**
         * <inheritdoc/>
         * <exception cref="NullReferenceException">
         *  Thrown when the pointer's object has been deallocated and the provided function attempts to make use of it. 
         * </exception>
         */
        public readonly R Apply<R>(Func<T, R> fn) => fn(val);

        public readonly void Apply(Action<T> fn) => fn(val);

        /**
         * <remarks>
         *  Sets internal reference value to null
         * </remarks>
         * <inheritdoc/>
         */
        public void OnDeallocate()
        {
            val = null;
        }

        public static IPointer<T> Encapsulate(T val) => new LoudSafePointer<T>(val);

        // Redefined since not compiling without this redefinition
        public static IPointer<T>[] EncapsulateAll(params T[] vals)
        {
            IPointer<T>[] ret = new IPointer<T>[vals.Length];
            for (int i = 0; i < ret.Length; i++) ret[i] = Encapsulate(vals[i]);
            return ret;
        }
    }
}
