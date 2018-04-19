using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.UI
{
    public interface IUIItem : IDrawComponent
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
