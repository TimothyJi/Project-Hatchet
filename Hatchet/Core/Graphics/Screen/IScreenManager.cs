using Hatchet.ContentLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen
{
    public interface IScreenManager : IHasOwnContent
    {
        void SetScreen(IScreen screen);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}