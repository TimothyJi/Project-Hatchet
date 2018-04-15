using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface IHatchetTexture2D : IAlternative<Texture2D>
    {
        int Width { get; }
        Rectangle Bounds { get; }
        int Height { get; }
    }
}
