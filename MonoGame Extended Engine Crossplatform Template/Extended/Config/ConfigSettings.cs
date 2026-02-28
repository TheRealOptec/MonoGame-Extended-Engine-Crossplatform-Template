using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Extended_Engine_Crossplatform_Template.Extended.Config
{
    /**
     * <summary>
     *  The struct <see cref="ConfigSettings"/> is used to configure this project's settings. Configurations defined here
     *  apply globally. 
     * </summary>
     * <remarks>In future, specific instance based config settings may be implemented</remarks>
     */
    public struct ConfigSettings
    {
        // Whether or not the framerate should be capped
        public const bool CAPPED_FRAME_RATE = true;
        // If the framerat is capped then what should it be capped to
        public const double MAX_FPS = 150d;
    }
}