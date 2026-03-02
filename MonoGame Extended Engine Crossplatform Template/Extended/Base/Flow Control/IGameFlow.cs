using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Flow_Control
{
    /**
     * <summary>
     *  The <see cref="IGameFlow"/> interface is used to define objects which can have their flow controlled by the game's update cycle. 
     * </summary>
     * <remarks>Methods need to be specifically implemented otherwise the default behaviour of doing nothing will be used</remarks>
     */
    public interface IGameFlow
    {
        /**
         * <summary>
         *  Executes every frame (i.e. every update cycle)
         * </summary>
         */
        public void OnFrame() { }
    }
}
