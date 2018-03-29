using System.Collections.Generic;

namespace Hatchet.Graphics.Collections
{
    public interface IFrameContainer
    {
        ITexture2D DefaultTexture { get; }
        List<IFrame> Frames { get; }
    }
}
