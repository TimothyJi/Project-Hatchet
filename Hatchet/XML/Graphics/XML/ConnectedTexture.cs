using Hatchet.XML;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Text;

namespace Hatchet.Graphics.XML
{
    public class ConnectedTexture : XMLContent
    {
        public IHatchetTexture2D Texture { get; set; }

        [ContentSerializer(ElementName = "ConnectionMap", CollectionItemName = "ConnectionPart")]
        public Dictionary<Directions, ITexturePart> TextureParts { get; set; }

        public ConnectedTexture(IHatchetTexture2D texture, Dictionary<Directions, ITexturePart> textureParts)
        {
            Texture = texture;
            TextureParts = textureParts;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(null, TextureParts.Count);
            stringBuilder.AppendLine(Texture.XNAVariant.ToString());
            foreach (var part in TextureParts)
            {
                stringBuilder.AppendLine(part.Key + ": " + part.Value.SourceRect);
            }
            return stringBuilder.ToString();
        }
    }
}
