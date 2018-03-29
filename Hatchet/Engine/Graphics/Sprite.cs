using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public class Sprite : ISprite
    {
        public float Alpha { get; }

        public virtual ITexture2D Texture { get; private set; }
        public virtual Vector2 Position { get; set; }
        public virtual Rectangle SourceRect { get; private set; }
        public virtual Color Color { get; private set; }
        public virtual float Rotation { get; set; }
        public virtual Vector2 Origin { get; private set; }
        public virtual Vector2 Scale { get; private set; }
        public virtual SpriteEffects SpriteEffects { get; set; }
        public virtual float LayerDepth { get; set; }

        public bool IsActive { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
                spriteBatch.Draw((Texture2D)Texture, Position, SourceRect, Color * Alpha, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
