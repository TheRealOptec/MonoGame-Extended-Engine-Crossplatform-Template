using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Game_Objects
{
    public class StdGameObjectSpace : IGameObjectSpace<Dictionary<TagRegistry, SkipList<GameObject>>>
    {
        // The internal game object storage structure
        // This is the standard structure since it is expected that game object's will mostly be filtered by their tag
        private readonly Dictionary<TagRegistry, SkipList<GameObject>> spaceObjs = new();

        // The standard size of each skiplist's nodes
        private const int STD_SKIP_SIZE = 64;

        public IPointer<GameObject> CreateObject(params Action<GameObject>[] genFns)
        {
            // Create a new game object
            GameObject newObj = new();
            // Apply the generation functions on this new game object
            foreach (var fn in genFns) fn(newObj);
            // Add this new game object to the object space
            foreach (var tag in newObj.GetTags()) {
                spaceObjs.TryGetValue(tag, out SkipList<GameObject> tagObjList);
                if (tagObjList == null) {
                    spaceObjs[tag] = new SkipList<GameObject>(STD_SKIP_SIZE);
                }
                spaceObjs[tag].Add(newObj);
            }
            // Create special safe pointer for this game object
            // TODO - change this to a non-loud safe pointer (when implemented obviously)
            return new LoudSafePointer<GameObject>(newObj);
        }

        public GameObject[] GetObject(IFilter<Dictionary<TagRegistry, SkipList<GameObject>>, GameObject> filter)
        {
            return filter.Filter(spaceObjs);
        }
    }
}
