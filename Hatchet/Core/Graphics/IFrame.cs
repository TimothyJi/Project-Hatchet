using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public interface IFrame
    {
        Rectangle SourceRect { get; }
        float FrameDuration { get; }
    }
}
