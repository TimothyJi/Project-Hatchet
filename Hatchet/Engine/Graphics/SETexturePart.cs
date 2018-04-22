using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics
{
    public class SETexturePart : TexturePart, IHasSpriteEffects
    {
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
    }
}
