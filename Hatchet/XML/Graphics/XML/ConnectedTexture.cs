using Hatchet.XML;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Hatchet.Graphics.XML
{
    public class ConnectedTexture : XMLContent
    {
        public ExternalReference<Texture2D> Texture { get; set; }

        [ContentSerializer(ElementName = "ConnectionMap", CollectionItemName = "ConnectionPart")]
        public Dictionary<Directions, ITexturePart> TextureParts { get; set; }
    }
}
