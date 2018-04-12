using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface ISprite
    {
        float Alpha { get; }

        ITexture2D Texture { get; set; }
        Vector2 Position { get; set; }
        Rectangle SourceRect { get; set; }
        Color Color { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
        Vector2 Scale { get; set; }
        SpriteEffects SpriteEffects { get; set; }
        float LayerDepth { get; set; }

        bool IsActive { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}