using Microsoft.Xna.Framework;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Components;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering;
using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Pointers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Game_Objects
{
    /**
     * <summary>
     *  The base unit for everything within this engine.
     * </summary>
     */
    public class GameObject : IGameObject, IPointerReference, IObjectComponentable<Dictionary<Type, IObjectComponent>>
    {
        // The internal pointer reference strategy which controls the allocation of pointers to this object
        private readonly IPointerReference pointerReference = new PointerReferenceBase();

        // The tags associated with this game object
        private readonly ISet<TagRegistry> tags = new HashSet<TagRegistry>();

        // The object space where the components of this game object are stored
        private readonly StdObjectComponentSpace compSpace = new();

        public void OnDeallocate()
        {
            pointerReference.OnDeallocate();
        }

        public void AddPointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointerReference.AddPointer<T>(p);
        }

        public void RemovePointer<T>(IPointer<T> p) where T : class, IPointerReference
        {
            pointerReference.RemovePointer<T>(p);
        }

        public TagRegistry[] GetTags() => tags.ToArray();

        public void AddTags(params TagRegistry[] tags) {
            foreach (var t in tags) {
                this.tags.Add(t);
            }
        }

        public IPointer<IObjectComponent>[] GetComponents(IFilter<Dictionary<Type, IObjectComponent>, IObjectComponent> filter) => compSpace.GetObject(filter);

        public IPointer<C> CreateComponent<C>(params Action<C>[] genFns) where C : class, IObjectComponent => compSpace.CreateObjectOfType<C>(genFns);
    }
}
