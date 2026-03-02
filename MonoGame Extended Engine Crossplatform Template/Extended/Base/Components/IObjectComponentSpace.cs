using MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Base.Components
{
    public interface IObjectComponentSpace<T> : IObjectSpace<IObjectComponent, T>
    {
    }
}
