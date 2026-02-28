using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Tags;
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
    public class GameObject : IGameObject, IPointerReference
    {

        private readonly IPointerReference pointerReference = new PointerReferenceBase();

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

        public TagRegistry[] GetTags()
        {
            throw new NotImplementedException();
        }
    }
}
