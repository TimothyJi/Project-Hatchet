using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public struct Frame : IFrame
    {
        public ITexture2D Texture { get; set; }
        public Rectangle SourceRect { get; set; }
        public float Duration { get; set; }
    }
}
