using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public class Frame : IFrame
    {
        public ITexture2D Texture { get; set; }
        public Rectangle SourceRect { get; set; }
        public float FrameDuration { get; set; }
    }
}
