using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public interface IDrawComponent : IHasTransparency, ITextured, IPositionable, IRotatable, IScalable
    {
        Rectangle? SourceRect { get; set; }
        Color Color { get; set; }
        SpriteEffects SpriteEffects { get; set; }
        float LayerDepth { get; set; }

        bool IsActive { get; set; }
        bool UseDestinationRectangle { get; set; }
    }

    public static class IDrawComponentExtensions
    {
        public static void Draw(this IDrawComponent draw, SpriteBatch spriteBatch)
        {
            if (draw.IsActive)
                if (draw.UseDestinationRectangle)
                    spriteBatch.Draw(draw.Texture.XNAVariant, draw.DestinationRectangle, draw.SourceRect, draw.Color * draw.Alpha, draw.Rotation, draw.Origin, draw.SpriteEffects, draw.LayerDepth);
                else
                    spriteBatch.Draw(draw.Texture.XNAVariant, draw.Position, draw.SourceRect, draw.Color * draw.Alpha, draw.Rotation, draw.Origin, draw.Scale, draw.SpriteEffects, draw.LayerDepth);
        }
    }
}