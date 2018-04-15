using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    /// <summary>
    /// Uses Microsoft.Xna.Framework.Graphics.Texture2D internally.
    /// Created to be more easily Mockable for testing purposes.
    /// </summary>
    public class HatchetTexture2D : IHatchetTexture2D
    {
        public Texture2D XNAVariant { get; private set; }

        public int Width => XNAVariant.Width;
        public Rectangle Bounds => XNAVariant.Bounds;
        public int Height => XNAVariant.Height;

        public static implicit operator HatchetTexture2D(Texture2D texture)
        {
            return new HatchetTexture2D { XNAVariant = texture };
        }

        public static implicit operator Texture2D(HatchetTexture2D texture)
        {
            return texture.XNAVariant;
        }

        public override bool Equals(object obj)
        {
            return XNAVariant.Equals(obj);
        }

        public override int GetHashCode()
        {
            return XNAVariant.GetHashCode();
        }

        public override string ToString()
        {
            return XNAVariant.ToString();
        }
    }
}
