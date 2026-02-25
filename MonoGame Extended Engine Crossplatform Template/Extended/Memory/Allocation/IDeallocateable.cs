using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Memory.Allocation
{
    /**
     * <summary>
     *  Represents objects or things that can be deallocated or have behaviour upon something being deallocated
     * </summary>
     */
    public interface IDeallocateable
    {
        /**
         * <summary>
         *  Runs upon a deallocation event being called on this object
         * </summary>
         */
        public void OnDeallocate();
    }
}
