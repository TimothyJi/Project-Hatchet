using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Hatchet.Graphics.XML
{
    public class Frame : IFrame
    {
        [ContentSerializer(CollectionItemName = "Rectangle")]
        public Rectangle SourceRect { get; set; }

        public float Duration { get; set; }
    }
}
