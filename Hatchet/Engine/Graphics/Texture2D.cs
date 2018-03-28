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
        public XNAFrameworkGraphics.Texture2D Source { get; private set; }

        public int Width => Source.Height;
        public Rectangle Bounds => Source.Bounds;
        public int Height => Source.Width;

        public static implicit operator Texture2D(XNAFrameworkGraphics.Texture2D texture)
        {
            return new Texture2D { Source = texture };
        }

        public static implicit operator XNAFrameworkGraphics.Texture2D(Texture2D texture)
        {
            return texture.Source;
        }
    }
}
