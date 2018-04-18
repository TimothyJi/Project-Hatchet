using Hatchet.ContentLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Hatchet.Graphics.Screen
{
    public class ScreenManager : IScreenManager
    {
        public IScreen Screen, NewScreen;
        public ScreenManagerStates State;

        public ContentManager Content { get; protected set; }

        public enum ScreenManagerStates
        {
            Blank,

            Normal,
            Transitioning
        }

        public ScreenManager()
        {
        }

        public ScreenManager(IScreen screen)
        {
            SetScreen(screen);
        }
        
        public void SetScreen(IScreen screen)
        {
            NewScreen = screen;
            if (Screen != null)
                Screen.State = ScreenStates.TransitioningOut;
            State = ScreenManagerStates.Transitioning;
        }

        public void Update(GameTime gameTime)
        {
            if (State == ScreenManagerStates.Transitioning)
            {
                if (Screen == null || Screen.State == ScreenStates.Unloaded)
                {
                    Screen = NewScreen;
                    NewScreen = null;
                    Screen.Initialize(this);
                    Screen.LoadContent(Content);
                    Screen.State = ScreenStates.TransitioningIn;
                }
                else if (Screen.State == ScreenStates.Active)
                {
                    State = ScreenManagerStates.Normal;
                }
            }
            if (Screen != null)
                Screen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Screen != null)
                Screen.Draw(spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, "Content");
        }

        public void UnloadContent()
        {
            Content.Unload();
        }
    }
}
