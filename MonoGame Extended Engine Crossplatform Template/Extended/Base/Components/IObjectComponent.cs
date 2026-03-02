using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Flow_Control;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Allocation;
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
     *  The <see cref="IObjectComponent"/> interface provides all the operations that an object component can perform. 
     * </summary>
     * <seealso cref="IDeallocateable"/>
     * <seealso cref="IPointerReference"/>
     * <seealso cref="IGameFlow"/>
     */
    public interface IObjectComponent : IDeallocateable, IPointerReference, IGameFlow
    {

    }
}
