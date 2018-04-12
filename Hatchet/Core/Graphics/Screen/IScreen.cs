using Hatchet.ContentLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen
{
    public interface IScreen : IHasOwnContent
    {
        ScreenStates State { get; set; }

        void Initialize();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
