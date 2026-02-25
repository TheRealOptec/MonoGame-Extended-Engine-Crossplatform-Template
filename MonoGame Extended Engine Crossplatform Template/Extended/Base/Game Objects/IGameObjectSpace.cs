using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Game_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces
{
    /**
     * <summary>
     *  An abstract representation of a container of <see cref="IGameObject"/>
     * </summary>
     * <remarks>
     *  <typeparamref name="S"/> is the type of internal <see cref="IGameObjectSpace{S}"/> structure. 
     * </remarks>
     * <inheritdoc/>
     */
    public interface IGameObjectSpace<S> : IObjectSpace<GameObject, S>
    {
    }
}
