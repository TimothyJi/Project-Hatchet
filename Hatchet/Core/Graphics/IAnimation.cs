using Hatchet.Graphics.Collections;

namespace Hatchet.Graphics
{
    public interface IAnimation
    {
        IFrameContainer Frames { get; }
        bool Loop { get; }
    }
}
