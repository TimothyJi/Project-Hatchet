using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Hatchet.Graphics.XML
{
    public struct Frame : IFrame
    {
        [ContentSerializer(Optional = true, AllowNull = true)]
        public IHatchetTexture2D Texture { get; set; }

        [ContentSerializer(ElementName = "Rectangle")]
        public Rectangle SourceRect { get; set; }
        
        public float Duration { get; set; }

        public Frame(IHatchetTexture2D texture, Rectangle sourceRect, float duration)
        {
            Texture = texture;
            SourceRect = sourceRect;
            Duration = duration;
        }
    }
}
