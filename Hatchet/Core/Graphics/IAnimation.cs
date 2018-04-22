using System.Collections.Generic;

namespace Hatchet.Graphics
{
    public interface IAnimation
    {
        List<IFrame> Frames { get; }
        bool Loop { get; }
    }
}
