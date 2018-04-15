using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface ISprite : IHasTransparency, ITextured, IPositionable, IRotatable, IScalable
    {
        Rectangle? SourceRect { get; set; }
        Color Color { get; set; }
        SpriteEffects SpriteEffects { get; set; }
        float LayerDepth { get; set; }

        bool IsActive { get; set; }
        bool UseDestinationRectangle { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}