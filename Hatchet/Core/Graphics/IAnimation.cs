using Hatchet.Graphics.Collections;

namespace Hatchet.Graphics
{
    public interface IAnimation
    {
        IFrameCollection FrameContainer { get; }
        bool Loop { get; }
    }
}
