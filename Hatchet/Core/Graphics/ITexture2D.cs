using Microsoft.Xna.Framework;
using XNAFrameworkGraphics = Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface ITexture2D : IXNAAlternative<XNAFrameworkGraphics.Texture2D>
    {
        int Width { get; }
        Rectangle Bounds { get; }
        int Height { get; }
    }
}
