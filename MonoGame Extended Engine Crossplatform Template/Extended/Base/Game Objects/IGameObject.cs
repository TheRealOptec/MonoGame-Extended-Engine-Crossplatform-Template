using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base
{
    /**
     * <summary>
     *  Defines the operations that all <see cref="GameObject"/> utilise. 
     * </summary>
     */
    public interface IGameObject
    {
        /**
         * <summary>
         *  Getter for this game object's tags
         * </summary>
         * <returns>
         *  An array of tags (tags are defined at <see cref="TagRegistry"/>)
         * </returns>
         * <seealso cref="TagRegistry"/>
         */
        public TagRegistry[] GetTags();

        /**
         * <summary>
         *  Adds the specified tags to this game object
         * </summary>
         */
        public void AddTags(params TagRegistry[] tags);
    }
}
