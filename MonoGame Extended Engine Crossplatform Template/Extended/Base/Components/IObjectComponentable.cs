using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Components
{
    /**
     * <summary>
     *  The <see cref="IObjectComponentable"/> interface describes objects which can have object components on them. 
     * </summary>
     * <remarks>The type <typeparamref name="T"/> describes the internal data structure which is used to store the components. </remarks>
     */
    public interface IObjectComponentable<T>
    {
        /**
         * <summary>
         *  Gets the components which match the given filter
         * </summary>
         * <param name="filter">
         *  An <see cref="IFilter{T, R}"/> object which will define how to filter the object components. 
         * </param>
         * <returns>
         *  An array of special pointers (<see cref="IPointer{T}"/>) which reference
         *  <see cref="IObjectComponent"/> objects which match the specified <see cref="IFilter{T, R}"/>
         * </returns>
         */
        public IPointer<IObjectComponent>[] GetComponents(IFilter<T, IObjectComponent> filter);

        /**
         * <summary>
         *  Creates an <see cref="IObjectComponent"/> of type <typeparamref name="C"/> and adds this component to this object. 
         * </summary>
         * <param name="genFns">
         *  An array of functions which can be used to set up the <see cref="IObjectComponent"/> before it is added to this object. 
         * </param>
         * <returns>
         *  A special pointer (<see cref="IPointer{C}"/>) pointing at the newly created <see cref="IObjectComponent"/>. 
         * </returns>
         */
        public IPointer<C> CreateComponent<C>(params Action<C>[] genFns) where C : class, IObjectComponent;
    }
}
