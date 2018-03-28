using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface ISprite
    {
        float Alpha { get; }

        ITexture2D Texture { get; }
        Vector2 Position { get; }
        Rectangle DestRect { get; }
        Rectangle SourceRect { get; }
        Color Color { get; }
        float Rotation { get; }
        Vector2 Origin { get; }
        Vector2 Scale { get; }
        SpriteEffects SpriteEffects { get; }
        float LayerMask { get; }

        bool IsActive { get; }

        void Draw(SpriteBatch spriteBatch);
    }
}