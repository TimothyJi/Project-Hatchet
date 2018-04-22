using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Hatchet.Graphics
{
    public class ConnectedTexture : Sprite
    {
        Dictionary<ConnectedSides, TexturePart> TextureParts { get; set; }

        public ConnectedTexture(HatchetTexture2D texture, Dictionary<ConnectedSides, TexturePart> textureParts)
        {
            Texture = texture;
            TextureParts = textureParts;
        }

        public void Update(GameTime gameTime, ConnectedSides sides)
        {
            SourceRect = TextureParts.ContainsKey(sides) ? TextureParts[sides].Rectangle : TextureParts[ConnectedSides.None].Rectangle;
        }
    }

    [Flags]
    public enum ConnectedSides
    {
        None = 0,
        Up = 1 << 0,
        Down = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3
    }
}
