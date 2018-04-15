using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public class Sprite : ISprite
    {
        public float Alpha { get; set; } = 1f;

        IHatchetTexture2D ITextured.Texture { get => Texture; set => Texture = (HatchetTexture2D)value; }
        public virtual HatchetTexture2D Texture { get; set; }
        public virtual Rectangle DestinationRectangle { get; set; }
        public virtual Vector2 Position { get => DestinationRectangle.Location.ToVector2(); set => DestinationRectangle = new Rectangle(value.ToPoint(), DestinationRectangle.Size); }
        public virtual Rectangle? SourceRect { get; set; }
        public virtual Color Color { get; set; } = Color.White;
        public virtual float Rotation { get; set; } = 0f;
        public virtual Vector2 Origin { get; set; } = Vector2.Zero;
        public virtual Vector2 Scale { get; set; } = Vector2.One;
        public virtual SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
        public virtual float LayerDepth { get; set; } = 1f;

        public bool IsActive { get; set; } = true;
        public bool UseDestinationRectangle { get; set; } = false;

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
                if (UseDestinationRectangle)
                    spriteBatch.Draw(Texture, DestinationRectangle, SourceRect, Color * Alpha, Rotation, Origin, SpriteEffects, LayerDepth);
                else
                    spriteBatch.Draw(Texture, Position, SourceRect, Color * Alpha, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
