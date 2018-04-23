using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Hatchet.Graphics
{
    public class ConnectedTexture : Sprite
    {
        Dictionary<Directions, ITexturePart> TextureParts { get; set; }

        public ConnectedTexture(HatchetTexture2D texture, Dictionary<Directions, ITexturePart> textureParts)
        {
            Texture = texture;
            TextureParts = textureParts;
        }

        public void Update(GameTime gameTime, Directions sides)
        {
            SourceRect = TextureParts.ContainsKey(sides) ? TextureParts[sides].SourceRect : TextureParts[Directions.None].SourceRect;
        }

        public static implicit operator ConnectedTexture(XML.ConnectedTexture xmlVariant)
        {
            return new ConnectedTexture(xmlVariant.Texture, xmlVariant.TextureParts);
        }

        public static implicit operator XML.ConnectedTexture(ConnectedTexture xmlVariant)
        {
            return new XML.ConnectedTexture(xmlVariant.Texture as HatchetTexture2D, xmlVariant.TextureParts);
        }
    }
}
