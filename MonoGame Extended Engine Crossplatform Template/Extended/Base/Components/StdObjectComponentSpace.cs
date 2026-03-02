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
    public class StdObjectComponentSpace : IObjectComponentSpace<Dictionary<Type, IObjectComponent>>
    {
        // The object components associated with this object space
        // Assumes that there will only be one object component of a certain type attached to this object space
        private readonly Dictionary<Type, IObjectComponent> comps = new();

        public IPointer<IObjectComponent>[] GetObject(IFilter<Dictionary<Type, IObjectComponent>, IObjectComponent> filter)
        {
            IObjectComponent[] filterResults = filter.Filter(this.comps);
            return LoudSafePointer<IObjectComponent>.EncapsulateAll(filterResults);
        }

        public IPointer<IObjectComponent> CreateObject(params Action<IObjectComponent>[] genFns)
        {
            throw new NotImplementedException();
        }

        public IPointer<A> CreateObjectOfType<A>(params Action<A>[] genFns) where A : class, IObjectComponent
        {
            throw new NotImplementedException();
        }

        // Requires overwriting for some reason
        public static Type GetStructureType() => typeof(Dictionary<Type, IObjectComponent>);
    }
}
