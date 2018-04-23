using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Hatchet.Graphics
{
    public class ConnectedTexture : Sprite
    {
        Dictionary<Directions, SETexturePart> TextureParts { get; set; }

        public ConnectedTexture(HatchetTexture2D texture, Dictionary<Directions, SETexturePart> textureParts)
        {
            Texture = texture;
            TextureParts = textureParts;
        }

        public void Update(GameTime gameTime, Directions sides)
        {
            SourceRect = TextureParts.ContainsKey(sides) ? TextureParts[sides].Rectangle : TextureParts[Directions.None].Rectangle;
        }
    }

    [Flags]
    public enum Directions
    {
        None = 0,
        Up = 1 << 0,
        Down = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3
    }
}
