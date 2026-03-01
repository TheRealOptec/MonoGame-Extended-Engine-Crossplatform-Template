using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Game_Objects
{
    /**
     * <inheritdoc/>
     * <remarks>Specialised specifically for <see cref="StdGameObjectSpace"/></remarks>
     * <seealso cref="IFilter{T, R}"/>
     * <seealso cref="StdGameObjectSpace"/>
     * <seealso cref="GameObject"/>
     */
    public class StdGameObjectSpaceFilter : IFilter<Dictionary<TagRegistry, SkipList<GameObject>>, GameObject>
    {
        // The tags to filter by
        private readonly TagRegistry[] filterTags;

        private StdGameObjectSpaceFilter(params TagRegistry[] filterTags) {
            this.filterTags = filterTags;
        }

        /**
         * <summary>
         *  Provides some semantics to filter game objects by tag
         * </summary>
         */
        public static StdGameObjectSpaceFilter FilterByTags(params TagRegistry[] filterTags) => new StdGameObjectSpaceFilter(filterTags);

        public GameObject[] Filter(Dictionary<TagRegistry, SkipList<GameObject>> structure)
        {
            ISet<GameObject> filteringSet = new HashSet<GameObject>();
            foreach (TagRegistry tag in filterTags) {
                bool validTag = structure.TryGetValue(tag, out SkipList<GameObject> objs);
                if (!validTag) continue;
                foreach (GameObject obj in objs) {
                    filteringSet.Add(obj);
                }
            }

            return filteringSet.ToArray();
        }
    }
}
