using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public class Sprite : ISprite
    {
        public float Alpha { get; }

        public ITexture2D Texture { get; private set; }
        public Vector2 Position { get; set; }
        public Rectangle SourceRect { get; private set; }
        public Color Color { get; private set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; private set; }
        public Vector2 Scale { get; private set; }
        public SpriteEffects SpriteEffects { get; set; }
        public float LayerDepth { get; set; }

        public bool IsActive { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
                spriteBatch.Draw(Texture as Texture2D, Position, SourceRect, Color * Alpha, Rotation, Origin, Scale, SpriteEffects, LayerDepth);)
        }
    }
}
