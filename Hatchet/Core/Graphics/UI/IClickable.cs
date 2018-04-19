using Microsoft.Xna.Framework;

namespace Hatchet.Graphics.UI
{
    public interface IClickable
    {
        event Event.ClickEvent OnClick;

        void Update(GameTime gameTime);
    }
}
