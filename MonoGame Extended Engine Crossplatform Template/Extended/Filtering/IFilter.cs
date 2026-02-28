using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Filtering
{
    public interface IFilter<T, R>
    {
        /**
         * <summary>
         *  Filters the provided datastucture <paramref name="structure"/> of type <typeparamref name="T"/> based upon 
         *  the provided filter functions
         * </summary>
         */
        public R[] Filter(T structure);
    }
}
