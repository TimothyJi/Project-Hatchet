using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public class TexturePart : ITexturePart
    {
        public Rectangle Rectangle { get; set; }
        Rectangle IHasSourceRect.SourceRect { get => Rectangle; set => Rectangle = value; }

        public TexturePart(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }
    }
}
