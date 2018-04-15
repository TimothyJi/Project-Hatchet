using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen
{
    public abstract class ScreenBase : IScreen
    {
        public ContentManager Content { get; protected set; }

        public ScreenStates State { get; set; }

        public void Initialize() { }

        public virtual void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, "Content");
        }

        public void UnloadContent()
        {
            Content.Unload();
            State = ScreenStates.Unloaded;
        }
        
        public virtual void Update(GameTime gameTime) { if (State == ScreenStates.Unloaded) return; }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
