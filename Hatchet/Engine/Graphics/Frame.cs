using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public class Frame : IFrame
    {
        public Rectangle SourceRect { get; set; }
        public float Duration { get; set; }
    }
}
