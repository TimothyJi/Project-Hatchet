using Microsoft.Xna.Framework;
using XNAFrameworkGraphics = Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    /// <summary>
    /// Uses Microsoft.Xna.Framework.Graphics.Texture2D internally.
    /// Created to be more easily Mockable for testing purposes.
    /// </summary>
    public class Texture2D : ITexture2D
    {
        public XNAFrameworkGraphics.Texture2D XNAVariant { get; private set; }

        public int Width => XNAVariant.Height;
        public Rectangle Bounds => XNAVariant.Bounds;
        public int Height => XNAVariant.Width;

        public static implicit operator Texture2D(XNAFrameworkGraphics.Texture2D texture)
        {
            return new Texture2D { XNAVariant = texture };
        }

        public static implicit operator XNAFrameworkGraphics.Texture2D(Texture2D texture)
        {
            return texture.XNAVariant;
        }
    }
}
