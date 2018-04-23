using Hatchet.XML;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Hatchet.Graphics.XML
{
    public class ConnectedTexture : XMLContent
    {
        [ContentSerializer(SharedResource = true)]
        public Texture2D Texture { get; set; }

        [ContentSerializer(ElementName = "ConnectionMap", CollectionItemName = "ConnectionPart")]
        public Dictionary<Directions, ITexturePart> TextureParts { get; set; }

        public ConnectedTexture(Texture2D texture, Dictionary<Directions, ITexturePart> textureParts)
        {
            Texture = texture;
            TextureParts = textureParts;
        }
    }
}
