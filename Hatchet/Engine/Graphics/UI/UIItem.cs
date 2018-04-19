using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.UI
{
    public abstract class UIItem : IUIItem
    {
        public virtual HatchetTexture2D Texture { get; set; }
        IHatchetTexture2D ITextured.Texture { get => Texture; set => Texture = (HatchetTexture2D)value; }
        public virtual Rectangle? SourceRect { get; set; } = null;
        public virtual Color Color { get; set; } = Color.White;
        public virtual SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
        public virtual float LayerDepth { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public virtual bool UseDestinationRectangle { get; set; } = false;
        public virtual float Alpha { get; set; } = 1f;
        public virtual Vector2 Position { get; set; } = Vector2.Zero;
        public virtual Rectangle DestinationRectangle { get; set; } = Rectangle.Empty;
        public virtual Vector2 Origin { get; set; } = Vector2.Zero;
        public virtual float Rotation { get; set; }
        public virtual Vector2 Scale { get; set; } = Vector2.One;

        public UIItem(Vector2 position, float layerDepth)
        {
            this.Position = position;
            this.LayerDepth = layerDepth;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
