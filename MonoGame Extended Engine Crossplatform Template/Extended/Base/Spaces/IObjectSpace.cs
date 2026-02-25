using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces
{
    /**
     * <summary>
     *  The <see cref="IObjectSpace"/> interface provides an abstract representation of the operations of a structure that holds objects of a 
     *  specific type. 
     * </summary>
     * <remarks>
     *  <typeparamref name="T"/> must be a class that implements <see cref="IPointerReference"/>
     * </remarks>
     * <seealso cref="IPointerReference"/>
     */
    public interface IObjectSpace<T, S> where T : class, IPointerReference
    {
        /**
         * <summary>
         *  Gets objects based upon the provided filter. 
         * </summary>
         * <param name="filter">A filter which controls which objects should be returned (see <see cref="IFilter{T, R}"/>)</param>
         * <returns>
         *  An array of <typeparamref name="T"/> matching the specified filter conditions.
         * </returns>
         */
        public T[] GetObject(IFilter<S, T> filter);

        /**
         * <summary>
         *  Creates an object within this object space. 
         * </summary>
         * <param name="genFns">Functions to apply on this object as it is created</param>
         * <returns>
         *  A special pointer to the this newly created object (see <see cref="IPointer{T}"/>)
         * </returns>
         */
        public IPointer<T> CreateObject(params Action<T>[] genFns);
    }
}
