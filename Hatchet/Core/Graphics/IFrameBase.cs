using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public interface IFrameBase
    {
        Rectangle SourceRect { get; }
        float Duration { get; }
    }
}
