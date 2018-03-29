using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Hatchet.Graphics.XML
{
    public class OptionalTextureFrame : IFrame
    {
        [ContentSerializer(Optional = true)]
        public ITexture2D Texture { get; set; }
        [ContentSerializer(ElementName = "Rectangle")]
        public Rectangle SourceRect { get; set; }
        [ContentSerializer(ElementName = "Duration")]
        public float FrameDuration { get; set; }
    }
}
